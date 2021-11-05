namespace AstroClient.ClientUI.ActionMenuButtons.AvatarParametersModule.Menu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using AstroActionMenu.Api;
    using AstroLibrary.Console;
    using AstroMonos.Components.Tools.Listeners;
    using CheetoLibrary;
    using MelonLoader;
    using UnityEngine;
    using VRC;
    using VRC.Playables;
    using VRC.SDK3.Avatars.ScriptableObjects;
    using VRC.SDKBase;
    using Color = System.Drawing.Color;

    internal class AvatarParametersEditorMod : GameEvents
    {
        internal static Dictionary<string, GameObject> s_PlayerList;
        internal static Dictionary<string, RefCountedObject<Texture2D>> s_Portraits;
        internal override void OnApplicationStart()
        {
            /* Hook into setter for parameter properties */
            unsafe
            {
                var param_prop_bool_set = (IntPtr)typeof(AvatarParameter)
                    .GetField("NativeMethodInfoPtr_Method_Public_set_Void_Boolean_0",
                        BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
                MelonUtils.NativeHookAttach(param_prop_bool_set,
                    new Action<IntPtr, bool>(Parameters.BoolPropertySetter).Method.MethodHandle.GetFunctionPointer());
                Parameters._boolPropertySetterDelegate =
                    Marshal.GetDelegateForFunctionPointer<Parameters.BoolPropertySetterDelegate>(
                        *(IntPtr*)(void*)param_prop_bool_set);

                var param_prop_int_set = (IntPtr)typeof(AvatarParameter)
                    .GetField("NativeMethodInfoPtr_Method_Public_set_Void_Int32_0",
                        BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
                MelonUtils.NativeHookAttach(param_prop_int_set,
                    new Action<IntPtr, int>(Parameters.IntPropertySetter).Method.MethodHandle.GetFunctionPointer());
                Parameters._intPropertySetterDelegate =
                    Marshal.GetDelegateForFunctionPointer<Parameters.IntPropertySetterDelegate>(
                        *(IntPtr*)(void*)param_prop_int_set);

                var param_prop_float_set = (IntPtr)typeof(AvatarParameter)
                    .GetField("NativeMethodInfoPtr_Method_Public_set_Void_Single_0",
                        BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
                MelonUtils.NativeHookAttach(param_prop_float_set,
                    new Action<IntPtr, float>(Parameters.FloatPropertySetter).Method.MethodHandle.GetFunctionPointer());
                Parameters._floatPropertySetterDelegate =
                    Marshal.GetDelegateForFunctionPointer<Parameters.FloatPropertySetterDelegate>(
                        *(IntPtr*)(void*)param_prop_float_set);
            }

            AMUtils.AddToModsFolder("Avatar Toggles", () =>
            {
                /* Filter inactive avatar objects */
                s_PlayerList = s_PlayerList.Where(o => o.Value).ToDictionary(o => o.Key, o => o.Value);

                /* Order by physical distance to camera */
                var query = from player in s_PlayerList
                    orderby Vector3.Distance(player.Value.transform.position, Camera.main.transform.position)
                    select player;

                /* Only allow a max of 10 players there at once */
                /* TODO: Consider adding multiple pages */
                var remaining_count = 10;

                foreach (var entry in query)
                {
                    var manager = entry.Value.GetComponentInParent<VRCAvatarManager>();

                    /* Ignore SDK2 & avatars w/o custom expressions */
                    if (!manager.HasCustomExpressions())
                        continue;

                    var avatar_id = entry.Value.GetComponent<VRC.Core.PipelineManager>().blueprintId;
                    var user_icon = s_Portraits[avatar_id].Get();

                    /* Source default expression icon */
                    var menu_icons = ActionMenuDriver.prop_ActionMenuDriver_0.field_Public_MenuIcons_0;
                    var default_expression = menu_icons.defaultExpression;

                    CustomSubMenu.AddSubMenu(entry.Key, () =>
                    {
                        if (entry.Value == null || !entry.Value.active)
                            return;

                        var parameters = manager.GetAllAvatarParameters();
                        var filtered = Parameters.FilterDefaultParameters(parameters);
                        var avatar_descriptor = manager.prop_VRCAvatarDescriptor_0;

                        CustomSubMenu.AddToggle("Lock", filtered.Any(Parameters.IsLocked),
                            (state) => { filtered.ForEach(state ? Parameters.Lock : Parameters.Unlock); },
                        CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(),
                                "AstroClient.Resources.locked.png")));
                        CustomSubMenu.AddButton("Save", () => Parameters.StoreParameters(manager),
                            CheetoUtils.LoadPNG(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(),
                                "AstroClient.Resources.save.png")));

                        AvatarParameter FindParameter(string name)
                        {
                            foreach (var parameter in parameters)
                                if (parameter.field_Private_String_0 == name)
                                    return parameter;
                            return null;
                        }

                        void ExpressionSubmenu(VRCExpressionsMenu expressions_menu)
                        {
                            if (entry.Value == null || !entry.Value.active)
                                return;

                            void FourAxisControl(VRCExpressionsMenu.Control control, Action<Vector2> callback)
                            {
                                CustomSubMenu.AddFourAxisPuppet(
                                    control.TruncatedName(),
                                    callback,
                                    control.icon ?? default_expression,
                                    topButtonText: control.labels[0]?.TruncatedName() ?? "Up",
                                    rightButtonText: control.labels[1]?.TruncatedName() ?? "Right",
                                    downButtonText: control.labels[2]?.TruncatedName() ?? "Down",
                                    leftButtonText: control.labels[3]?.TruncatedName() ?? "Left");
                            }

                            foreach (var control in expressions_menu.controls)
                                try
                                {
                                    switch (control.type)
                                    {
                                        case VRCExpressionsMenu.Control.ControlType.Button:
                                        /* Note: Action Menu "Buttons" are actually Toggles */
                                        /*       that set on press and revert on release.   */
                                        /* TODO: Add proper implementation.                 */
                                        case VRCExpressionsMenu.Control.ControlType.Toggle:
                                        {
                                            var param = FindParameter(control.parameter.name);
                                            var current_value = param.GetValue();
                                            var default_value = avatar_descriptor.expressionParameters
                                                .FindParameter(control.parameter.name)?.defaultValue ?? 0f;
                                            var target_value = control.value;

                                            void SetIntFloat(bool state)
                                            {
                                                param.SetValue(state ? target_value : default_value);
                                            }

                                            void SetBool(bool state)
                                            {
                                                param.SetValue(state ? 1f : 0f);
                                            }

                                            CustomSubMenu.AddToggle(
                                                control.TruncatedName(),
                                                current_value == target_value,
                                                param.prop_EnumNPublicSealedvaUnBoInFl5vUnique_0 ==
                                                AvatarParameter.EnumNPublicSealedvaUnBoInFl5vUnique.Bool
                                                    ? SetBool
                                                    : SetIntFloat,
                                                control.icon ?? default_expression);
                                            break;
                                        }

                                        case VRCExpressionsMenu.Control.ControlType.SubMenu:
                                        {
                                            CustomSubMenu.AddSubMenu(control.TruncatedName(),
                                                () => ExpressionSubmenu(control.subMenu),
                                                control.icon ?? default_expression);
                                            break;
                                        }

                                        case VRCExpressionsMenu.Control.ControlType.TwoAxisPuppet:
                                        {
                                            var horizontal = FindParameter(control.subParameters[0]?.name);
                                            var vertical = FindParameter(control.subParameters[1]?.name);
                                            FourAxisControl(control, (value) =>
                                            {
                                                horizontal.SetFloatProperty(value.x);
                                                vertical.SetFloatProperty(value.y);
                                            });
                                            break;
                                        }

                                        case VRCExpressionsMenu.Control.ControlType.FourAxisPuppet:
                                        {
                                            var up = FindParameter(control.subParameters[0]?.name);
                                            var down = FindParameter(control.subParameters[1]?.name);
                                            var left = FindParameter(control.subParameters[2]?.name);
                                            var right = FindParameter(control.subParameters[3]?.name);
                                            FourAxisControl(control, (value) =>
                                            {
                                                up.SetFloatProperty(Math.Max(0, value.y));
                                                down.SetFloatProperty(-Math.Min(0, value.y));
                                                left.SetFloatProperty(Math.Max(0, value.x));
                                                right.SetFloatProperty(-Math.Min(0, value.x));
                                            });
                                            break;
                                        }

                                        case VRCExpressionsMenu.Control.ControlType.RadialPuppet:
                                        {
                                            var param = FindParameter(control.subParameters[0]?.name);
                                            CustomSubMenu.AddRestrictedRadialPuppet(control.TruncatedName(),
                                                param.SetValue, param.GetValue(), control.icon ?? default_expression);
                                            break;
                                        }
                                    }
                                }
                                catch (Exception e)
                                {
                                    ModConsole.ErrorExc(e);
                                }
                        }

                        ExpressionSubmenu(avatar_descriptor.expressionsMenu);
                    }, user_icon);

                    if (--remaining_count == 0)
                        break;
                }
            });

            ModConsole.Log("Avatar Parameters Editor is ready!", Color.Green);
        }

        internal override void OnRoomJoined()
        {
            s_PlayerList = new Dictionary<string, GameObject>();
            s_Portraits = new Dictionary<string, RefCountedObject<Texture2D>>();
        }

        internal override void OnRoomLeft()
        {
            s_PlayerList = null;
            s_Portraits = null;
        }


        private GameObject PreviewCaptureCamera => ParametersEditorResources.AstroPreviewCamera;

        internal override void OnAvatarSpawn(Player player, GameObject Avatar, VRCAvatarManager VRCAvatarManager,
            VRC_AvatarDescriptor descriptor)
        {
            var player_name = Avatar.transform.root.GetComponentInChildren<VRCPlayer>().prop_String_0;
            s_PlayerList[player_name] = Avatar;
            Parameters.ApplyParameters(VRCAvatarManager);
            var avatar_id = Avatar.GetComponent<VRC.Core.PipelineManager>().blueprintId;
            var destroy_listener = Avatar.AddComponent<GameObjectListener>();
            var parameters = VRCAvatarManager.GetAvatarParameters().ToArray();
            destroy_listener.OnDestroyed += () =>
            {
                /* Unlock expression parameters */
                foreach (var parameter in parameters) parameter.Unlock();

                /* Decrement ref count on avatar portrait */
                if (s_Portraits.ContainsKey(avatar_id))
                    if (s_Portraits[avatar_id].Decrement())
                        s_Portraits.Remove(avatar_id);
            };

            /* Take preview image for action menu */
            /* Note: in this state, everyone should be t-posing and your own head is still there */
            if (VRCAvatarManager.HasCustomExpressions())
            {
                if (s_Portraits.ContainsKey(avatar_id))
                {
                    s_Portraits[avatar_id].Increment();
                }
                else
                {
                    /* Enable camera */
                    PreviewCaptureCamera.SetActive(true);

                    /* Move camera infront of head */
                    var head_height = descriptor.ViewPosition.y;
                    var head = Avatar.transform.position + new Vector3(0, head_height, 0);
                    var target = head + Avatar.transform.forward * 0.3f;
                    var camera = PreviewCaptureCamera.GetComponent<Camera>();
                    camera.transform.position = target;
                    camera.transform.LookAt(head);
                    camera.cullingMask = 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("PlayerLocal");
                    camera.orthographicSize = head_height / 8;
                    var image = camera.ToTexture2D($"AstroPortrait {avatar_id}");
                    image.hideFlags = HideFlags.DontUnloadUnusedAsset;

                    /* Store image */
                    s_Portraits.Add(avatar_id, new RefCountedObject<Texture2D>(image));

                    /* Disable camera again */
                    PreviewCaptureCamera.SetActive(false);
                }
            }
        }
    }
}