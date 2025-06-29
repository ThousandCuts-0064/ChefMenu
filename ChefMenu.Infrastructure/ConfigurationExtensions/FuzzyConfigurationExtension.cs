using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChefMenu.Infrastructure.ConfigurationExtensions;

internal static class FuzzyConfigurationExtension
{
    public static void HasFuzzyIndex<TEntity>(
        this EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, object?>> indexExpression,
        [CallerArgumentExpression(nameof(indexExpression))] string exprStr = null!)
        where TEntity : class
    {
        var tableName = builder.Metadata
            .GetTableName();

        var columnName = builder.Metadata
            .FindProperty(exprStr[(exprStr.LastIndexOf('.') + 1)..])!
            .GetColumnName();

        var ixName = $"ix_{tableName}_{columnName}_fuzzy";

        builder
            .HasIndex(indexExpression, ixName)
            .HasDatabaseName(ixName)
            .HasMethod(Sql.Gist)
            .HasOperators(Sql.GistTrgmOps);
    }
}