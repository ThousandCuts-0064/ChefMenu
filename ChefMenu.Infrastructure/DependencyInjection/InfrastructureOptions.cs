namespace ChefMenu.Infrastructure.DependencyInjection;

public sealed class InfrastructureOptions
{
    public required bool IsDevelopment { get; init; }
    public required string ConnectionString { get; init; }
}