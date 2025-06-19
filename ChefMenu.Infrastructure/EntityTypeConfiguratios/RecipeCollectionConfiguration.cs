using ChefMenu.Domain.Features.Keywords;
using ChefMenu.Domain.Features.RecipeCollections;
using ChefMenu.Domain.Features.RecipeCollections.ValueObjects;
using ChefMenu.Domain.Features.Recipes;
using ChefMenu.Infrastructure.ConfigurationExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefMenu.Infrastructure.EntityTypeConfiguratios;

internal class RecipeCollectionConfiguration : IEntityTypeConfiguration<RecipeCollection>
{
    public void Configure(EntityTypeBuilder<RecipeCollection> builder)
    {
        builder.Property(x => x.Id).UseIdentityAlwaysColumn().IsValueObject<RecipeCollectionId, int>();
        builder.Property(x => x.Name).IsValueObject<RecipeCollectionName, string>();

        builder.HasIndex(x => new { x.Name, x.CreatedById }).IncludeProperties(x => x.Id).IsUnique();
        builder.HasIndex(x => x.CreatedById);

        builder.HasAudit(x => x.CreatedRecipeCollections);

        builder
            .HasMany(x => x.Recipes)
            .WithMany()
            .UsingEntity<RecipeRecipeCollection>(
                x => x
                    .HasOne(y => y.Recipe)
                    .WithMany()
                    .HasForeignKey(y => y.RecipeId)
                    .HasPrincipalKey(y => y.Id)
                    .OnDelete(DeleteBehavior.Restrict),
                x => x
                    .HasOne(y => y.RecipeCollection)
                    .WithMany()
                    .HasForeignKey(y => y.RecipeCollectionId)
                    .HasPrincipalKey(y => y.Id)
                    .OnDelete(DeleteBehavior.Restrict),
                x =>
                {
                    x.HasKey(y => new { y.RecipeId, y.RecipeCollectionId });
                    x.HasIndex(y => y.RecipeCollectionId).IncludeProperties(y => y.RecipeId);
                    x.HasJoinAudit();
                });

        builder
            .HasMany(x => x.Keywords)
            .WithMany(x => x.RecipeCollections)
            .UsingEntity<KeywordRecipeCollection>(
                x => x
                    .HasOne(y => y.Keyword)
                    .WithMany()
                    .HasForeignKey(y => y.KeywordId)
                    .HasPrincipalKey(y => y.Id)
                    .OnDelete(DeleteBehavior.Restrict),
                x => x
                    .HasOne(y => y.RecipeCollection)
                    .WithMany()
                    .HasForeignKey(y => y.RecipeCollectionId)
                    .HasPrincipalKey(y => y.Id)
                    .OnDelete(DeleteBehavior.Restrict),
                x =>
                {
                    x.HasKey(y => new { y.KeywordId, y.RecipeCollectionId });
                    x.HasIndex(y => y.RecipeCollectionId).IncludeProperties(y => y.KeywordId);
                    x.HasJoinAudit();
                });
    }
}