namespace AstroClient
{
    using System.Collections.Generic;
    using UnityEngine;

    internal class PlayerCameraEditor : GameEvents
    {
        private static GameObject _PlayerCameraObject;
        internal static GameObject PlayerCameraObject
        {
            get
            {
                if (_PlayerCameraObject == null)
                {
                    return _PlayerCameraObject = GameObject.Find("Camera (eye)");
                }

                return _PlayerCameraObject;
            }
        }


        private static Camera _PlayerCamera;
        internal static Camera PlayerCamera
        {
            get
            {
                if (_PlayerCamera == null)
                {
                    return _PlayerCamera = PlayerCameraObject.GetComponent<Camera>();
                }

                return _PlayerCamera;
            }
        }


    }
}