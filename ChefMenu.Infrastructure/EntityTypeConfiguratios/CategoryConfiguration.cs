using ChefMenu.Domain.Features.Categories;
using ChefMenu.Domain.Features.Categories.ValueObjects;
using ChefMenu.Infrastructure.ConfigurationExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefMenu.Infrastructure.EntityTypeConfiguratios;

internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Id).UseIdentityAlwaysColumn().IsValueObject<CategoryId, int>();
        builder.Property(x => x.Name).IsValueObject<CategoryName, string>();

        builder.HasIndex(x => x.Name).IncludeProperties(x => x.Id).IsUnique();
        builder.HasFuzzyIndex(x => x.Name);

        builder.HasAudit();
    }
}