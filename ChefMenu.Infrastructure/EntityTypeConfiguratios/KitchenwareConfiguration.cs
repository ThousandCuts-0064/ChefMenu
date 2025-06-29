using ChefMenu.Domain.Features.Categories;
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
        builder.HasFuzzyIndex(x => x.Name);

        builder.HasAudit();

        builder
            .HasMany(x => x.Categories)
            .WithMany(x => x.Kitchenwares)
            .UsingEntity<CategoryKitchenware>(
                x => x
                    .HasOne(y => y.Category)
                    .WithMany()
                    .HasForeignKey(y => y.CategoryId)
                    .HasPrincipalKey(y => y.Id)
                    .OnDelete(DeleteBehavior.Restrict),
                x => x
                    .HasOne(y => y.Kitchenware)
                    .WithMany()
                    .HasForeignKey(y => y.KitchenwareId)
                    .HasPrincipalKey(y => y.Id)
                    .OnDelete(DeleteBehavior.Restrict),
                x =>
                {
                    x.HasKey(y => new { y.CategoryId, y.KitchenwareId });
                    x.HasIndex(y => y.KitchenwareId).IncludeProperties(y => y.CategoryId);
                    x.HasJoinAudit();
                });

    }
}