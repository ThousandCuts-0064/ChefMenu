using ChefMenu.Domain.Features.UserFeedbacks;
using ChefMenu.Domain.Features.UserFeedbacks.ValueObjects;
using ChefMenu.Infrastructure.ConfigurationExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefMenu.Infrastructure.EntityTypeConfiguratios;

internal class UserFeedbackConfiguration : IEntityTypeConfiguration<UserFeedback>
{
    public void Configure(EntityTypeBuilder<UserFeedback> builder)
    {
        builder.Property(x => x.Id).UseIdentityAlwaysColumn().IsValueObject<UserFeedbackId, int>();

        builder.HasAudit(x => x.CreatedUserFeedbacks);

        builder
            .HasOne(x => x.AsignedTo)
            .WithMany()
            .HasForeignKey(x => x.AsignedToId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
