using UnityEngine;

namespace DayClientML2.Utility.Extensions
{
	internal class VRInput
	{
		public class Vive
		{
			public static ViveController Left
			{
				get
				{
					if (Left == null)
						return new ViveController(HandType.Left);
					return Left;
				}
			}

			public static ViveController Right
			{
				get
				{
					if (Right == null)
						return new ViveController(HandType.Right);
					return Right;
				}
			}
		}

		public class ViveController : VRController
		{
			public ViveController(HandType type)
			{
				Type = ControllerType.HTC;
				HandType = type;
				Grip = new VRButton()
				{
					name = type == HandType.Right ? "Oculus_CrossPlatform_SecondaryHandTrigger" : "Oculus_CrossPlatform_PrimaryHandTrigger",
				};
				TrackPad = new VRButton()
				{
					name = type == HandType.Right ? "Oculus_CrossPlatform_SecondaryThumbstick" : "Oculus_CrossPlatform_PrimaryThumbstick",
				};
				Vertical = new VRAxis()
				{
					name = type == HandType.Right ? "Oculus_CrossPlatform_SecondaryThumbstickVertical" : "Oculus_CrossPlatform_PrimaryThumbstickVertical",
				};
				Horizontal = new VRAxis()
				{
					name = type == HandType.Right ? "Oculus_CrossPlatform_SecondaryThumbstickHorizontal" : "Oculus_CrossPlatform_SecondaryThumbstickHorizontal",
				};
				Trigger = new VRAxis()
				{
					name = type == HandType.Right ? "Oculus_CrossPlatform_SecondaryIndexTrigger" : "Oculus_CrossPlatform_PrimaryIndexTrigger",
				};
			}

			public VRButton Grip { get; set; }

			public VRButton TrackPad { get; set; }

			public VRAxis Vertical { get; set; }

			public VRAxis Horizontal { get; set; }

			public VRAxis Trigger { get; set; }
		}

		public class VRController
		{
			public ControllerType Type { get; set; }

			public HandType HandType { get; set; }

			public float Battery { get; }
		}

		public class VRButton
		{
			public string name { get; set; }

			public bool GetButtonDown
			{
				get
				{
					return Input.GetKeyDown(name);
				}
			}

			public bool GetButtonUp
			{
				get
				{
					return Input.GetKeyUp(name);
				}
			}

			public bool GetButton
			{
				get
				{
					return Input.GetKey(name);
				}
			}
		}

		public class VRAxis
		{
			public string name { get; set; }

			public float GetAxis
			{
				get
				{
					return Input.GetAxis(name);
				}
			}
		}

		public enum ButtonAction
		{
			GetButtonDown,
			GetButtonUp,
			GetButton
		}

		public enum ControllerType
		{
			Valve,
			HTC,
			OCULUS,
		}

		public enum HandType
		{
			Left,
			Right,
			Any
		}
	}
}