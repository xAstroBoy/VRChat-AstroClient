namespace AstroClient
{
	using DayClientML2.Utility.Extensions;
	using System;
	using UnityEngine;
	using VRC.Animation;

	/// <summary>
	/// Thanks to Blaze <3
	/// Slight modifications by Cheetos.
	/// </summary>
	class Flight : GameEvents
	{
		private static Vector3 Gravity;
		private static VRCPlayer currentPlayer;
		private static bool isInVR;
		private static Transform transform;
		private static VRCMotionState motionState;
		private static bool flyEnabled;
		private static bool noClipEnabled;

		// Broken for some reason, gotta investigate
		//public override void OnWorldReveal(string id, string Name, string AssetURL)
		//{
		//	FlyEnabled = false;
		//	NoClipEnabled = false;
		//}

		public static void SetDesktopFlySpeed(float v)
		{
			ConfigManager.Flight.DesktopFlySpeed = v;
		}

		public static void SetVRFlySpeed(float v)
		{
			ConfigManager.Flight.VRFlySpeed = v;
		}

		public static bool FlyEnabled
		{
			get => flyEnabled;
			set
			{
				if (value)
				{
					Gravity = Physics.gravity;
					Physics.gravity = Vector3.zero;
				}
				else
				{
					Physics.gravity = Gravity;
					if (noClipEnabled)
					{
						LocalPlayerUtils.GetLocalVRCPlayer().gameObject.GetComponent<CharacterController>().enabled = true;
					}
				}
				flyEnabled = value;
			}
		}

		public static bool NoClipEnabled
		{
			get => noClipEnabled;
			set
			{
				noClipEnabled = value;
				LocalPlayerUtils.GetLocalVRCPlayer().gameObject.GetComponent<CharacterController>().enabled = !value;
				
				if (!value && flyEnabled)
				{
					FlyEnabled = false;
				}
			}
		}

		public override void OnUpdate()
		{
			if (RoomManagerExtension.GetWorldInstance() == null || PopupManager.IsTyping)
			{
				return;
			}

			try
			{
				if (currentPlayer == null || transform == null)
				{
					currentPlayer = LocalPlayerUtils.GetLocalVRCPlayer();
					isInVR = MiscExtension.IsInVR();
					transform = Camera.main.transform;
				}

				/*if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F))
                {
                    if (!GlobalSettings.Fly)
                        Buttons.Fly.setToggleState(true, true);
                    else
                        Buttons.Fly.setToggleState(false, true);
                }

                if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.G))
                {
                    if (!GlobalSettings.NoClip)
                        Buttons.NoClip.setToggleState(true, true);
                    else
                        Buttons.NoClip.setToggleState(false, true);
                }*/


				if (FlyEnabled)
				{
					float flySpeed = isInVR ? ConfigManager.Flight.VRFlySpeed : ConfigManager.Flight.DesktopFlySpeed;

					if (Input.GetKey(KeyCode.LeftShift))
					{
						flySpeed *= 2;
					}

					if (ConfigManager.Flight.BasicFly)
					{
						if (isInVR)
						{
							if (Math.Abs(Input.GetAxis("Vertical")) != 0f)
								currentPlayer.transform.position += currentPlayer.transform.forward *
																	flySpeed * Time.deltaTime *
																	Input.GetAxis("Vertical");

							if (Math.Abs(Input.GetAxis("Horizontal")) != 0f)
								currentPlayer.transform.position += currentPlayer.transform.right *
																	flySpeed * Time.deltaTime *
																	Input.GetAxis("Horizontal");

							if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") < 0f)
								currentPlayer.transform.position += currentPlayer.transform.up *
																	flySpeed * Time.deltaTime *
																	Input.GetAxisRaw(
																		"Oculus_CrossPlatform_SecondaryThumbstickVertical");
							if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0f)
								currentPlayer.transform.position += currentPlayer.transform.up *
																	flySpeed * Time.deltaTime *
																	Input.GetAxisRaw(
																		"Oculus_CrossPlatform_SecondaryThumbstickVertical");
						}
						else
						{
							if (Input.GetKey(KeyCode.E))
								currentPlayer.transform.position += currentPlayer.transform.up *
																	flySpeed * Time.deltaTime;

							if (Input.GetKey(KeyCode.Q))
								currentPlayer.transform.position += currentPlayer.transform.up * -1 *
																	flySpeed * Time.deltaTime;

							if (Input.GetKey(KeyCode.W))
								currentPlayer.transform.position += currentPlayer.transform.forward *
																	flySpeed * Time.deltaTime;

							if (Input.GetKey(KeyCode.A))
								currentPlayer.transform.position += currentPlayer.transform.right * -1f *
																	flySpeed * Time.deltaTime;

							if (Input.GetKey(KeyCode.D))
								currentPlayer.transform.position += currentPlayer.transform.right *
																	flySpeed * Time.deltaTime;

							if (Input.GetKey(KeyCode.S))
								currentPlayer.transform.position += currentPlayer.transform.forward * -1f *
																	flySpeed * Time.deltaTime;
						}
					}
					else
					{
						if (isInVR)
						{
							if (Math.Abs(Input.GetAxis("Vertical")) != 0f)
								currentPlayer.transform.position += transform.transform.forward *
																	flySpeed * Time.deltaTime *
																	Input.GetAxis("Vertical");

							if (Math.Abs(Input.GetAxis("Horizontal")) != 0f)
								currentPlayer.transform.position += transform.transform.right *
																	flySpeed * Time.deltaTime *
																	Input.GetAxis("Horizontal");

							if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") < 0f)
								currentPlayer.transform.position += transform.transform.up *
																	flySpeed * Time.deltaTime *
																	Input.GetAxisRaw(
																		"Oculus_CrossPlatform_SecondaryThumbstickVertical");
							if (Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical") > 0f)
								currentPlayer.transform.position += transform.transform.up *
																	flySpeed * Time.deltaTime *
																	Input.GetAxisRaw(
																		"Oculus_CrossPlatform_SecondaryThumbstickVertical");
						}
						else
						{
							if (Input.GetKey(KeyCode.E))
								currentPlayer.transform.position += transform.transform.up *
																	flySpeed * Time.deltaTime;

							if (Input.GetKey(KeyCode.Q))
								currentPlayer.transform.position += transform.transform.up * -1 *
																	flySpeed * Time.deltaTime;

							if (Input.GetKey(KeyCode.W))
								currentPlayer.transform.position += transform.transform.forward *
																	flySpeed * Time.deltaTime;

							if (Input.GetKey(KeyCode.A))
								currentPlayer.transform.position += transform.transform.right * -1f *
																	flySpeed * Time.deltaTime;

							if (Input.GetKey(KeyCode.D))
								currentPlayer.transform.position += transform.transform.right *
																	flySpeed * Time.deltaTime;

							if (Input.GetKey(KeyCode.S))
								currentPlayer.transform.position += transform.transform.forward * -1f *
																	flySpeed * Time.deltaTime;
						}
					}
				}
				if (motionState != null)
				{
					motionState.Reset();
					if (motionState.field_Private_CharacterController_0 != null)
						motionState.field_Private_CharacterController_0.enabled = !NoClipEnabled;
				}
			}
			catch { }
		}
	}
}
