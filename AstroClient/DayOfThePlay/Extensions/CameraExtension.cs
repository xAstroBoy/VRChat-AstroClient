using System.Collections.Generic;
using UnityEngine;
using VRC.UserCamera;

namespace DayClientML2.Utility.Extensions
{
    internal static class CameraExtension
    {
        public static void ResetCamera()
        {
            CameraExtension.SetCameraMode(CameraExtension.CameraMode.Off);
            CameraExtension.SetCameraMode(CameraExtension.CameraMode.Photo);
            UserCameraController userCameraController = Utils.UserCameraController;
            CameraExtension.worldCameraVector = userCameraController.field_Public_Transform_0.transform.position;
            CameraExtension.worldCameraQuaternion = userCameraController.field_Public_Transform_0.transform.rotation;
            CameraExtension.worldCameraQuaternion *= Quaternion.Euler(90f, 0f, 180f);
            userCameraController.field_Internal_UserCameraIndicator_0.transform.position = userCameraController.field_Public_Transform_0.transform.position;
            userCameraController.field_Internal_UserCameraIndicator_0.transform.rotation = userCameraController.field_Public_Transform_0.transform.rotation;
        }

        public static void RotateAround(Vector3 center, Vector3 axis, float angle)
        {
            Vector3 worldCameraVector = CameraExtension.worldCameraVector;
            Quaternion quaternion = Quaternion.AngleAxis(angle, axis);
            Vector3 vector = worldCameraVector - center;
            vector = quaternion * vector;
            CameraExtension.worldCameraVector = center + vector;
            Quaternion worldCameraQuaternion = CameraExtension.worldCameraQuaternion;
            CameraExtension.worldCameraQuaternion *= Quaternion.Inverse(worldCameraQuaternion) * quaternion * worldCameraQuaternion;
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
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("None", 0);
            dictionary.Add("Blueprint", 10);
            dictionary.Add("Code", 4);
            dictionary.Add("Sparkles", 5);
            dictionary.Add("Green\nScreen", 7);
            dictionary.Add("Hypno", 6);
            dictionary.Add("Alpha\nTransparent", 8);
            dictionary.Add("Drawing", 9);
            dictionary.Add("Glitch", 3);
            dictionary.Add("Pixelate", 2);
            dictionary.Add("Old Timey", 1);
            dictionary.Add("Trippy", 11);
            return dictionary;
        }

        public static void SetCameraMode(CameraExtension.CameraMode mode)
        {
            Utils.UserCameraController.field_Private_UserCameraMode_0 = (UserCameraMode)mode;
        }

        public static void SetCameraSpace(CameraExtension.CameraSpace mode)
        {
            Utils.UserCameraController.field_Private_UserCameraSpace_0 = (UserCameraSpace)mode;
        }

        public static void SetCameraSpace(CameraExtension.CameraBehaviour mode)
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

        public static Vector3 worldCameraVector
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

        public static Quaternion worldCameraQuaternion
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

        public static CameraExtension.CameraBehaviour GetCameraBehaviour()
        {
            return (CameraExtension.CameraBehaviour)Utils.UserCameraController.field_Private_UserCameraMovementBehaviour_0;
        }

        public static CameraExtension.CameraSpace GetCameraSpace()
        {
            return (CameraExtension.CameraSpace)Utils.UserCameraController.field_Private_UserCameraSpace_0;
        }

        public static CameraExtension.Pin GetCurrentPin()
        {
            return (CameraExtension.Pin)Utils.UserCameraController.prop_Int32_0;
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