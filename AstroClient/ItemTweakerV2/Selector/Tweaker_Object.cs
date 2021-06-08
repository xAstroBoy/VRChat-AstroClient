﻿namespace AstroClient.ItemTweakerV2.Selector
{
	using AstroLibrary.Console;
	using AstroLibrary.Finder;
	using UnityEngine;

	public class Tweaker_Object
	{
		public static GameObject SetObjectToEditWithPath(string objpath)
		{
			var obj = GameObjectFinder.Find(objpath);
			if (obj != null)
			{
				ModConsole.Log("Path is valid, Found Gameobject obj : " + obj.name + "Using path " + objpath);
				Tweaker_Selector.SelectedObject = obj;
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
			Tweaker_Selector.SelectedObject = obj;
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
						Tweaker_Selector.SelectedObject = item;
					}
					return Tweaker_Selector.SelectedObject;
				}
				else
				{
					return Tweaker_Selector.SelectedObject;
				}
			}
			catch
			{
				return Tweaker_Selector.SelectedObject;
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
				if (Tweaker_Selector.SelectedObject == null)
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

		public static string GetObjectToEditName 
		{
			get
			{
				return Tweaker_Selector.SelectedObject.name;
			}

		}
	}
}