using AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds;
using AstroClient.ClientActions;
using AstroClient.Tools.UdonEditor;
using AstroClient.Tools.UdonSearcher;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections;
    using System.Collections.Generic;
    using AstroMonos.Components.Cheats.PatronCrackers;
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

    internal class EvolvantArcade : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
            
        }

        private static bool _HasSubscribed = false;
        private static bool HasSubscribed
        {
            get => _HasSubscribed;
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnRoomLeft += OnRoomLeft;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
            }
        }

        private static  void OnRoomLeft()
        {


            Private_gems = null;
            PatronsBehaviours.Clear();

            HasSubscribed = false;
        }

        internal static void InitButtons(QMGridTab main)
        {
        }



        private static void FindEverything()
        {
            
            UIPanel = UdonSearch.FindUdonEvent("UIPanel", "PurchaseRapidFire");
            if(UIPanel != null)
            {
                Private_gems = new AstroUdonVariable<int>(UIPanel.RawItem, "gems");
            }


            gems = 225; // Required amount to buy all 3 perks.
            Patch_PatronStuff();
            HasSubscribed = true;
            isCurrentWorld = true;
        }


        internal static string[] PatronShit { get; } =
        {
                    "isPatron",
                    "bTier3",
                    "bTier2",
        };

        private static void Patch_PatronStuff()
        {
            var results = UdonSearch.FindAllUdonsContainingSymbols(PatronShit);
            foreach (var item in results)
            {
                foreach (var symbolname in PatronShit)
                {
                    var symbol = item.FindUdonVariable(symbolname);
                    if (symbol != null)
                    {
                        UdonHeapEditor.PatchHeap(symbol, symbolname, true, () =>
                        {
                            Log.Debug($"Patched {symbol.gameObject.name} {symbolname} To True");
                        });

                    }
                }

            }
        }


        internal static int gems
        {
            get
            {
                if (Private_gems != null) return Private_gems.Value;
                return default(int);
            }
            set
            {
                if (Private_gems != null)
                {
                    Private_gems.Value = value;
                }
            }
        }

        private static AstroUdonVariable<int> Private_gems;


        private static List<UdonBehaviour_Cached> PatronsBehaviours { get; set; }
        private static UdonBehaviour_Cached UIPanel { get; set; }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.EvolvantArcade)
            {

                Log.Write($"Recognized {Name} World, Patching Gems Amount....");
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