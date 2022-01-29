namespace AstroClient.WorldModifications.Modifications.Jar.KitchenCooks
{
    #region Imports

    using System.Collections.Generic;
    using AstroMonos.Components.Cheats.PatronUnlocker;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;
    using Color = System.Drawing.Color;

    #endregion Imports

    internal class KitchenCooksCheats : AstroEvents
    {

        private static bool _OnlySelfHasPatreonPerk;

        private static bool _EveryoneHasPatreonPerk;
        private static PatronUnlocker GoldenKnife0 { get; set; }

        private static PatronUnlocker GoldenKnife1 { get; set; }

        private static bool KitchenCooksWorldLoaded { get; set; }  = false;

        private static QMNestedGridMenu KitchenCooksCheatPage { get; set; }

        private static QMToggleButton GetSelfPatreonKnifesBtn { get; set; }
        private static QMToggleButton GetEveryonePatreonKnifesBtn { get; set; }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.KitchenCooks)
            {
                KitchenCooksWorldLoaded = true;
                if (KitchenCooksCheatPage != null)
                {
                    ModConsole.Log($"Recognized {Name} World, Unlocking cheats menu!", Color.Green);
                    KitchenCooksCheatPage.GetMainButton().SetInteractable(true);
                    KitchenCooksCheatPage.GetMainButton().SetTextColor(UnityEngine.Color.green);
                }

                FindKnifes();
            }
            else
            {
                KitchenCooksWorldLoaded = false;
                if (KitchenCooksCheatPage != null)
                {
                    KitchenCooksCheatPage.GetMainButton().SetInteractable(false);
                    KitchenCooksCheatPage.GetMainButton().SetTextColor(UnityEngine.Color.red);
                }
            }
        }

        private static void FindKnifes()
        {
            Knife0 = GameObjectFinder.Find("/APPLIANCES/Cutting board (0)/Knife zone/Knife");
            if (Knife0 != null)
            {
                GoldenKnife0 = Knife0.GetOrAddComponent<PatronUnlocker>();
            }
            Knife1 = GameObjectFinder.Find("/APPLIANCES/Cutting board (1)/Knife zone/Knife");
            if (Knife1 != null)
            {
                GoldenKnife1 = Knife1.GetOrAddComponent<PatronUnlocker>();
            }
        }

        private static GameObject Knife1 { get; set; }
        private static GameObject Knife0 { get; set; }

        internal override void OnRoomLeft()
        {
            EveryoneHasPatreonPerk = false;
            OnlySelfHasPatreonPerk = false;
            Knife1 = null;
            Knife0 = null;
            GoldenKnife0 = null;
            GoldenKnife1 = null;
        }
        internal static bool OnlySelfHasPatreonPerk
        {
            get => _OnlySelfHasPatreonPerk;
            set
            {
                _OnlySelfHasPatreonPerk = value;
                if (GetSelfPatreonKnifesBtn != null) GetSelfPatreonKnifesBtn.SetToggleState(value);
                if (GoldenKnife0 != null) GoldenKnife0.OnlySelfHasPatreonPerk = value;
                if (GoldenKnife1 != null) GoldenKnife1.OnlySelfHasPatreonPerk = value;
            }
        }

        internal static bool EveryoneHasPatreonPerk
        {
            get => _EveryoneHasPatreonPerk;
            set
            {
                _EveryoneHasPatreonPerk = value;
                if (GetEveryonePatreonKnifesBtn != null) GetEveryonePatreonKnifesBtn.SetToggleState(value);
                if (GoldenKnife0 != null) GoldenKnife0.EveryoneHasPatreonPerk = value;
                if (GoldenKnife1 != null) GoldenKnife1.EveryoneHasPatreonPerk = value;
            }
        }

        internal static void InitCheatsMenu(QMGridTab submenu)
        {
            KitchenCooksCheatPage = new QMNestedGridMenu(submenu, "Kitchen Cooks Cheats", "Manage Kitchen Cooks Cheats");

            GetSelfPatreonKnifesBtn = new QMToggleButton(KitchenCooksCheatPage, "Private Golden Knifes", () =>
            {
                OnlySelfHasPatreonPerk = true;
                EveryoneHasPatreonPerk = false;
            }, "Private Golden Knifes", () => { OnlySelfHasPatreonPerk = false; }, "Unlocks The Patreon Perks (Golden Knifes) For You!");
            GetEveryonePatreonKnifesBtn = new QMToggleButton(KitchenCooksCheatPage, "Public Golden Knifes", () =>
            {
                EveryoneHasPatreonPerk = true;
                OnlySelfHasPatreonPerk = false;
            }, "Public Golden Knifes", () => { EveryoneHasPatreonPerk = false; }, "Unlocks The Patreon Perks (Golden Knifes) For Everyone!");

        }

    }
}