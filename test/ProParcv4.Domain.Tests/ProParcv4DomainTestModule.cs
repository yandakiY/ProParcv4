using Volo.Abp.Modularity;

namespace ProParcv4;

[DependsOn(
    typeof(ProParcv4DomainModule),
    typeof(ProParcv4TestBaseModule)
)]
public class ProParcv4DomainTestModule : AbpModule
{

}
