namespace AstroClient.WorldModifications.Modifications
{
    using System.Collections.Generic;
    using AstroMonos.Components.Cheats.Worlds.PuttPuttPond;
    using Constants;
    using Tools.Extensions;
    using Tools.World;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    internal class PuttPuttPond : AstroEvents
    {

        internal static QMNestedGridMenu PuttPuttPondMenu { get; set; }
        internal static QMToggleButton ActivatePatronModeToggle { get; set; }
        internal static void InitButtons(QMGridTab main)
        {
            PuttPuttPondMenu = new QMNestedGridMenu(main, "PuttPuttPond Exploits", "PuttPuttPond Exploits");
            ActivatePatronModeToggle = new QMToggleButton(main, "Patron Mode", () => { isPatron = true; }, () => { isPatron = false; }, "Enable Patron Golden putt");
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
                if (ActivatePatronModeToggle != null) ActivatePatronModeToggle.SetToggleState(newvalue);
            }
        }

        private static void FindEverything()
        {
            foreach (var item in WorldUtils_Old.Get_UdonBehaviours())
            {
                try
                {
                    if (item != null)
                    {
                        if (PatronController == null)
                        {
                            if (item.name.Equals("Patron Control"))
                            {
                                PatronController = item.gameObject.GetOrAddComponent<PuttPuttPond_PatronControlEditor>();
                            }
                        }
                        if (item.name.Equals("Golf Ball"))
                        {
                            var editor = item.gameObject.GetOrAddComponent<PuttPuttPond_GolfBallManipulator>();
                            if (editor != null)
                            {
                                if (!GolfBalls.Contains(editor))
                                {
                                    GolfBalls.Add(editor);
                                }
                            }
                        }
                    }
                }
                catch { }
            }

            if (PatronController != null)
            {
                if (ActivatePatronModeToggle != null) ActivatePatronModeToggle.SetToggleState(PatronController.isPatron.GetValueOrDefault(false));
            }
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.PuttPuttPond)
            {

                ModConsole.Log($"Recognized {Name} World, Patching Udon....");

                if (PuttPuttPondMenu != null)
                {
                    PuttPuttPondMenu.SetInteractable(true);
                    PuttPuttPondMenu.SetTextColor(Color.green);
                }

                FindEverything();
            }
            else
            {
                if (PuttPuttPondMenu != null)
                {
                    PuttPuttPondMenu.SetInteractable(false);
                    PuttPuttPondMenu.SetTextColor(Color.red);
                }
            }
        }

        internal static PuttPuttPond_GolfBallManipulator SelfGolfball
        {
            get
            {
                if (WorldUtils.WorldID != WorldIds.PuttPuttPond) return null;
                foreach (var item in GolfBalls)
                {
                    if (item != null)
                    {
                        if (item.gameObject.active && item.transform.parent.gameObject.active)
                        {
                            if (item.isSelf.GetValueOrDefault(false))
                            {
                                return item;
                            }
                        }
                    }
                }

                return null;
            }
        }

        internal override void OnRoomLeft()
        {
            GolfBalls.Clear();
            PatronController = null;
        }

        internal static PuttPuttPond_PatronControlEditor PatronController { get; set; }
        internal static List<PuttPuttPond_GolfBallManipulator> GolfBalls { get; set; } = new List<PuttPuttPond_GolfBallManipulator>();
    }
}