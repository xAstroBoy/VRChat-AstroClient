using Harmony;
using MelonLoader;
using RubyButtonAPI;
using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine;
using VRC;
using UnityEngine.UI;
using Console = Colorful.Console;
using Color = System.Drawing.Color;
using AstroClient.components;

#region AstroClient Imports

using VRC_EventHandler = VRC.SDKBase.VRC_EventHandler;
using AstroClient.WorldLights;
using AstroClient.variables;
using AstroClient.ConsoleUtils;
using AstroClient.GameObjectDebug;
using AstroClient.World.Hub;
using AstroClient.Worlds;
using AstroClient.Startup.Buttons;
using AstroClient.AstroUtils.PlayerMovement;
using AstroClient.AstroUtils.ItemTweaker;
using AstroClient.Components;
using AstroClient.Startup;
using AstroClient.Cloner;
using AstroClient.extensions;
using AstroClient.Finder;
using AstroClient.Variables;
using AstroClient.BetterPatch;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Win32;
using System.Linq;
using AstroClient.UdonExploits;
using AstroClient.ButtonShortcut;
using Colorful;
#endregion AstroClient Imports

namespace AstroClient
{
    public static class BuildInfo
    {
        public const string Name = "AstroClient"; // Name of the Mod.  (MUST BE SET)
        public const string Author = "xAstroBoy"; // Author of the Mod.  (Set as null if none)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    [Serializable]
    public class Main : MelonMod
    {


        // Thanks Kirai <3
        // LETS TEST

        public static void GradientThing()
        {
            FigletFont font = FigletFont.LoadFromAssembly("Larry3D.flf");
            Figlet Logo = new Figlet(font);
            Console.WriteWithGradient(Logo.ToAscii(BuildInfo.Name).ToString(), System.Drawing.Color.LightBlue, System.Drawing.Color.MidnightBlue, 16);
        }





        public override void OnApplicationStart()
        {
            ModConsole.OnApplicationStart();
            try
            {
                Console.ReplaceAllColorsWithDefaults();
                GradientThing();
                Console.ReplaceAllColorsWithDefaults();
            }
            catch(Exception e)
            {
                ModConsole.Error("Failed To generate Gradient, the Embeded file doesn't exist!");
            }
            ComponentHelper.RegisterComponents();
            HookFadeTo();
            HookSpawnEmojiRPC();
            MelonCoroutines.Start(HookNetworkManager());
            HookTriggerEvent();
            HookAvatarManager();

            //ItemTweakerMain.InitActionMenu();
        }

        public IEnumerator HookNetworkManager()
        {
            while (ReferenceEquals(NetworkManager.field_Internal_Static_NetworkManager_0, null)) yield return null;
            while (ReferenceEquals(VRCAudioManager.field_Private_Static_VRCAudioManager_0, null)) yield return null;
            while (ReferenceEquals(VRCUiManager.prop_VRCUiManager_0, null)) yield return null;

            NetworkManagerHooks.Initialize();
            NetworkManagerHooks.OnJoin += OnPlayerJoined;
            NetworkManagerHooks.OnLeave += OnPlayerLeft;
        }

        private void HookAvatarManager()
        {
            Harmony.Patch(typeof(VRCAvatarManager).GetMethod("Awake", BindingFlags.Instance | BindingFlags.Public), null, new HarmonyMethod(typeof(Main).GetMethod("OnVRCAMAwake", BindingFlags.Static | BindingFlags.NonPublic)));
            ModConsole.Log("Hooked VRCAvatarManager");
        }

        private static void OnVRCAMAwake(VRCAvatarManager __instance)
        {
            VRCAvatarManager.MulticastDelegateNPublicSealedVoGaVRBoUnique multicastDelegateNPublicSealedVoGaVRBoUnique = (System.Action<GameObject, VRC.SDKBase.VRC_AvatarDescriptor, bool>)OnAvatarSpawn;
            VRCAvatarManager.MulticastDelegateNPublicSealedVoGaVRBoUnique field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_ = __instance.field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_0;
            VRCAvatarManager.MulticastDelegateNPublicSealedVoGaVRBoUnique field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_2 = __instance.field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_1;
            field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_ = ((field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_ == null) ? multicastDelegateNPublicSealedVoGaVRBoUnique : Il2CppSystem.Delegate.Combine(field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_, multicastDelegateNPublicSealedVoGaVRBoUnique).Cast<VRCAvatarManager.MulticastDelegateNPublicSealedVoGaVRBoUnique>());
            field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_2 = ((field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_2 == null) ? multicastDelegateNPublicSealedVoGaVRBoUnique : Il2CppSystem.Delegate.Combine(field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_2, multicastDelegateNPublicSealedVoGaVRBoUnique).Cast<VRCAvatarManager.MulticastDelegateNPublicSealedVoGaVRBoUnique>());
            __instance.field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_0 = field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_;
            __instance.field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_1 = field_Internal_MulticastDelegateNPublicSealedVoGaVRBoUnique_2;
        }

        private static void OnAvatarSpawn(GameObject avatar, VRC.SDKBase.VRC_AvatarDescriptor DescriptorObj, bool state)
        {
            if (avatar != null && DescriptorObj != null)
            {
                GameObjHelper.CheckTransform(avatar.transform);

                if (GameObjHelper._GameObjects == null)
                {
                    return;
                }

                if (GameObjHelper._GameObjects.Count < 2)
                {
                    return;
                }

                if (!Bools.DisableNSFWMenu)
                {
                    LewdVRChat.AvatarLoaded(avatar.transform, avatar.transform.root.GetComponentInChildren<Player>());
                }
            }
        }

        private void HookTriggerEvent()
        {
            ModConsole.Log("Hooking TriggerEvent");
            var xrefs = XrefScanner.XrefScan(typeof(VRC_EventDispatcherRFC).GetMethod(nameof(VRC_EventDispatcherRFC.TriggerEvent)));
            foreach (var x in xrefs)
            {
                if (x.Type == XrefType.Method && x.TryResolve() != null && x.TryResolve().DeclaringType == typeof(VRC_EventDispatcherRFC))
                {
                    var methodToPatch = (MethodInfo)x.TryResolve();
                    Harmony.Patch(methodToPatch, new HarmonyMethod(typeof(Main).GetMethod("TriggerEventHook", BindingFlags.Public | BindingFlags.Static)));
                    break;
                }
            }
        }

        public static bool TriggerEventHook(VRC_EventHandler __0, VRC_EventHandler.VrcEvent __1, VRC_EventHandler.VrcBroadcastType __2, int __3, float __4)
        {
            try
            {
                HubButtonsControl.TriggerEventHook(__0, __1, __2, __3, __4);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }




        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            Console.ReplaceAllColorsWithDefaults();

            switch (buildIndex)
            {
                case 0: // app
                case 1: // ui
                    break;

                default:
                    MelonCoroutines.Start(OnLevelLoadEvents());
                    break;
            }
        }


        public void OnPlayerJoined(Player player)
        {
            LewdVRChat.OnPlayerJoined(player);
            JarRoleController.OnPlayerJoined(player);
            // DEMO


        }




        public void OnPlayerLeft(Player player)
        {
            ObjectMiscOptions.OnPlayerLeft(player);
            LewdVRChat.OnPlayerLeft(player);
            SingleTagsUtils.onPlayerLeft(player);
        }


        public override void OnUpdate()
        {
            LocalPlayerUtils.OnUpdate();
            EmojiUtils.OnUpdate();
            LewdVRChat.OnUpdate();
            QuickMenuUtils.OnUpdate();
            ComponentHelper.OnUpdate();
            ColliderDisplay.OnUpdate();
            EmojiUtils.OnUpdate();
            Movement.OnUpdate();
            HubButtonsControl.OnUpdate();



            // RANDOM SHIT
            VRChatObjects.OnUpdate();

        }

        public override void OnLateUpdate()
        {
            if (!Bools.DisableNSFWMenu)
            {
                LewdVRChat.OnLateUpdate();
            }

        }


        //private static bool DoOnce = false;
        public static void Test()
        {
            //if (!DoOnce)
            //{
            //    ModConsole.Log("Checking if you are protected...");
            //    try
            //    {
            //        HarmonyInstance.UnpatchAllInstances();
            //    }
            //    catch(Exception e)
            //    {
            //        if(e.Message == "You tried fam, but this is protected")
            //        {
            //            ModConsole.Log("Protected, Failed to unpatch Harmony Patches.");
                        
            //        }
            //        ModConsole.LogExc(e);
            //        return;
            //    }
            //    ModConsole.Log("You aren't protected...");
            //}
        }
        private static IEnumerator OnWorldReveal()
        {
            ObjectMiscOptions.OnWorldReveal();
            LewdVRChat.OnWorldReveal();
            Movement.OnWorldReveal();
            QVPensUtils.OnWorldReveal();
            WorldUtils.OnWorldReveal();
            Murder2Cheats.OnWorldReveal();
            Murder4Cheats.OnWorldReveal();
            AmongUSCheats.OnWorldReveal();
            JarRoleController.OnWorldReveal();
            HubButtonsControl.OnWorldReveal();
            WorldUnlocker.OnWorldReveal();
            WorldAddons.OnWorldReveal();
            CheatsShortcutButton.OnWorldReveal();
            yield break;
        }

        private static IEnumerator OnLevelLoadEvents()
        {
            Test();
            SingleTagsUtils.OnLevelLoad();
            ItemTweakerMain.OnLevelLoad();
            ObjectCloner.OnLevelLoad();
            HandsUtils.OnLevelLoad();
            ModConsole.OnLevelLoad();
            CrazyObjectManager.OnLevelLoad();
            ItemInflaterManager.OnLevelLoad();
            ObjectSpinnerManager.OnLevelLoad();
            AmongUSUdonExploits.OnLevelLoad();
            OrbitManager.OnLevelLoad();
            PlayerWatcherManager.OnLevelLoad();
            PlayerAttackerManager.OnLevelLoad();
            RocketManager.OnLevelLoad();
            GameObjectESP.OnLevelLoad();
            ScaleEditor.OnLevelLoad();
            ObjectMiscOptions.OnLevelLoad();
            LightControl.OnLevelLoad();
            LewdVRChat.OnLevelLoad();
            ColliderDisplay.OnLevelLoad();
            EmojiUtils.OnLevelLoad();
            GameObjectUtils.OnLevelLoad();
            LocalPlayerUtils.OnLevelLoad();
            QVPensUtils.OnLevelLoad();
            WorldUtils.OnLevelLoad();
            CustomLists.OnLevelLoad();
            GlobalLists.OnLevelLoad();
            Murder2Cheats.OnLevelLoad();
            Murder4Cheats.OnLevelLoad();
            HubButtonsControl.OnLevelLoad();
            WorldAddons.OnLevelLoad();
            JarRoleController.OnLevelLoad();
            GameObjMenu.OnLevelLoad();
            Headlight.Headlight.OnLevelLoad();
            yield break;
        }

        private IEnumerator Init()
        {
            Patching.InitPatch();
            yield break;
        }

        public override void VRChat_OnUiManagerInit()
        {
            QuickMenuUtils.SetQuickMenuCollider(5, 5);
            MelonCoroutines.Start(Init());
            UserInteractMenuBtns.InitButtons(-1, 1, true); //UserMenu Main Button

            InitMainsButtons(5, 0, true);
            ItemTweakerMain.InitButtons(5, 0.5f, true); //ItemTweaker Main Button
            new QMSingleButton("ShortcutMenu", 5, 1f, "GameObject Toggler", new Action(() => 
            { GameObjMenu.ReturnToRoot(); GameObjMenu.gameobjtogglermenu.getMainButton().getGameObject().GetComponent<Button>().onClick.Invoke(); }
            ), "Advanced GameObject Toggler", null, null, true);
            CheatsShortcutButton.Init_Cheats_ShortcutBtn(5, 1.5f, true);


        }





        public static void InitMainsButtons(float x, float y, bool btnHalf)
        {
            QMNestedButton AstroClient = new QMNestedButton("ShortcutMenu", x, y, "AstroClient Menu", "AstroClient Menu", null, null, null, null, btnHalf);  // Menu Main Button
            ConsoleUtils.ModConsole.ToggleDebugInfo = new QMToggleButton(AstroClient, 4, 2, "Debug Console ON", new Action(ConsoleUtils.ModConsole.ToggleConsole), "Debug Console OFF", new Action(ConsoleUtils.ModConsole.ToggleConsole), "Shows Client Details in Melonloader's console", null, null, null, false);
            WorldAddons.InitButtons(AstroClient, 1, 0, true);
            LightControl.InitButtons(AstroClient, 1, 0.5f, true);
            Movement.InitButtons(AstroClient, 1, 1, true);
            GameObjectUtils.InitButtons(AstroClient, 1, 1.5f, true);
            EmojiUtils.InitButton(AstroClient, 1, 2, true);
            LewdVRChat.InitButtons(AstroClient, 1, 2.5f, true);
            WorldPickupsBtn.InitButtons(AstroClient, 2, 0, true);
            ComponentsBtn.InitButtons(AstroClient, 2, 0.5f, true);
            TriggerSubMenu(AstroClient, 2, 1, true);
            GlobalUdonExploits.InitButtons(AstroClient, 2, 1.5f, true);
            VRC_InteractableSubMenu(AstroClient, 2, 2, true);
            Headlight.Headlight.HeadlightButtonInit(AstroClient, 3, 0, true);
        }

        public static void TriggerSubMenu(QMNestedButton main, float x, float y, bool btnHalf)
        {
            var menu = new QMNestedButton(main, x, y, "Interact Triggers", "Interact with Level Triggers", null, null, null, null, btnHalf);
            var scroll = new QMScroll(menu);
            new QMSingleButton(menu, 0, -1, "Refresh", delegate
            {
                scroll.Refresh();
            }, "", null, null, true);
            scroll.SetAction(delegate
            {
                foreach (var trigger in WorldUtils.GetAllWorldTriggers())
                {
                    scroll.Add(
                    new QMSingleButton(scroll.BaseMenu, 0, 0, $"Click {trigger.name}", delegate
                    {
                        trigger.TriggerClick();
                    }, $"Click {trigger.name}", null, ItemTweakerMain.GetObjectStatus(trigger)));
                }
            });
        }

        public static void VRC_InteractableSubMenu(QMNestedButton main, float x, float y, bool btnHalf)
        {
            var menu = new QMNestedButton(main, x, y, "Interact VRC_Interactable", "Interact with VRC_Interactable Triggers", null, null, null, null, btnHalf);
            var scroll = new QMScroll(menu);
            new QMSingleButton(menu, 0, -1, "Refresh", delegate
            {
                scroll.Refresh();
            }, "", null, null, true);
            scroll.SetAction(delegate
            {
                foreach (var obj in WorldUtils.GetAllVRCInteractables())
                {
                    scroll.Add(
                    new QMSingleButton(scroll.BaseMenu, 0, 0, $"Click {obj.name}", delegate
                    {
                        obj.VRC_Interactable_Click();
                    }, $"Click {obj.name}", null, ItemTweakerMain.GetObjectStatus(obj)));
                }
            });
        }


        private static void OnFadeToEvent()
        {
            ModConsole.Log("You entered this world : " + WorldUtils.GetWorldName(), System.Drawing.Color.Goldenrod);
            ModConsole.Log("World ID : " + WorldUtils.GetWorldID(), System.Drawing.Color.Goldenrod);
            ModConsole.Log("World Asset URL : " + WorldUtils.GetWorldAssetURL(), System.Drawing.Color.Goldenrod);
            MelonCoroutines.Start(OnWorldReveal());
        }

        #region Hooks

        private void HookSpawnEmojiRPC()
        {
            unsafe
            {
                try
                {
                    ModConsole.Log("Hooking SpawnEmojiRPC");
                    var originalMethod = *(IntPtr*)(IntPtr)UnhollowerUtils
                        .GetIl2CppMethodInfoPointerFieldForGeneratedMethod(
                            typeof(VRCPlayer).GetMethod(
                                nameof(VRCPlayer
                                    .SpawnEmojiRPC))).GetValue(null);
                    MelonUtils.NativeHookAttach((IntPtr)(&originalMethod), typeof(Main).GetMethod(nameof(SpawnEmojiRPCPatch), BindingFlags.Static | BindingFlags.NonPublic).MethodHandle.GetFunctionPointer());
                    _SpawnEmojiRPCDelegate = Marshal.GetDelegateForFunctionPointer<SpawnEmojiRPCDelegate>(originalMethod);
                    if (_SpawnEmojiRPCDelegate != null)
                    {
                        ModConsole.Log("Hooked SpawnEmojiRPC");
                    }
                    else
                    {
                        ModConsole.Error("Failed to hook SpawnEmojiRPC!");
                    }
                }
                catch(Exception e)
                {
                    ModConsole.Error("Failed to hook SpawnEmojiRPC!, ERROR : "  + e);

                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SpawnEmojiRPCDelegate(IntPtr thisPtr, int emoji, IntPtr PlayerPtr);

        private static SpawnEmojiRPCDelegate _SpawnEmojiRPCDelegate;

        private static void SpawnEmojiRPCPatch(IntPtr thisPtr, int emoji, IntPtr PlayerPtr)
        {
            try
            {
                if (thisPtr != IntPtr.Zero && PlayerPtr != IntPtr.Zero)
                {
                    var player = new VRCPlayer(thisPtr);

                    if (player != null)
                    {
                        EmojiUtils.SpawnEmojiRPCHook(player, emoji);
                    }
                }
            }
            catch (Exception e)
            {
                ModConsole.Error(e.Message);
            }
            finally
            {
                _SpawnEmojiRPCDelegate(thisPtr, emoji, PlayerPtr);
            }
        }

        private void HookFadeTo()
        {
            unsafe
            {
                ModConsole.Log("Hooking FadeTo");
                var originalMethod = *(IntPtr*)(IntPtr)UnhollowerUtils
                    .GetIl2CppMethodInfoPointerFieldForGeneratedMethod(
                        typeof(VRCUiManager).GetMethod(
                            nameof(VRCUiManager
                                .Method_Public_Void_String_Single_Action_0))).GetValue(null);
                MelonUtils.NativeHookAttach((IntPtr)(&originalMethod), typeof(Main).GetMethod(nameof(FadeToPatch), BindingFlags.Static | BindingFlags.NonPublic).MethodHandle.GetFunctionPointer());
                _fadeToDelegate = Marshal.GetDelegateForFunctionPointer<FadeToDelegate>(originalMethod);
                if (_fadeToDelegate != null)
                {
                    ModConsole.Log("Hooked OnFadeTo");
                }
                else
                {
                    ModConsole.Error("Failed to hook OnFadeTo!");
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void FadeToDelegate(IntPtr thisPtr, IntPtr fadeTypePtr, float duration, IntPtr action);

        private static FadeToDelegate _fadeToDelegate;

        private static void FadeToPatch(IntPtr thisPtr, IntPtr fadeTypePtr, float duration, IntPtr action)
        {
            try
            {
                if (thisPtr != IntPtr.Zero && fadeTypePtr != IntPtr.Zero)
                {
                    string fadeType = IL2CPP.Il2CppStringToManaged(fadeTypePtr);
                    //ModConsole.Log("FadeType Called : " + fadeType + " With duration : " + duration, ConsoleColor.Yellow);
                    if (fadeType.Equals("BlackFade") && duration.Equals(0f) &&
                        RoomManager.field_Internal_Static_ApiWorldInstance_0 != null)
                    {
                        OnFadeToEvent();
                    }
                }
            } 
            catch (Exception e)
            {
                ModConsole.Error(e.Message);
            }
            finally
            {
                _fadeToDelegate(thisPtr, fadeTypePtr, duration, action);
            }
        }

        #endregion Hooks
    }
}