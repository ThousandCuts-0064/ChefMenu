using ChefMenu.Domain.Features.Categories;
using ChefMenu.Domain.Features.Comments;
using ChefMenu.Domain.Features.Ingredients;
using ChefMenu.Domain.Features.Keywords;
using ChefMenu.Domain.Features.Kitchenwares;
using ChefMenu.Domain.Features.RecipeCollections;
using ChefMenu.Domain.Features.Recipes;
using ChefMenu.Domain.Features.SystemActionHistories;
using ChefMenu.Domain.Features.SystemConfigs;
using ChefMenu.Domain.Features.UserActions;
using ChefMenu.Domain.Features.UserFeedbacks;
using ChefMenu.Domain.Features.Users;
using Microsoft.EntityFrameworkCore;

namespace ChefMenu.Application;

public interface IAppDbContext
{
    public DbSet<User> Users { get; }
    public DbSet<Kitchenware> Kitchenwares { get; }
    public DbSet<Keyword> Keywords { get; }
    public DbSet<Category> Categories { get; }
    public DbSet<Ingredient> Ingredients { get; }
    public DbSet<Recipe> Recipes { get; }
    public DbSet<Comment> Comments { get; }
    public DbSet<RecipeCollection> RecipeCollections { get; }
    public DbSet<SystemConfig> SystemConfigs { get; }
    public DbSet<UserAction> UserActions { get; init; }
    public DbSet<UserFeedback> UserFeedbacks { get; init; }
    public DbSet<SystemActionHistory> SystemActionHistories { get; init; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}