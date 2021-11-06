namespace AstroClient
{
    using System.Collections;
    using System.Collections.Generic;
    using AstroButtonAPI;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using AstroMonos.AstroUdons;
    using AstroMonos.Components.Cheats.Worlds.SuperTowerDefense;
    using AstroMonos.Components.Cheats.Worlds.UdonTycoon;
    using CheetoLibrary;
    using MelonLoader;
    using UnityEngine;
    using Variables;
    using VRC.Udon.Serialization.OdinSerializer.Utilities;
    using static Variables.CustomLists;

    internal class UdonTycoon : GameEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Udon_Tycoon)
            {
                ModConsole.Log($"Recognized {Name}, Cheats available.");
                var one = UdonSearch.FindUdonEvent("_polyCollector", "_UpdateCounter").UdonBehaviour.gameObject;
                if (one != null)
                {
                    PolyCollector = one.GetOrAddComponent<UdonTycoon_PolyCollector>();
                }
                var two  = UdonSearch.FindUdonEvent("LevelController", "_ConfirmAllPartsPlaced").UdonBehaviour.gameObject;
                if (two != null)
                {
                    LevelController = two.GetOrAddComponent<UdonTycoon_LevelController>();
                }


            }
        }

        internal override void OnRoomLeft()
        {
            PolyCollector = null;
        }

        internal static void InitButtons(QMTabMenu main, float x, float y, bool btnHalf)
        {
            udonTycoonCheatPage = new QMNestedButton(main, x, y, "Udon Tycoon", "Udon Tycoon Cheats", null, null, null, null, btnHalf);

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





        internal static QMNestedButton udonTycoonCheatPage { get; set; }

        internal static UdonTycoon_PolyCollector PolyCollector { get; set; }

        internal static UdonTycoon_LevelController LevelController { get; set; }

    }
}