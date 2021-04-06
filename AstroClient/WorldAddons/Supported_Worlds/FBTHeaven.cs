using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using AstroClient.Finder;
using AstroClient.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroClient
{
    public class FBTHeaven : Overridables
    {

        public override void OnWorldReveal(string id, string name, string asseturl)
        {
            if (id == WorldIds.FBTHeaven)
            {
                ModConsole.Log($"Recognized {name} World,  Removing Blinders and Dividers...");
                var blinders = GameObjectFinder.Find("[AREA_DEVIDERS]");
                if (blinders != null)
                {
                    blinders.DestroyMeLocal();
                }

                ModConsole.Log("Editing Door Handlers Signs to be interactive...");
                var Door_1_Interactive = GameObjectFinder.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room1/Door/Door_Handle_Sign_Button_Unlock_1");
                var Door_2_Interactive = GameObjectFinder.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room2/Door/Door_Handle_Sign_Button_Unlock_2");
                var Door_3_Interactive = GameObjectFinder.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room3/Door/Door_Handle_Sign_Button_Unlock_3");
                var Door_4_Interactive = GameObjectFinder.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room4/Door/Door_Handle_Sign_Button_Unlock_4");

                var Door_1_Visual = GameObjectFinder.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room_Doors/Room_1/Door_Handle_Sign_1");
                var Door_2_Visual = GameObjectFinder.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room_Doors/Room_2/Door_Handle_Sign_2");
                var Door_3_Visual = GameObjectFinder.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room_Doors/Room_3/Door_Handle_Sign_3");
                var Door_4_Visual = GameObjectFinder.Find("[STATIC]/Building/FBT_Heaven/Private_Room_Hallway/Room_Doors/Room_4/Door_Handle_Sign_4");

                if (Door_1_Interactive != null && Door_1_Visual != null)
                {
                    ModConsole.Log("Adding Lockpick Private Door 1");
                    TriggersCloner.CloneVRC2SDKTrigger(Door_1_Interactive, Door_1_Visual, "Lockpick door 1");

                }
                if (Door_2_Interactive != null && Door_2_Visual != null)
                {
                    ModConsole.Log("Adding Lockpick Private Door 2");
                    TriggersCloner.CloneVRC2SDKTrigger(Door_2_Interactive, Door_2_Visual, "Lockpick door 2");

                }
                if (Door_3_Interactive != null && Door_3_Visual != null)
                {
                    ModConsole.Log("Adding Lockpick Private Door 3");
                    TriggersCloner.CloneVRC2SDKTrigger(Door_3_Interactive, Door_3_Visual, "Lockpick door 3");

                }
                if (Door_4_Interactive != null && Door_4_Visual != null)
                {
                    ModConsole.Log("Adding Lockpick Private Door 4");
                    TriggersCloner.CloneVRC2SDKTrigger(Door_4_Interactive, Door_4_Visual, "Lockpick door 4");
                }
            }
        }
    }
}
