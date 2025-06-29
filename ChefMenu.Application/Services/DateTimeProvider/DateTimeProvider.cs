namespace ChefMenu.Application.Services.DateTimeProvider;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}