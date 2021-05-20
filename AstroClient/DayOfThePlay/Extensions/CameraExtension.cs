namespace DayClientML2.Utility.Extensions
{
	using System.Collections.Generic;
	using UnityEngine;
	using VRC.UserCamera;

	internal static class CameraExtension
	{
		public static void ResetCamera()
		{
			SetCameraMode(CameraMode.Off);
			SetCameraMode(CameraMode.Photo);
			UserCameraController userCameraController = Utils.UserCameraController;
			WorldCameraVector = userCameraController.field_Public_Transform_0.transform.position;
			WorldCameraQuaternion = userCameraController.field_Public_Transform_0.transform.rotation;
			WorldCameraQuaternion *= Quaternion.Euler(90f, 0f, 180f);
			userCameraController.field_Internal_UserCameraIndicator_0.transform.position = userCameraController.field_Public_Transform_0.transform.position;
			userCameraController.field_Internal_UserCameraIndicator_0.transform.rotation = userCameraController.field_Public_Transform_0.transform.rotation;
		}

		public static void RotateAround(Vector3 center, Vector3 axis, float angle)
		{
			Vector3 worldCameraVector = CameraExtension.WorldCameraVector;
			Quaternion quaternion = Quaternion.AngleAxis(angle, axis);
			Vector3 vector = worldCameraVector - center;
			vector = quaternion * vector;
			CameraExtension.WorldCameraVector = center + vector;
			Quaternion worldCameraQuaternion = CameraExtension.WorldCameraQuaternion;
			CameraExtension.WorldCameraQuaternion *= Quaternion.Inverse(worldCameraQuaternion) * quaternion * worldCameraQuaternion;
		}

		public static void TakePicture(int timer)
		{
			UserCameraController userCameraController = Utils.UserCameraController;
			userCameraController.field_Private_Single_0 = 0f;
			userCameraController.StartCoroutine(userCameraController.Method_Private_IEnumerator_Int32_PDM_0(timer));
		}

		public static void Disable()
		{
			UserCameraController userCameraController = Utils.UserCameraController;
			userCameraController.enabled = false;
		}

		public static void Enable()
		{
			UserCameraController userCameraController = Utils.UserCameraController;
			userCameraController.enabled = true;
			userCameraController.StopAllCoroutines();
		}

		public static void PictureRPC(VRC.Player Target)
		{
			UserCameraIndicator userCameraController = Utils.UserCameraController.field_Internal_UserCameraIndicator_0;
			userCameraController.PhotoCapture(Target);
		}

		public static Dictionary<string, int> Filters()
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>
			{
				{ "None", 0 },
				{ "Blueprint", 10 },
				{ "Code", 4 },
				{ "Sparkles", 5 },
				{ "Green\nScreen", 7 },
				{ "Hypno", 6 },
				{ "Alpha\nTransparent", 8 },
				{ "Drawing", 9 },
				{ "Glitch", 3 },
				{ "Pixelate", 2 },
				{ "Old Timey", 1 },
				{ "Trippy", 11 }
			};
			return dictionary;
		}

		public static void SetCameraMode(CameraMode mode)
		{
			Utils.UserCameraController.field_Private_UserCameraMode_0 = (UserCameraMode)mode;
		}

		public static void SetCameraSpace(CameraSpace mode)
		{
			Utils.UserCameraController.field_Private_UserCameraSpace_0 = (UserCameraSpace)mode;
		}

		public static void SetCameraSpace(CameraBehaviour mode)
		{
			Utils.UserCameraController.field_Private_UserCameraMovementBehaviour_0 = (UserCameraMovementBehaviour)mode;
		}

		public static void CycleCameraBehaviour()
		{
			Utils.UserCameraController.field_Public_Transform_0.transform.Find("PhotoControls/Left_CameraMode").GetComponent<CameraInteractable>().Interact();
		}

		public static void CycleCameraSpace()
		{
			Utils.UserCameraController.field_Public_Transform_0.transform.Find("PhotoControls/Left_Space").GetComponent<CameraInteractable>().Interact();
		}

		public static void TogglePinMenu()
		{
			Utils.UserCameraController.field_Public_Transform_0.transform.Find("PhotoControls/Left_Pins").GetComponent<CameraInteractable>().Interact();
		}

		public static void ToggleLock()
		{
			Utils.UserCameraController.field_Public_Transform_0.transform.Find("PhotoControls/Right_Lock").GetComponent<CameraInteractable>().Interact();
		}

		public static Vector3 WorldCameraVector
		{
			get
			{
				return Utils.UserCameraController.field_Private_Vector3_0;
			}
			set
			{
				Utils.UserCameraController.field_Private_Vector3_0 = value;
			}
		}

		public static Quaternion WorldCameraQuaternion
		{
			get
			{
				return Utils.UserCameraController.field_Private_Quaternion_0;
			}
			set
			{
				Utils.UserCameraController.field_Private_Quaternion_0 = value;
			}
		}

		public static CameraBehaviour GetCameraBehaviour()
		{
			return (CameraBehaviour)Utils.UserCameraController.field_Private_UserCameraMovementBehaviour_0;
		}

		public static CameraSpace GetCameraSpace()
		{
			return (CameraSpace)Utils.UserCameraController.field_Private_UserCameraSpace_0;
		}

		public static Pin GetCurrentPin()
		{
			return (Pin)Utils.UserCameraController.prop_Int32_0;
		}

		public enum CameraMode
		{
			Off,
			Photo,
			Video
		}

		public enum CameraScale
		{
			Normal,
			Medium,
			Big
		}

		public enum CameraBehaviour
		{
			None,
			Smooth,
			LookAt
		}

		public enum CameraSpace
		{
			Attached,
			Local,
			World,
			COUNT
		}

		public enum Pin
		{
			Pin1,
			Pin2,
			Pin3
		}
	}
}