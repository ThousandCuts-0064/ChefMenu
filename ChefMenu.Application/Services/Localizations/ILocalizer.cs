using System.Globalization;

namespace ChefMenu.Application.Services.Localizations;

public interface ILocalizer
{
    public string Localize(string code, CultureInfo cultureInfo, string defaultValue);
}