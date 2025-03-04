using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Vakili.StoreTest.Data;

/* This is used if database provider does't define
 * IStoreTestDbSchemaMigrator implementation.
 */
public class NullStoreTestDbSchemaMigrator : IStoreTestDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
