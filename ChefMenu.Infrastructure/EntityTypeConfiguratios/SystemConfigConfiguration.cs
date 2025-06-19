using ChefMenu.Domain.Features.SystemConfigs;
using ChefMenu.Domain.Features.SystemConfigs.ValueObjects;
using ChefMenu.Infrastructure.ConfigurationExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefMenu.Infrastructure.EntityTypeConfiguratios;

public class SystemConfigConfiguration : IEntityTypeConfiguration<SystemConfig>
{
    public void Configure(EntityTypeBuilder<SystemConfig> builder)
    {
        builder.HasKey(x => x.Key);

        builder.Property(x => x.Key).IsValueObject<SystemConfigKey, string>();

        builder.HasAudit();
    }
}