using ChefMenu.Domain.Features.Products;
using ChefMenu.Domain.Features.Products.ValueObjects;
using ChefMenu.Infrastructure.ConfigurationExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefMenu.Infrastructure.EntityTypeConfiguratios;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Id).UseIdentityAlwaysColumn().IsValueObject<ProductId, int>();
        builder.Property(x => x.Name).IsValueObject<ProductName, string>();

        builder.HasIndex(x => x.Name).IncludeProperties(x => x.Id).IsUnique();

        builder.HasAudit();
    }
}