using ChefMenu.Domain.Enums;
using ChefMenu.Domain.Features.Shared.ValueObjects;
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
        builder
            .Property(x => x.Id)
            .UseIdentityAlwaysColumn()
            .HasIdentityOptions(UserId.LastSystem.Value + 1)
            .IsValueObject<UserId, int>();

        builder.Property(x => x.Username).IsValueObject<Username, string>();
        builder.Property(x => x.Email).IsValueObject<Email, string>();
        builder.Property(x => x.PasswordHash).IsValueObject<PasswordHash, string>();

        builder.HasAudit();

        builder.HasIndex(x => x.Username).IncludeProperties(x => x.Id).IsUnique();
        builder.HasIndex(x => x.Email).IncludeProperties(x => x.Id).IsUnique();
        builder.HasFuzzyIndex(x => x.Username);

        builder.HasData(
            new User
            {
                Id = UserId.InternalSystem,
                CreatedById = UserId.InternalSystem,
                Username = Username.Create(nameof(UserId.InternalSystem)),
                Email = Email.InternalSystem,
                PasswordHash = PasswordHash.Create(""),
                Role = UserRole.System,
                DisplayName = DisplayName.Create(nameof(UserId.InternalSystem)),
                Description = Description.Create(nameof(UserId.InternalSystem)),
            },
            new User
            {
                Id = UserId.PublicSystem,
                CreatedById = UserId.InternalSystem,
                Username = Username.Create(nameof(UserId.PublicSystem)),
                Email = Email.PublicSystem,
                PasswordHash = PasswordHash.Create(""),
                Role = UserRole.System,
                DisplayName = DisplayName.Create(nameof(UserId.PublicSystem)),
                Description = Description.Create(nameof(UserId.PublicSystem)),
            },
            new User
            {
                Id = UserId.AiSystem,
                CreatedById = UserId.InternalSystem,
                Username = Username.Create(nameof(UserId.AiSystem)),
                Email = Email.AiSystem,
                PasswordHash = PasswordHash.Create(""),
                Role = UserRole.System,
                DisplayName = DisplayName.Create(nameof(UserId.AiSystem)),
                Description = Description.Create(nameof(UserId.AiSystem)),
            });
    }
}