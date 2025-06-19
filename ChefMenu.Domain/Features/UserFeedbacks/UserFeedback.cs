using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Comments;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.UserFeedbacks.ValueObjects;
using ChefMenu.Domain.Features.Users;
using ChefMenu.Domain.Features.Users.ValueObjects;

namespace ChefMenu.Domain.Features.UserFeedbacks;

public sealed class UserFeedback : AuditableEntity<UserFeedbackId>
{
    public UserId? AsignedToId { get; set; }

    public required UserFeedbackType Type { get; init; }
    public required UserFeedbackStatus Status { get; init; }

    public User? AsignedTo { get; set; }
    public HashSet<Comment> Comments { get; set; } = [];
}