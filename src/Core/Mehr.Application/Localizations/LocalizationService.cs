using Microsoft.Extensions.Localization;
using Mehr.Resources;

namespace Mehr.Application.Localizations;

public class LocalizationService : ILocalizationService
{
    private readonly IStringLocalizer<SharedResource> _localizer;

    public LocalizationService(IStringLocalizer<SharedResource> localizer)
    {
        _localizer = localizer;
    }

    public string GetString(string key, params object[] args)
    {
        return _localizer[key, args];
    }

}
