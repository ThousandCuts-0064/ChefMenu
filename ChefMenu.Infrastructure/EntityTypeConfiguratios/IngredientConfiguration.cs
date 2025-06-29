using ChefMenu.Domain.Features.Categories;
using ChefMenu.Domain.Features.Ingredients;
using ChefMenu.Domain.Features.Ingredients.ValueObjects;
using ChefMenu.Infrastructure.ConfigurationExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefMenu.Infrastructure.EntityTypeConfiguratios;

internal class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.Property(x => x.Id).UseIdentityAlwaysColumn().IsValueObject<IngredientId, int>();
        builder.Property(x => x.Name).IsValueObject<IngredientName, string>();

        builder.HasIndex(x => x.Name).IncludeProperties(x => x.Id).IsUnique();
        builder.HasFuzzyIndex(x => x.Name);

        builder.HasAudit();

        builder
            .HasMany(x => x.Categories)
            .WithMany(x => x.Ingredients)
            .UsingEntity<CategoryIngredient>(
                x => x
                    .HasOne(y => y.Category)
                    .WithMany()
                    .HasForeignKey(y => y.CategoryId)
                    .HasPrincipalKey(y => y.Id)
                    .OnDelete(DeleteBehavior.Restrict),
                x => x
                    .HasOne(y => y.Ingredient)
                    .WithMany()
                    .HasForeignKey(y => y.IngredientId)
                    .HasPrincipalKey(y => y.Id)
                    .OnDelete(DeleteBehavior.Restrict),
                x =>
                {
                    x.HasKey(y => new { y.CategoryId, y.IngredientId });
                    x.HasIndex(y => y.IngredientId).IncludeProperties(y => y.CategoryId);
                    x.HasJoinAudit();
                });
    }
}