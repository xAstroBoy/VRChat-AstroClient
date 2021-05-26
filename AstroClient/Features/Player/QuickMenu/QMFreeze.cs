namespace AstroClient.Features.Player.QuickMenu
{
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;
	using VRC.Animation;
	using VRC.SDKBase;
	using static AstroClient.LocalPlayerUtils;

	public class QMFreeze : GameEvents
	{




		public override void OnLateUpdate()
		{
			if (FreezePlayerOnQMOpen)
			{
				if(QuickMenuUtils.IsQuickMenuOpen)
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
		}




		private static bool _FreezePlayerOnQMOpen;
		public static bool FreezePlayerOnQMOpen
		{
			get
			{
				return _FreezePlayerOnQMOpen;
			}
			set
			{
				_FreezePlayerOnQMOpen = value;
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
