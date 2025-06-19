namespace ChefMenu.Infrastructure.DependencyInjection;

public sealed class InfrastructureOptions
{
    public required string ConnectionString { get; init; }
    public required bool IsDevelopment { get; init; }
}