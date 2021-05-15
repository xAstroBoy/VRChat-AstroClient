namespace AstroClient.Extensions
{
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using VRC.SDK3.Components;
	using VRC.SDKBase;

	public static class ExtensionUtils
	{
		public static void VRC_Trigger_UpdateInteractionText(this GameObject obj, string NewText)
		{
			if (obj != null)
			{
				var one = obj.GetComponentsInChildren<VRC_Trigger>(true);
				var two = obj.GetComponentsInChildren<VRCSDK2.VRC_Trigger>(true);

				if (one.Count() != 0)
				{
					foreach (var child in one)
					{
						if (child.interactText != NewText)
						{
							child.interactText = NewText;
						}
					}
				}
				if (two.Count() != 0)
				{
					foreach (var child in one)
					{
						if (child.interactText != NewText)
						{
							child.interactText = NewText;
						}
					}
				}
			}
		}

		public static void VRC_Interactable_Click(this List<GameObject> list)
		{
			foreach (var item in list)
			{
				if (item != null)
				{
					item.VRC_Interactable_Click();
				}
			}
		}

		public static void VRC_Interactable_Click(this GameObject obj)
		{
			bool ObjHasBeenActivated = false;
			bool TriggerHasBeenEnabled = false;
			if (obj != null)
			{
				var SDKbase = obj.GetComponent<VRC_Interactable>();
				var SDK2 = obj.GetComponent<VRCSDK2.VRC_Interactable>();
				var SDK3 = obj.GetComponent<VRCInteractable>();

				if (!obj.active)
				{
					ObjHasBeenActivated = true;
					obj.SetActive(true);
				}

				if (SDKbase != null)
				{
					if (!SDKbase.enabled)
					{
						TriggerHasBeenEnabled = true;
						SDKbase.enabled = true;
					}

					SDKbase.Interact();
					if (TriggerHasBeenEnabled)
					{
						SDKbase.enabled = false;
					}

					if (ObjHasBeenActivated)
					{
						obj.SetActive(false);
					}
				}
				else if (SDK2 != null)
				{
					if (!SDK2.enabled)
					{
						TriggerHasBeenEnabled = true;
						SDK2.enabled = true;
					}

					SDK2.Interact();
					if (TriggerHasBeenEnabled)
					{
						SDK2.enabled = false;
					}

					if (ObjHasBeenActivated)
					{
						obj.SetActive(false);
					}
				}
				else if (SDK3 != null)
				{
					if (!SDK3.enabled)
					{
						TriggerHasBeenEnabled = true;
						SDK3.enabled = true;
					}

					SDK3.Interact();
					if (TriggerHasBeenEnabled)
					{
						SDK3.enabled = false;
					}

					if (ObjHasBeenActivated)
					{
						obj.SetActive(false);
					}
				}
			}
		}


		public static void TriggerClick(this VRC_Trigger obj)
		{
			bool ObjHasBeenActivated = false;
			bool TriggerHasBeenEnabled = false;

			if (obj != null)
			{
				OnlineEditor.TakeObjectOwnership(obj.gameObject);

				var SDKbase = obj.GetComponent<VRC_Trigger>();
				var SDK2 = obj.GetComponent<VRCSDK2.VRC_Trigger>();
				if (!obj.gameObject.active)
				{
					ObjHasBeenActivated = true;
					obj.gameObject.SetActive(true);
				}

				if (SDKbase != null)
				{
					if (!SDKbase.enabled)
					{
						TriggerHasBeenEnabled = true;
						SDKbase.enabled = true;
					}

					SDKbase.Interact();
					if (TriggerHasBeenEnabled)
					{
						SDKbase.enabled = false;
					}

					if (ObjHasBeenActivated)
					{
						obj.gameObject.SetActive(false);
					}
				}
				else if (SDK2 != null)
				{
					if (!SDK2.enabled)
					{
						TriggerHasBeenEnabled = true;
						SDK2.enabled = true;
					}

					SDK2.Interact();
					if (TriggerHasBeenEnabled)
					{
						SDK2.enabled = false;
					}

					if (ObjHasBeenActivated)
					{
						obj.gameObject.SetActive(false);
					}

				}
				OnlineEditor.RemoveOwnerShip(obj.gameObject);

			}
		}


		public static void TriggerClick(this GameObject obj)
		{
			bool ObjHasBeenActivated = false;
			bool TriggerHasBeenEnabled = false;

			if (obj != null)
			{
				OnlineEditor.TakeObjectOwnership(obj);

				var SDKbase = obj.GetComponent<VRC_Trigger>();
				var SDK2 = obj.GetComponent<VRCSDK2.VRC_Trigger>();
				if (!obj.active)
				{
					ObjHasBeenActivated = true;
					obj.SetActive(true);
				}

				if (SDKbase != null)
				{
					if (!SDKbase.enabled)
					{
						TriggerHasBeenEnabled = true;
						SDKbase.enabled = true;
					}

					SDKbase.Interact();
					if (TriggerHasBeenEnabled)
					{
						SDKbase.enabled = false;
					}

					if (ObjHasBeenActivated)
					{
						obj.SetActive(false);
					}
				}
				else if (SDK2 != null)
				{
					if (!SDK2.enabled)
					{
						TriggerHasBeenEnabled = true;
						SDK2.enabled = true;
					}

					SDK2.Interact();
					if (TriggerHasBeenEnabled)
					{
						SDK2.enabled = false;
					}

					if (ObjHasBeenActivated)
					{
						obj.SetActive(false);
					}
				}
				OnlineEditor.RemoveOwnerShip(obj);

			}
		}
	}
}