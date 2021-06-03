﻿namespace AstroClient.ItemTweaker
{
	using AstroClient.AstroUtils.ItemTweaker;
	using AstroClient.Components;
	using AstroLibrary.Console;
	using AstroClient.Extensions;
	using AstroLibrary.Finder;
	using RubyButtonAPI;
	using UnityEngine;

	public class Tweaker_Object : GameEvents
	{
		public override void OnLevelLoaded()
		{
			DoNotPickOtherItems = false;
			if (TransformToEditBtn != null)
			{
				UpdateCapturedObject(null);
			}
			if (CurrentSelectedObject != null)
			{
				CurrentSelectedObject = null;
			}
			CurrentSelectedItemEnabledESP = false;
			if (LockHoldItem != null)
			{
				LockHoldItem.SetToggleState(false);
			}

			if (LockHoldItem != null)
			{
				LockHoldItem.SetToggleState(false);
			}
		}

		public static string GetObjectToEditName
		{
			get
			{
				return CurrentSelectedObject != null ? CurrentSelectedObject.name : "Not Selected Yet";
			}
		}

		public static void UpdateCapturedObject(GameObject obj)
		{
			if (obj != null)
			{
				if (TransformToEditBtn != null)
				{
					TransformToEditBtn.SetButtonText("Editing: " + obj.name);
					TransformToEditBtn.SetToolTip("Editing: " + obj.name);
				}
				if (GameObjMenu.GameObjMenuObjectToEdit != null)
				{
					GameObjMenu.GameObjMenuObjectToEdit.SetButtonText("Editing: " + obj.name);
					GameObjMenu.GameObjMenuObjectToEdit.SetToolTip("Editing: " + obj.name);
				}
				UpdateCapturedButtonColor(obj.active);
			}
			else
			{
				if (TransformToEditBtn != null)
				{
					TransformToEditBtn.SetButtonText("Pick a Gameobject to start!");
					TransformToEditBtn.SetToolTip("Pick a Gameobject to start!");
				}
				if (GameObjMenu.GameObjMenuObjectToEdit != null)
				{
					GameObjMenu.GameObjMenuObjectToEdit.SetButtonText("Pick a Gameobject to start!");
					GameObjMenu.GameObjMenuObjectToEdit.SetToolTip("Pick a Gameobject to start!");
				}
			}
		}

		public static void UpdateCapturedButtonColor(bool isActive)
		{
			if (isActive)
			{
				TransformToEditBtn.SetTextColor(Color.green);
			}
			else
			{
				TransformToEditBtn.SetTextColor(Color.red);
			}
		}

		private static bool _DoNotPickOtherItems;

		public static bool DoNotPickOtherItems
		{
			get
			{
				return _DoNotPickOtherItems;
			}
			set
			{
				if (CurrentSelectedObject == null)
				{
					value = false;
				}
				_DoNotPickOtherItems = value;
				if (LockHoldItem != null)
				{
					LockHoldItem.SetToggleState(value);
				}
			}
		}

		private static bool _CurrentSelectedItemEnabledESP = false;

		public static bool CurrentSelectedItemEnabledESP
		{
			get
			{
				return _CurrentSelectedItemEnabledESP;
			}
			set
			{
				_CurrentSelectedItemEnabledESP = value;
				if (value)
				{
					if (CurrentSelectedObject != null)
					{
						var ESP = CurrentSelectedObject.GetComponent<ESP_ItemTweaker>();
						if (ESP == null)
						{
							CurrentSelectedObject.AddComponent<ESP_ItemTweaker>();
						}
					}
				}
				else
				{
					if (_CurrentSelectedObject != null)
					{
						var ESP = _CurrentSelectedObject.GetComponent<ESP_ItemTweaker>();
						if (ESP != null)
						{
							ESP.DestroyMeLocal();
						}
					}
				}
				_CurrentSelectedItemEnabledESP = value;
			}
		}

		private static GameObject _CurrentSelectedObject;

		public static GameObject CurrentSelectedObject
		{
			get
			{
				return _CurrentSelectedObject;
			}
			set
			{
				if (_CurrentSelectedObject == value)
				{
					return;
				}
				if (_CurrentSelectedObject != null)
				{
					var ESP = _CurrentSelectedObject.GetComponent<ESP_ItemTweaker>();
					if (ESP != null)
					{
						ESP.DestroyMeLocal();
					}
				}

				_CurrentSelectedObject = value;
				if (CurrentSelectedItemEnabledESP)
				{
					if (value != null)
					{
						var ESP = value.GetComponent<ESP_ItemTweaker>();
						if (ESP == null)
						{
							value.AddComponent<ESP_ItemTweaker>();
						}
					}
				}
				if (value != null)
				{

					RigidBodyController RigidBodyController = value.GetComponent<RigidBodyController>();
					if (RigidBodyController == null)
					{
						RigidBodyController = value.AddComponent<RigidBodyController>();
						if (RigidBodyController != null)
						{
							RigidBodyController.EditMode = false;
						}
					}

					PickupController PickupController = value.GetComponent<PickupController>();
					if (PickupController == null)
					{
						PickupController = value.AddComponent<PickupController>();
						if (PickupController != null)
						{
							PickupController.EditMode = false;
						}
					}

				}


				CrazyObjectManager.UpdateTimeButton(value);
				ObjectSpinnerManager.UpdateSpinnerButton(value);
				ObjectSpinnerManager.UpdateTimerButton(value);
				RocketManager.UpdateButton(value);
				ItemTweakerMain.CheckIfContainsPickupProperties(value);
				ItemTweakerMain.SetActiveButtonStatus(value);
				UpdateCapturedObject(value);
				ItemTweakerMain.UpdateTargetButtons();
				ItemTweakerMain.UpdateTeleportToMeBtns();
			}
		}

		public static GameObject SetObjectToEditWithPath(string objpath)
		{
			var obj = GameObjectFinder.Find(objpath);
			if (obj != null)
			{
				ModConsole.Log("Path is valid, Found Gameobject obj : " + obj.name + "Using path " + objpath);
				CurrentSelectedObject = obj;
				return obj;
			}
			else
			{
				return null;
			}
		}

		public static void SetObjectToEdit(GameObject obj)
		{
			if (DoNotPickOtherItems)
			{
				return;
			}
			CurrentSelectedObject = obj;
		}

		public static GameObject GetGameObjectToEdit()
		{
			try
			{
				if (!DoNotPickOtherItems)
				{
					var item = PlayerHands.GetHoldTransform();
					if (item != null)
					{
						CurrentSelectedObject = item;
					}
					return CurrentSelectedObject;
				}
				else
				{
					return CurrentSelectedObject;
				}
			}
			catch
			{
				return CurrentSelectedObject;
			}
		}

		public static QMSingleButton TransformToEditBtn;
		public static QMSingleToggleButton LockHoldItem;
	}
}