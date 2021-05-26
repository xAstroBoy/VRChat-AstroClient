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
	using static AstroClient.LocalPlayerUtils;

	public class QMFreeze : GameEvents
	{


		public override void OnLevelLoaded()
		{
			LocalMotionState = null;
			if (FreezePlayerOnQMOpenToggle != null)
			{
				FreezePlayerOnQMOpenToggle.SetToggleState(FreezePlayerOnQMOpen);
			}
			UnfreezePlayerOnce = true;
		}


		public override void OnUpdate()
		{
			if (FreezePlayerOnQMOpen)
			{
				try
				{
					if (GetPlayerCharControl() != null)
					{
						GetPlayerCharControl().enabled = !QuickMenuUtils.IsQuickMenuOpen;
					}
				}
				catch
				{
				}
			}
			else
			{
				if (!UnfreezePlayerOnce)
				{
					if (GetPlayerCharControl() != null)
					{
						if (!GetPlayerCharControl().enabled)
						{
							GetPlayerCharControl().enabled = true;
						}
					}
					UnfreezePlayerOnce = true;
				}
			}
		}




		public static CharacterController GetPlayerCharControl()
		{
			try
			{
				if (GetPlayerGameObject() != null && GetLocalVRCPlayer() != null && GetPlayerGameObject().GetComponent<CharacterController>() != null)
				{
					if (charcontrol == null)
					{
						return charcontrol = GetPlayerGameObject().GetComponent<CharacterController>();
					}
					else
					{
						return charcontrol;
					}
				}
			}
			catch
			{
				return null;
			}
			return null;
		}

		public static CharacterController charcontrol;

		public static VRCMotionState GetPlayerVRCMotionState()
		{
			if (LocalMotionState != null)
			{
				return LocalMotionState;
			}
			else
			{
				LocalMotionState = GetPlayerGameObject().GetComponent<VRCMotionState>();
				return LocalMotionState;
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
				UnfreezePlayerOnce = false;

			}
		}




		private static bool UnfreezePlayerOnce;

		public static VRCMotionState LocalMotionState;

		public static QMToggleButton FreezePlayerOnQMOpenToggle;


	}
}
