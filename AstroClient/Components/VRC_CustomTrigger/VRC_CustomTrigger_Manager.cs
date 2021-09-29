#pragma warning disable CS0618

namespace AstroClient.Components
{
	using System;
	using System.Reflection;
	using System.Linq;
	using UnityEngine;
	using VRC.SDKBase;
	using System.Collections.Generic;
	using HarmonyLib;

	internal class VRC_CustomTriggerMod : GameEvents
    {
        private static TutorialManager tutorialManagerInstance;
        private static MethodInfo trackingmanagerGetTrackedTransform;
        private static MethodInfo inputManagerGetSetting;
        private static FieldInfo interactablesfield;
        private static FieldInfo pickupfield;

       internal override void OnApplicationStart()
        {

			//var instance = HarmonyLib.Harmony.CreateAndPatchAll(typeof(VRC_CustomTriggerMod));



			//instance.Patch(typeof(VRCUiCursor).GetMethod(nameof(VRCUiCursor.Method_Public_Void_ObjectNPublicRaBoObVRRaBoLi1VRObUnique_Boolean_0)),
			//	null, 
			//	new HarmonyMethod(typeof(VRC_CustomTriggerMod).GetMethod(nameof(SetTargetInfo), BindingFlags.Static | BindingFlags.NonPublic)),
			//	new HarmonyMethod(typeof(VRC_CustomTriggerMod).GetMethod(nameof(SetTargetInfo_Transpiler), BindingFlags.Static | BindingFlags.NonPublic)));
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

        private static Il2CppSystem.Collections.Generic.List<VRC_Interactable> VRCUiCursor_InteractablesList(object __0)
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
                return interactablesfield.GetValue(__0) as Il2CppSystem.Collections.Generic.List<VRC_Interactable>;
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



		internal static void Create(string interacttext, GameObject parent, Action oninteract)
		{
			VRC_Trigger oldtrigger = parent.GetComponent<VRC_Trigger>();
			if (oldtrigger != null)
				GameObject.DestroyImmediate(oldtrigger, true);
			VRC_EventHandler oldeventhandler = parent.GetComponent<VRC_EventHandler>();
			if (oldeventhandler != null)
				GameObject.DestroyImmediate(oldeventhandler, true);
			VRC_CustomTrigger trigger = parent.AddComponent<VRC_CustomTrigger>();
			trigger.onInteract += oninteract;
			trigger.interactText = interacttext;
		}


		private static void SetTargetInfo(VRCUiCursor __instance, object __0)
        {
			if (__instance == null) return;
            // VRCUiCursor Left = 2
            bool left_handed = ((int)__instance.field_Public_EnumNPublicSealedvaNoRiLe4vUnique_0 == 2);
            VRC_Pickup outputpickup = null;
            Il2CppSystem.Collections.Generic.List<VRC_Interactable> outputinteractiblelist = null;

            // VRCInputManager LegacyGrasp = 5
            if (!VRCInputManager_GetSetting(5))
            {
                Component component = null;
                Il2CppSystem.Collections.Generic.List<VRC_Interactable> interactablelist = VRCUiCursor_InteractablesList(__0);
                if (interactablelist != null)
                {
                    foreach (VRC_Interactable vrc_Interactable in interactablelist)
                    {
                        VRC_UseEvents component1 = vrc_Interactable.GetComponent<VRC_UseEvents>();
                        VRC_CustomTrigger component2 = vrc_Interactable.GetComponent<VRC_CustomTrigger>();
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

                __instance.field_Public_VRCUiSelectedOutline_0.Method_Public_Void_Component_0(null);

                // VRCUiCursor.ILJCEPNGACG.Interactable = 8
                if (LongCheck((long)__instance.field_Public_EnumNPublicSealedvaNoUiWeUiInPiFlPlOtUnique_0, 8) && (component != null))
                {
                    // VRCTracking.CJBHMLMLAHK.HandTracker_LeftPalm = 9
                    // VRCTracking.CJBHMLMLAHK.HandTracker_RightPalm = 10
                    Transform trackedTransform = VRCTrackingManager_GetTrackedTransform(left_handed ? 9 : 10);
                    if ((trackedTransform == null) || VRCTrackingManager.Method_Public_Static_Boolean_Vector3_0(trackedTransform.position))
                    {
                        __instance.field_Public_VRCUiSelectedOutline_0.Method_Public_Void_Component_0(component);
                        GetTutorialManager().Method_Public_Void_List_1_VRC_Interactable_Component_Boolean_0(interactablelist, component, left_handed);
                        outputinteractiblelist = interactablelist;
                    }
                }

                // VRCUiCursor Pickup = 16
                VRC_Pickup newpickup = VRCUiCursor_Pickup(__0);
                if (LongCheck((long)__instance.field_Public_EnumNPublicSealedvaNoUiWeUiInPiFlPlOtUnique_0, 16) && (newpickup != null))
                {
                    if (newpickup.currentlyHeldBy == null)
                    {
                        __instance.field_Public_VRCUiSelectedOutline_0.Method_Public_Void_Component_0(newpickup);
                        GetTutorialManager().Method_Public_Void_VRC_Pickup_Boolean_PDM_0(newpickup, left_handed);
                        outputpickup = newpickup;
                    }
                    else
                        __instance.field_Public_VRCUiSelectedOutline_0.Method_Public_Void_Component_0(null);
                }
            }
            else
                __instance.field_Public_VRCUiSelectedOutline_0.Method_Public_Void_Component_0(null);

            VRCHandGrasper vrchandGrasper = null;
            if (VRCPlayer.field_Internal_Static_VRCPlayer_0 != null)
                vrchandGrasper = VRCPlayer.field_Internal_Static_VRCPlayer_0.Method_Public_VRCHandGrasper_ControllerHand_0(left_handed ? ControllerHand.Left : ControllerHand.Right);
            if (vrchandGrasper != null)
                vrchandGrasper.Method_Public_Void_VRC_Pickup_List_1_VRC_Interactable_0(outputpickup, outputinteractiblelist);
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

