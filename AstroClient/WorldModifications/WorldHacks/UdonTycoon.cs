namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using AstroMonos.Components.Cheats.Worlds.UdonTycoon;
    using Tools.UdonSearcher;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    internal class UdonTycoon : AstroEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Udon_Tycoon)
            {
                if (udonTycoonCheatPage != null)
                {
                    udonTycoonCheatPage.SetInteractable(true);
                    udonTycoonCheatPage.SetTextColor(Color.green);
                }

                ModConsole.Log($"Recognized {Name}, Cheats available.");
                var one = UdonSearch.FindUdonEvent("_polyCollector", "_UpdateCounter").UdonBehaviour.gameObject;
                if (one != null)
                {
                    PolyCollector = one.GetOrAddComponent<UdonTycoon_PolyCollector>();
                }
                var two = UdonSearch.FindUdonEvent("LevelController", "_ConfirmAllPartsPlaced").UdonBehaviour.gameObject;
                if (two != null)
                {
                    LevelController = two.GetOrAddComponent<UdonTycoon_LevelController>();
                }
            }
            else
            {
                if (udonTycoonCheatPage != null)
                {
                    udonTycoonCheatPage.SetInteractable(false);
                    udonTycoonCheatPage.SetTextColor(Color.red);
                }
            }
        }

        internal override void OnRoomLeft()
        {
            PolyCollector = null;
        }

        internal static void InitButtons(QMGridTab main)
        {
            udonTycoonCheatPage = new QMNestedGridMenu(main, "Udon Tycoon", "Udon Tycoon Cheats");

            _ = new QMSingleButton(udonTycoonCheatPage, 1, 0f, "Set 9999999999 Polys", () => { SetPolys(999999999); }, "Edit Current Polys Balance!", null, null, true);
        }

        private static void SetPolys(int value)
        {
            var safevalue = Mathf.Abs(value);
            if (PolyCollector != null)
            {
                if (PolyCollector.CurrentCounter.HasValue)
                {
                    PolyCollector.CurrentCounter = value;
                }
            }

            if (LevelController != null)
            {
                if (LevelController.PolyCounter1.IsNotNullOrEmptyOrWhiteSpace())
                {
                    LevelController.PolyCounter1 = value.ToString();
                }

                if (LevelController.PolyCounter2.HasValue)
                {
                    LevelController.PolyCounter2 = value;
                }

                if (LevelController.PolyCounter3.IsNotNullOrEmptyOrWhiteSpace())
                {
                    LevelController.PolyCounter3 = value.ToString();
                }
            }
        }

        internal static QMNestedGridMenu udonTycoonCheatPage { get; set; }

        internal static UdonTycoon_PolyCollector PolyCollector { get; set; }

        internal static UdonTycoon_LevelController LevelController { get; set; }
    }
}