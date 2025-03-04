using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using Vakili.StoreTest.Localization;

namespace Vakili.StoreTest.Web;

[Dependency(ReplaceServices = true)]
public class StoreTestBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<StoreTestResource> _localizer;

    public StoreTestBrandingProvider(IStringLocalizer<StoreTestResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
