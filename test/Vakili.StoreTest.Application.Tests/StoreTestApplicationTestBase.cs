using Volo.Abp.Modularity;

namespace Vakili.StoreTest;

public abstract class StoreTestApplicationTestBase<TStartupModule> : StoreTestTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
