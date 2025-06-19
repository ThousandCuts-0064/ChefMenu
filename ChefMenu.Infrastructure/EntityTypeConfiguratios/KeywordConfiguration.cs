using ChefMenu.Domain.Features.Keywords;
using ChefMenu.Domain.Features.Keywords.ValueObjects;
using ChefMenu.Infrastructure.ConfigurationExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefMenu.Infrastructure.EntityTypeConfiguratios;

internal class KeywordConfiguration : IEntityTypeConfiguration<Keyword>
{
    public void Configure(EntityTypeBuilder<Keyword> builder)
    {
        builder.Property(x => x.Id).UseIdentityAlwaysColumn().IsValueObject<KeywordId, int>();
        builder.Property(x => x.Name).IsValueObject<KeywordName, string>();

        builder.HasIndex(x => x.Name).IncludeProperties(x => x.Id).IsUnique();

        builder.HasAudit();
    }
}