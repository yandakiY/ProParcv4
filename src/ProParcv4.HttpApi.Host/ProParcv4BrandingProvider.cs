using Microsoft.Extensions.Localization;
using ProParcv4.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ProParcv4;

[Dependency(ReplaceServices = true)]
public class ProParcv4BrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ProParcv4Resource> _localizer;

    public ProParcv4BrandingProvider(IStringLocalizer<ProParcv4Resource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
