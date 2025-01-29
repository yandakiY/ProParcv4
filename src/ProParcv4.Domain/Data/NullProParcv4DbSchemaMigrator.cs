using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ProParcv4.Data;

/* This is used if database provider does't define
 * IProParcv4DbSchemaMigrator implementation.
 */
public class NullProParcv4DbSchemaMigrator : IProParcv4DbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
