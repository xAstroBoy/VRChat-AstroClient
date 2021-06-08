namespace AstroClient.ItemTweakerV2.Selector
{
	using AstroLibrary.Console;
	using AstroLibrary.Finder;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;
	public class Selector_Utils
	{

		public static GameObject SetObjectToEditWithPath(string objpath)
		{
			var obj = GameObjectFinder.Find(objpath);
			if (obj != null)
			{
				ModConsole.Log("Path is valid, Found Gameobject obj : " + obj.name + "Using path " + objpath);
				Object_Selector.SelectedObject = obj;
				return obj;
			}
			else
			{
				return null;
			}
		}

		public static void SetObjectToEdit(GameObject obj)
		{
			if (LockItem)
			{
				return;
			}
			Object_Selector.SelectedObject = obj;
		}

		public static GameObject GetGameObjectToEdit()
		{
			try
			{
				if (!LockItem)
				{
					var item = PlayerHands.GetHoldTransform();
					if (item != null)
					{
						Object_Selector.SelectedObject = item;
					}
					return Object_Selector.SelectedObject;
				}
				else
				{
					return Object_Selector.SelectedObject;
				}
			}
			catch
			{
				return Object_Selector.SelectedObject;
			}
		}

		private static bool _DoNotPickOtherItems;
		public static bool LockItem
		{
			get
			{
				return _DoNotPickOtherItems;
			}
			set
			{
				if (Object_Selector.SelectedObject == null)
				{
					value = false;
				}
				_DoNotPickOtherItems = value;
				if (TweakerV2Main.LockHoldItem != null)
				{
					TweakerV2Main.LockHoldItem.SetToggleState(value);
				}
			}
		}


	}
}
