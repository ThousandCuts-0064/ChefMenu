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

        builder.HasAudit();

        builder
            .HasOne(x => x.Kitchenware)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.KitchenwareId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Product)
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.ProductId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        var unionProps = builder.Metadata.FindProperties(
        [
            nameof(Category.KitchenwareId),
            nameof(Category.ProductId)
        ])!;

        builder.ToTable(x => x.HasCheckConstraint(
            "ck_union",
            $"""
                ({unionProps[0].GetColumnName()} IS NOT NULL)::int
                + ({unionProps[1].GetColumnName()} IS NOT NULL)::int
                = 1
             """));
    }
}