﻿namespace AstroClient.Features.Player.Movement
{
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;
	using VRC.SDKBase;
	using static AstroClient.LocalPlayerUtils;

	public class JumpModifier : GameEvents
	{


		public override void OnUpdate()
		{
			CheckForJumpUpdates();
			FixJumpMissing();
		}

		public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
		{
			HasCheckedJump = false;
		}

		public static void OnLevelLoad()
		{
			IsJumpOverriden = false;
		}




		private static void FixJumpMissing()
		{
			try
			{
				if (Networking.LocalPlayer != null)
				{
					if (!HasCheckedJump)
					{
						if (Networking.LocalPlayer.GetJumpImpulse() == 0f)
						{
							HasCheckedJump = true;
							Networking.LocalPlayer.SetJumpImpulse(4);
						}
						else
						{
							HasCheckedJump = true;
						}
					}
				}
			}
			catch
			{
				HasCheckedJump = false;
			}
		}





		public static void CheckForJumpUpdates()
		{
			if (GetLocalVRCPlayer() != null)
			{
				if (GetLocalPlayerAPI() != null)
				{
					if (InputUtils.IsImputJumpCalled())
					{
						if (IsPlayerGrounded() && IsJumpOverriden)
						{
							EmulatedJump();
						}
						else
						{
							if (!IsPlayerGrounded() && IsUnlimitedJumpActive)
							{
								EmulatedJump();
							}
						}
					}

					if (InputUtils.IsInputJumpPressed() && IsRocketJumpActive)
					{
						EmulatedJump();
					}
				}
			}
		}

		public static void EmulatedJump()
		{
			Vector3 velocity = Networking.LocalPlayer.GetVelocity();
			velocity.y = Networking.LocalPlayer.GetJumpImpulse();
			Networking.LocalPlayer.SetVelocity(velocity);
		}




		private static bool HasCheckedJump = false;

		private static bool _IsUnlimitedJumpActive;

		public static QMSingleToggleButton UnlimitedJumpToggle;

		public static bool IsUnlimitedJumpActive
		{
			get
			{
				return _IsUnlimitedJumpActive;
			}
			set
			{
				_IsUnlimitedJumpActive = value;
				if (UnlimitedJumpToggle != null)
				{
					UnlimitedJumpToggle.SetToggleState(value);
				}
			}
		}


		public static QMSingleToggleButton RocketJumpToggle;

		private static bool _isRocketJumpActive;

		public static bool IsRocketJumpActive
		{
			get
			{
				return _isRocketJumpActive;
			}
			set
			{
				_isRocketJumpActive = value;
				if (RocketJumpToggle != null)
				{
					RocketJumpToggle.SetToggleState(value);
				}
			}
		}

		public static QMToggleButton JumpOverrideToggle;
		private static bool _IsJumpOverriden;

		public static bool IsJumpOverriden
		{
			get
			{
				return _IsJumpOverriden;
			}
			set
			{
				_IsJumpOverriden = value;
				if (JumpOverrideToggle != null)
				{
					JumpOverrideToggle.SetToggleState(value);
				}
			}
		}
	}
}