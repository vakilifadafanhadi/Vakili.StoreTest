using Vakili.StoreTest.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Vakili.StoreTest.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class StoreTestController : AbpControllerBase
{
    protected StoreTestController()
    {
        LocalizationResource = typeof(StoreTestResource);
    }
}
