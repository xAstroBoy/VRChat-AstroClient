namespace DayClientML2.Utility.Extensions
{
	using UnityEngine;

	internal class VRInput
    {
        public class Vive
        {
            public static ViveController Left => Left ?? new ViveController(HandType.Left);

            public static ViveController Right => Right ?? new ViveController(HandType.Right);
        }

        public class ViveController : VRController
        {
            public ViveController(HandType type)
            {
                Type = ControllerType.HTC;
                HandType = type;
                Grip = new VRButton()
                {
                    Name = type == HandType.Right ? "Oculus_CrossPlatform_SecondaryHandTrigger" : "Oculus_CrossPlatform_PrimaryHandTrigger",
                };
                TrackPad = new VRButton()
                {
                    Name = type == HandType.Right ? "Oculus_CrossPlatform_SecondaryThumbstick" : "Oculus_CrossPlatform_PrimaryThumbstick",
                };
                Vertical = new VRAxis()
                {
                    Name = type == HandType.Right ? "Oculus_CrossPlatform_SecondaryThumbstickVertical" : "Oculus_CrossPlatform_PrimaryThumbstickVertical",
                };
                Horizontal = new VRAxis()
                {
                    Name = type == HandType.Right ? "Oculus_CrossPlatform_SecondaryThumbstickHorizontal" : "Oculus_CrossPlatform_SecondaryThumbstickHorizontal",
                };
                Trigger = new VRAxis()
                {
                    Name = type == HandType.Right ? "Oculus_CrossPlatform_SecondaryIndexTrigger" : "Oculus_CrossPlatform_PrimaryIndexTrigger",
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
            public string Name { get; set; }

            public bool GetButtonDown
            {
                get
                {
                    return Input.GetKeyDown(Name);
                }
            }

            public bool GetButtonUp
            {
                get
                {
                    return Input.GetKeyUp(Name);
                }
            }

            public bool GetButton
            {
                get
                {
                    return Input.GetKey(Name);
                }
            }
        }

        public class VRAxis
        {
            public string Name { get; set; }

            public float GetAxis
            {
                get
                {
                    return Input.GetAxis(Name);
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