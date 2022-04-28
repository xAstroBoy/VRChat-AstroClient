using AstroClient.ClientActions;
using AstroClient.xAstroBoy.Utility;
using Cheetah;

namespace AstroClient
{
    #region Imports

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
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



        public override void OnApplicationStart()
        {
            MelonCoroutines.Start(InitializeClient());
        }

        private IEnumerator InitializeClient()
        {
            //LogSupport.RemoveAllHandlers(); // Fuck ML ugly console.

            // New Cheetah Console/Log Stuff
            WriteBanner();
            ConfigManager.Validate();
            ConfigManager.Load();
            Log.Level = ConfigManager.General.DebugLog == true ? LogLevel.DEBUG : LogLevel.INFO;
            WindowsUtils.ShowConsole(true);
            WindowsUtils.Initialize(); // Tell the console to support Windows Anniversary Update colors
            ConsoleUtils.SetColor(ConsoleUtils.ColorType.FOREGROUND, Cheetah.Color.White);
            Log.Write("Initializing...");

            //ModConsole.Initialize("AstroClient");
            //if (ModConsole.DebugMode != ConfigManager.General.DebugLog)
            //{
            //    ModConsole.DebugMode = ConfigManager.General.DebugLog;
            //}


            Bools.IsDeveloper = true;
            MelonCoroutines.Start(InitializeOverridables());
            DoAfterUiManagerInit(() => { Start_VRChat_OnUiManagerInit(); });
            Delay_DoAfterUiManagerInit(() => { Delayed_Start_VRChat_OnUiManagerInit(); });

            DoAfterQuickMenuInit(() => { Start_VRChat_OnQuickMenuInit(); });
            DoAfterActionMenuInit(() => { Start_VRChat_OnActionMenuInit(); });
            ClientEventActions.OnApplicationStart?.SafetyRaise();

            Log.Write("Initialization complete!", Cheetah.Color.Green);
            yield return null;
        }

        public override void OnUpdate()
        {
            ClientEventActions.OnUpdate?.SafetyRaise();
        }

        //public override void OnLateUpdate()
        //{
        //    ClientEventActions.LateUpdate?.SafetyRaise();
        //}

        private IEnumerator WaitForActionMenuInit()
        {
            while (ActionMenuDriver.prop_ActionMenuDriver_0 == null) //VRCUIManager Init is too early
                yield return null;
        }

        //public override void OnGUI()
        //{
        //    ClientEventActions.OnGui?.SafetyRaiseWithParams();
        //}

        public override void OnApplicationLateStart()
        {
            ClientEventActions.OnApplicationLateStart?.SafetyRaise();
        }

        public override void OnApplicationQuit()
        {
            ClientEventActions.OnApplicationQuit?.SafetyRaise();
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
                Console.WriteFigletWithGradient(Figlets.Larry3D, BuildInfo.Name, System.Drawing.Color.SkyBlue, System.Drawing.Color.MidnightBlue);
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
                        if (ConfigManager.General.PreloadClientResources)
                        {
                            try
                            {
                                component.StartPreloadResources(); // NEEDED TO DO PATCHING EVENT
                            }
                            catch (System.Exception e)
                            {
                                Log.Exception(e);
                            }
                        }
                        try
                        {
                            component.RegisterToEvents(); // Register classes to all events to init.
                        }
                        catch (System.Exception e)
                        {
                            Log.Exception(e);
                        }
                        //GameEvents.Add(component);
                    }
                }

            }

            stopwatch.Stop();
            //Log.Debug($"Initialized {GameEvents.Count} GameEvents: Took {stopwatch.ElapsedMilliseconds}ms");
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
                    ClientEventActions.OnSceneLoaded.SafetyRaiseWithParams(buildIndex, sceneName);
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
        protected void Delay_DoAfterUiManagerInit(Action code)
        {
            _ = MelonCoroutines.Start(DelayOnUiManagerInitCoro(code));
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
            code();
        }
        protected IEnumerator DelayOnUiManagerInitCoro(Action code)
        {
            while (VRCUiManager.prop_VRCUiManager_0 == null)
                yield return new WaitForSeconds(0.001f);
            MiscUtils.DelayFunction(10f, () =>
            {
                code();
            });
        }

        private void Start_VRChat_OnQuickMenuInit()
        {
            var sw = Stopwatch.StartNew();
            ClientEventActions.VRChat_OnQuickMenuInit?.SafetyRaise();
            DoAfterUserInteractMenuInit(() => { Start_VRChat_OnUserInteractMenuInit(); });
            sw.Stop(); Log.Debug($"QuickMenu Init : Took {sw.ElapsedMilliseconds}ms");
        }

        private void Start_VRChat_OnActionMenuInit()
        {
            var sw = Stopwatch.StartNew();
            ClientEventActions.VRChat_OnActionMenuInit?.SafetyRaise();
            sw.Stop(); Log.Debug($"ActionMenu Init : Took {sw.ElapsedMilliseconds}ms");
        }

        private void Start_VRChat_OnUserInteractMenuInit()
        {
            var sw = Stopwatch.StartNew();
            UserInteractMenuBtns.InitUserButtons(); //UserMenu Main Button
            sw.Stop(); Log.Debug($"UserInteractMenu Init : Took {sw.ElapsedMilliseconds}ms");
        }

        private void Delayed_Start_VRChat_OnUiManagerInit()
        {
            var sw = Stopwatch.StartNew();
            ClientEventActions.Delayed_VRChat_OnUiManagerInit?.SafetyRaise();
            sw.Stop(); Log.Debug($"Start_VRChat_OnUiManagerInit: Took {sw.ElapsedMilliseconds}ms");
        }
        private void Start_VRChat_OnUiManagerInit()
        {
            var sw = Stopwatch.StartNew();
            ClientEventActions.VRChat_OnUiManagerInit?.SafetyRaise();
            sw.Stop(); Log.Debug($"Start_VRChat_OnUiManagerInit: Took {sw.ElapsedMilliseconds}ms");
        }

    }
}