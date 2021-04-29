namespace AstroClient
{
	using AstroClient.components;
	using AstroClient.ConsoleUtils;
	using System.Linq;
	using UnityEngine;
	using VRC.Udon;
	using static AstroClient.ObjectMiscOptions;
	using static AstroClient.variables.CustomLists;

	internal class ScaleEditor : GameEvents
	{
		private static float ModifiedVectorX()
		{
			if (ObjectMiscOptions.EditVectorX)
			{
				return ScaleValueToUse;
			}
			else
			{
				return 0;
			}
		}

		private static float ModifiedVectorY()
		{
			if (ObjectMiscOptions.EditVectorY)
			{
				return ScaleValueToUse;
			}
			else
			{
				return 0;
			}
		}

		private static float ModifiedVectorZ()
		{
			if (ObjectMiscOptions.EditVectorZ)
			{
				return ScaleValueToUse;
			}
			else
			{
				return 0;
			}
		}

		internal static void EditScaleSize(GameObject obj, bool increase)
		{
			if (obj != null)
			{
				if (!HasOriginalScaleStored(obj))
				{
					StoreOriginalScale(obj, obj.transform.localScale);
				}
				if (!InflaterScaleMode)
				{
					if (increase)
					{
						obj.transform.localScale = obj.transform.localScale + new Vector3(ModifiedVectorX(), ModifiedVectorY(), ModifiedVectorZ());
						if (obj.GetComponent<ItemInflater>() != null)
						{
							if (obj.GetComponent<ItemInflater>().enabled)
							{
								obj.GetComponent<ItemInflater>().enabled = false;
							}
							obj.GetComponent<ItemInflater>().NewSize = obj.transform.localScale;
						}
						EditUdon(obj, obj.transform.localScale);
					}
					else
					{
						obj.transform.localScale = obj.transform.localScale - new Vector3(ModifiedVectorX(), ModifiedVectorY(), ModifiedVectorZ());
						if (obj.GetComponent<ItemInflater>() != null)
						{
							if (obj.GetComponent<ItemInflater>().enabled)
							{
								obj.GetComponent<ItemInflater>().enabled = false;
							}
							obj.GetComponent<ItemInflater>().NewSize = obj.transform.localScale;
						}
						EditUdon(obj, obj.transform.localScale);
					}
				}
				else
				{
					if (obj.GetComponent<ItemInflater>() != null)
					{
						if (!obj.GetComponent<ItemInflater>().enabled)
						{
							obj.GetComponent<ItemInflater>().enabled = true;
						}
						if (increase)
						{
							obj.GetComponent<ItemInflater>().NewSize = obj.GetComponent<ItemInflater>().NewSize + new Vector3(ModifiedVectorX(), ModifiedVectorY(), ModifiedVectorZ());
							EditUdon(obj, obj.transform.localScale);
						}
						else
						{
							obj.GetComponent<ItemInflater>().NewSize = obj.GetComponent<ItemInflater>().NewSize - new Vector3(ModifiedVectorX(), ModifiedVectorY(), ModifiedVectorZ());
							EditUdon(obj, obj.transform.localScale);
						}
					}
					else
					{
						var SizeInflater = obj.AddComponent<ItemInflater>();
						if (SizeInflater != null)
						{
							if (!SizeInflater.enabled)
							{
								SizeInflater.enabled = true;
							}
							if (increase)
							{
								obj.GetComponent<ItemInflater>().NewSize = obj.GetComponent<ItemInflater>().NewSize + new Vector3(ModifiedVectorX(), ModifiedVectorY(), ModifiedVectorZ());
								EditUdon(obj, obj.transform.localScale);
							}
							else
							{
								obj.GetComponent<ItemInflater>().NewSize = obj.GetComponent<ItemInflater>().NewSize - new Vector3(ModifiedVectorX(), ModifiedVectorY(), ModifiedVectorZ());
								EditUdon(obj, obj.transform.localScale);
							}
						}
					}
				}
			}
		}

		internal static bool HasOriginalScaleStored(GameObject obj)
		{
			return ScaleCheck.Where(x => x.TargetObj == obj).Select(x => x.HasBeenStored).DefaultIfEmpty(false).First();
		}

		internal static Vector3 GetOriginalScale(GameObject obj)
		{
			return ScaleCheck.Where(x => x.TargetObj == obj).Select(x => x.OriginalScale).DefaultIfEmpty(new Vector3(0, 0, 0)).First();
		}

		internal static void StoreOriginalScale(GameObject obj, Vector3 OriginalScale)
		{
			if (obj != null)
			{
				var item = new GameObjScales(obj, OriginalScale, true);
				if (!ScaleCheck.Contains(item))
				{
					ScaleCheck.Add(item);
				}
			}
		}

		public override void OnLevelLoaded()
		{
			ScaleCheck.Clear();
		}

		internal static void EditUdon(GameObject obj, Vector3 scale)
		{
			//TODO: FIND A SOLUTION IN UDON WORLD ITEM EDITS WITHOUT DESTROYING COMPONENT
			// DESTROYING COMPONENT CAUSES OBJECT LOSE SCRIPT AND INTERACTIVITY WITH OTHER WORLD COMPONENTS
			var udon = obj.GetComponent<UdonBehaviour>();
			if (udon != null)
			{
				// ATTEMPT TO MAKE THE UDONSYNC COMPONENT TO EDIT SCALE
				udon.gameObject.transform.localScale = scale;
				udon.enabled = true;
			}
		}

		internal static void RestoreOriginalScale(GameObject obj)
		{
			if (HasOriginalScaleStored(obj))
			{
				obj.transform.localScale = GetOriginalScale(obj);
				if (obj.GetComponent<ItemInflater>() != null)
				{
					obj.GetComponent<ItemInflater>().enabled = false;
					if (!obj.GetComponent<ItemInflater>().enabled)
					{
						obj.GetComponent<ItemInflater>().NewSize = GetOriginalScale(obj);
						obj.GetComponent<ItemInflater>().enabled = true;
					}
				}
			}
			else
			{
				ModConsole.Log($"I Dont have the original Scale stored for Object {obj.gameObject.name}");
			}
		}
	}
}