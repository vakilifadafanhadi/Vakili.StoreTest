using Vakili.StoreTest.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Vakili.StoreTest.Permissions;

public class StoreTestPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(StoreTestPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(StoreTestPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StoreTestResource>(name);
    }
}
