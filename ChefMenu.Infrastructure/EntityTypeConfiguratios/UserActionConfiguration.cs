using ChefMenu.Domain.Features.UserActions;
using ChefMenu.Infrastructure.ConfigurationExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefMenu.Infrastructure.EntityTypeConfiguratios;

internal class UserActionConfiguration : IEntityTypeConfiguration<UserAction>
{
    public void Configure(EntityTypeBuilder<UserAction> builder)
    {
        builder.HasKey(x => new
        {
            x.CreatedById,
            x.Type,
            x.ChefId,
            x.ProductId,
            x.KitchenwareId,
            x.CategoryId,
            x.KeywordId,
            x.RecipeId,
            x.RecipeCollectionId,
            x.CommentId
        });

        builder.HasJoinAudit();

        var unionProps = builder.Metadata.FindProperties(
        [
            nameof(UserAction.ChefId),
            nameof(UserAction.ProductId),
            nameof(UserAction.KitchenwareId),
            nameof(UserAction.CategoryId),
            nameof(UserAction.KeywordId),
            nameof(UserAction.RecipeId),
            nameof(UserAction.RecipeCollectionId),
            nameof(UserAction.CommentId)
        ])!;

        builder.ToTable(x => x.HasCheckConstraint(
            "ck_union",
            $"""
                ({unionProps[0].GetColumnName()} IS NOT NULL)::int
                + ({unionProps[1].GetColumnName()} IS NOT NULL)::int
                + ({unionProps[2].GetColumnName()} IS NOT NULL)::int
                + ({unionProps[3].GetColumnName()} IS NOT NULL)::int
                + ({unionProps[4].GetColumnName()} IS NOT NULL)::int
                + ({unionProps[5].GetColumnName()} IS NOT NULL)::int
                + ({unionProps[6].GetColumnName()} IS NOT NULL)::int
                + ({unionProps[7].GetColumnName()} IS NOT NULL)::int
                = 1
             """));

        builder.HasIndex(x => x.ChefId).HasFilter($"{unionProps[0].GetColumnName()} IS NOT NULL");
        builder.HasIndex(x => x.ProductId).HasFilter($"{unionProps[1].GetColumnName()} IS NOT NULL");
        builder.HasIndex(x => x.KitchenwareId).HasFilter($"{unionProps[2].GetColumnName()} IS NOT NULL");
        builder.HasIndex(x => x.CategoryId).HasFilter($"{unionProps[3].GetColumnName()} IS NOT NULL");
        builder.HasIndex(x => x.KeywordId).HasFilter($"{unionProps[4].GetColumnName()} IS NOT NULL");
        builder.HasIndex(x => x.RecipeId).HasFilter($"{unionProps[5].GetColumnName()} IS NOT NULL");
        builder.HasIndex(x => x.RecipeCollectionId).HasFilter($"{unionProps[6].GetColumnName()} IS NOT NULL");
        builder.HasIndex(x => x.CommentId).HasFilter($"{unionProps[7].GetColumnName()} IS NOT NULL");
    }
}