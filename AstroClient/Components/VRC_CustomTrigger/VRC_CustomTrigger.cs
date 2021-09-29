namespace AstroClient.Components
{
	using System;
	using VRC.SDKBase;

	internal class VRC_CustomTrigger : VRC_Interactable
	{
		internal Action onInteract;

		//internal override void Awake()
		//{
		//	interactTextPlacement = transform;
		//	base.Awake();
		//}

		//internal override void Interact() { onInteract?.Invoke(); }

		[Obsolete("This is only here to remind Cheetos")]
		internal static void PlaceHolder()
		{

		}
	}
}