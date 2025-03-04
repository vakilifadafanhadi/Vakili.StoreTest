using Vakili.StoreTest.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Vakili.StoreTest.Web.Pages;

public abstract class StoreTestPageModel : AbpPageModel
{
    protected StoreTestPageModel()
    {
        LocalizationResourceType = typeof(StoreTestResource);
    }
}
