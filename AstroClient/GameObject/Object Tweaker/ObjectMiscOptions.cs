namespace AstroClient
{
	using AstroClient.AstroUtils.ItemTweaker;
	using AstroClient.Components;
	using AstroLibrary.Console;
	using AstroClient.Extensions;
	using AstroClient.GameObjectDebug;
	using DayClientML2.Utility.Extensions;
	using RubyButtonAPI;
	using System;
	using UnityEngine;
	using VRC;

	public class ObjectMiscOptions : GameEvents
	{
		public override void OnPlayerLeft(Player player)
		{
			if (player != null)
			{
				if (CurrentTarget == player.GetVRCPlayer())
				{
					CurrentTarget = null;
				}
			}
		}

		public override void OnLevelLoaded()
		{
			CurrentTarget = null;
			if (CurrentScaleButton != null)
			{
				CurrentScaleButton.setButtonText(string.Empty);
			}
			EditVectorX = true;
			EditVectorY = true;
			EditVectorZ = true;
			InflaterScaleMode = false;
		}

		public override void OnWorldReveal(string id, string name, string asseturl)
		{
			if (CurrentTarget == null)
			{
				CurrentTarget = VRC.Core.APIUser.CurrentUser.GetPlayer();
			}
		}

		public static void MarkPlayerAsTarget()
		{
			try
			{
				var apiuser = QuickMenuUtils.GetSelectedUser();
				if (apiuser != null)
				{
					var targetuser = apiuser.GetPlayer();
					if (targetuser != null)
					{
						CurrentTarget = targetuser;
					}
					else
					{
						ModConsole.Log("[TargetPlayer] Cant find user : " + apiuser.displayName);
					}
				}
			}
			catch (Exception) { }
		}

		public static void AllWorldPickupsOrbitsOnTarget()
		{
			try
			{
				var apiuser = QuickMenuUtils.GetSelectedUser();
				if (apiuser != null)
				{
					var targetuser = apiuser.GetPlayer();
					if (targetuser != null)
					{
						CurrentTarget = targetuser;
						foreach (var item in WorldUtils.Get_Pickups())
						{
							if (item != null)
							{
								OrbitManager.AddOrbitObject(item, targetuser);
							}
						}
					}
					else
					{
						ModConsole.Log("[Orbit] Cant find user : " + apiuser.displayName);
					}
				}
			}
			catch (Exception) { }
		}

		public static void TeleportAllWorldPickupsToPlayer()
		{
			try
			{
				var apiuser = QuickMenuUtils.GetSelectedUser();
				if (apiuser != null)
				{
					var targetuser = apiuser.GetPlayer();
					if (targetuser != null)
					{
						CurrentTarget = targetuser;
						foreach (var item in WorldUtils.Get_Pickups())
						{
							if (item != null)
							{
								ItemPosition.TeleportObject(item, targetuser, HumanBodyBones.RightHand, false);
							}
						}
					}
					else
					{
						ModConsole.Log("[Attacker] Cant find user : " + apiuser.displayName);
					}
				}
				else
				{
					ModConsole.Log("ApiUser is null.");
				}
			}
			catch (Exception) { }
		}

		public static void AllWorldPickupsAttackTarget()
		{
			try
			{
				var apiuser = QuickMenuUtils.GetSelectedUser();
				if (apiuser != null)
				{
					var targetuser = apiuser.GetPlayer();
					if (targetuser != null)
					{
						CurrentTarget = targetuser;
						foreach (var item in WorldUtils.Get_Pickups())
						{
							if (item != null)
							{
								PlayerAttackerManager.AddObject(item, targetuser);
							}
						}
					}
					else
					{
						ModConsole.Log("[Attacker] Cant find user : " + apiuser.displayName);
					}
				}
				else
				{
					ModConsole.Error("Error : ApiUser is null");
				}
			}
			catch (Exception) { }
		}

		public static void AllWorldPickupsWatchTarget()
		{
			try
			{
				var apiuser = QuickMenuUtils.GetSelectedUser();
				if (apiuser != null)
				{
					var targetuser = apiuser.GetPlayer();
					if (targetuser != null)
					{
						CurrentTarget = targetuser;
						foreach (var item in WorldUtils.Get_Pickups())
						{
							if (item != null)
							{
								PlayerWatcherManager.AddObject(item, targetuser);
							}
						}
					}
					else
					{
						ModConsole.Log("[Watcher] Cant find user : " + apiuser.displayName);
					}
				}
				else
				{
					ModConsole.Error("Error : ApiUser is null");
				}
			}
			catch (Exception) { }
		}

		public static void RemoveAttackerFromobj(GameObject obj)
		{
			if (obj != null)
			{
				var attacker = obj.GetComponent<PlayerAttacker>();
				if (attacker != null)
				{
					attacker.DestroyMeLocal();
				}
			}
		}

		public static void RemoveWatcherFromobj(GameObject obj)
		{
			if (obj != null)
			{
				var watcher = obj.GetComponent<PlayerWatcher>();
				if (watcher != null)
				{
					watcher.DestroyMeLocal();
				}
			}
		}

		public static void RemoveOrbitingObject(GameObject obj)
		{
			if (obj != null)
			{
				var orbit = obj.GetComponent<Orbit>();
				if (orbit != null)
				{
					orbit.DestroyMeLocal();
				}
			}
		}

		public static void MakeHeldItemOrbitAroundTarget(GameObject obj)
		{
			try
			{
				var targetuser = CurrentTarget;
				if (targetuser != null)
				{
					if (obj != null)
					{
						OrbitManager.AddOrbitObject(obj, CurrentTarget);
					}
				}
				else
				{
					ModConsole.Log("[Attacker] Cant find Last Target ");
				}
			}
			catch (Exception) { }
		}

		public static void MakeObjectAttackTarget(GameObject obj)
		{
			try
			{
				var targetuser = CurrentTarget;
				if (targetuser != null)
				{
					if (obj != null)
					{
						PlayerAttackerManager.AddObject(obj, targetuser);
					}
				}
				else
				{
					ModConsole.Log("[Attacker] Cant find Last Target ");
				}
			}
			catch (Exception) { }
		}

		public static void MakeObjectWatchTarget(GameObject obj)
		{
			try
			{
				var targetuser = CurrentTarget;
				if (targetuser != null)
				{
					if (obj != null)
					{
						PlayerWatcherManager.AddObject(obj, targetuser);
					}
				}
				else
				{
					ModConsole.Log("[Watcher] Cant find Last Target ");
				}
			}
			catch (Exception) { }
		}

		public static void MakeObjectOrbitToTarget(GameObject obj)
		{
			try
			{
				var targetuser = CurrentTarget;
				if (targetuser != null)
				{
					if (obj != null)
					{
						OrbitManager.AddOrbitObject(obj, targetuser);
					}
				}
				else
				{
					ModConsole.Error("[ORBIT] Cant find Target ");
				}
			}
			catch (Exception) { }
		}

		public static void RemoveAllWatchersPlayer()
		{
			try
			{
				var apiuser = QuickMenuUtils.GetSelectedUser();
				if (apiuser != null)
				{
					PlayerWatcherManager.RemovePickupsWatchersBoundToPlayer(apiuser);
				}
			}
			catch (Exception) { }
		}

		public static void RemoveAllAttackPlayer()
		{
			try
			{
				var apiuser = QuickMenuUtils.GetSelectedUser();
				if (apiuser != null)
				{
					PlayerAttackerManager.RemovePickupsAttackerBoundToPlayer(apiuser);
				}
			}
			catch (Exception) { }
		}

		public static void RemoveAllOrbitPlayer()
		{
			try
			{
				var apiuser = QuickMenuUtils.GetSelectedUser();
				if (apiuser != null)
				{
					OrbitManager.RemoveOrbitObjectsBoundToPlayer(apiuser);
				}
			}
			catch (Exception) { }
		}

		public static void IncreaseHoldItemScale(GameObject obj)
		{
			ScaleEditor.EditScaleSize(obj, true);
			UpdateScaleButton(obj);
		}

		public static void RestoreOriginalScaleItem(GameObject obj)
		{
			ScaleEditor.RestoreOriginalScale(obj);
			UpdateScaleButton(obj);
		}

		public static void DecreaseHoldItemScale(GameObject obj)
		{
			ScaleEditor.EditScaleSize(obj, false);
			UpdateScaleButton(obj);
		}

		public static void AllowTheftGlobal()
		{
			foreach (var obj in GameObjectUtils.GetAllPickupObjects())
			{
				Pickup.SetDisallowTheft(obj, false);
			}
		}

		public static void DisallowTheftGlobal()
		{
			foreach (var obj in GameObjectUtils.GetAllPickupObjects())
			{
				Pickup.SetDisallowTheft(obj, true);
			}
		}

		public static void UpdateScaleButton(GameObject obj)
		{
			if (obj != null)
			{
				if (InflaterScaleMode)
				{
					if (obj.GetComponent<ItemInflater>() != null)
					{
						if (obj.GetComponent<ItemInflater>().enabled)
						{
							CurrentScaleButton.setButtonText("Object 's scale : " + obj.GetComponent<ItemInflater>().NewSize.ToString());
							return;
						}
					}
				}

				CurrentScaleButton.setButtonText("Object 's scale : " + obj.transform.localScale.ToString());
				return;
			}
			else
			{
				CurrentScaleButton.setButtonText("");
			}
		}

		public static void UpdateCurrentAddValue()
		{
			if (CurrentAddValue != null)
			{
				CurrentAddValue.setButtonText(ScaleValueToUse.ToString());
			}
			if (ItemTweakerMain.ScaleSlider != null)
			{
				ItemTweakerMain.ScaleSlider.SetValue(ScaleValueToUse);
			}
		}

		public static void SetScaleValueToUse(float newval)
		{
			ScaleValueToUse = newval;
			UpdateCurrentAddValue();
		}

		public static void ResetDefValue()
		{
			ScaleValueToUse = 1f;
			UpdateCurrentAddValue();
		}

		public static void ToggleInflaterEditor()
		{
			InflaterScaleMode = !InflaterScaleMode;
		}

		public static void ToggleInteractionLock(GameObject obj, bool value)
		{
			if (obj != null)
			{
				var control = obj.GetComponent<RigidBodyController>();
				if (control != null)
				{
					if (!control.EditMode)
					{
						control.EditMode = true;
					}
					control.PreventOthersFromGrabbing = value;
				}
			}
		}

		public static QMSingleButton CurrentAddValue;
		public static QMSingleButton GameObjectActualScale;
		public static QMSingleButton CurrentScaleButton;
		public static QMSingleToggleButton InflaterModeButton;

		public static QMSingleToggleButton ScaleEditX;
		public static QMSingleToggleButton ScaleEditY;
		public static QMSingleToggleButton ScaleEditZ;

		public static float ScaleValueToUse = 0.1f;

		private static bool _InflaterScaleMode = false;

		public static bool InflaterScaleMode
		{
			get
			{
				return _InflaterScaleMode;
			}
			set
			{
				if (InflaterModeButton != null)
				{
					InflaterModeButton.setToggleState(value);
				}
				_InflaterScaleMode = value;
			}
		}

		private static bool _EditVectorX = true;
		private static bool _EditVectorY = true;
		private static bool _EditVectorZ = true;

		public static bool EditVectorX
		{
			get
			{
				return _EditVectorX;
			}
			set
			{
				if (ScaleEditX != null)
				{
					ScaleEditX.setToggleState(value);
				}
				_EditVectorX = value;
			}
		}

		public static bool EditVectorY
		{
			get
			{
				return _EditVectorY;
			}
			set
			{
				if (ScaleEditY != null)
				{
					ScaleEditY.setToggleState(value);
				}
				_EditVectorY = value;
			}
		}

		public static bool EditVectorZ
		{
			get
			{
				return _EditVectorZ;
			}
			set
			{
				if (ScaleEditZ != null)
				{
					ScaleEditZ.setToggleState(value);
				}
				_EditVectorZ = value;
			}
		}

		private static Player _CurrentTarget;

		public static Player CurrentTarget
		{
			get
			{
				return _CurrentTarget;
			}
			set
			{
				_CurrentTarget = value;
				ItemTweakerMain.UpdateTargetButtons();
			}
		}
	}
}