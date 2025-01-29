using Volo.Abp.Settings;

namespace ProParcv4.Settings;

public class ProParcv4SettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ProParcv4Settings.MySetting1));
    }
}
