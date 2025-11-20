namespace Mehr.Application.Localizations;

public interface ILocalizationService
{
    string GetString(string key, params object[] args);
}
