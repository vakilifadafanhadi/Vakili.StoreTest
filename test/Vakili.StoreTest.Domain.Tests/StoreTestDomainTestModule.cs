using Volo.Abp.Modularity;

namespace Vakili.StoreTest;

[DependsOn(
    typeof(StoreTestDomainModule),
    typeof(StoreTestTestBaseModule)
)]
public class StoreTestDomainTestModule : AbpModule
{

}
