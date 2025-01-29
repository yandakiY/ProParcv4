using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using ProParcv4.Permissions;
using Volo.Abp.Authorization.Permissions;

namespace ProParcv4;

[DependsOn(
    typeof(ProParcv4DomainModule),
    typeof(ProParcv4ApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class ProParcv4ApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<AbpPermissionOptions>(options =>
        {
            options.DefinitionProviders.Add<ProParcv4PermissionDefinitionProvider>();
        });

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ProParcv4ApplicationModule>();
        });
    }
}
