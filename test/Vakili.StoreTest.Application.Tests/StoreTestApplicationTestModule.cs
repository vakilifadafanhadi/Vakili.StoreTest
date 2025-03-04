using Volo.Abp.Modularity;

namespace Vakili.StoreTest;

[DependsOn(
    typeof(StoreTestApplicationModule),
    typeof(StoreTestDomainTestModule)
)]
public class StoreTestApplicationTestModule : AbpModule
{

}
