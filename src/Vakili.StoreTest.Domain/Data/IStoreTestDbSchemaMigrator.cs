using System.Threading.Tasks;

namespace Vakili.StoreTest.Data;

public interface IStoreTestDbSchemaMigrator
{
    Task MigrateAsync();
}
