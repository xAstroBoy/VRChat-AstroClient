namespace AstroClient
{
    #region Imports

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using AstroButtonAPI;
    using AstroClientCore.Events;
    using AstroLibrary;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using AstroMonos;
    using AstroMonos.Components.Tools;
    using ButtonShortcut;
    using CheetoLibrary;
    using CheetosConsole;
    using ClientUI.Menu;
    using ClientUI.QuickMenuButtons;
    using Experiments;
    using GameObjectDebug;
    using ItemTweakerV2;
    using ItemTweakerV2.Selector;
    using MelonLoader;
    using Skyboxes;
    using UnhollowerBaseLib;
    using UnityEngine;
    using Variables;
    using VRC;
    using VRC.Core;
    using VRC.UI;
    using VRC.UI.Elements;
    using WorldLights;
    using Worlds;
    using Application = UnityEngine.Application;
    using AvatarUtils = AvatarMods.AvatarUtils;
    using Button = UnityEngine.UI.Button;
    using Color = System.Drawing.Color;
    using Console = CheetosConsole.Console;
    using QuickMenu = QuickMenu;

    #endregion Imports

    public class Main : MelonMod
    {
        #region EventHandlers

        internal static event EventHandler Event_OnApplicationLateStart;


        internal static event EventHandler Event_OnUpdate;

        internal static event EventHandler Event_LateUpdate;


        internal static event EventHandler Event_VRChat_OnUiManagerInit;

        internal static event EventHandler Event_VRChat_OnQuickMenuInit;

        internal static event EventHandler Event_VRChat_OnActionMenuInit;

        internal static event EventHandler<OnSceneLoadedEventArgs> Event_OnSceneLoaded;

        internal static event EventHandler Event_OnApplicationQuit;

        #endregion EventHandlers

        #region Buttons

        internal static QMSingleToggleButton ToggleDebugInfo;
        internal static QMSingleButton CopyIDButton;
        internal static QMSingleButton AvatarByIDButton;
        internal static QMSingleButton ClearVRamButton;
        internal static QMSingleButton JoinInstanceButton;
        internal static QMSingleButton ReloadAvatarsButton;
        internal static QMSingleButton CloseButton;
        internal static QMSingleButton RestartButton;

        #endregion Buttons

        private static List<GameEvents> GameEvents { get; set; } = new List<GameEvents>();

        private static List<Tweaker_Events> Tweaker_Overridables { get; set; } = new List<Tweaker_Events>();

        public override void OnApplicationStart()
        {
            LogSupport.RemoveAllHandlers(); // Fuck ML ugly console.
            ModConsole.Initialize("AstroClient");
            WriteBanner();
            ConfigManager.Validate();
            ConfigManager.Load();
            if (ModConsole.DebugMode != ConfigManager.General.DebugLog)
            {
                ModConsole.DebugMode = ConfigManager.General.DebugLog;
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

#if OFFLINE
            KeyManager.IsAuthed = true;
            Bools.IsDeveloper = true;
#else
            for (; !NetworkingManager.IsReady;)
            {
            }
#endif

            stopwatch.Stop();
            ModConsole.DebugLog($"Client Connected: Took {stopwatch.ElapsedMilliseconds}ms");

            if (!KeyManager.IsAuthed)
            {
                ModConsole.Error("Authentication Failed!");
                ModConsole.OpenLatestLogFile();
                Application.Quit();
                Process.GetCurrentProcess().Close();
                Environment.Exit(0);
            }
            else
            {
                InitializeOverridables();
                DoAfterUiManagerInit(() => { Start_VRChat_OnUiManagerInit(); });
                DoAfterQuickMenuInit(() => { Start_VRChat_OnQuickMenuInit(); });
                DoAfterActionMenuInit(() => { Start_VRChat_OnActionMenuInit(); });

            }
        }

        public override void OnUpdate()
        {
            if(KeyManager.IsAuthed)
            Event_OnUpdate?.SafetyRaise();
        }
        public override void OnLateUpdate()
        {
            if (KeyManager.IsAuthed)
                Event_LateUpdate?.SafetyRaise();
        }

        private IEnumerator WaitForActionMenuInit()
        {
            while (ActionMenuDriver.prop_ActionMenuDriver_0 == null) //VRCUIManager Init is too early 
                yield return null;
        }

        public override void OnApplicationLateStart()
        {
            if (!KeyManager.IsAuthed) return;
            Event_OnApplicationLateStart?.SafetyRaise();
        }

        public override void OnApplicationQuit()
        {
            if (!KeyManager.IsAuthed) return;
            Event_OnApplicationQuit?.SafetyRaise();
            ConfigManager.SaveAll();
        }

        public override void OnPreferencesSaved()
        {
            if (!KeyManager.IsAuthed) return;
            ConfigManager.SaveAll();
        }

        /// <summary>
        /// Maybe move this later?
        /// </summary>
        internal static void WriteBanner()
        {
            try
            {
                Console.WriteFigletWithGradient(FigletFont.LoadFromAssembly("Larry3D.flf"), BuildInfo.Name, Color.LightBlue, Color.MidnightBlue);
            }
            catch (Exception e)
            {
                ModConsole.Error("Failed To generate Gradient, the Embeded file doesn't exist!");
                ModConsole.ErrorExc(e);
            }
        }

        internal static void InitializeOverridables()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (!KeyManager.IsAuthed)
                return;
            Type[] array = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < array.Length; i++)
            {
                Type type = array[i];
                var btype = type.BaseType;

                if (btype != null && btype.Equals(typeof(GameEvents)))
                {
                    GameEvents component = Assembly.GetExecutingAssembly().CreateInstance(type.ToString(), true) as GameEvents;
                    if (component != null)
                    {
                        try
                        {
                            component.ExecutePriorityPatches(); // NEEDED TO DO PATCHING EVENT
                        }
                        catch (System.Exception e)
                        {
                            ModConsole.ErrorExc(e);
                        }
                        try
                        {
                            component.OnApplicationStart();
                        }
                        catch (System.Exception e)
                        {
                            ModConsole.ErrorExc(e);
                        }
                        GameEvents.Add(component);
                    }
                }

                if (btype != null && btype.Equals(typeof(Tweaker_Events)))
                {
                    Tweaker_Events component = Assembly.GetExecutingAssembly().CreateInstance(type.ToString(), true) as Tweaker_Events;
                    Tweaker_Overridables.Add(component);
                }
            }

            stopwatch.Stop();
            ModConsole.DebugLog($"Initialized {GameEvents.Count} GameEvents: Took {stopwatch.ElapsedMilliseconds}ms");
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (!KeyManager.IsAuthed) return;
            switch (buildIndex)
            {
                case 0: // app
                case 1: // ui
                    break;

                default:
                    Event_OnSceneLoaded.SafetyRaise(new OnSceneLoadedEventArgs(buildIndex, sceneName));
                    break;
            }
        }




        protected void DoAfterUserInteractMenuInit(Action code)
        {
            if (!KeyManager.IsAuthed) return;
            _ = MelonCoroutines.Start(OnUserInteractMenuInitCoro(code));
        }

        protected void DoAfterActionMenuInit(Action code)
        {
            if (!KeyManager.IsAuthed) return;
            _ = MelonCoroutines.Start(OnActionMenuInitCoro(code));
        }

        private IEnumerator OnActionMenuInitCoro(Action code)
        {
            while (ActionMenuDriver.prop_ActionMenuDriver_0 == null)
                yield return null;

            code();
        }
        private IEnumerator OnUserInteractMenuInitCoro(Action code)
        {
            while (QuickMenuTools.GetSelectedUserQMInstance() == null)
                yield return null;

            code();
        }

        protected void DoAfterUiManagerInit(Action code)
        {
            if (!KeyManager.IsAuthed) return;
            _ = MelonCoroutines.Start(OnUiManagerInitCoro(code));
        }

        protected void DoAfterQuickMenuInit(Action code)
        {
            if (!KeyManager.IsAuthed) return;
            _ = MelonCoroutines.Start(OnQuickMenuInitCoro(code));
        }

        protected IEnumerator OnQuickMenuInitCoro(Action code)
        {
            Transform Critical1 = null;
            Transform Critical2 = null;
            Transform Critical3 = null;
            VRC.UI.Elements.QuickMenu Critical4 = null;
            bool exception = false;
            bool Instantiated = false;
            while (!Instantiated)
            {
                try
                {
                    Critical1 = QuickMenuTools.UserInterface;
                    Critical2 = QuickMenuTools.QuickMenuTransform;
                    Critical3 = QuickMenuTools.NestedMenuTemplate;
                    Critical4 = QuickMenuTools.QuickMenuInstance;
                }
                catch
                {
                    exception = true;
                }

                if (exception)
                {
                    exception = false;
                    yield return new WaitForSeconds(0.001f);
                }
                else
                {
                    if (Critical1 != null && Critical2 != null && Critical3 != null)
                    {
                        code();
                        Instantiated = true;
                        yield break;
                    }
                    else if (Critical1 == null || Critical2 == null || Critical3 == null)
                    {
                        yield return new WaitForSeconds(0.001f);
                    }
                }
            }

            yield return null;
        }

        protected IEnumerator OnUiManagerInitCoro(Action code)
        {
            while (VRCUiManager.prop_VRCUiManager_0 == null)
                yield return new WaitForSeconds(0.001f);
            //while (GameObject.Find(UIUtils.QuickMenu) == null)
            //    yield return new WaitForSeconds(0.001f);
            code();
        }

        private void Start_VRChat_OnQuickMenuInit()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (!KeyManager.IsAuthed)
            {
                stopwatch.Stop();
                return;
            }

            try
            {
                InitSetupUI();

            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }
            Event_VRChat_OnQuickMenuInit?.SafetyRaise();
                        
            DoAfterUserInteractMenuInit(() => { Start_VRChat_OnUserInteractMenuInit(); });
            stopwatch.Stop();
            ModConsole.DebugLog($"QuickMenu Init : Took {stopwatch.ElapsedMilliseconds}ms");
        }

        private void Start_VRChat_OnActionMenuInit()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (!KeyManager.IsAuthed)
            {
                stopwatch.Stop();
                return;
            }

            Event_VRChat_OnActionMenuInit?.SafetyRaise();
            stopwatch.Stop();
            ModConsole.DebugLog($"ActionMenu Init : Took {stopwatch.ElapsedMilliseconds}ms");
        }


        private void Start_VRChat_OnUserInteractMenuInit()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (!KeyManager.IsAuthed)
            {
                stopwatch.Stop();
                return;
            }

            UserInteractMenuBtns.InitUserButtons(-1, 3, true); //UserMenu Main Button
            stopwatch.Stop();
            ModConsole.DebugLog($"UserInteractMenu Init : Took {stopwatch.ElapsedMilliseconds}ms");
        }



        private void Start_VRChat_OnUiManagerInit()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            Event_VRChat_OnUiManagerInit?.SafetyRaise();

            stopwatch.Stop();
            ModConsole.DebugLog($"Start_VRChat_OnUiManagerInit: Took {stopwatch.ElapsedMilliseconds}ms");
        }


        private void InitSetupUI()
        {
            if (!KeyManager.IsAuthed)
            {
                return;
            }
            try
            {
                InitMainsButtons();
            }
            catch (Exception e)
            {
                ModConsole.ErrorExc(e);
            }


        }

        internal static void InitMainsButtons()
        {
            if (!KeyManager.IsAuthed) return;
            QMTabMenu AstroClient = new QMTabMenu(TabIndexs.Main, "AstroClient Menu", null, null, null, CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.planet.png"));
            ModConsole.DebugLog("1");
            ToggleDebugInfo = new QMSingleToggleButton(AstroClient, 4, 2.5f, "Debug Console ON", () => { Bools.IsDebugMode = true; }, "Debug Console OFF", () => { Bools.IsDebugMode = false; }, "Shows Client Details in Melonloader's console", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
            ModConsole.DebugLog("2");

            // Top Right Buttons
            CopyIDButton = new QMSingleButton(AstroClient, 5, -1, "Copy\nInstance ID", () => { Clipboard.SetText($"{WorldUtils.FullID}"); }, "Copy the ID of the current instance.", null, null, true);

            ModConsole.DebugLog("3");
            JoinInstanceButton = new QMSingleButton(AstroClient, 5, -0.5f, "Join\nInstance", () => { new PortalInternal().Method_Private_Void_String_String_PDM_0(Clipboard.GetText().Split(':')[0], Clipboard.GetText().Split(':')[1]); }, "Join an instance via your clipboard.", null, null, true);
            ModConsole.DebugLog("4");

            AvatarByIDButton = new QMSingleButton(AstroClient, 5, 0.5f, "Avatar\nBy ID", () =>
            {
                string text = Clipboard.GetText();
                if (text.StartsWith("avtr_")) new PageAvatar { field_Public_SimpleAvatarPedestal_0 = new SimpleAvatarPedestal { field_Internal_ApiAvatar_0 = new ApiAvatar { id = text } } }.ChangeToSelectedAvatar();
                else MelonLogger.Error("Clipboard does not contains Avatar ID!");
            }, "Alows you to change into a public avatar with its id.", null, null, true);

            ModConsole.DebugLog("5");
            ReloadAvatarsButton = new QMSingleButton(AstroClient, 5, 1f, "Reload\nAvatars", () => { MelonCoroutines.Start(AvatarUtils.ReloadAllAvatars()); }, "Reloads All Avatars", null, null, true);
            ModConsole.DebugLog("6");

            CloseButton = new QMSingleButton(AstroClient, 0, 0, "Close Game", () => { Process.GetCurrentProcess().Kill(); }, "Close the game");
            ModConsole.DebugLog("7");

            RestartButton = new QMSingleButton(AstroClient, 0, 1, "Restart Game", () =>
            {
                _ = Process.Start(Directory.GetParent(Application.dataPath) + "\\VRChat.exe");
                Process.GetCurrentProcess().Kill();
            }, "Restart the game");
            ModConsole.DebugLog("8");

            // Protections
            QMNestedButton protectionsButton = new QMNestedButton(AstroClient, 4, 2f, "Protections", "Protections Menu", null, UnityEngine.Color.yellow, null, null, true);
            ModConsole.DebugLog("9");

            QMSingleToggleButton toggleBlockRPC = new QMSingleToggleButton(protectionsButton, 2, 0, "RPC Block", () => { Bools.BlockRPC = true; }, "RPC Block", () => { Bools.BlockRPC = false; }, "Toggle RPC Blocking", UnityEngine.Color.green, UnityEngine.Color.red, null, Bools.BlockRPC, true);
            toggleBlockRPC.SetToggleState(Bools.BlockRPC);
            ModConsole.DebugLog("10");

            QMSingleToggleButton toggleBlockUdon = new QMSingleToggleButton(protectionsButton, 3, 0, "Udon Block", () => { Bools.BlockUdon = true; }, "Udon Block", () => { Bools.BlockUdon = false; }, "Toggle Udon Blocking", UnityEngine.Color.green, UnityEngine.Color.red, null, Bools.BlockRPC, true);
            toggleBlockUdon.SetToggleState(Bools.BlockUdon);
            ModConsole.DebugLog("11");

            QMSingleToggleButton toggleAntiPortal = new QMSingleToggleButton(protectionsButton, 4, 2.5f, "Anti Portal", () => { Bools.AntiPortal = true; }, "Anti Portal", () => { Bools.AntiPortal = false; }, "Stops you from entering portals.", UnityEngine.Color.green, UnityEngine.Color.red, null, Bools.AntiPortal, true);
            toggleAntiPortal.SetToggleState(Bools.AntiPortal);
            //ModConsole.DebugLog("12");



            //TweakerV2Main.Init_TweakerV2Main(TabIndexs.Tweaker);
            ModConsole.DebugLog("13");
            ExploitsMenu.InitButtons(TabIndexs.Exploits);
            ModConsole.DebugLog("14");
            WorldsCheats.InitButtons(TabIndexs.Cheats);
            ModConsole.DebugLog("15");
            HistoryMenu.InitButtons(TabIndexs.History);
            ModConsole.DebugLog("16");
            AdminMenu.InitButtons(TabIndexs.Admin);
            ModConsole.DebugLog("17");
            DevMenu.InitButtons(TabIndexs.Dev);
            ModConsole.DebugLog("18");

            // Misc
            SkyboxEditor.CustomSkyboxesMenu(AstroClient, 1, 0, true);
            ModConsole.DebugLog("19");

            LightControl.InitButtons(AstroClient, 1, 0.5f, true);
            ModConsole.DebugLog("20");

            GameObjectMenu.InitButtons(AstroClient, 1, 1.5f, true);
            ModConsole.DebugLog("21");

            if (Bools.IsDeveloper)
            {
                MapEditorMenu.InitButtons(AstroClient, 1, 2.5f, true);
            }
            ModConsole.DebugLog("22");

            WorldPickupsBtn.InitButtons(AstroClient, 2, 0, true);

            ModConsole.DebugLog("23");
            ComponentsBtn.InitButtons(AstroClient, 2, 0.5f, true);
            ModConsole.DebugLog("24");

            Headlight.Headlight.HeadlightButtonInit(AstroClient, 3, 0, true);
            ModConsole.DebugLog("25");

            CameraTweaker.InitQMMenu(AstroClient, 3, 0.5f, true);
            ModConsole.DebugLog("26");

            SettingsMenuBtn.InitButtons(AstroClient, 3, 2.5f, true);
            ModConsole.DebugLog("27");

            _ = new QMSingleButton("MainMenu", 5, 3.5f, "GameObject Toggler", () =>
            {
                GameObjMenu.ReturnToRoot();
                GameObjMenu.gameobjtogglermenu.GetMainButton().GetGameObject().GetComponent<Button>().onClick.Invoke();
            }, "Advanced GameObject Toggler", null, null, true);
            ModConsole.DebugLog("28");
            CheatsShortcutButton.Init_Cheats_ShortcutBtn(5, 3f, true);
            ModConsole.DebugLog("29");


        }
    }
}