using Vakili.StoreTest.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Vakili.StoreTest.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(StoreTestEntityFrameworkCoreModule),
    typeof(StoreTestApplicationContractsModule)
)]
public class StoreTestDbMigratorModule : AbpModule
{
}
