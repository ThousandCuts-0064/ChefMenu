using ChefMenu.Domain.Features.Users;
using ChefMenu.Domain.Features.Users.ValueObjects;
using ChefMenu.Infrastructure.ConfigurationExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefMenu.Infrastructure.EntityTypeConfiguratios;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id).UseIdentityAlwaysColumn().IsValueObject<UserId, int>();
        builder.Property(x => x.Username).IsValueObject<Username, string>();
        builder.Property(x => x.Email).IsValueObject<Email, string>();
        builder.Property(x => x.PasswordHash).IsValueObject<PasswordHash, string>();

        builder.Property(x => x.CreatedAt).HasDefaultValueSql(Sql.Now);

        builder.HasIndex(x => x.Username).IncludeProperties(x => x.Id).IsUnique();
        builder.HasIndex(x => x.Email).IncludeProperties(x => x.Id).IsUnique();
    }
}