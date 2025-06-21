using ChefMenu.Domain.Features.Ingredients;
using ChefMenu.Domain.Features.Keywords;
using ChefMenu.Domain.Features.Kitchenwares;
using ChefMenu.Domain.Features.Recipes;
using ChefMenu.Domain.Features.Recipes.ValueObjects;
using ChefMenu.Infrastructure.ConfigurationExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefMenu.Infrastructure.EntityTypeConfiguratios;

internal class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.Property(x => x.Id).UseIdentityAlwaysColumn().IsValueObject<RecipeId, int>();
        builder.Property(x => x.Name).IsValueObject<RecipeName, string>();

        builder.HasIndex(x => new { x.Name, x.CreatedById }).IncludeProperties(x => x.Id).IsUnique();
        builder.HasIndex(x => x.CreatedById);

        builder.HasAudit(x => x.CreatedRecipes);

        builder
            .HasMany(x => x.Kitchenwares)
            .WithMany(x => x.Recipes)
            .UsingEntity<KitchenwareRecipe>(
                x => x
                    .HasOne(y => y.Kitchenware)
                    .WithMany()
                    .HasForeignKey(y => y.KitchenwareId)
                    .HasPrincipalKey(y => y.Id)
                    .OnDelete(DeleteBehavior.Restrict),
                x => x
                    .HasOne(y => y.Recipe)
                    .WithMany()
                    .HasForeignKey(y => y.RecipeId)
                    .HasPrincipalKey(y => y.Id)
                    .OnDelete(DeleteBehavior.Restrict),
                x =>
                {
                    x.HasKey(y => new { y.KitchenwareId, y.RecipeId });
                    x.HasIndex(y => y.RecipeId).IncludeProperties(y => y.KitchenwareId);
                    x.HasJoinAudit();
                });

        builder
            .HasMany(x => x.Ingredients)
            .WithMany(x => x.Recipes)
            .UsingEntity<IngredientRecipe>(
                x => x
                    .HasOne(y => y.Ingredient)
                    .WithMany()
                    .HasForeignKey(y => y.IngredientId)
                    .HasPrincipalKey(y => y.Id)
                    .OnDelete(DeleteBehavior.Restrict),
                x => x
                    .HasOne(y => y.Recipe)
                    .WithMany(y => y.IngredientRecipes)
                    .HasForeignKey(y => y.RecipeId)
                    .HasPrincipalKey(y => y.Id)
                    .OnDelete(DeleteBehavior.Restrict),
                x =>
                {
                    x.HasKey(y => new { y.IngredientId, y.RecipeId });
                    x.HasIndex(y => y.RecipeId).IncludeProperties(y => y.IngredientId);
                    x.HasJoinAudit();
                });

        builder
            .HasMany(x => x.Keywords)
            .WithMany(x => x.Recipes)
            .UsingEntity<KeywordRecipe>(
                x => x
                    .HasOne(y => y.Keyword)
                    .WithMany()
                    .HasForeignKey(y => y.KeywordId)
                    .HasPrincipalKey(y => y.Id)
                    .OnDelete(DeleteBehavior.Restrict),
                x => x
                    .HasOne(y => y.Recipe)
                    .WithMany()
                    .HasForeignKey(y => y.RecipeId)
                    .HasPrincipalKey(y => y.Id)
                    .OnDelete(DeleteBehavior.Restrict),
                x =>
                {
                    x.HasKey(y => new { y.KeywordId, y.RecipeId });
                    x.HasIndex(y => y.RecipeId).IncludeProperties(y => y.KeywordId);
                    x.HasJoinAudit();
                });
    }
}