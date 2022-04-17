using AstroClient.CheetosUI;
using AstroClient.Startup.Hooks;
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

            var AuthorizedTriggerLoc = GameObjectFinder.FindRootSceneObject("tf you lookin at").FindObject("Electronics/HTC");
            if(AuthorizedTriggerLoc != null)
            {
                foreach(var triggers in AuthorizedTriggerLoc.Get_Triggers())
                {
                    if(triggers.name.Contains("Authorized"))
                    {

                        var IsSDK1 = triggers.GetComponent<VRC_Trigger>();
                        if (IsSDK1 != null)
                        {
                            AuthorizedTrigger = IsSDK1;
                        }
                        break;
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
            }
        }

        internal static bool isCurrentWorld { get; set; } = false;


    }
}