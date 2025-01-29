using Volo.Abp.Modularity;

namespace ProParcv4;

/* Inherit from this class for your domain layer tests. */
public abstract class ProParcv4DomainTestBase<TStartupModule> : ProParcv4TestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
