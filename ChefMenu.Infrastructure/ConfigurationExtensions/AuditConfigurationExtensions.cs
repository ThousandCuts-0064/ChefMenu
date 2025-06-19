using System.Linq.Expressions;
using ChefMenu.Domain.Features.Core;
using ChefMenu.Domain.Features.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefMenu.Infrastructure.ConfigurationExtensions;

internal static class AuditConfigurationExtensions
{
    public static void HasAudit<TEntity>(
        this EntityTypeBuilder<TEntity> builder,
        Expression<Func<User, IEnumerable<TEntity>?>>? creatorNavigationExpression = null)
        where TEntity : class, IAuditableEntity
    {
        builder.Property(x => x.CreatedAt).HasDefaultValueSql(Sql.Now);

        builder
            .HasOne(x => x.CreatedBy)
            .WithMany(creatorNavigationExpression)
            .HasForeignKey(x => x.CreatedById)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.UpdatedBy)
            .WithMany()
            .HasForeignKey(x => x.UpdatedById)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.DeletedBy)
            .WithMany()
            .HasForeignKey(x => x.DeletedById)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public static void HasJoinAudit<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : JoinEntity
    {
        builder.Property(x => x.CreatedAt).HasDefaultValueSql(Sql.Now);

        builder
            .HasOne(x => x.CreatedBy)
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
