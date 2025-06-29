using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Comments;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.RecipeCollections;
using ChefMenu.Domain.Features.Recipes;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.UserFeedbacks;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Domain.Features.Users;

public sealed class User : AuditableEntity<UserId>
{
    public required Username Username { get; set; }
    public required Email Email { get; set; }
    public required PasswordHash PasswordHash { get; set; }
    public required UserRole Role { get; set; }
    public required DisplayName DisplayName { get; set; }
    public Description? Description { get; set; }
    public Uri? ImageUri { get; set; }
    public Rank? Rank { get; set; }
    public bool IsPublic { get; set; }

    public HashSet<Comment> CreatedComments { get; set; } = [];
    public HashSet<Recipe> CreatedRecipes { get; set; } = [];
    public HashSet<RecipeCollection> CreatedRecipeCollections { get; set; } = [];
    public HashSet<UserFeedback> CreatedUserFeedback { get; set; } = [];
    public HashSet<Comment> ReceivedComments { get; set; } = [];
}