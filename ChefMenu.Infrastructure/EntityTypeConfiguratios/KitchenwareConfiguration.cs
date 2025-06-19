using ChefMenu.Domain.Features.Kitchenwares;
using ChefMenu.Domain.Features.Kitchenwares.ValueObjects;
using ChefMenu.Infrastructure.ConfigurationExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefMenu.Infrastructure.EntityTypeConfiguratios;

internal class KitchenwareConfiguration : IEntityTypeConfiguration<Kitchenware>
{
    public void Configure(EntityTypeBuilder<Kitchenware> builder)
    {
        builder.Property(x => x.Id).UseIdentityAlwaysColumn().IsValueObject<KitchenwareId, int>();
        builder.Property(x => x.Name).IsValueObject<KitchenwareName, string>();

        builder.HasIndex(x => x.Name).IncludeProperties(x => x.Id).IsUnique();

        builder.HasAudit();
    }
}