// Credits to Blaze and DayOfThePlay

namespace AstroClient.xAstroBoy.Utility
{
    using System.Collections.Generic;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using UnityEngine.XR;
    using VRC.UserCamera;

    public static class CameraUtils
    {
        public static void ResetCamera()
        {
            SetCameraMode(CameraMode.Off);
            SetCameraMode(CameraMode.Photo);
            UserCameraController userCameraController = GameInstances.UserCameraController;
            WorldCameraVector = userCameraController.field_Public_Transform_0.transform.position;
            WorldCameraQuaternion = userCameraController.field_Public_Transform_0.transform.rotation;
            WorldCameraQuaternion *= Quaternion.Euler(90f, 0f, 180f);
            userCameraController.field_Internal_UserCameraIndicator_0.transform.position = userCameraController.field_Public_Transform_0.transform.position;
            userCameraController.field_Internal_UserCameraIndicator_0.transform.rotation = userCameraController.field_Public_Transform_0.transform.rotation;
        }

        public static void RotateAround(Vector3 center, Vector3 axis, float angle)
        {
            Vector3 worldCameraVector = WorldCameraVector;
            Quaternion quaternion = Quaternion.AngleAxis(angle, axis);
            Vector3 vector = worldCameraVector - center;
            vector = quaternion * vector;
            WorldCameraVector = center + vector;
            Quaternion worldCameraQuaternion = WorldCameraQuaternion;
            WorldCameraQuaternion *= Quaternion.Inverse(worldCameraQuaternion) * quaternion * worldCameraQuaternion;
        }

        public static void TakePicture(int timer)
        {
            UserCameraController userCameraController = GameInstances.UserCameraController;
            userCameraController.field_Private_Single_0 = 0f;
            userCameraController.StartCoroutine(userCameraController.Method_Private_IEnumerator_Int32_PDM_0(timer));
        }

        public static void Disable()
        {
            UserCameraController userCameraController = GameInstances.UserCameraController;
            userCameraController.enabled = false;
        }

        public static void Enable()
        {
            UserCameraController userCameraController = GameInstances.UserCameraController;
            userCameraController.enabled = true;
            userCameraController.StopAllCoroutines();
        }

        public static void PictureRPC(VRC.Player Target)
        {
            UserCameraIndicator userCameraController = GameInstances.UserCameraController.field_Internal_UserCameraIndicator_0;
            userCameraController.PhotoCapture(Target);
        }

        public static Vector3 GetWorldCameraPosition()
        {
            VRCVrCamera camera = GameInstances.VRCVrCamera;
            var type = camera.GetIl2CppType();
            if (type == Il2CppType.Of<VRCVrCameraSteam>())
            {
                VRCVrCameraSteam steam = camera.Cast<VRCVrCameraSteam>();
                Transform transform1 = steam.field_Private_Transform_0;
                Transform transform2 = steam.field_Private_Transform_1;
                if (transform1.name == "Camera (eye)")
                {
                    return transform1.position;
                }
                if (transform2.name == "Camera (eye)")
                {
                    return transform2.position;
                }
            }
            if (type == Il2CppType.Of<VRCVrCameraUnity>())
            {
                VRCVrCameraUnity unity = camera.Cast<VRCVrCameraUnity>();
                return unity.field_Public_Camera_0.transform.position;
            }
            if (type == Il2CppType.Of<VRCVrCameraWave>())
            {
                VRCVrCameraWave wave = camera.Cast<VRCVrCameraWave>();
                return wave.transform.position;
            }
            return camera.transform.parent.TransformPoint(GetLocalCameraPosition());
        }

        public static Vector3 GetLocalCameraPosition()
        {
            VRCVrCamera camera = GameInstances.VRCVrCamera;
            var type = camera.GetIl2CppType();
            if (type == Il2CppType.Of<VRCVrCamera>())
            {
                return camera.transform.localPosition;
            }
            if (type == Il2CppType.Of<VRCVrCameraSteam>())
            {
                VRCVrCameraSteam steam = camera.Cast<VRCVrCameraSteam>();
                Transform transform1 = steam.field_Private_Transform_0;
                Transform transform2 = steam.field_Private_Transform_1;
                if (transform1.name == "Camera (eye)")
                {
                    return camera.transform.parent.InverseTransformPoint(transform1.position);
                }
                if (transform2.name == "Camera (eye)")
                {
                    return camera.transform.parent.InverseTransformPoint(transform2.position);
                }
                else
                {
                    return Vector3.zero;
                }
            }
            if (type == Il2CppType.Of<VRCVrCameraUnity>())
            {
                if (PlayerUtils.IsInVR())
                {
                    return camera.transform.localPosition + InputTracking.GetLocalPosition(XRNode.CenterEye);
                }
                VRCVrCameraUnity unity = camera.Cast<VRCVrCameraUnity>();
                return camera.transform.parent.InverseTransformPoint(unity.field_Public_Camera_0.transform.position);
            }
            if (type == Il2CppType.Of<VRCVrCameraWave>())
            {
                VRCVrCameraWave wave = camera.Cast<VRCVrCameraWave>();
                return wave.field_Public_Transform_0.InverseTransformPoint(camera.transform.position);
            }
            return Vector3.zero;
        }

        public static Dictionary<string, int> Filters
        {
            get
            {
                return new Dictionary<string, int>{
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
            }
        }

        public static void SetCameraMode(CameraMode mode)
        {
            GameInstances.UserCameraController.field_Private_UserCameraMode_0 = (UserCameraMode)mode;
        }

        public static void SetCameraSpace(CameraSpace mode)
        {
            GameInstances.UserCameraController.field_Private_UserCameraSpace_0 = (UserCameraSpace)mode;
        }

        //public static void SetCameraSpace(CameraBehaviour mode)
        //{
        //    Utils.UserCameraController.field_Private_UserCameraMode_0 = (UserCameraMovementBehaviour)mode;
        //}

        //public static void CycleCameraBehaviour()
        //{
        //    Utils.UserCameraController.field_Public_Transform_0.transform.Find("PhotoControls/Left_CameraMode").GetComponent<CameraInteractable>().Interact();
        //}

        //public static void CycleCameraSpace()
        //{
        //    Utils.UserCameraController.field_Public_Transform_0.transform.Find("PhotoControls/Left_Space").GetComponent<CameraInteractable>().Interact();
        //}

        //public static void TogglePinMenu()
        //{
        //    Utils.UserCameraController.field_Public_Transform_0.transform.Find("PhotoControls/Left_Pins").GetComponent<CameraInteractable>().Interact();
        //}

        //public static void ToggleLock()
        //{
        //    Utils.UserCameraController.field_Public_Transform_0.transform.Find("PhotoControls/Right_Lock").GetComponent<CameraInteractable>().Interact();
        //}

        public static Vector3 WorldCameraVector
        {
            get
            {
                return GameInstances.UserCameraController.field_Private_Vector3_0;
            }
            set
            {
                GameInstances.UserCameraController.field_Private_Vector3_0 = value;
            }
        }

        public static Quaternion WorldCameraQuaternion
        {
            get
            {
                return GameInstances.UserCameraController.field_Private_Quaternion_0;
            }
            set
            {
                GameInstances.UserCameraController.field_Private_Quaternion_0 = value;
            }
        }

        //public static CameraBehaviour GetCameraBehaviour()
        //{
        //    return (CameraBehaviour)Utils.UserCameraController.field_Private_UserCameraMovementBehaviour_0;
        //}

        public static CameraSpace GetCameraSpace()
        {
            return (CameraSpace)GameInstances.UserCameraController.field_Private_UserCameraSpace_0;
        }

        public static Pin GetCurrentPin()
        {
            return (Pin)GameInstances.UserCameraController.prop_Int32_0;
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