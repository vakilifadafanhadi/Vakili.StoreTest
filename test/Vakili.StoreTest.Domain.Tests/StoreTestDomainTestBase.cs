using Volo.Abp.Modularity;

namespace Vakili.StoreTest;

/* Inherit from this class for your domain layer tests. */
public abstract class StoreTestDomainTestBase<TStartupModule> : StoreTestTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
