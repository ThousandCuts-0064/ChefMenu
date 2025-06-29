using ChefMenu.Domain.Features.Comments;
using ChefMenu.Domain.Features.Comments.ValueObjects;
using ChefMenu.Infrastructure.ConfigurationExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefMenu.Infrastructure.EntityTypeConfiguratios;

internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(x => x.Id).UseIdentityAlwaysColumn().IsValueObject<CommentId, int>();

        builder.HasIndex(x => x.CreatedById);

        builder.HasAudit(x => x.CreatedComments);

        builder
            .HasOne(x => x.Parent)
            .WithMany(x => x.Children)
            .HasForeignKey(x => x.ParentId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.ReceivedComments)
            .HasForeignKey(x => x.UserId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Recipe)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.RecipeId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.RecipeCollection)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.RecipeCollectionId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.UserFeedback)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.UserFeedbackId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        var unionProps = builder.Metadata.FindProperties(
        [
            nameof(Comment.ParentId),
            nameof(Comment.UserId),
            nameof(Comment.RecipeId),
            nameof(Comment.RecipeCollectionId),
            nameof(Comment.UserFeedbackId)
        ])!;

        builder.ToTable(x => x.HasCheckConstraint(
            "ck_union",
            $"""
                ({unionProps[0].GetColumnName()} IS NOT NULL)::int
                + ({unionProps[1].GetColumnName()} IS NOT NULL)::int
                + ({unionProps[2].GetColumnName()} IS NOT NULL)::int
                + ({unionProps[3].GetColumnName()} IS NOT NULL)::int
                + ({unionProps[4].GetColumnName()} IS NOT NULL)::int
                = 1
             """));

        builder.HasIndex(x => x.ParentId).HasFilter($"{unionProps[0].GetColumnName()} IS NOT NULL");
        builder.HasIndex(x => x.UserId).HasFilter($"{unionProps[1].GetColumnName()} IS NOT NULL");
        builder.HasIndex(x => x.RecipeId).HasFilter($"{unionProps[2].GetColumnName()} IS NOT NULL");
        builder.HasIndex(x => x.RecipeCollectionId).HasFilter($"{unionProps[3].GetColumnName()} IS NOT NULL");
        builder.HasIndex(x => x.UserFeedbackId).HasFilter($"{unionProps[4].GetColumnName()} IS NOT NULL");

    }
}