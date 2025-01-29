using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProParcv4.Data;
using Volo.Abp.DependencyInjection;

namespace ProParcv4.EntityFrameworkCore;

public class EntityFrameworkCoreProParcv4DbSchemaMigrator
    : IProParcv4DbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreProParcv4DbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ProParcv4DbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ProParcv4DbContext>()
            .Database
            .MigrateAsync();
    }
}
