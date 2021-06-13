using System;
using UnityEngine;
using VRC.SDKBase;

namespace AstroClient.Components
{
	public class VRC_CustomTrigger : VRC_Interactable
	{
		public Action onInteract;

		//public override void Awake()
		//{
		//	interactTextPlacement = transform;
		//	base.Awake();
		//}

		//public override void Interact() { onInteract?.Invoke(); }

		[Obsolete("This is only here to remind Cheetos")]
		public static void PlaceHolder()
		{

		}
	}
}