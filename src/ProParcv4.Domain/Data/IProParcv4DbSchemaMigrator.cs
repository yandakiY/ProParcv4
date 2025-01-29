using System.Threading.Tasks;

namespace ProParcv4.Data;

public interface IProParcv4DbSchemaMigrator
{
    Task MigrateAsync();
}
