using ChefMenu.Domain.Features.SystemActionHistories;
using ChefMenu.Domain.Features.SystemActionHistories.ValueObjects;
using ChefMenu.Infrastructure.ConfigurationExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefMenu.Infrastructure.EntityTypeConfiguratios;

internal class SystemActionHistoryConfiguration : IEntityTypeConfiguration<SystemActionHistory>
{
    public void Configure(EntityTypeBuilder<SystemActionHistory> builder)
    {
        builder.Property(x => x.Id).UseIdentityAlwaysColumn().IsValueObject<SystemActionHistoryId, int>();
        builder.Property(x => x.EntityName).IsValueObject<EntityName, string>();

        builder
            .HasOne(x => x.ExecutedBy)
            .WithMany()
            .HasForeignKey(x => x.ExecutedById)
            .HasPrincipalKey(x => x.Id);
    }
}
