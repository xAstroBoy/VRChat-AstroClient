namespace AstroClient
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using UnityEngine;
    using VRCSDK2;

    internal static  class TriggersCloner
    {
        internal static  void CloneVRC2SDKTrigger(GameObject OrigObj, GameObject DisplayObj, string InteractText)
        {
            var DeleteTrigger = DisplayObj.GetComponentInChildren<VRC_Trigger>(true);
            var WorkingTrigger = OrigObj.GetComponentInChildren<VRC_Trigger>(true);
            VRC_Trigger Cloned_trigger = null;

            if (DeleteTrigger != null)
            {
                DeleteTrigger.DestroyMeLocal();
            }
            if (WorkingTrigger != null)
            {
                Cloned_trigger = DisplayObj.AddComponent<VRC_Trigger>().GetCopyOf(WorkingTrigger);
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