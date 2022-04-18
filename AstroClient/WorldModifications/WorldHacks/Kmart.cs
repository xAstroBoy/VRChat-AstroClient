using AstroClient.CheetosUI;
using AstroClient.Startup.Hooks;
using VRC;
using VRC.SDKBase;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections;
    using System.Collections.Generic;
    using AstroMonos.Components.Cheats.PatronCrackers;
    using AstroMonos.Components.Cheats.Worlds.PuttPuttPond;
    using CustomClasses;
    using MelonLoader;
    using Tools.Extensions;
    using Tools.World;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.Utility;

    internal class Kmart : AstroEvents
    {

        private static VRC_Trigger AuthorizedTrigger { get; set; }
        private static VRC_Trigger UnauthorizedTrigger { get; set; }

        internal static bool RemoveBlocksForJoinedPlayers { get; set; } = false;

        private static void FindEverything()
        {
            var UselessColliders = GameObjectFinder.FindRootSceneObject("tf you lookin at").FindObject("RoombaBase/instance_1/instance_1_1");
            if (UselessColliders != null)
            {
                foreach(var item in UselessColliders.transform.Get_All_Childs())
                {
                    item.IgnoreLocalPlayerCollision();
                }
            }

            var keypadtriggerloc = GameObjectFinder.FindRootSceneObject("tf you lookin at").FindObject("Electronics/HTC");
            if(keypadtriggerloc != null)
            {
                foreach(var triggers in keypadtriggerloc.Get_Triggers())
                {
                    if(triggers.name.Contains("Authorized"))
                    {

                        var IsSDK1 = triggers.GetComponent<VRC_Trigger>();
                        if (IsSDK1 != null)
                        {
                            AuthorizedTrigger = IsSDK1;
                        }
                    }
                    if (triggers.name.Contains("Unauthorized"))
                    {

                        var IsSDK1 = triggers.GetComponent<VRC_Trigger>();
                        if (IsSDK1 != null)
                        {
                            UnauthorizedTrigger = IsSDK1;
                        }
                    }

                }
            }

            if(AuthorizedTrigger != null)
            {
                new WorldButton(new Vector3(-16.6f, 3.2f, -5.92f), new Vector3(0, 90, 0), " <color=red>Bypass Keypad For Everyone!</color>", () =>
                 {
                     BypassKmartRestrictions();
                 });
            }
        }

        internal static void RestoreKmartRestrictions()
        {
            if (UnauthorizedTrigger != null)
            {
                RemoveBlocksForJoinedPlayers = false;
                WorldTriggerHook.SendTriggerToEveryone = true;
                UnauthorizedTrigger.TriggerClick();
                WorldTriggerHook.SendTriggerToEveryone = false;
            }
        }


        internal static void BypassKmartRestrictions()
        {
            if(AuthorizedTrigger != null)
            {
                WorldTriggerHook.SendTriggerToEveryone = true;
                AuthorizedTrigger.TriggerClick();
                WorldTriggerHook.SendTriggerToEveryone = false;

            }
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.KMartExpress_1)
            {

                Log.Write($"Recognized {Name} World, Removing Blocking System....", System.Drawing.Color.Gold);
                isCurrentWorld = true;
                FindEverything();
            }
            else
            {
                isCurrentWorld = false;
                AuthorizedTrigger = null;
                UnauthorizedTrigger = null;
                RemoveBlocksForJoinedPlayers = false;
            }
        }

        internal override void OnPlayerJoined(Player player)
        {
            if (RemoveBlocksForJoinedPlayers)
            {
                BypassKmartRestrictions();  // KEK
            }

        }

        internal static bool isCurrentWorld { get; set; } = false;


    }
}