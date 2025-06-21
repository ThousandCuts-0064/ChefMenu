using ChefMenu.Application;
using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Categories;
using ChefMenu.Domain.Features.Comments;
using ChefMenu.Domain.Features.Ingredients;
using ChefMenu.Domain.Features.Keywords;
using ChefMenu.Domain.Features.Kitchenwares;
using ChefMenu.Domain.Features.RecipeCollections;
using ChefMenu.Domain.Features.Recipes;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.SystemActionHistories;
using ChefMenu.Domain.Features.SystemConfigs;
using ChefMenu.Domain.Features.UserActions;
using ChefMenu.Domain.Features.UserFeedbacks;
using ChefMenu.Domain.Features.Users;
using ChefMenu.Infrastructure.ConfigurationExtensions;
using ChefMenu.Infrastructure.EntityTypeConfiguratios;
using Microsoft.EntityFrameworkCore;

namespace ChefMenu.Infrastructure;

internal sealed class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<User> Users { get; init; }
    public DbSet<Kitchenware> Kitchenwares { get; init; }
    public DbSet<Keyword> Keywords { get; init; }
    public DbSet<Category> Categories { get; init; }
    public DbSet<Ingredient> Ingredients { get; init; }
    public DbSet<Recipe> Recipes { get; init; }
    public DbSet<Comment> Comments { get; init; }
    public DbSet<RecipeCollection> RecipeCollections { get; init; }
    public DbSet<SystemConfig> SystemConfigs { get; init; }
    public DbSet<UserAction> UserActions { get; init; }
    public DbSet<UserFeedback> UserFeedbacks { get; init; }
    public DbSet<SystemActionHistory> SystemActionHistories { get; init; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .HasValueObject<Description, string>()
            .HasValueObject<DisplayName, string>()
            .HasValueObject<Quantity, int>()
            .HasValueObject<Rank, int>()
            .HasValueObject<Text, string>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new UserConfiguration())
            .ApplyConfiguration(new KitchenwareConfiguration())
            .ApplyConfiguration(new KeywordConfiguration())
            .ApplyConfiguration(new CategoryConfiguration())
            .ApplyConfiguration(new IngredientConfiguration())
            .ApplyConfiguration(new RecipeConfiguration())
            .ApplyConfiguration(new CommentConfiguration())
            .ApplyConfiguration(new RecipeCollectionConfiguration())
            .ApplyConfiguration(new SystemConfigConfiguration())
            .ApplyConfiguration(new UserActionConfiguration())
            .ApplyConfiguration(new UserFeedbackConfiguration())
            .ApplyConfiguration(new SystemActionHistoryConfiguration());

        modelBuilder
            .HasPostgresEnum<MeasurementUnit>()
            .HasPostgresEnum<SystemActionType>()
            .HasPostgresEnum<UserActionType>()
            .HasPostgresEnum<UserFeedbackStatus>()
            .HasPostgresEnum<UserFeedbackType>()
            .HasPostgresEnum<UserRole>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSnakeCaseNamingConvention()
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
}