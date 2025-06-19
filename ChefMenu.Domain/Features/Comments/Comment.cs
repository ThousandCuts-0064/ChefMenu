using ChefMenu.Domain.Features.Comments.ValueObjects;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.RecipeCollections;
using ChefMenu.Domain.Features.RecipeCollections.ValueObjects;
using ChefMenu.Domain.Features.Recipes;
using ChefMenu.Domain.Features.Recipes.ValueObjects;
using ChefMenu.Domain.Features.Shared.ValueObjects;
using ChefMenu.Domain.Features.UserFeedbacks;
using ChefMenu.Domain.Features.UserFeedbacks.ValueObjects;
using ChefMenu.Domain.Features.Users;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Domain.Features.Comments;

public sealed class Comment : AuditableEntity<CommentId>
{
    public CommentId? ParentId { get; init; }
    public UserId? UserId { get; init; }
    public RecipeId? RecipeId { get; init; }
    public RecipeCollectionId? RecipeCollectionId { get; init; }
    public UserFeedbackId? UserFeedbackId { get; init; }

    public required Text Text { get; set; }

    public Comment? Parent { get; init; }
    public User? User { get; init; }
    public Recipe? Recipe { get; init; }
    public RecipeCollection? RecipeCollection { get; init; }
    public UserFeedback? UserFeedback { get; init; }
    public HashSet<Comment> Children { get; set; } = [];
}