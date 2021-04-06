using AstroClient.ConsoleUtils;
using AstroClient.Finder;
using AstroClient.Variables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroClient
{
    public class Meroom : Overridables
    {
        public override void OnWorldReveal()
        {
            if (WorldUtils.GetWorldID() == WorldIds.Meroom)
            {
                ModConsole.Log("Recognized Meroom, Spawning Lockpick Trigger.");

                var PrivateRoomSwitchTrigger = GameObjectFinder.Find("Private room/Button/switch");
                var DisplaySwitchTrigger = GameObjectFinder.Find("Living room/Button/switch (1)");
                if (PrivateRoomSwitchTrigger == null)
                {
                    ModConsole.Log("Failed to Find Private Room Switch, Has MeRoom World updated?", Color.Red);
                }
                else
                {
                    ModConsole.Log("Found Private room Switch!", Color.Green);
                }
                if (DisplaySwitchTrigger == null)
                {
                    ModConsole.Log("Failed to Find Living Room Display Switch, Has MeRoom World updated?", Color.Red);
                }
                else
                {
                    ModConsole.Log("Found Living Room Display Switch!", Color.Green);
                }
                if (PrivateRoomSwitchTrigger == null || DisplaySwitchTrigger == null)
                {
                    ModConsole.Log("Aborted LockPick Button Generation.", Color.Yellow);
                    return;
                }

                if (PrivateRoomSwitchTrigger != null && DisplaySwitchTrigger != null)
                {
                    TriggersCloner.CloneVRC2SDKTrigger(PrivateRoomSwitchTrigger, DisplaySwitchTrigger, "Lockpick Door");
                }
            }
        }


    }
}
