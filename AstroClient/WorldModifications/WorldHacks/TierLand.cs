using AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds;
using AstroClient.Tools.UdonSearcher;

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

    internal class TierLand : AstroEvents
    {

        internal static void InitButtons(QMGridTab main)
        {
        }



        private static void FindEverything()
        {
            PatronSystem = UdonSearch.FindUdonEvent("Patreon Credits", "GetPatronTier");
            if(PatronSystem != null)
            {
                PatronSystem.gameObject.GetOrAddComponent<JarCreditReader>();
            }
        }


        private static UdonBehaviour_Cached PatronSystem { get; set; }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.TierLand)
            {

                Log.Write($"Recognized {Name} World, Patching Patron System....");
                isCurrentWorld = true;
                if (CurrentMenu != null)
                {
                    CurrentMenu.SetInteractable(true);
                    CurrentMenu.SetTextColor(Color.green);
                }

                FindEverything();
            }
            else
            {
                isCurrentWorld = false;
                if (CurrentMenu != null)
                {
                    CurrentMenu.SetInteractable(false);
                    CurrentMenu.SetTextColor(Color.red);
                }
            }
        }

        internal static bool isCurrentWorld { get; set; } = false;

        internal static QMNestedGridMenu CurrentMenu { get; set; }

    }
}