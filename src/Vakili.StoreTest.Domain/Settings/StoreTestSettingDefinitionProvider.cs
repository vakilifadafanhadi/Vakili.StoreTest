using Volo.Abp.Settings;

namespace Vakili.StoreTest.Settings;

public class StoreTestSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(StoreTestSettings.MySetting1));
    }
}
