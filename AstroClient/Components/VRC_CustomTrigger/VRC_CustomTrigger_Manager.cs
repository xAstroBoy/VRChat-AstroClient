using Harmony;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;
using VRCSDK2;
#pragma warning disable CS0618

namespace AstroClient.Components
{

    public class VRC_CustomTriggerMod : GameEvents
    {
        private static TutorialManager tutorialManagerInstance;
        private static MethodInfo trackingmanagerGetTrackedTransform;
        private static MethodInfo inputManagerGetSetting;
        private static FieldInfo interactablesfield;
        private static FieldInfo pickupfield;

       public override void OnApplicationStart()
        {
            HarmonyInstance harmonyInstance = HarmonyInstance.Create("vrc_customtrigger");
            harmonyInstance.Patch(typeof(VRCUiCursor).GetMethod("SetTargetInfo"), null, new HarmonyMethod(typeof(VRC_CustomTriggerMod).GetMethod("SetTargetInfo", BindingFlags.Static | BindingFlags.NonPublic)), new HarmonyMethod(typeof(VRC_CustomTriggerMod).GetMethod("SetTargetInfo_Transpiler", BindingFlags.Static | BindingFlags.NonPublic)));
        }

        private static bool LongCheck(long input, long type) { return (input & type) == type; }

        private static Transform VRCTrackingManager_GetTrackedTransform(int trackerpos)
        {
            if (trackingmanagerGetTrackedTransform == null)
                trackingmanagerGetTrackedTransform = typeof(VRCTrackingManager).GetMethod("GetTrackedTransform");
            if (trackingmanagerGetTrackedTransform != null)
            {
                object[] paramtbl = new object[] { trackerpos };
                return (Transform)trackingmanagerGetTrackedTransform.Invoke(null, paramtbl);
            }
            return null;
        }

        private static TutorialManager GetTutorialManager()
        {
            if (tutorialManagerInstance == null)
            {
                FieldInfo[] nonpublicStaticPopupFields = typeof(TutorialManager).GetFields(BindingFlags.NonPublic | BindingFlags.Static);
                if (nonpublicStaticPopupFields.Length == 0)
                    return null;
                FieldInfo tutorialManagerInstanceField = nonpublicStaticPopupFields.First(field => field.FieldType == typeof(TutorialManager));
                if (tutorialManagerInstanceField == null)
                    return null;
                tutorialManagerInstance = tutorialManagerInstanceField.GetValue(null) as TutorialManager;
            }
            return tutorialManagerInstance;
        }

        private static List<VRC_Interactable> VRCUiCursor_InteractablesList(object __0)
        {
            if (interactablesfield == null)
            {
                Type[] typestbl = typeof(VRCUiCursor).GetNestedTypes();
                if (typestbl.Length != 0)
                {
                    FieldInfo[] fieldstbl = typestbl[0].GetFields();
                    if (fieldstbl.Length != 0)
                        interactablesfield = fieldstbl.First(field => field.FieldType == typeof(List<>).MakeGenericType(typeof(VRC_Interactable)));
                }
            }
            if (interactablesfield != null)
                return interactablesfield.GetValue(__0) as List<VRC_Interactable>;
            return null;
        }

        private static VRC_Pickup VRCUiCursor_Pickup(object __0)
        {
            if (pickupfield == null)
            {
                Type[] typestbl = typeof(VRCUiCursor).GetNestedTypes();
                if (typestbl.Length != 0)
                {
                    FieldInfo[] fieldstbl = typestbl[0].GetFields();
                    if (fieldstbl.Length != 0)
                        pickupfield = fieldstbl.First(field => field.FieldType == typeof(VRC_Pickup));
                }
            }
            if (pickupfield != null)
                return pickupfield.GetValue(__0) as VRC_Pickup;
            return null;
        }

        private static bool VRCInputManager_GetSetting(int setting)
        {
            if (inputManagerGetSetting == null)
                inputManagerGetSetting = typeof(VRCInputManager).GetMethod("GetSetting");
            if (inputManagerGetSetting != null)
            {
                object[] paramtbl = new object[] { setting };
                return (bool)inputManagerGetSetting.Invoke(null, paramtbl);
            }
            return false;
        }

        private static void SetTargetInfo(VRCUiCursor __instance, object __0)
        {
            // VRCUiCursor Left = 2
            bool left_handed = ((int)__instance.field_Public_EnumNPublicSealedvaNoRiLe4vUnique_0 == 2);
            VRC_Pickup outputpickup = null;
            List<VRC_Interactable> outputinteractiblelist = null;

            // VRCInputManager LegacyGrasp = 5
            if (!VRCInputManager_GetSetting(5))
            {
                Component component = null;
                List<VRC_Interactable> interactablelist = VRCUiCursor_InteractablesList(__0);
                if (interactablelist != null)
                {
                    foreach (VRC_Interactable vrc_Interactable in interactablelist)
                    {
                        VRC_UseEvents component1 = vrc_Interactable.GetComponent<VRC_UseEvents>();
                        VRCSDK2.VRC_CustomTrigger component2 = vrc_Interactable.GetComponent<VRCSDK2.VRC_CustomTrigger>();
                        VRC_Trigger component3 = vrc_Interactable.GetComponent<VRC_Trigger>();
                        bool flag1 = (component1 != null);
                        bool flag2 = (component2 != null);
                        bool flag3 = ((component3 != null) && (component3.HasInteractiveTriggers || component3.HasPickupTriggers));
                        if (flag1 || flag2 || flag3)
                        {
                            component = vrc_Interactable;
                            break;
                        }
                    }
                }

                __instance.field_Public_VRCUiSelectedOutline_0.MemberwiseClone();

                // VRCUiCursor.ILJCEPNGACG.Interactable = 8
                if (LongCheck((long)__instance.field_Public_EnumNPublicSealedvaNoUiWeUiInPiFlPlOtUnique_0, 8) && (component != null))
                {
                    // VRCTracking.CJBHMLMLAHK.HandTracker_LeftPalm = 9
                    // VRCTracking.CJBHMLMLAHK.HandTracker_RightPalm = 10
                    Transform trackedTransform = VRCTrackingManager_GetTrackedTransform(left_handed ? 9 : 10);
                    if ((trackedTransform == null) || VRCTrackingManager.Method_Public_Static_Boolean_Vector3_0(trackedTransform.position))
                    {
                        __instance.field_Public_VRCUiSelectedOutline_0.Method_Public_Void_Component_0(component);
                        GetTutorialManager().InteractableSelected(interactablelist, component, left_handed);
                        outputinteractiblelist = interactablelist;
                    }
                }

                // VRCUiCursor Pickup = 16
                VRC_Pickup newpickup = VRCUiCursor_Pickup(__0);
                if (LongCheck((long)__instance.over, 16) && (newpickup != null))
                {
                    if (newpickup.currentlyHeldBy == null)
                    {
                        __instance.outline.Clone(newpickup);
                        GetTutorialManager().PickupSelected(newpickup, left_handed);
                        outputpickup = newpickup;
                    }
                    else
                        __instance.outline.Clone(null);
                }
            }
            else
                __instance.outline.Clone(null);

            VRCHandGrasper vrchandGrasper = null;
            if (VRCPlayer.Instance != null)
                vrchandGrasper = VRCPlayer..GetHandGrasper(left_handed ? ControllerHand.Left : ControllerHand.Right);
            if (vrchandGrasper != null)
                vrchandGrasper.SetSelectedObject(outputpickup, outputinteractiblelist);
        }

        private static IEnumerable<CodeInstruction> SetTargetInfo_Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> codelist = new List<CodeInstruction>();
            for (int i = 0; i < instructions.Count<CodeInstruction>(); i++)
            {
                CodeInstruction codeInstruction = instructions.ElementAt(i);
                if ("call Boolean get_legacyGrasp()".Equals(codeInstruction.ToString()))
                    break;
                else
                    codelist.Add(codeInstruction);
            }
            return codelist.AsEnumerable<CodeInstruction>();
        }
    }
}

