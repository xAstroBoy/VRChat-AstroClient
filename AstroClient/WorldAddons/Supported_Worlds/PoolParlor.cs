namespace AstroClient
{
    using AstroClient.Components;
    using AstroClient.Udon;
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using RubyButtonAPI;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using VRC.Udon;
    using static AstroClient.Variables.CustomLists;

    public class PoolParlor : GameEvents
    {




        public static void InitButtons(QMTabMenu main, float x, float y, bool btnHalf)
        {
            PoolParlorCheats = new QMNestedButton(main, x, y, "Super Tower Defense", "Super Tower Defense Cheats", null, null, null, null, btnHalf);

            _ = new QMSingleButton(PoolParlorCheats, 1, 0f, "+", () => { CurrentTableSkin++; }, "Set Table Skin!", null, null, false);
            TableSkinBtn = new QMSingleButton(PoolParlorCheats, 2, 0f, "Default Table", () => { }, "Table Skin!", null, null, false);
            _ = new QMSingleButton(PoolParlorCheats, 3, 0, "-", () => { CurrentTableSkin--;}, "Set Table Skin!", null, null, false);

            _ = new QMSingleButton(PoolParlorCheats, 1, 1f, "+", () => { CurrentCueSkin++; }, "Set Cue Skin!", null, null, false);
            CueSkinBtn = new QMSingleButton(PoolParlorCheats, 2, 1f, "Default Cue", () => { }, "Cue Skin!", null, null, false);
            _ = new QMSingleButton(PoolParlorCheats, 3, 1, "-", () => { CurrentCueSkin--; }, "Set Cue Skin!", null, null, false);

        }






        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.PoolParlor)
            {
                ModConsole.Log($"Recognized {Name} World, Patching Skins....");

                // DEAD Until Lists gets exposed...

                var module1 = UdonSearch.FindAllUdonEvents("BilliardsModule", "_start");
                foreach (var modules in module1)
                {
                    BilliardsModules.Add(modules.UdonBehaviour.DisassembleUdonBehaviour()); // WTF
                }
                var cue_0_unpacked = UdonSearch.FindUdonEvent("intl.cue-0", "_start");
                if(cue_0_unpacked != null)
                {
                    Cue_0 = cue_0_unpacked.UdonBehaviour.DisassembleUdonBehaviour();
                }
                var cue_1_unpacked = UdonSearch.FindUdonEvent("intl.cue-1", "_start");
                if (cue_1_unpacked != null)
                {
                    Cue_1 = cue_1_unpacked.UdonBehaviour.DisassembleUdonBehaviour();
                }
                var module2 = UdonSearch.FindAllUdonEvents("NetworkingManager", "_OnGameReset");
                foreach (var modules in module2)
                {
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


                if (world != null && table_primary != null && Meta_Cue_Rack != null && table_Balls != null)
                {
                    Add_Modifier_ToCueBall(Find_Balls("0", "0"));

                    Add_Modifier_ToBall(Find_Balls("0", "1"));
                    Add_Modifier_ToBall(Find_Balls("0", "2"));
                    Add_Modifier_ToBall(Find_Balls("0", "3"));
                    Add_Modifier_ToBall(Find_Balls("0", "4"));
                    Add_Modifier_ToBall(Find_Balls("0", "5"));
                    Add_Modifier_ToBall(Find_Balls("0", "6"));
                    Add_Modifier_ToBall(Find_Balls("0", "7"));
                    Add_Modifier_ToBall(Find_Balls("0", "8"));
                    Add_Modifier_ToBall(Find_Balls("0", "9"));
                    Add_Modifier_ToBall(Find_Balls("1", "0"));
                    Add_Modifier_ToBall(Find_Balls("1", "1"));
                    Add_Modifier_ToBall(Find_Balls("1", "2"));
                    Add_Modifier_ToBall(Find_Balls("1", "3"));
                    Add_Modifier_ToBall(Find_Balls("1", "4"));
                    Add_Modifier_ToBall(Find_Balls("1", "5"));
                }
            }
        }

        public static void GetCurrentTable()
        {
            int currentskin = 0;
            foreach (var module in NetworkingManagers)
            {
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

        public static void GetCurrentCue()
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
            if(Enum.IsDefined(typeof(CueSkins), currentskin))
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

        public static void SetTableSkin(TableSkins value)
        {
            SetTableSkinLocal(value);
            SetTableSkin_PoolParlorModule(value);
            SetTableSkin_NetworkingManager(value);
            SetTableSkinSynced(value);
        }
        private static void SetTableSkinLocal(TableSkins value)
        {
            foreach (var module in BilliardsModules)
            {
                UdonHeapEditor.PatchHeap(module, "tableSkinLocal", ((int)value), true);
                UdonHeapEditor.PatchHeap(module, "__0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32", (int)value, true);
                UdonHeapEditor.PatchHeap(module, "__0_mp_72681C8A3F190167F4664BA51221AA32_Int32", (int)value, true);
                UdonHeapEditor.PatchHeap(module, "__0_mp_E1F7FEED75E8E688F1A147B44E5225D5_Byte", (int)value, true);

            }
        }
        private static void SetTableSkin_PoolParlorModule(TableSkins value)
        {

            UdonHeapEditor.PatchHeap(PoolParlorModule, "__0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32", (int)value, true);
        }

        private static void SetTableSkin_NetworkingManager(TableSkins value)
        {
            foreach(var module in NetworkingManagers)
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

        private static void SetActiveCueSkin(CueSkins value)
        {
            foreach (var module in BilliardsModules)
            {
                UdonHeapEditor.PatchHeap(module, "activeCueSkin", ((int)value), true);
            }
        }
        private static void SetSyncedCueSkin(CueSkins value)
        {
            UdonHeapEditor.PatchHeap(Cue_0, "syncedCueSkin", ((int)value), true);
            UdonHeapEditor.PatchHeap(Cue_1, "syncedCueSkin", ((int)value), true);
        }

        public  enum TableSkins
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

        public enum CueSkins
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



        private static void Add_Modifier_ToBall(Parlor_Balls ball)
        {
            if (ball != null)
            {
                var udon = ball.Estetic_Ball.GetOrAddComponent<VRC_AstroUdonTrigger>();
                if (udon != null)
                {
                    udon.OnInteract += () => { ball.Table_Ball_Pickup.SetActive(!ball.Table_Ball_Pickup.active); };
                    if (ball.Table_Ball_Pickup.active)
                    {
                        udon.interactText = $"Deactivate {ball.Table_Ball.name} Pickup";
                    }
                    else
                    {
                        udon.interactText = $"Activate {ball.Table_Ball.name} Pickup";
                    }
                }
                ball.Ball_table_pickup_listener.OnDisabled += () =>
                {
                    udon.interactText = $"Activate {ball.Table_Ball.name} Pickup";
                };
                ball.Ball_table_pickup_listener.OnEnabled += () =>
                {
                    udon.interactText = $"Deactivate {ball.Table_Ball.name} Pickup";
                };
            }
        }

        private static void Add_Modifier_ToCueBall(Parlor_Balls clue)
        {
            if (clue != null)
            {
                var udon = clue.Estetic_Ball.GetOrAddComponent<VRC_AstroUdonTrigger>();
                if (udon != null)
                {
                    udon.OnInteract += () => { clue.Table_Ball_Pickup.SetActive(!clue.Table_Ball_Pickup.active); };
                    if (clue.Table_Ball_Pickup.active)
                    {
                        udon.interactText = "Deactivate Clue Ball Pickup";
                    }
                    else
                    {
                        udon.interactText = "Activate Clue Ball Pickup";
                    }
                }
                clue.Ball_table_pickup_listener.OnDisabled += () =>
                {
                    udon.interactText = "Activate Clue Ball Pickup";
                };
                clue.Ball_table_pickup_listener.OnEnabled += () =>
                {
                    udon.interactText = "Deactivate Clue Ball Pickup";
                };
            }
        }

        public static Parlor_Balls Find_Balls(string first_number, string second_number)
        {
            if (world != null && table_primary != null && Meta_Cue_Rack != null && table_Balls != null)
            {
                if (first_number + second_number == "00")
                {
                    var cue_ball_table = table_Balls.FindObject("ball00");
                    var cue_ball_table_pickup = cue_ball_table.FindObject("pickup");
                    var cue_ball_table_Pickup_Listener = cue_ball_table_pickup.GetOrAddComponent<GameObjectListener>();
                    var cue_ball_estetic = Meta_Cue_Rack.FindObject("Cue_Ball");
                    if (cue_ball_table != null && cue_ball_table_pickup != null && cue_ball_estetic != null && cue_ball_table_Pickup_Listener != null)
                    {
                        return new Parlor_Balls(first_number + second_number, cue_ball_table.gameObject, cue_ball_table_pickup.gameObject, cue_ball_table_Pickup_Listener, cue_ball_estetic.gameObject);
                    }
                    return null;
                }
                else
                {
                    Transform rack_ball;
                    Transform table_ball = table_Balls.FindObject($"ball{first_number + second_number}");
                    Transform table_ball_pickup = table_ball.FindObject("pickup");
                    GameObjectListener table_ball_pickup_listener = table_ball_pickup.GetOrAddComponent<GameObjectListener>();

                    if (first_number == "0")
                    {
                        rack_ball = Meta_Cue_Rack.FindObject($"{second_number}Ball");
                    }
                    else
                    {
                        rack_ball = Meta_Cue_Rack.FindObject($"{first_number + second_number}Ball");
                    }
                    if (table_ball != null && table_ball_pickup != null && rack_ball != null && table_ball_pickup_listener != null)
                    {
                        return new Parlor_Balls(first_number + second_number, table_ball.gameObject, table_ball_pickup.gameObject, table_ball_pickup_listener, rack_ball.gameObject);
                    }
                    return null;
                }
                return null;
            }
            return null;
        }

        public class Parlor_Balls
        {
            public string Ball_Number { get; set; }
            public GameObject Table_Ball { get; set; }
            public GameObject Table_Ball_Pickup { get; set; }
            public GameObject Estetic_Ball { get; set; }
            public GameObjectListener Ball_table_pickup_listener { get; set; }

            public Parlor_Balls(string Ball_Number, GameObject Table_Ball, GameObject Table_Ball_Pickup, GameObjectListener Ball_table_pickup_listener, GameObject Estetic_Ball)
            {
                this.Ball_Number = Ball_Number;
                this.Table_Ball = Table_Ball;
                this.Table_Ball_Pickup = Table_Ball_Pickup;
                this.Ball_table_pickup_listener = Ball_table_pickup_listener;
                this.Estetic_Ball = Estetic_Ball;
            }
        }

        public override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            table_primary = null;
            table_Balls = null;
            world = null;
            Meta_Cue_Rack = null;
        }

        public static Transform table_primary{ get; private set; }
        public static Transform table_Balls{ get; private set; }

        public static Transform world{ get; private set; }
        public static Transform Meta_Cue_Rack{ get; private set; }


        public static UdonBehaviour_Cached UpdateColorScheme_Table { get; private set;  }


        public static DisassembledUdonBehaviour Cue_0 { get; private set;  }
        public static DisassembledUdonBehaviour Cue_1 { get; private set; }

        public static DisassembledUdonBehaviour PoolParlorModule { get; private set; }

        public static List<DisassembledUdonBehaviour> NetworkingManagers { get; private set; } = new List<DisassembledUdonBehaviour>();

        public static List<DisassembledUdonBehaviour> BilliardsModules { get; private set; } = new List<DisassembledUdonBehaviour>();
        public static QMNestedButton PoolParlorCheats { get; set; }

        private static TableSkins _CurrentTableSkin;
        public static TableSkins CurrentTableSkin
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
                if(UpdateColorScheme_Table != null)
                {
                    UpdateColorScheme_Table.ExecuteUdonEvent();
                }
            }
        }
        public static QMSingleButton TableSkinBtn { get; set; }

        private static CueSkins _CurrentCueSkin;
        public static CueSkins CurrentCueSkin
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
                SetActiveCueSkin(value);
                SetSyncedCueSkin(value);
            }
        }
        public static QMSingleButton CueSkinBtn { get; set; }

    }
}