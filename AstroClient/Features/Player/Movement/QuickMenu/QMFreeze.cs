namespace AstroClient.Features.Player.Movement.QuickMenu_QMFreeze
{
	using AstroLibrary.Console;
	using DayClientML2.Utility;
	using Harmony;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using System.Reflection;
	using UnityEngine;
	using VRC.SDKBase;

	public class QMFreeze : GameEvents
	{

		public override void OnLevelLoaded()
		{
			Frozen = false;
		}


		// TODO: Make a Field Patcher to hook into the getter.

		//private HarmonyInstance harmony;

		//private void HookQuickMenu()
		//{
		//	if (harmony == null)
		//	{
		//		harmony = HarmonyInstance.Create(BuildInfo.Name + " QMFreezeHook");
		//	}

		//	foreach (var method in typeof(QuickMenu).GetMethods())
		//	{
		//		if (method != null)
		//		{
		//			ModConsole.Log($"QMFreeze Patch Found Method : [ {method.Name} ]");
		//			if (method.Name.ToLower().StartsWith("get_"))
		//			{
		//				if (method.Name.ToLower() == "get_prop_Boolean_0")
		//				{
		//					ModConsole.DebugLog("Registering Patch QMFreezeHook");
		//					harmony.Patch(typeof(QuickMenu).GetMethod(method.Name, BindingFlags.Instance | BindingFlags.Public), null, new HarmonyMethod(typeof(QMFreeze).GetMethod(nameof(QuickMenuIsOpen), BindingFlags.Static | BindingFlags.NonPublic)));
		//				}
		//			}
		//		}
		//	}



		//	ModConsole.DebugLog("Hooked QuickMenu");
		//}



		//private static void QuickMenuIsOpen(ref bool value)
		//{
		//	if (FreezePlayerOnQMOpen)
		//	{
		//		if (value)
		//		{
		//			Freeze();
		//		}
		//		else
		//		{
		//			Unfreeze();
		//		}
		//	}
		//}

		public override void OnLateUpdate()
		{
			if (FreezePlayerOnQMOpen)
			{
				if (QuickMenuUtils.IsQuickMenuOpen)
				{
					Freeze();
				}
				else
				{
					Unfreeze();
				}
			}
		}




		public static void Unfreeze()
		{
			if (Frozen)
			{
				Physics.gravity = _originalGravity;
				if (RestoreVelocity)
				{
					Networking.LocalPlayer.SetVelocity(_originalVelocity);
				}
				Frozen = false;
			}
		}

		public static void Freeze()
		{
			if (!Frozen)
			{
				_originalGravity = Physics.gravity;
				_originalVelocity = Networking.LocalPlayer.GetVelocity();
				if (_originalVelocity == Vector3.zero)
				{
					return;
				}
				Physics.gravity = Vector3.zero;
				Networking.LocalPlayer.SetVelocity(Vector3.zero);
				Frozen = true;
			}
			else
			{
				if(Networking.LocalPlayer.GetVelocity() != Vector3.zero)
				{
					Networking.LocalPlayer.SetVelocity(Vector3.zero);
				}
			}
		}




		public static bool FreezePlayerOnQMOpen
		{
			get
			{
				return ConfigManager.Movement.QMFreeze;
			}
			set
			{
				ConfigManager.Movement.QMFreeze = value;
				if (FreezePlayerOnQMOpenToggle != null)
				{
					FreezePlayerOnQMOpenToggle.SetToggleState(value);
				}

			}
		}

		public static QMToggleButton FreezePlayerOnQMOpenToggle;
		public static bool Frozen;

		private static Vector3 _originalGravity;
		private static Vector3 _originalVelocity;


		internal static bool Opened;
		internal static bool RestoreVelocity = false;

	}
}
