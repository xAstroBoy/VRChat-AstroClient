﻿namespace AstroClient
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
    using Extensions = AstroButtonAPI.Extensions;
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

        internal static QMToggleButton ToggleDebugInfo;
        internal static QMSingleButton CopyIDButton;
        internal static QMSingleButton AvatarByIDButton;
        internal static QMSingleButton ClearVRamButton;
        internal static QMSingleButton JoinInstanceButton;
        internal static QMSingleButton ReloadAvatarsButton;

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
            while (true)
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
                    if (Critical1 != null && Critical2 != null && Critical3 != null && Critical4 != null)
                    {
                        code();
                        yield break;
                    }
                    else if (Critical1 == null || Critical2 == null || Critical3 == null || Critical4 == null)
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
            QMGridTab AstroClient = new QMGridTab(TabIndexs.Main, "AstroClient Menu", null, null, null, CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.planet.png"));
            MainClientWings.InitMainWing();
            GameProcessMenu.InitButtons(AstroClient);
            ProtectionsMenu.InitButtons(AstroClient);
            SkyboxScrollMenu.InitButtons(AstroClient);
            LightControl.InitButtons(AstroClient);
            GameObjectMenu.InitButtons(AstroClient);
            if (Bools.IsDeveloper)
            {
                MapEditorMenu.InitButtons(AstroClient);
            }

            WorldPickupsBtn.InitButtons(AstroClient);

            ComponentsBtn.InitButtons(AstroClient);

            Headlight.Headlight.HeadlightButtonInit(AstroClient, 3, 0, true);

            CameraTweaker.InitQMMenu(AstroClient);

            SettingsMenuBtn.InitButtons(AstroClient, 3, 2.5f, true);


            ToggleDebugInfo = new QMToggleButton(AstroClient, "Debug Console", () => { Bools.IsDebugMode = true; }, () => { Bools.IsDebugMode = false; }, "Shows Client Details in Melonloader's console", null, null, null, Bools.AntiPortal);
            // Top Right Buttons
            ToggleDebugInfo.SetToggleState(Bools.IsDebugMode);

            ExploitsMenu.InitButtons(TabIndexs.Exploits);
            WorldsCheats.InitButtons(TabIndexs.Cheats);
            HistoryMenu.InitButtons(TabIndexs.History);
            AdminMenu.InitButtons(TabIndexs.Admin);
            DevMenu.InitButtons(TabIndexs.Dev);

            // Misc
            TweakerV2Main.Init_TweakerV2Main(TabIndexs.Tweaker);
            ModConsole.DebugLog("Done.");

            CheatsShortcutButton.Init_Cheats_ShortcutBtn();

            //_ = new QMSingleButton("MainMenu", 5, 3.5f, "GameObject Toggler", () =>
            //{
            //    GameObjMenu.ReturnToRoot();
            //    GameObjMenu.gameobjtogglermenu.GetMainButton().GetGameObject().GetComponent<Button>().onClick.Invoke();
            //}, "Advanced GameObject Toggler", null, null, true);
            //ModConsole.DebugLog("28");
            //ModConsole.DebugLog("29");


        }
    }
}