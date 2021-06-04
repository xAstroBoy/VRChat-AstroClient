namespace AstroClient.World.Hub

{
	using AstroClient.Variables;
	using AstroLibrary.Console;
	using AstroLibrary.Finder;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using UnityEngine;
	using VRC.SDKBase;
	using static AstroClient.LocalPlayerUtils;
	using static VRC.SDKBase.VRC_EventHandler;

	public class VRChatHub : GameEvents
    {
        public static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            VRChat_Hub_Addons = new QMNestedButton(menu, x, y, "Hub Mods", "Control HUB World.", null, null, null, null, btnHalf);
            VRChat_Hub_Addons.GetMainButton().SetResizeTextForBestFit(true);
            HubLock = new QMToggleButton(VRChat_Hub_Addons, 1, 0, "Hub Button Lock ON", new Action(ToggleHubButtonLock), "Hub Button Lock OFF", new Action(ToggleHubButtonLock), "Prevents other people from annoying you in the hub by fighting back!", null, null, null, btnHalf);
            new QMSingleButton(VRChat_Hub_Addons, 2, 0, "Active all Hub Objects!", new Action(ToggleAllHubObjectOn), "Enable all Hub Props!", null, null);
            IgnoreSelfFight = new QMToggleButton(VRChat_Hub_Addons, 3, 0, "Ignore Self ON", new Action(ToggleIgnoreSelf), "Ignore Self OFF", new Action(ToggleIgnoreSelf), "Prevents other people from annoying you in the hub by fighting back!", null, null, null, false);
        }

        public static QMNestedButton VRChat_Hub_Addons;

        public static void ToggleAllHubObjectOn()
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

        public override void OnLevelLoaded()
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

        public override void OnUpdate()
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

        public static void FindHubButtons()
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

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            if (id == WorldIds.VRChatDefaultHub)
            {
                isHubWorldLoaded = true;
                FindHubButtons();
            }
            else
            {
                isHubWorldLoaded = false;
            }
        }

        public static void ToggleHubButtonLock()
        {
            IsHubButtonLocked = !IsHubButtonLocked;
        }

        public static void ToggleIgnoreSelf()
        {
            IgnoreSelf = !IgnoreSelf;
        }

        // TODO : REWRITE THE EMULATORS OF CLICKS.

        public static void Emulate_beachball_click(bool isOnUpdate = false)
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
                            ModConsole.Log("Clicked " + item.name);
                            One.Interact();
                        }
                    }
                    else
                    {
                        ModConsole.Warning(item.name + " event handler is missing!");
                    }
                    Fighting_Toy_BeachBall = false;
                }
            }
        }

        public static void Emulate_mirror_props_click(bool isOnUpdate = false)
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
                            ModConsole.Log("Clicked " + item.name);
                            // BlinkColorObject(item, Color.green, //OriginalColor_Buttontoggle_MirrorProps);
                            One.Interact();
                        }
                    }
                    else
                    {
                        ModConsole.Warning(item.name + " event handler is missing!");
                    }
                    Fighting_MirrorProps = false;
                }
            }
        }

        public static void Emulate_table_roleplay_props_click(bool isOnUpdate = false)
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
                            ModConsole.Log("Clicked " + item.name);
                            // BlinkColorObject(item, Color.green, //OriginalColor_Buttontoggle_Table_Props);
                            One.Interact();
                        }
                    }
                    else
                    {
                        ModConsole.Warning(item.name + " event handler is missing!");
                    }
                    Fighting_RolePlayFighting_Props = false;
                }
            }
        }

        public static void Emulate_building_crystals_blocks_click(bool isOnUpdate = false)
        {
            var item = Button_toggle_CrystalBlocks;
            if (item != null)
            {
                if (Fighting_Build_Crystals_blocks)
                {
                    var One = item.GetComponentInChildren<VRC_Trigger>();
                    if (One != null)
                    {
                        if ((Status_CrystalBlock_Props != CrystalBlock_Props && isOnUpdate) || !isOnUpdate)
                        {
                            ModConsole.Log("Clicked " + item.name);
                            // BlinkColorObject(item, Color.green, //OriginalColor_Buttontoggle_CrystalBlocks);
                            One.Interact();
                        }
                    }
                    else
                    {
                        ModConsole.Warning(item.name + " event handler is missing!");
                    }
                    Fighting_Build_Crystals_blocks = false;
                }
            }
        }

        public static void Emulate_boats_props_click(bool isOnUpdate = false)
        {
            var item = Button_toggle_Boats;
            if (item != null)
            {
                if (Fighting_Boats_Props)
                {
                    var One = item.GetComponentInChildren<VRC_Trigger>();
                    if (One != null)
                    {
                        if ((Status_Boats_Props != Boats_Props && isOnUpdate) || !isOnUpdate)
                        {
                            ModConsole.Log("Clicked " + item.name);
                            // BlinkColorObject(item, Color.green, //OriginalColor_Buttontoggle_Boats);
                            One.Interact();
                        }
                    }
                    else
                    {
                        ModConsole.Warning(item.name + " event handler is missing!");
                    }
                    Fighting_Boats_Props = false;
                }
            }
        }

        public static bool ConvertVrcBool(VrcBooleanOp Value)
        {
            return Value switch
            {
                VrcBooleanOp.True => true,
                VrcBooleanOp.False => false,
                _ => false,
            };
        }

        public override void VRC_EventDispatcherRFC_triggerEvent(VRC_EventHandler EventHandler, VrcEvent VrcEvent, VrcBroadcastType VrcBroadcastType, int value, float floatvalue)
        {
            HubObjectPatcher(EventHandler, VrcEvent);
            UpdateVariablesHub(EventHandler, VrcEvent);
        }

        public static void HubObjectPatcher(VRC_EventHandler EventHandler, VrcEvent VrcEvent)
        {
            if (EventHandler != null && VrcEvent != null)
            {
                if ((EventHandler.ToString() != GetSelfVRCPlayerApi().displayName && EventHandler.ToString() != variables.Strings.AstroClientAuthor) || IgnoreSelf)
                {
                    if (IsHubButtonLocked)
                    {
                        if (VrcEvent.ParameterObject.name == "_RolePlay_Props")
                        {
                            if (VrcEvent.ParameterBoolOp != Table_Props)
                            {
                                ModConsole.Warning(EventHandler.ToString() + $" has tried to {(ConvertVrcBool(VrcEvent.ParameterBoolOp) ? "show" : "hide")} the roleplay props!");
                                // BlinkColorObject(Button_toggle_Table_Props, Color.red, //OriginalColor_Buttontoggle_Table_Props);
                                Status_Table_Props = VrcEvent.ParameterBoolOp;
                                Fighting_RolePlayFighting_Props = true;
                            }
                        }
                        if (VrcEvent.ParameterObject.name == "_MirrorProps")
                        {
                            if (VrcEvent.ParameterBoolOp != Mirror_Props)
                            {
                                ModConsole.Warning(EventHandler.ToString() + $" has tried to {(ConvertVrcBool(VrcEvent.ParameterBoolOp) ? "show" : "hide")} the mirror props!");
                                // BlinkColorObject(Button_toggle_MirrorProps, Color.red, //OriginalColor_Buttontoggle_MirrorProps);
                                Status_Mirror_Props = VrcEvent.ParameterBoolOp;
                                Fighting_MirrorProps = true;
                            }
                        }
                        if (VrcEvent.ParameterObject.name == "TOY_BeachBall")
                        {
                            if (VrcEvent.ParameterBoolOp != BeachBalls_Props)
                            {
                                ModConsole.Warning(EventHandler.ToString() + $" has tried to {(ConvertVrcBool(VrcEvent.ParameterBoolOp) ? "show" : "hide")} the beachballs props!");
                                // BlinkColorObject(Button_toggle_BeachBall, Color.red, //OriginalColor_Buttontoggle_BeachBall);
                                Status_BeachBalls_Props = VrcEvent.ParameterBoolOp;
                                Fighting_Toy_BeachBall = true;
                            }
                        }
                        if (VrcEvent.ParameterObject.name == "_Build_Props")
                        {
                            if (VrcEvent.ParameterBoolOp != CrystalBlock_Props)
                            {
                                ModConsole.Warning(EventHandler.ToString() + $" has tried to {(ConvertVrcBool(VrcEvent.ParameterBoolOp) ? "show" : "hide")} the Crystals Block props!");
                                // BlinkColorObject(Button_toggle_CrystalBlocks, Color.red, //OriginalColor_Buttontoggle_CrystalBlocks);
                                Status_CrystalBlock_Props = VrcEvent.ParameterBoolOp;
                                Fighting_Build_Crystals_blocks = true;
                            }
                        }

                        if (VrcEvent.ParameterObject.name == "_BOATS")
                        {
                            if (VrcEvent.ParameterBoolOp != Boats_Props)
                            {
                                ModConsole.Warning(EventHandler.ToString() + $" has tried to {(ConvertVrcBool(VrcEvent.ParameterBoolOp) ? "show" : "hide")} the boats props!");
                                // BlinkColorObject(Button_toggle_Boats, Color.red, //OriginalColor_Buttontoggle_BeachBall);
                                Status_Boats_Props = VrcEvent.ParameterBoolOp;
                                Fighting_Boats_Props = true;
                            }
                        }
                    }
                }
            }
        }

        public static void UpdateVariablesHub(VRC_EventHandler EventHandler, VrcEvent VrcEvent)
        {
            if (EventHandler != null && VrcEvent != null)
            {
                if (EventHandler.ToString() == GetSelfVRCPlayerApi().displayName)
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
        }

        public static bool IsHubButtonLocked = true;
        public static QMToggleButton HubLock;
        public static QMToggleButton IgnoreSelfFight;

        public static VrcBooleanOp Mirror_Props = VrcBooleanOp.True;
        public static VrcBooleanOp BeachBalls_Props = VrcBooleanOp.True;
        public static VrcBooleanOp Table_Props = VrcBooleanOp.True;
        public static VrcBooleanOp CrystalBlock_Props = VrcBooleanOp.True;
        public static VrcBooleanOp Boats_Props = VrcBooleanOp.True;

        public static VrcBooleanOp Status_Mirror_Props = VrcBooleanOp.Unused;
        public static VrcBooleanOp Status_BeachBalls_Props = VrcBooleanOp.Unused;
        public static VrcBooleanOp Status_Table_Props = VrcBooleanOp.Unused;
        public static VrcBooleanOp Status_CrystalBlock_Props = VrcBooleanOp.Unused;
        public static VrcBooleanOp Status_Boats_Props = VrcBooleanOp.Unused;

        public static bool Fighting_MirrorProps;
        public static bool Fighting_Toy_BeachBall;
        public static bool Fighting_RolePlayFighting_Props;
        public static bool Fighting_Build_Crystals_blocks;
        public static bool Fighting_Boats_Props;

        public static GameObject Button_toggle_BeachBall; // Button_Prop_BeachBall
        public static GameObject Button_toggle_MirrorProps; // Button_Enable_Props
        public static GameObject Button_toggle_Table_Props; // Button_Enable_Table_Props
        public static GameObject Button_toggle_CrystalBlocks; // Button_CrystalBlocks
        public static GameObject Button_toggle_Boats; // Button_Prop_Boats

        public static bool HasAnalyzedHubGameObjects;
        public static bool isHubWorldLoaded;

        public static bool IgnoreSelf;
        public static float LastTimeCheck = 0;
    }
}