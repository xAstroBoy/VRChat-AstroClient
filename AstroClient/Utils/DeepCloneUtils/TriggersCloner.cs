namespace AstroClient
{
	using AstroLibrary.Console;
	using AstroClient.extensions;
	using UnityEngine;
	using VRCSDK2;

	public static class TriggersCloner
	{
		public static void CloneVRC2SDKTrigger(GameObject OrigObj, GameObject DisplayObj, string InteractText)
		{
			var DeleteTrigger = DisplayObj.GetComponentInChildren<VRCSDK2.VRC_Trigger>(true);
			var WorkingTrigger = OrigObj.GetComponentInChildren<VRCSDK2.VRC_Trigger>(true);
			VRC_Trigger Cloned_trigger = null;

			if (DeleteTrigger != null)
			{
				DeleteTrigger.DestroyMeLocal();
			}
			if (WorkingTrigger != null)
			{
				Cloned_trigger = DisplayObj.AddComponent<VRCSDK2.VRC_Trigger>().GetCopyOf(WorkingTrigger);
				if (Cloned_trigger != null)
				{
					Cloned_trigger.interactText = "[AstroClient]: " + InteractText;
				}
			}
			if (Cloned_trigger != null)
			{
				DisplayObj.AddCollider();
				ModConsole.Log($"Added Successfully {InteractText}");
			}
		}
	}
}