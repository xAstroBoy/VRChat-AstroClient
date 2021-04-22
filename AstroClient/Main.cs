using MelonLoader;
using RubyButtonAPI;

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.UI;
using Console = CheetosConsole.Console;

using AstroClient.WorldLights;
using AstroClient.variables;
using AstroClient.ConsoleUtils;
using AstroClient.GameObjectDebug;
using AstroClient.Worlds;
using AstroClient.Startup.Buttons;
using AstroClient.AstroUtils.PlayerMovement;
using AstroClient.AstroUtils.ItemTweaker;
using AstroClient.Components;
using AstroClient.UdonExploits;
using AstroClient.ButtonShortcut;
using CheetosConsole;
using AstroClient.Cheetos;

namespace AstroClient
{
    public class Main : MelonMod
    {
        //public static event EventHandler Event_OnApplicationStart;

        public static event EventHandler Event_OnUpdate;

        public static event EventHandler Event_LateUpdate;

        public static event EventHandler Event_VRChat_OnUiManagerInit;

        public static event EventHandler Event_OnLevelLoaded;

        public static List<GameEvents> Overridable_List = new List<GameEvents>();

        public override void OnApplicationStart()
        {
            ConfigManager.Validate();
            ConfigManager.Load();

            KeyManager.ReadKey();

            AstroNetworkClient.Initialize();

            while (!KeyManager.IsAuthed)
            {
            }

            try
            {
                Console.WriteFigletWithGradient(FigletFont.LoadFromAssembly("Larry3D.flf"), BuildInfo.Name, System.Drawing.Color.LightBlue, System.Drawing.Color.MidnightBlue);
            }
            catch (Exception e)
            {
                ModConsole.Error("Failed To generate Gradient, the Embeded file doesn't exist!");
                ModConsole.ErrorExc(e);
            }

            InitializeOverridables();
            //Event_OnApplicationStart?.Invoke(this, new EventArgs());
        }

        public override void OnPreferencesSaved()
        {
            if (KeyManager.IsAuthed)
            {
                ConfigManager.Save();
            }
        }

        public static void InitializeOverridables()
        {
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                var btype = type.BaseType;

                if (btype != null && btype.Equals(typeof(GameEvents)))
                {
                    GameEvents component = Assembly.GetExecutingAssembly().CreateInstance(type.ToString(), true) as GameEvents;
                    component.ExecutePriorityPatches(); // NEEDED TO DO PATCHING EVENT

                    component.OnApplicationStart();
                    Overridable_List.Add(component);
                }
            }
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            switch (buildIndex)
            {
                case 0: // app
                case 1: // ui
                    break;

                default:
                    //Task.Run(() => {  });
                    Event_OnLevelLoaded?.Invoke(this, new EventArgs());
                    if (ToggleDebugInfo != null)
                    {
                        ToggleDebugInfo.setToggleState(Bools.IsDebugMode);
                    }
                    break;
            }
        }

        public override void OnUpdate()
        {
            Event_OnUpdate?.Invoke(this, new EventArgs());
        }

        public override void OnLateUpdate()
        {
            Event_LateUpdate?.Invoke(this, new EventArgs());
        }

        public override void VRChat_OnUiManagerInit()
        {
            if (KeyManager.IsAuthed == true)
            {
                QuickMenuUtils.SetQuickMenuCollider(5, 5);
                UserInteractMenuBtns.InitButtons(-1, 1, true); //UserMenu Main Button

                InitMainsButtons(5, 0, true);
                ItemTweakerMain.InitButtons(5, 0.5f, true); //ItemTweaker Main Button
                new QMSingleButton("ShortcutMenu", 5, 1f, "GameObject Toggler", new Action(() =>
                { GameObjMenu.ReturnToRoot(); GameObjMenu.gameobjtogglermenu.getMainButton().getGameObject().GetComponent<Button>().onClick.Invoke(); }
                ), "Advanced GameObject Toggler", null, null, true);
                CheatsShortcutButton.Init_Cheats_ShortcutBtn(5, 1.5f, true);

                Event_VRChat_OnUiManagerInit?.Invoke(this, new EventArgs());
            }
        }

        public static void InitMainsButtons(float x, float y, bool btnHalf)
        {
            if (KeyManager.IsAuthed == true)
            {
                //QMNestedButton AstroClient = new QMNestedButton("ShortcutMenu", x, y, "AstroClient Menu", "AstroClient Menu", null, null, null, null, btnHalf);  // Menu Main Button
                QMTabMenu AstroClient = new QMTabMenu(1f, "AstroClient Menu", null, null, null, Environment.CurrentDirectory + @"\AstroClient\Resources\planet.png");
                PlayerESPControl.PlayerESPToggleBtn = new QMSingleToggleButton(AstroClient, 4, 1f, "Player ESP ON", new Action(() => { PlayerESPControl.EnabledESP = true; }), "Player ESP OFF", new Action(() => { PlayerESPControl.EnabledESP = false; }), "Hides your avatar for yourself", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);

                ToggleDebugInfo = new QMSingleToggleButton(AstroClient, 4, 2.5f, "Debug Console ON", new Action(() => { Bools.IsDebugMode = true; }), "Debug Console OFF", new Action(() => { Bools.IsDebugMode = false; }), "Shows Client Details in Melonloader's console", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
                ToggleHideAvatar = new QMSingleToggleButton(AstroClient, 4, 1.5f, "Hide Avatar ON", new Action(() => { AvatarHider.HideAvatar = true; }), "Hide Avatar OFF", new Action(() => { AvatarHider.HideAvatar = false; }), "Hides your avatar for yourself", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);

                WorldsCheats.InitButtons(AstroClient, 1, 0, true);
                LightControl.InitButtons(AstroClient, 1, 0.5f, true);
                Movement.InitButtons(AstroClient, 1, 1, true);
                GameObjectUtils.InitButtons(AstroClient, 1, 1.5f, true);
                EmojiUtils.InitButton(AstroClient, 1, 2, true);
                LewdVRChat.InitButtons(AstroClient, 1, 2.5f, true);
                WorldPickupsBtn.InitButtons(AstroClient, 2, 0, true);
                ComponentsBtn.InitButtons(AstroClient, 2, 0.5f, true);
                RandomSubmenus.TriggerSubMenu(AstroClient, 2, 1, true);
                GlobalUdonExploits.InitButtons(AstroClient, 2, 1.5f, true);
                RandomSubmenus.VRC_InteractableSubMenu(AstroClient, 2, 2, true);
                Headlight.Headlight.HeadlightButtonInit(AstroClient, 3, 0, true);

                SettingsMenuBtn.InitButtons(AstroClient, 3, 2.5f, true);
            }
        }

        public static QMSingleToggleButton ToggleDebugInfo;
        public static QMSingleToggleButton ToggleHideAvatar;
    }
}