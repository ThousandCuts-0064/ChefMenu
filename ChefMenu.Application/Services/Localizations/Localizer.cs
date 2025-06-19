using System.Globalization;

namespace ChefMenu.Application.Services.Localizations;

public class Localizer : ILocalizer
{
    public string Localize(string code, CultureInfo cultureInfo, string defaultValue)
    {
        return defaultValue;
    }
}