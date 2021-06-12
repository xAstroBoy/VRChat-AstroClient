using System;
using UnityEngine;

namespace VRCSDK2
{
	public class VRC_CustomTrigger : VRC_Interactable
	{
		public Action onInteract;

		public override void Awake()
		{
			interactTextPlacement = transform;
			base.Awake();
		}

		public override void Interact() { onInteract?.Invoke(); }

		public static void Create(string interacttext, GameObject parent, Action oninteract)
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
	}
}