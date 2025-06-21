using System.Security.Claims;
using ChefMenu.Api.Endpoints.Auth;
using ChefMenu.Api.Endpoints.Core;
using ChefMenu.Api.JsonSerialization;
using ChefMenu.Api.RequestValidations;
using ChefMenu.Application.DependencyInjection;
using ChefMenu.Domain.Enums;
using ChefMenu.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateSlimBuilder(args);

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
        ConnectionString = builder.Configuration.GetConnectionString("ChefMenu")
            ?? throw new InvalidOperationException("Connection string must be set!"),
        IsDevelopment = builder.Environment.IsDevelopment()
    });

builder.Services
    .AddAuthentication(BearerTokenDefaults.AuthenticationScheme)
    .AddBearerToken(BearerTokenDefaults.AuthenticationScheme, x =>
    {
        x.BearerTokenExpiration = TimeSpan.FromMinutes(5);
        x.RefreshTokenExpiration = TimeSpan.FromDays(30);
    });

builder.Services
    .AddAuthorizationBuilder()
    .SetInvokeHandlersAfterFailure(false)
    .SetDefaultPolicy(new AuthorizationPolicyBuilder(BearerTokenDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .RequireRole(Enum.GetNames<UserRole>())
        .RequireClaim(ClaimTypes.NameIdentifier)
        .RequireClaim(ClaimTypes.Name)
        .RequireClaim(ClaimTypes.Expiration)
        .Build());

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddOpenApi();
}

await using var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(x => x.SwaggerEndpoint("/openapi/v1.json", "Api"));
}

app
    .UseAuthentication()
    .UseAuthorization();

app
    .MapGroup("/api")
    .AddEndpointFilter<RequestValidationFilter>()
    .ProducesValidationProblem()
    .MapEndpointGroup<AuthEndpointGroup>();

await app.RunAsync();