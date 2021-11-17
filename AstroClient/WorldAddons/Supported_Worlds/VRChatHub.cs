namespace AstroClient.WorldAddons.Supported_Worlds

{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using VRC.SDKBase;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.Utility;
    using static VRC.SDKBase.VRC_EventHandler;

    internal class VRChatHub : AstroEvents
    {
        internal static void InitButtons(QMGridTab menu)
        {
            VRChat_Hub_Addons = new QMNestedGridMenu(menu, "Hub Mods", "Control HUB World.");
            HubLock = new QMToggleButton(VRChat_Hub_Addons, 1, 0, "Hub Button Lock ON", new Action(ToggleHubButtonLock), "Hub Button Lock OFF", new Action(ToggleHubButtonLock), "Prevents other people from annoying you in the hub by fighting back!");
            _ = new QMSingleButton(VRChat_Hub_Addons, 2, 0, "Active all Hub Objects!", new Action(ToggleAllHubObjectOn), "Enable all Hub Props!");
            IgnoreSelfFight = new QMToggleButton(VRChat_Hub_Addons, 3, 0, "Ignore Self ON", new Action(ToggleIgnoreSelf), "Ignore Self OFF", new Action(ToggleIgnoreSelf), "Prevents other people from annoying you in the hub by fighting back!");
        }

        internal static QMNestedGridMenu VRChat_Hub_Addons;

        internal static void ToggleAllHubObjectOn()
        {
            Fighting_Boats_Props = true;
            Fighting_Toy_BeachBall = true;
            Fighting_RolePlayFighting_Props = true;
            Fighting_MirrorProps = true;
            Fighting_Build_Crystals_blocks = true;
            Status_Mirror_Props = VrcBooleanOp.False;
            Status_BeachBalls_Props = VrcBooleanOp.False;
            Status_Table_Props = VrcBooleanOp.False;
            Status_CrystalBlock_Props = VrcBooleanOp.False;
            Status_Boats_Props = VrcBooleanOp.False;
            Mirror_Props = VrcBooleanOp.True;
            BeachBalls_Props = VrcBooleanOp.True;
            Table_Props = VrcBooleanOp.True;
            CrystalBlock_Props = VrcBooleanOp.True;
            Boats_Props = VrcBooleanOp.True;
            Emulate_beachball_click();
            Emulate_boats_props_click();
            Emulate_building_crystals_blocks_click();
            Emulate_mirror_props_click();
            Emulate_table_roleplay_props_click();
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            Status_Mirror_Props = VrcBooleanOp.Unused;
            Status_BeachBalls_Props = VrcBooleanOp.Unused;
            Status_Table_Props = VrcBooleanOp.Unused;
            Status_CrystalBlock_Props = VrcBooleanOp.Unused;
            Status_Boats_Props = VrcBooleanOp.Unused;
            isHubWorldLoaded = false;
            HasAnalyzedHubGameObjects = false;
            Button_toggle_BeachBall = null;
            Button_toggle_MirrorProps = null;
            Button_toggle_Table_Props = null;
            Button_toggle_CrystalBlocks = null;
            Button_toggle_Boats = null;
            if (HubLock != null)
            {
                HubLock.SetToggleState(IsHubButtonLocked);
            }
            if (IgnoreSelfFight != null)
            {
                IgnoreSelfFight.SetToggleState(IgnoreSelf);
            }
        }

        internal override void OnUpdate()
        {
            if (isHubWorldLoaded)
            {
                if (!HasAnalyzedHubGameObjects)
                {
                    FindHubButtons();
                }
                if (Time.time - LastTimeCheck > 0.9f)
                {
                    Emulate_beachball_click(true);
                    Emulate_boats_props_click(true);
                    Emulate_building_crystals_blocks_click(true);
                    Emulate_mirror_props_click(true);
                    Emulate_table_roleplay_props_click(true);
                    LastTimeCheck = Time.time;
                }
            }
        }

        internal static void FindHubButtons()
        {
            if (!HasAnalyzedHubGameObjects)
            {
                if (Button_toggle_Boats == null)
                {
                    Button_toggle_Boats = GameObjectFinder.Find("_UI/UI_HotSpring_Buttons/Button_Prop_Boats");
                }

                if (Button_toggle_BeachBall == null)
                {
                    Button_toggle_BeachBall = GameObjectFinder.Find("_UI/UI_HotSpring_Buttons/Button_Prop_BeachBall");
                }

                if (Button_toggle_CrystalBlocks == null)
                {
                    Button_toggle_CrystalBlocks = GameObjectFinder.Find("_UI/UI_Crystal_Buttons/Button_CrystalBlocks");
                }

                if (Button_toggle_MirrorProps == null)
                {
                    Button_toggle_MirrorProps = GameObjectFinder.Find("_UI/UI_Mirror_Buttons/Button_Enable_Props");
                }

                if (Button_toggle_Table_Props == null)
                {
                    Button_toggle_Table_Props = GameObjectFinder.Find("_UI/UI_Mirror_Buttons/Button_Enable_Table_Props");
                }

                HasAnalyzedHubGameObjects = true;
            }
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.VRChatDefaultHub)
            {
                if (VRChat_Hub_Addons != null)
                {
                    ModConsole.Log($"Recognized {Name} World, revealing Hub Addons Submenu Button!", System.Drawing.Color.Green);
                    VRChat_Hub_Addons.GetMainButton().SetIntractable(true);
                    VRChat_Hub_Addons.GetMainButton().SetTextColor(Color.green);
                    isHubWorldLoaded = true;
                    FindHubButtons();
                }
            }
            else
            {
                if (VRChat_Hub_Addons != null)
                {
                    VRChat_Hub_Addons.GetMainButton().SetIntractable(false);
                    VRChat_Hub_Addons.GetMainButton().SetTextColor(Color.red);
                    isHubWorldLoaded = false;
                }
            }
        }

        internal static void ToggleHubButtonLock() => IsHubButtonLocked = !IsHubButtonLocked;

        internal static void ToggleIgnoreSelf() => IgnoreSelf = !IgnoreSelf;

        // TODO : REWRITE THE EMULATORS OF CLICKS.

        internal static void Emulate_beachball_click(bool isOnUpdate = false)
        {
            var item = Button_toggle_BeachBall;
            if (item != null)
            {
                if (Fighting_Toy_BeachBall)
                {
                    var One = item.GetComponentInChildren<VRC_Trigger>();
                    if (One != null)
                    {
                        if ((Status_BeachBalls_Props != BeachBalls_Props && isOnUpdate) || !isOnUpdate)
                        {
                            // BlinkColorObject(item, Color.green, //OriginalColor_Buttontoggle_BeachBall);
                            ModConsole.Log($"Clicked {item.name}");
                            One.Interact();
                        }
                    }
                    else
                    {
                        ModConsole.Warning($"{item.name} event handler is missing!");
                    }
                    Fighting_Toy_BeachBall = false;
                }
            }
        }

        internal static void Emulate_mirror_props_click(bool isOnUpdate = false)
        {
            var item = Button_toggle_MirrorProps;
            if (item != null)
            {
                if (Fighting_MirrorProps)
                {
                    var One = item.GetComponentInChildren<VRC_Trigger>();
                    if (One != null)
                    {
                        if ((Status_Mirror_Props != Mirror_Props && isOnUpdate) || !isOnUpdate)
                        {
                            ModConsole.Log($"Clicked {item.name}");
                            // BlinkColorObject(item, Color.green, //OriginalColor_Buttontoggle_MirrorProps);
                            One.Interact();
                        }
                    }
                    else
                    {
                        ModConsole.Warning($"{item.name} event handler is missing!");
                    }
                    Fighting_MirrorProps = false;
                }
            }
        }

        internal static void Emulate_table_roleplay_props_click(bool isOnUpdate = false)
        {
            var item = Button_toggle_Table_Props;
            if (item != null)
            {
                if (Fighting_RolePlayFighting_Props)
                {
                    var One = item.GetComponentInChildren<VRC_Trigger>();
                    if (One != null)
                    {
                        if ((Status_Table_Props != Table_Props && isOnUpdate) || !isOnUpdate)
                        {
                            ModConsole.Log($"Clicked {item.name}");
                            // BlinkColorObject(item, Color.green, //OriginalColor_Buttontoggle_Table_Props);
                            One.Interact();
                        }
                    }
                    else
                    {
                        ModConsole.Warning($"{item.name} event handler is missing!");
                    }
                    Fighting_RolePlayFighting_Props = false;
                }
            }
        }

        internal static void Emulate_building_crystals_blocks_click(bool isOnUpdate = false)
        {
            var item = Button_toggle_CrystalBlocks;
            if (item != null && Fighting_Build_Crystals_blocks)
            {
                var One = item.GetComponentInChildren<VRC_Trigger>();
                if (One != null)
                {
                    if ((Status_CrystalBlock_Props != CrystalBlock_Props && isOnUpdate) || !isOnUpdate)
                    {
                        ModConsole.Log($"Clicked {item.name}");
                        // BlinkColorObject(item, Color.green, //OriginalColor_Buttontoggle_CrystalBlocks);
                        One.Interact();
                    }
                }
                else
                {
                    ModConsole.Warning($"{item.name} event handler is missing!");
                }
                Fighting_Build_Crystals_blocks = false;
            }
        }

        internal static void Emulate_boats_props_click(bool isOnUpdate = false)
        {
            var item = Button_toggle_Boats;
            if (item != null && Fighting_Boats_Props)
            {
                var One = item.GetComponentInChildren<VRC_Trigger>();
                if (One != null)
                {
                    if ((Status_Boats_Props != Boats_Props && isOnUpdate) || !isOnUpdate)
                    {
                        ModConsole.Log($"Clicked {item.name}");
                        // BlinkColorObject(item, Color.green, //OriginalColor_Buttontoggle_Boats);
                        One.Interact();
                    }
                }
                else
                {
                    ModConsole.Warning($"{item.name} event handler is missing!");
                }
                Fighting_Boats_Props = false;
            }
        }

        internal static bool ConvertVrcBool(VrcBooleanOp Value)
        {
            switch (Value)
            {
                case VrcBooleanOp.True:
                    return true;

                case VrcBooleanOp.False:
                    return false;

                default:
                    return false;
            }
        }

        internal override void VRC_EventDispatcherRFC_triggerEvent(VRC_EventHandler EventHandler, VrcEvent VrcEvent, VrcBroadcastType VrcBroadcastType, int value, float floatvalue)
        {
            if (isHubWorldLoaded)
            {
                HubObjectPatcher(EventHandler, VrcEvent);
                UpdateVariablesHub(EventHandler, VrcEvent);
            }
        }

        internal static void HubObjectPatcher(VRC_EventHandler EventHandler, VrcEvent VrcEvent)
        {
            if (EventHandler != null && VrcEvent != null)
            {
                if ((EventHandler.ToString() != PlayerUtils.DisplayName()) || IgnoreSelf)
                {
                    if (IsHubButtonLocked)
                    {
                        if (VrcEvent.ParameterObject.name == "_RolePlay_Props" && VrcEvent.ParameterBoolOp != Table_Props)
                        {
                            ModConsole.Warning(EventHandler.ToString() + $" has tried to {(ConvertVrcBool(VrcEvent.ParameterBoolOp) ? "show" : "hide")} the roleplay props!");
                            Status_Table_Props = VrcEvent.ParameterBoolOp;
                            Fighting_RolePlayFighting_Props = true;
                        }
                        if (VrcEvent.ParameterObject.name == "_MirrorProps" && VrcEvent.ParameterBoolOp != Mirror_Props)
                        {
                            ModConsole.Warning(EventHandler.ToString() + $" has tried to {(ConvertVrcBool(VrcEvent.ParameterBoolOp) ? "show" : "hide")} the mirror props!");
                            // BlinkColorObject(Button_toggle_MirrorProps, Color.red, //OriginalColor_Buttontoggle_MirrorProps);
                            Status_Mirror_Props = VrcEvent.ParameterBoolOp;
                            Fighting_MirrorProps = true;
                        }
                        if (VrcEvent.ParameterObject.name == "TOY_BeachBall" && VrcEvent.ParameterBoolOp != BeachBalls_Props)
                        {
                            ModConsole.Warning(EventHandler.ToString() + $" has tried to {(ConvertVrcBool(VrcEvent.ParameterBoolOp) ? "show" : "hide")} the beachballs props!");
                            // BlinkColorObject(Button_toggle_BeachBall, Color.red, //OriginalColor_Buttontoggle_BeachBall);
                            Status_BeachBalls_Props = VrcEvent.ParameterBoolOp;
                            Fighting_Toy_BeachBall = true;
                        }
                        if (VrcEvent.ParameterObject.name == "_Build_Props" && VrcEvent.ParameterBoolOp != CrystalBlock_Props)
                        {
                            ModConsole.Warning(EventHandler.ToString() + $" has tried to {(ConvertVrcBool(VrcEvent.ParameterBoolOp) ? "show" : "hide")} the Crystals Block props!");
                            // BlinkColorObject(Button_toggle_CrystalBlocks, Color.red, //OriginalColor_Buttontoggle_CrystalBlocks);
                            Status_CrystalBlock_Props = VrcEvent.ParameterBoolOp;
                            Fighting_Build_Crystals_blocks = true;
                        }

                        if (VrcEvent.ParameterObject.name == "_BOATS" && VrcEvent.ParameterBoolOp != Boats_Props)
                        {
                            ModConsole.Warning(EventHandler.ToString() + $" has tried to {(ConvertVrcBool(VrcEvent.ParameterBoolOp) ? "show" : "hide")} the boats props!");
                            Status_Boats_Props = VrcEvent.ParameterBoolOp;
                            Fighting_Boats_Props = true;
                        }
                    }
                }
            }
        }

        internal static void UpdateVariablesHub(VRC_EventHandler EventHandler, VrcEvent VrcEvent)
        {
            if (EventHandler != null && VrcEvent != null && EventHandler.ToString() == PlayerUtils.DisplayName())
            {
                if (VrcEvent.ParameterObject.name == "_RolePlay_Props")
                {
                    if (!Fighting_RolePlayFighting_Props)
                    {
                        Table_Props = VrcEvent.ParameterBoolOp;
                        Status_Table_Props = VrcEvent.ParameterBoolOp;
                        // BlinkColorObject(Button_toggle_Table_Props, Color.green, //OriginalColor_Buttontoggle_Table_Props);
                    }
                }
                if (VrcEvent.ParameterObject.name == "_MirrorProps")
                {
                    if (!Fighting_MirrorProps)
                    {
                        Mirror_Props = VrcEvent.ParameterBoolOp;
                        Status_Mirror_Props = VrcEvent.ParameterBoolOp;
                        // BlinkColorObject(Button_toggle_MirrorProps, Color.green, //OriginalColor_Buttontoggle_MirrorProps);
                    }
                }
                if (VrcEvent.ParameterObject.name == "TOY_BeachBall")
                {
                    if (!Fighting_Toy_BeachBall)
                    {
                        BeachBalls_Props = VrcEvent.ParameterBoolOp;
                        Status_BeachBalls_Props = VrcEvent.ParameterBoolOp;
                        // BlinkColorObject(Button_toggle_BeachBall, Color.green, //OriginalColor_Buttontoggle_BeachBall);
                    }
                }
                if (VrcEvent.ParameterObject.name == "_Build_Props")
                {
                    if (!Fighting_Build_Crystals_blocks)
                    {
                        CrystalBlock_Props = VrcEvent.ParameterBoolOp;
                        Status_CrystalBlock_Props = VrcEvent.ParameterBoolOp;
                        // BlinkColorObject(Button_toggle_CrystalBlocks, Color.green, //OriginalColor_Buttontoggle_CrystalBlocks);
                    }
                }
                if (VrcEvent.ParameterObject.name == "_BOATS")
                {
                    if (!Fighting_Boats_Props)
                    {
                        Boats_Props = VrcEvent.ParameterBoolOp;
                        Status_Boats_Props = VrcEvent.ParameterBoolOp;
                        // BlinkColorObject(Button_toggle_Boats, Color.green, //OriginalColor_Buttontoggle_Boats);
                    }
                }
            }
        }

        internal static bool IsHubButtonLocked = true;
        internal static QMToggleButton HubLock;
        internal static QMToggleButton IgnoreSelfFight;

        internal static VrcBooleanOp Mirror_Props = VrcBooleanOp.True;
        internal static VrcBooleanOp BeachBalls_Props = VrcBooleanOp.True;
        internal static VrcBooleanOp Table_Props = VrcBooleanOp.True;
        internal static VrcBooleanOp CrystalBlock_Props = VrcBooleanOp.True;
        internal static VrcBooleanOp Boats_Props = VrcBooleanOp.True;

        internal static VrcBooleanOp Status_Mirror_Props = VrcBooleanOp.Unused;
        internal static VrcBooleanOp Status_BeachBalls_Props = VrcBooleanOp.Unused;
        internal static VrcBooleanOp Status_Table_Props = VrcBooleanOp.Unused;
        internal static VrcBooleanOp Status_CrystalBlock_Props = VrcBooleanOp.Unused;
        internal static VrcBooleanOp Status_Boats_Props = VrcBooleanOp.Unused;

        internal static bool Fighting_MirrorProps;
        internal static bool Fighting_Toy_BeachBall;
        internal static bool Fighting_RolePlayFighting_Props;
        internal static bool Fighting_Build_Crystals_blocks;
        internal static bool Fighting_Boats_Props;

        internal static GameObject Button_toggle_BeachBall; // Button_Prop_BeachBall
        internal static GameObject Button_toggle_MirrorProps; // Button_Enable_Props
        internal static GameObject Button_toggle_Table_Props; // Button_Enable_Table_Props
        internal static GameObject Button_toggle_CrystalBlocks; // Button_CrystalBlocks
        internal static GameObject Button_toggle_Boats; // Button_Prop_Boats

        internal static bool HasAnalyzedHubGameObjects;
        internal static bool isHubWorldLoaded;

        internal static bool IgnoreSelf;
        internal static float LastTimeCheck = 0;
    }
}