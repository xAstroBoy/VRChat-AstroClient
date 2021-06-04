namespace AstroClient
{
	using AstroClient.Extensions;
	using AstroClient.Variables;
	using AstroLibrary.Console;
	using AstroLibrary.Finder;
	using System.Collections.Generic;

	public class FBTHeaven : GameEvents
    {
        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            if (id == WorldIds.FBTHeaven)
            {
                ModConsole.DebugLog($"Recognized {Name} World,  Removing Blinders and Dividers...");
                var blinders = GameObjectFinder.Find("[AREA_DEVIDERS]");
                if (blinders != null)
                {
                    blinders.DestroyMeLocal();
                }

                ModConsole.DebugLog("Editing Door Handlers Signs to be interactive...");
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
                    ModConsole.DebugLog("Adding Lockpick Private Door 1");
                    TriggersCloner.CloneVRC2SDKTrigger(Door_1_Interactive, Door_1_Visual, "Lockpick door 1");
                }
                if (Door_2_Interactive != null && Door_2_Visual != null)
                {
                    ModConsole.DebugLog("Adding Lockpick Private Door 2");
                    TriggersCloner.CloneVRC2SDKTrigger(Door_2_Interactive, Door_2_Visual, "Lockpick door 2");
                }
                if (Door_3_Interactive != null && Door_3_Visual != null)
                {
                    ModConsole.DebugLog("Adding Lockpick Private Door 3");
                    TriggersCloner.CloneVRC2SDKTrigger(Door_3_Interactive, Door_3_Visual, "Lockpick door 3");
                }
                if (Door_4_Interactive != null && Door_4_Visual != null)
                {
                    ModConsole.DebugLog("Adding Lockpick Private Door 4");
                    TriggersCloner.CloneVRC2SDKTrigger(Door_4_Interactive, Door_4_Visual, "Lockpick door 4");
                }
            }
        }
    }
}