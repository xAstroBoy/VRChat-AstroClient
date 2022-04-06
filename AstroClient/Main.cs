namespace AstroClient
{
    #region Imports

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using AstroEventArgs;
    using Cheetah;
    using CheetosConsole;
    using ClientResources.Loaders;
    using ClientUI.Menu.ItemTweakerV2.Selector;
    using ClientUI.Menu.Menus;
    using ClientUI.Menu.Menus.UserMenu;
    using Config;
    using Constants;
    using MelonLoader;
    using Tools.Extensions;
    using UnhollowerBaseLib;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using Color = System.Drawing.Color;
    using Console = CheetosConsole.Console;

    #endregion Imports

    public class Main : MelonMod
    {
        #region EventHandlers

        internal static event Action Event_OnApplicationLateStart;

        internal static event Action Event_OnUpdate;

        internal static event Action Event_LateUpdate;

        //internal static event Action Event_OnGui;

        internal static event Action Event_VRChat_OnUiManagerInit;

        internal static event Action Event_VRChat_OnQuickMenuInit;

        internal static event Action Event_VRChat_OnActionMenuInit;

        internal static event Action<int,string> Event_OnSceneLoaded;

        internal static event Action Event_OnApplicationQuit;

        #endregion EventHandlers

        private static List<AstroEvents> GameEvents { get; set; } = new List<AstroEvents>();

        private static List<Tweaker_Events> Tweaker_Overridables { get; set; } = new List<Tweaker_Events>();

        public override void OnApplicationStart()
        {
            MelonCoroutines.Start(InitializeClient());
        }

        private IEnumerator InitializeClient()
        {
            LogSupport.RemoveAllHandlers(); // Fuck ML ugly console.

            // New Cheetah Console/Log Stuff
            Log.Level = ConfigManager.General.DebugLog == true ? LogLevel.DEBUG : LogLevel.INFO;
            WindowsUtils.ShowConsole(true);
            WindowsUtils.Initialize(); // Tell the console to support Windows Anniversary Update colors
            ConsoleUtils.SetColor(ConsoleUtils.ColorType.FOREGROUND, Cheetah.Color.White);
            Log.Write("Initializing...");

            //ModConsole.Initialize("AstroClient");
            //WriteBanner();
            ConfigManager.Validate();
            ConfigManager.Load();
            //if (ModConsole.DebugMode != ConfigManager.General.DebugLog)
            //{
            //    ModConsole.DebugMode = ConfigManager.General.DebugLog;
            //}

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Bools.IsDeveloper = true;
            MelonCoroutines.Start(InitializeOverridables());
            DoAfterUiManagerInit(() => { Start_VRChat_OnUiManagerInit(); });
            DoAfterQuickMenuInit(() => { Start_VRChat_OnQuickMenuInit(); });
            DoAfterActionMenuInit(() => { Start_VRChat_OnActionMenuInit(); });

            Log.Write("Initialization complete!", Cheetah.Color.Green);
            yield return null;
        }

        public override void OnUpdate()
        {
            Event_OnUpdate?.SafetyRaise();
        }

        public override void OnLateUpdate()
        {
            Event_LateUpdate?.SafetyRaise();
        }

        private IEnumerator WaitForActionMenuInit()
        {
            while (ActionMenuDriver.prop_ActionMenuDriver_0 == null) //VRCUIManager Init is too early
                yield return null;
        }

        //public override void OnGUI()
        //{
        //    Event_OnGui?.SafetyRaise();
        //}

        public override void OnApplicationLateStart()
        {
            Event_OnApplicationLateStart?.SafetyRaise();
        }

        public override void OnApplicationQuit()
        {
            Event_OnApplicationQuit?.SafetyRaise();
            ConfigManager.SaveAll();
        }

        public override void OnPreferencesSaved()
        {
            ConfigManager.SaveAll();
        }

        /// <summary>
        /// Maybe move this later?
        /// </summary>
        internal static void WriteBanner()
        {
            try
            {
                Console.WriteFigletWithGradient(Figlets.Larry3D, BuildInfo.Name, Color.LightBlue, Color.MidnightBlue);
            }
            catch (Exception e)
            {
                Log.Error("Failed To generate Gradient, the Embeded file doesn't exist!");
                Log.Exception(e);
            }
        }

        private IEnumerator InitializeOverridables()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Type[] array = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < array.Length; i++)
            {
                Type type = array[i];
                var btype = type.BaseType;

                if (btype != null && btype.Equals(typeof(AstroEvents)))
                {
                    AstroEvents component = Assembly.GetExecutingAssembly().CreateInstance(type.ToString(), true) as AstroEvents;
                    if (component != null)
                    {
                        try
                        {
                            component.ExecutePriorityPatches(); // NEEDED TO DO PATCHING EVENT
                        }
                        catch (System.Exception e)
                        {
                            Log.Exception(e);
                        }

                        try
                        {
                            component.StartPreloadResources(); // NEEDED TO PRELOAD RESOURCES BEFORE CLIENT INITIATES
                        }
                        catch (System.Exception e)
                        {
                            Log.Exception(e);
                        }

                        try
                        {
                            component.OnApplicationStart();
                        }
                        catch (System.Exception e)
                        {
                            Log.Exception(e);
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
            Log.Debug($"Initialized {GameEvents.Count} GameEvents: Took {stopwatch.ElapsedMilliseconds}ms");
            yield return null;
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            switch (buildIndex)
            {
                case 0: // app
                case 1: // ui
                    break;

                default:
                    Event_OnSceneLoaded.SafetyRaise(buildIndex, sceneName);
                    break;
            }
        }

        protected void DoAfterUserInteractMenuInit(Action code)
        {
            _ = MelonCoroutines.Start(OnUserInteractMenuInitCoro(code));
        }

        protected void DoAfterActionMenuInit(Action code)
        {
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
            while (QuickMenuTools.SelectedUserMenuQM == null)
                yield return null;

            code();
        }

        protected void DoAfterUiManagerInit(Action code)
        {
            _ = MelonCoroutines.Start(OnUiManagerInitCoro(code));
        }

        protected void DoAfterQuickMenuInit(Action code)
        {
            _ = MelonCoroutines.Start(OnQuickMenuInitCoro(code));
        }
        private IEnumerator OnQuickMenuInitCoro(Action code)
        {
            while (QuickMenuTools.QuickMenuInstance == null)
                yield return null;

            code();
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
            var sw = Stopwatch.StartNew();
            Event_VRChat_OnQuickMenuInit?.SafetyRaise();
            DoAfterUserInteractMenuInit(() => { Start_VRChat_OnUserInteractMenuInit(); });
            sw.Stop(); Log.Debug($"QuickMenu Init : Took {sw.ElapsedMilliseconds}ms");
        }

        private void Start_VRChat_OnActionMenuInit()
        {
            var sw = Stopwatch.StartNew();
            Event_VRChat_OnActionMenuInit?.SafetyRaise();
            sw.Stop(); Log.Debug($"ActionMenu Init : Took {sw.ElapsedMilliseconds}ms");
        }

        private void Start_VRChat_OnUserInteractMenuInit()
        {
            var sw = Stopwatch.StartNew();
            UserInteractMenuBtns.InitUserButtons(); //UserMenu Main Button
            sw.Stop(); Log.Debug($"UserInteractMenu Init : Took {sw.ElapsedMilliseconds}ms");
        }

        private void Start_VRChat_OnUiManagerInit()
        {
            var sw = Stopwatch.StartNew();
            Event_VRChat_OnUiManagerInit?.SafetyRaise();
            sw.Stop(); Log.Debug($"Start_VRChat_OnUiManagerInit: Took {sw.ElapsedMilliseconds}ms");
        }

    }
}