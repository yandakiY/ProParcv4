using Volo.Abp.Modularity;

namespace ProParcv4;

[DependsOn(
    typeof(ProParcv4ApplicationModule),
    typeof(ProParcv4DomainTestModule)
)]
public class ProParcv4ApplicationTestModule : AbpModule
{

}
