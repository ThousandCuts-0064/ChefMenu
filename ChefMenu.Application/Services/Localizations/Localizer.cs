using System.Globalization;

namespace ChefMenu.Application.Services.Localizations;

internal sealed class Localizer : ILocalizer
{
    public string Localize(string code, CultureInfo cultureInfo, string defaultValue)
    {
        return defaultValue;
    }
}