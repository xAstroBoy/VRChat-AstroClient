namespace AstroClient
{
    using System.Collections.Generic;
    using UnityEngine;

    internal class FOV : GameEvents
    {
        internal static  void Set_Camera_FOV(float v)
        {
            var gameObject = GameObject.Find("Camera (eye)");
            if (gameObject != null)
            {
                var component = gameObject.GetComponent<Camera>();
                if (component != null) component.fieldOfView = v;
            }
            ConfigManager.General.FOV = v;
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            Set_Camera_FOV(ConfigManager.General.FOV);
        }
    }
}