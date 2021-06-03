namespace AstroClient.Extensions
{
	using AstroClient.Experiments;
	using AstroLibrary.Console;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using VRC;
	using VRC.SDK3.Components;
	using VRC.SDKBase;
	using VRC.Udon;
	using Color = System.Drawing.Color;

	public static class ComponentParser_ext
	{

		public static List<GameObject> Get_VRCInteractables(this GameObject obj)
		{

			if (obj != null)
			{
				try
				{

					List<GameObject> list1 = new List<GameObject>();
					List<GameObject> list2 = new List<GameObject>();
					List<GameObject> list3 = new List<GameObject>();


					list1 = obj.GetComponentsInChildren<VRC_Interactable>(true).Select(i => i.gameObject).Where(x => x != null).ToList();
					list2 = obj.GetComponentsInChildren<VRCSDK2.VRC_Interactable>(true).Select(i => i.gameObject).Where(x => x != null).ToList();
					list3 = obj.GetComponentsInChildren<VRCInteractable>(true).Select(i => i.gameObject).Where(x => x != null).ToList();


					// Linq Still broken, does grab some duplicated gameobjects on the way (Might add a check as well in future)
					// Unite The lists In one (avoiding duplicates).
					//result = list1
					//	.Union(list2)
					//	.Union(list3)
					//	.Distinct()
					//	.ToList()
					//	.Where(x => x.gameObject != null)
					//	.ToList(); // Never null.
					foreach (var item in list2)
					{
						if (item != null)
						{
							if (!list1.Contains(item))
							{
								list1.Add(item);
							}
						}
					}

					foreach (var item in list3)
					{
						if (item != null)
						{
							if (!list1.Contains(item))
							{
								list1.Add(item);
							}
						}
					}

					return list1;

				}
				catch (Exception e)
				{
					ModConsole.Error("Error parsing Pickup VRC Interactables");
					ModConsole.ErrorExc(e);
					return null;
				}
			}
			return null;
		}

		public static List<GameObject> Get_Triggers(this GameObject obj)
		{
			if (obj != null)
			{
				try
				{
					List<GameObject> list1 = new List<GameObject>();
					List<GameObject> list2 = new List<GameObject>();

					list1 = obj.GetComponentsInChildren<VRC.SDKBase.VRC_Trigger>(true).Select(i => i.gameObject).Where(x => x != null).ToList();
					list2 = obj.GetComponentsInChildren<VRCSDK2.VRC_Trigger>(true).Select(i => i.gameObject).Where(x => x != null).ToList();
					foreach(var item in list2)
					{
						if (item != null)
						{
							if (!list1.Contains(item))
							{
								list1.Add(item);
							}
						}
					}

					// Linq Still broken, does grab some duplicated gameobjects on the way (Might add a check as well in future)
					//// Unite The lists In one (avoiding duplicates).
					//result = 
					//	 list1
					//	.Union(list2)
					//  .Distinct()
					//	.ToList()
					//	.Where(x => x.gameObject != null)
					//	.ToList(); // Never null.

					return list1;
				}
				catch (Exception e)
				{
					ModConsole.Error("Error parsing World Triggers");
					ModConsole.ErrorExc(e);
					return null;
				}
			}
			return null;
		}

		public static List<UdonBehaviour> Get_UdonBehaviours(this GameObject obj)
		{
			List<UdonBehaviour> events = new List<UdonBehaviour>();

			foreach (var item in obj.GetComponentsInChildren<UdonBehaviour>(true))
			{
				if (item != null)
				{
					if (item._eventTable.keys.Count != 0)
					{
						if (events.Contains(item))
						{
							events.Add(item);
						}
					}
				}
			}
			return events;
		}


		public static List<UdonBehaviour> Get_UdonBehaviours(this Transform obj)
		{
			return obj.Get_UdonBehaviours();
		}

		public static List<UdonBehaviour> Get_Triggers(this Transform obj)
		{
			return obj.Get_Triggers();
		}

		public static List<UdonBehaviour> Get_VRCInteractables(this Transform obj)
		{
			return obj.Get_VRCInteractables();
		}
	}
}
