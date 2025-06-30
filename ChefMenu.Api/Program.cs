using System.Security.Claims;
using ChefMenu.Api.Constants;
using ChefMenu.Api.Endpoints.Auth;
using ChefMenu.Api.Endpoints.Categories;
using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.Endpoints.Ingredients;
using ChefMenu.Api.Endpoints.Keywords;
using ChefMenu.Api.Endpoints.Kitchenwares;
using ChefMenu.Api.Endpoints.Me;
using ChefMenu.Api.Endpoints.RecipeCollections;
using ChefMenu.Api.Endpoints.Recipes;
using ChefMenu.Api.Endpoints.Users;
using ChefMenu.Api.Extensions;
using ChefMenu.Api.JsonSerialization;
using ChefMenu.Api.RequestValidations;
using ChefMenu.Application.DependencyInjection;
using ChefMenu.Domain.Enums;
using ChefMenu.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Context;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateSlimBuilder(args);

builder.Host.UseSerilog((context, x) => x.ReadFrom.Configuration(context.Configuration));

builder.WebHost.UseKestrelHttpsConfiguration();

builder.Services
    .Configure<BinderOptions>(x => x.ErrorOnUnknownConfiguration = true)
    .ConfigureHttpJsonOptions(x =>
    {
        x.SerializerOptions.TypeInfoResolver = GlobalJsonTypeInfoResolver.Instance;
        x.SerializerOptions.Converters.AddGlobalJsonConverters();
    })
    .AddApplication(new ApplicationOptions
    {
        PasswordHasher = "PasswordHasher"
    })
    .AddInfrastructure(new InfrastructureOptions
    {
        IsDevelopment = builder.Environment.IsDevelopment(),
        ConnectionString = builder.Configuration.GetConnectionString("ChefMenu")
            ?? throw new InvalidOperationException("Connection string must be set!")
    });

builder.Services
    .AddAuthentication(BearerTokenDefaults.AuthenticationScheme)
    .AddBearerToken(BearerTokenDefaults.AuthenticationScheme, x =>
    {
        x.BearerTokenExpiration = TimeSpan.FromMinutes(builder.Environment.IsDevelopment() ? 600 : 5);
        x.RefreshTokenExpiration = TimeSpan.FromDays(30);
    });

builder.Services
    .AddAuthorizationBuilder()
    .SetInvokeHandlersAfterFailure(false)
    .AddDefaultPolicy(AuthPolicies.Default, x =>
    {
        x.RequireAuthenticatedUser();
        x.RequireRole(Enum.GetNames<UserRole>());
        x.RequireClaim(ClaimTypes.NameIdentifier);
        x.RequireClaim(ClaimTypes.Name);
    })
    .AddPolicy(AuthPolicies.ModeratorPlus, x =>
    {
        x.RequireAssertion(y => y.User.GetUserRole() >= UserRole.Moderator);
    })
    .AddPolicy(AuthPolicies.AdminPlus, x =>
    {
        x.RequireAssertion(y => y.User.GetUserRole() >= UserRole.Admin);
    });

builder.Services
    .AddCors(x => x.AddDefaultPolicy(y => y.AllowAnyOrigin()))
    .AddResponseCompression(x => x.EnableForHttps = true)
    .AddResponseCaching(x => x.UseCaseSensitivePaths = true)
    .AddProblemDetails(x => x.CustomizeProblemDetails = y =>
    {
        y.ProblemDetails.Extensions["traceId"] = y.HttpContext.TraceIdentifier;
    })
    .AddHttpLogging(x =>
    {
        x.LoggingFields = HttpLoggingFields.All;
        x.CombineLogs = true;
    })
    .AddRateLimiter(x => x.AddFixedWindowLimiter(RateLimitPolicies.Default, y =>
    {
        y.PermitLimit = 60;
        y.Window = TimeSpan.FromMinutes(1);
    }));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddOpenApi(x => x.AddDocumentTransformer((document, _, _) =>
    {
        var securityScheme = new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Name = HeaderNames.Authorization,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "opaque",
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = BearerTokenDefaults.AuthenticationScheme
            },
        };

        document.Components ??= new OpenApiComponents();
        document.Components.SecuritySchemes = new Dictionary<string, OpenApiSecurityScheme>
        {
            [BearerTokenDefaults.AuthenticationScheme] = securityScheme
        };
        document.SecurityRequirements.Add(new OpenApiSecurityRequirement
        {
            [securityScheme] = []
        });

        return Task.CompletedTask;
    }));
}

await using var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/openapi/v1.json", "Api");
        x.DefaultModelsExpandDepth(-1);
        x.DisplayOperationId();
        x.DisplayRequestDuration();
        x.EnableDeepLinking();
        x.EnableFilter();
        x.EnablePersistAuthorization();
        x.EnableTryItOutByDefault();
        x.ShowCommonExtensions();
    });
}

app
    .UseWhen(
        x =>
            !x.Request.Path.StartsWithSegments("/api/auth")
            && !x.Request.Path.StartsWithSegments("/openapi")
            && !x.Request.Path.StartsWithSegments("/swagger"),
        x => x
            .UseResponseCompression()
            .UseHttpLogging()
            .UseSerilogRequestLogging()
    )
    .UseHsts()
    .UseHttpsRedirection()
    .UseCors()
    .UseRateLimiter()
    .UseResponseCaching()
    .UseAuthentication()
    .UseAuthorization()
    .Use(async (context, next) =>
    {
        if (context.User.Identity?.IsAuthenticated ?? false)
        {
            using (LogContext.PushProperty("_pipe", "|"))
            using (LogContext.PushProperty("UserId", context.User.GetUserId()))
            using (LogContext.PushProperty("Username", context.User.GetUsername()))
            using (LogContext.PushProperty("UserRole", context.User.GetUserRole()))
            {
                await next();
            }
        }
        else
        {
            await next();
        }
    });

app
    .MapGroup("/api")
    .RequireRateLimiting(RateLimitPolicies.Default)
    .RequireAuthorization()
    .AddEndpointFilter<RequestValidationFilter>()
    .ProducesValidationProblem()
    .MapEndpointGroup<AuthEndpointGroup>()
    .MapEndpointGroup<UsersEndpointGroup>()
    .MapEndpointGroup<MeEndpointGroup>()
    .MapEndpointGroup<CategoriesEndpointGroup>()
    .MapEndpointGroup<IngredientsEndpointGroup>()
    .MapEndpointGroup<KitchenwaresEndpointGroup>()
    .MapEndpointGroup<KeywordsEndpointGroup>()
    .MapEndpointGroup<RecipesEndpointGroup>()
    .MapEndpointGroup<RecipeCollectionsEndpointGroup>();

await app.RunAsync();