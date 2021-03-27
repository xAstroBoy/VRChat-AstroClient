#if DEBUG
namespace AstroClient
{
    using RubyButtonAPI;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CheetosDebugUI : Overridables
    {
        public override void VRChat_OnUiManagerInit()
        {
            var settingsButton = new QMSingleButton("ShortcutMenu", 5, 3, "AstroClient Force Save", () => { ForceSettingsSave(); }, "AstroClient Force Save", null, null, true);
        }

        private void ForceSettingsSave()
        {
            //ModConsole.DebugLog($"{plu.GetType()}, {plu.GetType().BaseType}");

            foreach (var overridable in Main.Overridable_List)
            {
                if (overridable.saveData != null)
                {
                    //ModConsole.DebugLog($"{overridable.GetType() has save data}")
                    //SettingsManager.Test<SaveData>(overridable.saveData);
                }
                //ModConsole.DebugLog($"About to force save {overridable.GetType()} which is a {overridable.GetType().BaseType}");
            }
        }
    }
}
#endif
