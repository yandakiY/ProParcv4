using ProParcv4.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ProParcv4.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ProParcv4EntityFrameworkCoreModule),
    typeof(ProParcv4ApplicationContractsModule)
)]
public class ProParcv4DbMigratorModule : AbpModule
{
}
