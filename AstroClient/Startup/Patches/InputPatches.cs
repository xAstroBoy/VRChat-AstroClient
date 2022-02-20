namespace AstroClient.Startup.Patches
{
    #region Imports

    using System;
    using System.Reflection;
    using AstroEventArgs;
    using Cheetos;
    using Harmony;
    using Tools.Extensions;
    using Tools.Input;
    using UnityEngine.Events;

    #endregion Imports

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class InputPatches : AstroEvents
    {

        internal static EventHandler<VRCInputArgs> Event_OnInput_Jump { get; set; }
        internal static EventHandler<VRCInputArgs> Event_OnInput_UseLeft { get; set; }
        internal static EventHandler<VRCInputArgs> Event_OnInput_UseRight { get; set; }
        internal static EventHandler<VRCInputArgs> Event_OnInput_GrabLeft { get; set; }
        internal static EventHandler<VRCInputArgs> Event_OnInput_GrabRight { get; set; }

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
        internal override void OnRoomJoined()
        {
            EnableListener = true;
        }

        internal override void OnRoomLeft()
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
                        Event_OnInput_Jump.SafetyRaise(new VRCInputArgs(__instance.isClicked(), __instance.isDown(), __instance.isUp()));
                        EnableListener = true;
                        break;
                    }
                case InputTypes.UseLeft:
                    {
                        Event_OnInput_UseLeft.SafetyRaise(new VRCInputArgs(__instance.isClicked(), __instance.isDown(), __instance.isUp()));
                        EnableListener = true;
                        break;
                    }

                case InputTypes.UseRight:
                    {
                        Event_OnInput_UseRight.SafetyRaise(new VRCInputArgs(__instance.isClicked(), __instance.isDown(), __instance.isUp()));
                        EnableListener = true;
                        break;
                    }

                case InputTypes.GrabLeft:
                    {
                        Event_OnInput_GrabLeft.SafetyRaise(new VRCInputArgs(__instance.isClicked(), __instance.isDown(), __instance.isUp()));
                        EnableListener = true;
                        break;
                    }

                case InputTypes.GrabRight:
                    {
                        Event_OnInput_GrabRight.SafetyRaise(new VRCInputArgs(__instance.isClicked(), __instance.isDown(), __instance.isUp()));
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
                ModConsole.ErrorExc(ex);
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
                ModConsole.DebugLog($"Input Name : {input.Name()}");

                ModConsole.Log($"field_Private_Boolean_0 {input.field_Private_Boolean_0.ToString()}");
                ModConsole.Log($"field_Private_Boolean_1 {input.field_Private_Boolean_1.ToString()}");
                ModConsole.Log($"prop_Boolean_0 {input.prop_Boolean_0.ToString()}");
                ModConsole.Log($"prop_Boolean_1 {input.prop_Boolean_1.ToString()}");
                ModConsole.Log($"prop_Boolean_2 {input.prop_Boolean_2.ToString()}");
                ModConsole.Log($"prop_Boolean_3 {input.prop_Boolean_3.ToString()}");
                ModConsole.Log($"prop_Boolean_4 {input.prop_Boolean_4.ToString()}");
                ModConsole.Log($"field_Private_Single_0 {input.field_Private_Single_0}");
                ModConsole.Log($"field_Private_Single_1 {input.field_Private_Single_1}");
                ModConsole.Log($"field_Private_Single_2 {input.field_Private_Single_2}");
                ModConsole.Log($"field_Private_Single_3 {input.field_Private_Single_3}");
                ModConsole.Log($"field_Private_Single_4 {input.field_Private_Single_4}");
                ModConsole.Log($"field_Private_Single_5 {input.field_Private_Single_5}");
                ModConsole.Log($"field_Public_Single_0 {input.field_Public_Single_0}");
                ModConsole.Log($"prop_Single_0 {input.prop_Single_0}");
                ModConsole.Log($"prop_Single_1 {input.prop_Single_1}");
                isDumping = false;
            }

        }

        private static bool isDumping = false;

    }
}