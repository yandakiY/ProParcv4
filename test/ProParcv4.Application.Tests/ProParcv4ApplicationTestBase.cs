using Volo.Abp.Modularity;

namespace ProParcv4;

public abstract class ProParcv4ApplicationTestBase<TStartupModule> : ProParcv4TestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
