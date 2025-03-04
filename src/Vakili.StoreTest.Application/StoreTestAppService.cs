using Vakili.StoreTest.Localization;
using Volo.Abp.Application.Services;

namespace Vakili.StoreTest;

/* Inherit your application services from this class.
 */
public abstract class StoreTestAppService : ApplicationService
{
    protected StoreTestAppService()
    {
        LocalizationResource = typeof(StoreTestResource);
    }
}
