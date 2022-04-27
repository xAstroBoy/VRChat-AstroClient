using AstroClient.ClientActions;

namespace AstroClient.Startup.Patches
{
    #region Imports

    using System;
    using System.Reflection;
    
    using Cheetos;
    using HarmonyLib;
    using Tools.Extensions;
    using Tools.Input;
    using UnityEngine.Events;

    #endregion Imports

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class InputPatches : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnRoomJoined += OnRoomJoined;
            ClientEventActions.Event_OnRoomLeft += OnRoomLeft;

        }

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(InputPatches).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            InitPatch();
        }

        private static bool EnableListener = false;
        private void OnRoomJoined()
        {
            EnableListener = true;
        }

        private void OnRoomLeft()
        {
            EnableListener = false;
        }

        private void InitPatch()
        {

            //new AstroPatch(typeof(VRCInput).GetMethod(nameof(VRCInput.Method_Public_Boolean_0)), null, GetPatch(nameof(MovementListener)));
            //new AstroPatch(typeof(VRCInput).GetMethod(nameof(VRCInput.Method_Public_Boolean_1)), null, GetPatch(nameof(MovementListener)));
            //new AstroPatch(typeof(VRCInput).GetMethod(nameof(VRCInput.Method_Public_Boolean_2)), null, GetPatch(nameof(MovementListener)));
            //new AstroPatch(typeof(VRCInput).GetMethod(nameof(VRCInput.Method_Public_Boolean_3)), null, GetPatch(nameof(MovementListener)));
            //new AstroPatch(typeof(VRCInput).GetMethod(nameof(VRCInput.Method_Private_Boolean_0)), null, GetPatch(nameof(MovementListener)));
            //new AstroPatch(typeof(VRCInput).GetMethod(nameof(VRCInput.Method_Private_Boolean_1)), null, GetPatch(nameof(MovementListener)));
            new AstroPatch(AccessTools.Property(typeof(VRCInput), nameof(VRCInput.prop_Boolean_0)).GetMethod, null, GetPatch(nameof(MovementListener)));
            //new AstroPatch(AccessTools.Property(typeof(VRCInput), nameof(VRCInput.prop_Boolean_1)).GetMethod, null, GetPatch(nameof(MovementListener)));
            //new AstroPatch(AccessTools.Property(typeof(VRCInput), nameof(VRCInput.prop_Boolean_2)).GetMethod, null, GetPatch(nameof(MovementListener)));
            //new AstroPatch(AccessTools.Property(typeof(VRCInput), nameof(VRCInput.prop_Boolean_3)).GetMethod, null, GetPatch(nameof(MovementListener)));
            //new AstroPatch(AccessTools.Property(typeof(VRCInput), nameof(VRCInput.prop_Boolean_4)).GetMethod, null, GetPatch(nameof(MovementListener)));

            //new AstroPatch(typeof(VRCInput).GetMethod(nameof(VRCInput.Method_Public_Void_Single_0)), null, GetPatch(nameof(InputListener_two)));

        }

        private static void MovementListener(VRCInput __instance)
        {
            if (!EnableListener) return;
            if (__instance == null)
            {
                return;
            }

            EnableListener = false;
            switch (__instance.Name())
            {
                case InputTypes.Jump:
                    {
                        ClientEventActions.Event_OnInput_Jump.SafetyRaiseWithParams(__instance.isClicked(), __instance.isDown(), __instance.isUp());
                        EnableListener = true;
                        break;
                    }
                case InputTypes.UseLeft:
                    {
                        ClientEventActions.Event_OnInput_UseLeft.SafetyRaiseWithParams(__instance.isClicked(), __instance.isDown(), __instance.isUp());
                        EnableListener = true;
                        break;
                    }

                case InputTypes.UseRight:
                    {
                        ClientEventActions.Event_OnInput_UseRight.SafetyRaiseWithParams(__instance.isClicked(), __instance.isDown(), __instance.isUp());
                        EnableListener = true;
                        break;
                    }

                case InputTypes.GrabLeft:
                    {
                        ClientEventActions.Event_OnInput_GrabLeft.SafetyRaiseWithParams(__instance.isClicked(), __instance.isDown(), __instance.isUp());
                        EnableListener = true;
                        break;
                    }

                case InputTypes.GrabRight:
                    {
                        ClientEventActions.Event_OnInput_GrabRight.SafetyRaiseWithParams(__instance.isClicked(), __instance.isDown(), __instance.isUp());
                        EnableListener = true;
                        break;
                    }

                default:
                    EnableListener = true;
                    break;
            }

        }

        private static void InputListener_two(VRCInput __instance, float __0)
        {
            try
            {
                if (__instance != null)
                {
                    if (__instance.Name().Equals("UseRight"))
                    {
                        ConvertToString(__instance);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Log.Exception(ex);
            }
        }

        private static void ConvertToString(VRCInput input)
        {
            if (isDumping) return;
            if (input != null)
            {
                if (!isDumping)
                {
                    isDumping = true;
                }
                Console.Clear();
                Log.Debug($"Input Name : {input.Name()}");

                Log.Debug($"field_Private_Boolean_0 {input.field_Private_Boolean_0.ToString()}");
                Log.Debug($"field_Private_Boolean_1 {input.field_Private_Boolean_1.ToString()}");
                Log.Debug($"prop_Boolean_0 {input.prop_Boolean_0.ToString()}");
                Log.Debug($"prop_Boolean_1 {input.prop_Boolean_1.ToString()}");
                Log.Debug($"prop_Boolean_2 {input.prop_Boolean_2.ToString()}");
                Log.Debug($"prop_Boolean_3 {input.prop_Boolean_3.ToString()}");
                Log.Debug($"prop_Boolean_4 {input.prop_Boolean_4.ToString()}");
                Log.Debug($"field_Private_Single_0 {input.field_Private_Single_0}");
                Log.Debug($"field_Private_Single_1 {input.field_Private_Single_1}");
                Log.Debug($"field_Private_Single_2 {input.field_Private_Single_2}");
                Log.Debug($"field_Private_Single_3 {input.field_Private_Single_3}");
                Log.Debug($"field_Private_Single_4 {input.field_Private_Single_4}");
                Log.Debug($"field_Private_Single_5 {input.field_Private_Single_5}");
                Log.Debug($"field_Public_Single_0 {input.field_Public_Single_0}");
                Log.Debug($"prop_Single_0 {input.prop_Single_0}");
                Log.Debug($"prop_Single_1 {input.prop_Single_1}");
                isDumping = false;
            }

        }

        private static bool isDumping = false;

    }
}