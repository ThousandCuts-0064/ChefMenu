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

        builder.HasAudit();
    }
}