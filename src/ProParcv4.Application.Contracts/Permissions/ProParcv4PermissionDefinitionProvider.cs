using ProParcv4.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace ProParcv4.Permissions;

public class ProParcv4PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ProParcv4Permissions.GroupName);

        var booksPermission = myGroup.AddPermission(ProParcv4Permissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(ProParcv4Permissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(ProParcv4Permissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(ProParcv4Permissions.Books.Delete, L("Permission:Books.Delete"));

        // Define your own permissions here. Example:
        // myGroup.AddPermission(ProParcv4Permissions.MyPermission1, L("Permission:MyPermission1"));
        var vehiculesPermission = myGroup.AddPermission(ProParcv4Permissions.Vehicules.Default, L("Permission:Vehicules"));
        vehiculesPermission.AddChild(ProParcv4Permissions.Vehicules.Create, L("Permission:Vehicules.Create"));
        vehiculesPermission.AddChild(ProParcv4Permissions.Vehicules.Edit, L("Permission:Vehicules.Edit"));
        vehiculesPermission.AddChild(ProParcv4Permissions.Vehicules.Delete, L("Permission:Vehicules.Delete"));


    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ProParcv4Resource>(name);
    }
}
