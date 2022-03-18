namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using AstroMonos.Components.Cheats.Worlds.PatronCrackers;
    using AstroMonos.Components.Cheats.Worlds.PuttPuttPond;
    using AstroMonos.Components.ESP;
    using AstroMonos.Components.ESP.UdonBehaviour;
    using CustomClasses;
    using Tools.Extensions;
    using Tools.UdonEditor;
    using UnityEngine;
    using UnityEngine.UI;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    internal class PrisonEscape : AstroEvents
    {
        internal static QMNestedGridMenu CurrentMenu;
        internal static bool isCurrentWorld = false;
        internal static void InitButtons(QMGridTab main)
        {
            CurrentMenu = new QMNestedGridMenu(main, "Prison Escape Cheats", "Prison Escape Cheats");
        }


        internal static void FindEverything()
        {
            if (MoneyPile != null)
            {
                MoneyInteraction = MoneyPile.FindUdonEvent("_interact");
                if (MoneyInteraction != null)
                {
                    Remove_MaxPickupDist(MoneyInteraction); // Get Rid of the anti-cheat!
                }
            }

            if (Keycard != null)
            {
                GetRedCard = Keycard.FindUdonEvent("_interact");
                if (GetRedCard != null)
                {
                    Remove_MaxPickupDist(GetRedCard); // Get Rid of the anti-cheat!
                }

            }

            if (Gate_Button != null)
            {
                GateInteraction = Gate_Button.FindUdonEvent("_interact");
            }

            if (Vents != null)
            {
                foreach (var triggervent in Vents.Get_UdonBehaviours())
                {
                    var interactevent = triggervent.FindUdonEvent("_interact");
                    if (interactevent != null)
                    {
                        if (interactevent.name.Equals("Trigger"))
                        {
                            Remove_maxUseDist(interactevent);
                        }
                    }
                }
            }

            foreach (var item in WorldUtils.UdonScripts)
            {
                if (item.name.Contains("Crate"))
                {
                    if (item.name.Contains("Crate Large"))
                    {
                        Crates.AddGameObject(item.gameObject); 
                    }
                }

                if (item.name.Equals("Patron Control"))
                {
                   PatronController = item.GetOrAddComponent<Ostinyo_World_PatronCracker>(); // Fuck u Ostinyo 
                    TogglePatronGuns = item.FindUdonEvent("_TogglePatronGuns");
                    ToggleDoublePoints = item.FindUdonEvent("_ToggleDoublePoints");

                }
            }


        }


        internal static bool? isPatron
        {
            get
            {
                if (PatronController != null) return PatronController.isPatron;
                return null;
            }
            set
            {
                var newvalue = value.GetValueOrDefault(false);
                if (PatronController != null)
                {
                    PatronController.SetAsPatron(newvalue);
                }

            }
        }



        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id.Equals(WorldIds.PrisonEscape))
            {
                if (CurrentMenu != null)
                {
                    CurrentMenu.SetInteractable(true);
                    CurrentMenu.SetTextColor(Color.green);
                }

                isCurrentWorld = true;
                FindEverything();
            }
            else
            {
                if (CurrentMenu != null)
                {
                    CurrentMenu.SetInteractable(false);
                    CurrentMenu.SetTextColor(Color.red);
                }

                isCurrentWorld = false;
            }
        }

        internal override void OnRoomLeft()
        {
            isCurrentWorld = false;
            MoneyInteraction = null;
            GetRedCard = null;
            RedCardBehaviour = null;
            GateInteraction = null;

            PatronController = null;            
            ToggleDoublePoints = null;
            TogglePatronGuns = null;
            foreach (var crate in Crates)
            {
                var renderer = crate.GetGetInChildrens<Renderer>(true);
                if (renderer != null)
                {
                    renderer.transform.RemoveComponent<ESP_HighlightItem>();
                }
            }
            LargeCrateESP = false;
            Crates.Clear();
        }


        private static void Remove_MaxPickupDist(UdonBehaviour_Cached item)
        {
            if (item != null)
            {
                try
                {

                    ModConsole.DebugLog($"Setting {item.gameObject.name} maxPickupDist to 999999999");
                    if (item.RawItem != null)
                    {
                        UdonHeapEditor.PatchHeap(item.RawItem, "maxPickupDist", 999999999f, true);
                    }
                }
                catch
                {
                }
            }
        }

        private static void Remove_maxUseDist(UdonBehaviour_Cached item)
        {
            if (item != null)
            {
                try
                {
                    ModConsole.DebugLog($"Setting {item.gameObject.name} maxUseDist to 999999999");
                    if (item.RawItem != null)
                    {
                        UdonHeapEditor.PatchHeap(item.RawItem, "maxUseDist", 999999999f, true);
                    }
                }
                catch{}
            }
        }

        private static bool _LargeCrateESP = false;

        internal static bool LargeCrateESP
        {
            get
            {
                return _LargeCrateESP;
            }
            set
            {
                _LargeCrateESP = value;
                ToggleLargeCrateESP(value);
            }
        }

        private static void ToggleLargeCrateESP(bool isOn)
        {
            foreach (var crate in Crates)
            {
                var renderer = crate.GetGetInChildrens<Renderer>(true);
                if (renderer != null)
                {
                    if (isOn)
                    {
                        renderer.transform.GetOrAddComponent<ESP_HighlightItem>();
                    }
                    else
                    {
                        renderer.transform.RemoveComponent<ESP_HighlightItem>();
                    }
                }
            }
        }


        internal static void TakeKeyCard()
        {
            if (GetRedCard != null)
            {
                if (RedCardBehaviour == null)
                {
                    // Check if Taken, if so set the heap value back to false.
                    RedCardBehaviour = GetRedCard.UdonBehaviour.ToRawUdonBehaviour();
                }

                if (RedCardBehaviour != null)
                {
                    var isTaken = UdonHeapParser.Udon_Parse_Boolean(RedCardBehaviour, "taken");
                    if (isTaken.GetValueOrDefault(false))
                    {
                        UdonHeapEditor.PatchHeap(RedCardBehaviour, "taken", false, true);
                    }
                }

                GetRedCard.InvokeBehaviour();

            }
        }


        internal static Ostinyo_World_PatronCracker PatronController { get; set; }

        private static RawUdonBehaviour RedCardBehaviour = null;
        internal static UdonBehaviour_Cached MoneyInteraction = null;
        internal static UdonBehaviour_Cached GateInteraction = null;

        internal static UdonBehaviour_Cached TogglePatronGuns = null;
        internal static UdonBehaviour_Cached ToggleDoublePoints = null;

        private static UdonBehaviour_Cached GetRedCard = null;
        private static List<GameObject> Crates = new List<GameObject>();



        private static GameObject _Openables;

        internal static GameObject Openables
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Openables == null)
                    {
                        return _Openables = GameObjectFinder.FindRootSceneObject("Openables");
                    }
                    return _Openables;
                }

                return null;
            }
        }


        private static GameObject _Vents;
        internal static GameObject Vents
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Vents == null)
                    {
                        return _Vents = Openables.FindObject("Vents");
                    }
                    return _Vents;
                }

                return null;
            }
        }

        private static GameObject _Prison;

        internal static GameObject Prison
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Prison == null)
                    {
                        return _Prison = GameObjectFinder.FindRootSceneObject("Prison");
                    }
                    return _Prison;
                }

                return null;
            }
        }


        private static GameObject _Gate_Button;
        internal static GameObject Gate_Button
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Gate_Button == null)
                    {
                        return _Gate_Button = Guard_Booth.FindObject("Gate Button");
                    }
                    return _Gate_Button;
                }

                return null;
            }
        }

        private static GameObject _Guard_Booth;
        internal static GameObject Guard_Booth
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_Guard_Booth == null)
                    {
                        return _Guard_Booth = Yard.FindObject("Guard Booth");
                    }
                    return _Guard_Booth;
                }

                return null;
            }
        }


        private static GameObject _Yard;
        internal static GameObject Yard
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (Prison == null) return null;
                    if (_Yard == null)
                    {
                        return _Yard = Prison.FindObject("Yard");
                    }
                    return _Yard;
                }

                return null;
            }
        }


        private static GameObject _ITEMS;

        internal static GameObject ITEMS
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (_ITEMS == null)
                    {
                        return _ITEMS = GameObjectFinder.FindRootSceneObject("Items");
                    }
                    return _ITEMS;
                }

                return null;
            }
        }

        private static GameObject _Money;
        internal static GameObject Money
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (ITEMS == null) return null;
                    if (_Money == null)
                    {
                        return _Money = ITEMS.FindObject("Money");
                    }
                    return _Money;
                }

                return null;
            }
        }


        private static GameObject _MoneyPile;
        internal static GameObject MoneyPile
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (Money == null) return null;
                    if (_MoneyPile == null)
                    {
                        return _MoneyPile = Money.FindObject("Money Pile");
                    }
                    return _MoneyPile;
                }

                return null;
            }
        }



        private static GameObject _Keycards;
        internal static GameObject Keycards
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (ITEMS == null) return null;
                    if (_Keycards == null)
                    {
                        return _Keycards = ITEMS.FindObject("Keycards");
                    }
                    return _Keycards;
                }

                return null;
            }
        }


        private static GameObject _Keycard;
        internal static GameObject Keycard
        {
            get
            {
                if (isCurrentWorld)
                {
                    if (Keycards == null) return null;
                    if (_Keycard == null)
                    {
                        return _Keycard = Keycards.FindObject("Keycard");
                    }
                    return _Keycard;
                }

                return null;
            }
        }


    }
}