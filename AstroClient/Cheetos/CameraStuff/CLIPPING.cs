namespace AstroClient
{
    using System.Collections.Generic;
    using UnityEngine;

    internal class CLIPPING : GameEvents
    {
        public static void Set_Camera_FarClipPlane(float v)
        {
            var gameObject = GameObject.Find("Camera (eye)");
            if (gameObject != null)
            {
                var component = gameObject.GetComponent<Camera>();
                if (component != null) component.farClipPlane = v;
            }
            ConfigManager.General.FarClipPlane = v;
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            Set_Camera_FarClipPlane(ConfigManager.General.FarClipPlane);
        }
    }
}