using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vakili.StoreTest.Data;
using Volo.Abp.DependencyInjection;

namespace Vakili.StoreTest.EntityFrameworkCore;

public class EntityFrameworkCoreStoreTestDbSchemaMigrator
    : IStoreTestDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreStoreTestDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the StoreTestDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<StoreTestDbContext>()
            .Database
            .MigrateAsync();
    }
}
