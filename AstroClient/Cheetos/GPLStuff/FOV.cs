namespace AstroClient
{
    using UnityEngine;

    class FOV
    {
        public static void Set_Camera_FOV(float v)
        {
            var gameObject = GameObject.Find("Camera (eye)");
            if (gameObject != null)
            {
                var component = gameObject.GetComponent<Camera>();
                if (component != null) component.fieldOfView = v;
            }
        }
    }
}
