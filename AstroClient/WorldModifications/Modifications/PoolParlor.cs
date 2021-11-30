namespace AstroClient.WorldModifications.Modifications
{
    using System;
    using System.Collections.Generic;
    using AstroMonos.AstroUdons;
    using AstroMonos.Components.Spoofer;
    using Tools.Extensions;
    using Tools.UdonEditor;
    using Tools.UdonSearcher;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using static Constants.CustomLists;

    internal class PoolParlor : AstroEvents
    {
        // TODO : Rewrite this (read and cache from behaviour themself!)
        internal static void InitButtons(QMGridTab main)
        {
            PoolParlorCheats = new QMNestedButton(main, "PoolParlor", "PoolParlor Customization");

            _ = new QMSingleButton(PoolParlorCheats, 1, 0f, "+", () => { CurrentTableSkin++; }, "Set Table Skin!", null, null, true);
            TableSkinBtn = new QMSingleButton(PoolParlorCheats, 2, 0f, "Default Table", () => { CurrentTableSkin = _CurrentTableSkin; }, "Table Skin!", null, null, true);
            _ = new QMSingleButton(PoolParlorCheats, 3, 0, "-", () => { CurrentTableSkin--; }, "Set Table Skin!", null, null, true);

            _ = new QMSingleButton(PoolParlorCheats, 1, 1f, "+", () => { CurrentCueSkin++; }, "Set Cue Skin!", null, null, true);
            CueSkinBtn = new QMSingleButton(PoolParlorCheats, 2, 1f, "Default Cue", () => { CurrentCueSkin = _CurrentCueSkin; }, "Cue Skin!", null, null, true);
            _ = new QMSingleButton(PoolParlorCheats, 3, 1, "-", () => { CurrentCueSkin--; }, "Set Cue Skin!", null, null, true);

            CueSkinOverrideBtn = new QMSingleToggleButton(PoolParlorCheats, 1, 2f, "OVerride Cue Skin", () => { OverrideCurrentSkins = true; }, "Override Cue Skin", () => { OverrideCurrentSkins = false; }, "Enable Cue Skin Override using Spoofer.", Color.green, Color.red, null, false, true);
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.PoolParlor)
            {
                if (PoolParlorCheats != null)
                {
                    PoolParlorCheats.SetIntractable(true);
                    PoolParlorCheats.SetTextColor(Color.green);
                }

                ModConsole.Log($"Recognized {Name} World, Patching Skins....");

                if (PlayerSpooferUtils.SpoofAsWorldAuthor)
                {
                    ModConsole.Warning("Use the New Customization Menu to Access Table and Cue skins!");
                    PlayerSpooferUtils.SpoofAsWorldAuthor = false;
                }
                // DEAD Until Lists gets exposed...

                var module1 = UdonSearch.FindAllUdonEvents("BilliardsModule", "_start");
                for (int i = 0; i < module1.Count; i++)
                {
                    UdonBehaviour_Cached modules = module1[i];
                    BilliardsModules.Add(modules.UdonBehaviour.DisassembleUdonBehaviour()); // WTF
                }
                var cue_0_unpacked = UdonSearch.FindUdonEvent("intl.cue-0", "_start");
                if (cue_0_unpacked != null)
                {
                    Cue_0 = cue_0_unpacked.UdonBehaviour.DisassembleUdonBehaviour();
                }
                var cue_1_unpacked = UdonSearch.FindUdonEvent("intl.cue-1", "_start");
                if (cue_1_unpacked != null)
                {
                    Cue_1 = cue_1_unpacked.UdonBehaviour.DisassembleUdonBehaviour();
                }
                var module2 = UdonSearch.FindAllUdonEvents("NetworkingManager", "_OnGameReset");
                for (int i = 0; i < module2.Count; i++)
                {
                    UdonBehaviour_Cached modules = module2[i];
                    NetworkingManagers.Add(modules.UdonBehaviour.DisassembleUdonBehaviour()); // WTF
                }

                var PoolParlorModule_unpacked = UdonSearch.FindUdonEvent("PoolParlorModule", "_GetSAOMenu");
                if (PoolParlorModule_unpacked != null)
                {
                    PoolParlorModule = PoolParlorModule_unpacked.UdonBehaviour.DisassembleUdonBehaviour();
                }

                UpdateColorScheme_Table = UdonSearch.FindUdonEvent("GraphicsManager", "_UpdateTableColorScheme");
                GetCurrentTable();
                GetCurrentCue();
                SetupCues();
            }
            else
            {
                if (PoolParlorCheats != null)
                {
                    PoolParlorCheats.SetIntractable(false);
                    PoolParlorCheats.SetTextColor(Color.red);
                }
            }
        }

        internal static void GetCurrentTable()
        {
            int currentskin = 0;
            for (int i = 0; i < NetworkingManagers.Count; i++)
            {
                DisassembledUdonBehaviour module = NetworkingManagers[i];
                var result = UdonHeapParser.Udon_Parse_Byte(module, "tableSkinSynced");
                if (result != null && result.HasValue)
                {
                    currentskin = result.Value;
                }
                break;
            }
            if (Enum.IsDefined(typeof(TableSkins), currentskin))
            {
                var translated = (TableSkins)currentskin;
                if (TableSkinBtn != null)
                {
                    TableSkinBtn.SetButtonText(translated.ToString());
                }
            }
            else
            {
                ModConsole.Warning("New Table Skin Detected, Please Notify the developer To implement it.");
            }
        }

        internal static void GetCurrentCue()
        {
            int currentskin = 0;
            foreach (var module in BilliardsModules)
            {
                var result = UdonHeapParser.Udon_Parse_Int32(module, "activeCueSkin");
                if (result != null && result.HasValue)
                {
                    currentskin = result.Value;
                }
                break;
            }
            if (Enum.IsDefined(typeof(CueSkins), currentskin))
            {
                var translated = (CueSkins)currentskin;
                if (CueSkinBtn != null)
                {
                    CueSkinBtn.SetButtonText(translated.ToString());
                }
            }
            else
            {
                ModConsole.Warning("New Cue Skin Detected, Please Notify the developer To implement it.");
            }
        }

        internal static void SetTableSkin(TableSkins skin)
        {
            SetTableSkinLocal(skin);
            SetTableSkin_PoolParlorModule(skin);
            SetTableSkin_NetworkingManager(skin);
            SetTableSkinSynced(skin);
        }

        private static void SetTableSkinLocal(TableSkins value)
        {
            foreach (var module in BilliardsModules)
            {
                try
                {
                    UdonHeapEditor.PatchHeap(module, "tableSkinLocal", ((int)value), true);
                    UdonHeapEditor.PatchHeap(module, "__0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32", (int)value, true);
                    UdonHeapEditor.PatchHeap(module, "__0_mp_72681C8A3F190167F4664BA51221AA32_Int32", (int)value, true);
                    UdonHeapEditor.PatchHeap(module, "__0_mp_E1F7FEED75E8E688F1A147B44E5225D5_Byte", (int)value, true);
                }
                catch { }
            }
        }

        private static void SetTableSkin_PoolParlorModule(TableSkins value)
        {
            UdonHeapEditor.PatchHeap(PoolParlorModule, "__0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32", (int)value, true);
        }

        private static void SetTableSkin_NetworkingManager(TableSkins value)
        {
            foreach (var module in NetworkingManagers)
            {
                UdonHeapEditor.PatchHeap(module, "__0_mp_72681C8A3F190167F4664BA51221AA32_Byte", (int)value, true);
            }
        }

        private static void SetTableSkinSynced(TableSkins value)
        {
            foreach (var module in NetworkingManagers)
            {
                if (UdonHeapParser.Udon_Parse_System_UInt16(module, "tableSkinSynced").HasValue)
                {
                    UdonHeapEditor.PatchHeap(module, "tableSkinSynced", (ushort)value, true);
                }
                else
                {
                    UdonHeapEditor.PatchHeap(module, "tableSkinSynced", ((byte)value), true);
                }
            }
        }

        internal static void SetCueSkin(CueSkins skin)
        {
            SetActiveCueSkin(skin);
            SetSyncedCueSkin(skin);
        }

        private static void SetActiveCueSkin(CueSkins value)
        {
            foreach (var module in BilliardsModules)
            {
                try
                {
                    if (UdonHeapParser.Udon_Parse_Int32(module, "activeCueSkin").Value != (int)value)
                    {
                        UdonHeapEditor.PatchHeap(module, "activeCueSkin", ((int)value), true);
                    }
                }
                catch
                {
                }
            }
        }

        private static void SetSyncedCueSkin(CueSkins value)
        {
            try
            {
                UdonHeapEditor.PatchHeap(Cue_0, "activeCueSkin", ((int)value), true);
            }
            catch { } // Nobody cares .
            try
            {
                UdonHeapEditor.PatchHeap(Cue_0, "syncedCueSkin", ((int)value), true);
            }
            catch { } // Nobody cares .

            try
            {
                UdonHeapEditor.PatchHeap(Cue_1, "activeCueSkin", ((int)value), true);
            }
            catch { } // Nobody cares .
            try
            {
                UdonHeapEditor.PatchHeap(Cue_1, "syncedCueSkin", ((int)value), true);
            }
            catch { } // Nobody cares .
        }

        internal enum TableSkins
        {
            White = 0,
            Green = 1,
            Blue = 2,
            Purple = 3,
            Black = 4,
            Red = 5,
            Toaster = 6,
            Chintzy = 7,
            Yuuta = 8,
        }

        internal enum CueSkins
        {
            DefaultDark = 0,
            TournamentWinner = 1,
            Trickshotter = 2,
            Toaster = 3,
            Yuuta = 4,
            Chintzy = 5,
            Meta = 6,
            HolyStar = 7,
            DefaultLight = 8,
            BetaTester = 9,
        }

        public static void SetupCues()
        {
            var cue1 = GameObjectFinder.FindRootSceneObject("Modules").transform.FindObject("BilliardsModule/intl.cue-0");
            if (cue1 != null)
            {
                var Primary = cue1.FindObject("primary");
                var Secondary = cue1.FindObject("secondary");
                // Do  stuff;
                if (Primary != null)
                {
                    if (Primary != null)
                    {
                        Cue1_Primary = Primary.gameObject.AddComponent<VRC_AstroPickup>();
                        Cue1_Primary.OnPickup = onPickup;
                        Cue1_Primary.OnPickupUseUp = onPickup;
                        Cue1_Primary.OnPickupUseDown = onPickup;
                        Cue1_Primary.OnDrop = OnDrop;
                    }
                    if (Secondary != null)
                    {
                        Cue1_Secondary = Secondary.gameObject.AddComponent<VRC_AstroPickup>();
                        Cue1_Secondary.OnPickup = onPickup;
                        Cue1_Secondary.OnPickupUseUp = onPickup;
                        Cue1_Secondary.OnPickupUseDown = onPickup;
                        Cue1_Secondary.OnDrop = OnDrop;
                    }
                }
            }
            var cue2 = GameObjectFinder.FindRootSceneObject("Modules").transform.FindObject("BilliardsModule/intl.cue-1");
            if (cue2 != null)
            {
                var Primary_2 = cue2.FindObject("primary");
                var Secondary_2 = cue2.FindObject("secondary");
                // Do  stuff;
                if (Primary_2 != null)
                {
                    Cue2_Primary = Primary_2.gameObject.AddComponent<VRC_AstroPickup>();
                    Cue2_Primary.OnPickup = onPickup;
                    Cue2_Primary.OnPickupUseUp = onPickup;
                    Cue2_Primary.OnPickupUseDown = onPickup;

                    Cue2_Primary.OnDrop = OnDrop;
                }
                if (Secondary_2 != null)
                {
                    Cue2_Secondary = Secondary_2.gameObject.AddComponent<VRC_AstroPickup>();
                    Cue2_Secondary.OnPickup = onPickup;
                    Cue2_Secondary.OnPickupUseUp = onPickup;
                    Cue2_Secondary.OnPickupUseDown = onPickup;
                    Cue2_Secondary.OnDrop = OnDrop;
                }
            }
        }

        internal override void OnRoomLeft()
        {
            if (OverrideCurrentSkins)
            {
                PlayerSpooferUtils.SpoofAsWorldAuthor = false;
            }
        }

        private static void OnDrop()
        {
            if (OverrideCurrentSkins)
            {
                PlayerSpooferUtils.SpoofAsWorldAuthor = false;
            }
        }

        private static void onPickup()
        {
            if (OverrideCurrentSkins)
            {
                SetCueSkin(_CurrentCueSkin);
                PlayerSpooferUtils.SpoofAsWorldAuthor = true;
            }
        }

        internal static VRC_AstroPickup Cue1_Primary { get; private set; }
        internal static VRC_AstroPickup Cue1_Secondary { get; private set; }

        internal static VRC_AstroPickup Cue2_Primary { get; private set; }
        internal static VRC_AstroPickup Cue2_Secondary { get; private set; }

        internal static UdonBehaviour_Cached UpdateColorScheme_Table { get; private set; }

        internal static DisassembledUdonBehaviour Cue_0 { get; private set; }
        internal static DisassembledUdonBehaviour Cue_1 { get; private set; }

        internal static DisassembledUdonBehaviour PoolParlorModule { get; private set; }

        internal static List<DisassembledUdonBehaviour> NetworkingManagers { get; private set; } = new List<DisassembledUdonBehaviour>();

        internal static List<DisassembledUdonBehaviour> BilliardsModules { get; private set; } = new List<DisassembledUdonBehaviour>();
        internal static QMNestedButton PoolParlorCheats { get; set; }

        private static TableSkins _CurrentTableSkin;

        internal static TableSkins CurrentTableSkin
        {
            get
            {
                return _CurrentTableSkin;
            }
            set
            {
                if (!Enum.IsDefined(typeof(TableSkins), value))
                {
                    value = TableSkins.White;
                }
                _CurrentTableSkin = value;
                if (TableSkinBtn != null)
                {
                    TableSkinBtn.SetButtonText(value.ToString());
                }
                SetTableSkin(value);
                if (UpdateColorScheme_Table != null)
                {
                    UpdateColorScheme_Table.InvokeBehaviour();
                }
            }
        }

        internal static QMSingleButton TableSkinBtn { get; set; }

        private static CueSkins _CurrentCueSkin = CueSkins.DefaultLight;

        internal static CueSkins CurrentCueSkin
        {
            get
            {
                return _CurrentCueSkin;
            }
            set
            {
                if (!Enum.IsDefined(typeof(CueSkins), value))
                {
                    value = CueSkins.DefaultLight;
                }
                if (CueSkinBtn != null)
                {
                    CueSkinBtn.SetButtonText(value.ToString());
                }
                _CurrentCueSkin = value;
                SetCueSkin(value);
            }
        }

        internal static QMSingleButton CueSkinBtn { get; set; }

        internal static QMSingleToggleButton CueSkinOverrideBtn { get; set; }

        private static bool _OverrideCurrentSkins = false;

        internal static bool OverrideCurrentSkins
        {
            get
            {
                return _OverrideCurrentSkins;
            }
            set
            {
                _OverrideCurrentSkins = value;
                if (CueSkinOverrideBtn != null)
                {
                    CueSkinOverrideBtn.SetToggleState(value);
                }
            }
        }
    }
}