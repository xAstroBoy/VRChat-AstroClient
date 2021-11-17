namespace AstroClient.Tools.Extensions
{
    using System.Collections.Generic;
    using AstroMonos.Components.ESP.ItemTweaker;
    using AstroMonos.Components.ESP.Pickup;
    using AstroMonos.Components.ESP.Trigger;
    using AstroMonos.Components.ESP.UdonBehaviour;
    using AstroMonos.Components.ESP.VRCInteractable;
    using Colors;
    using UnityEngine;

    internal static class Esp_ext
    {
        internal static void Set_Pickup_ESP_Color(this GameObject obj, Color Color)
        {
            if (obj != null)
            {
                var ESP = obj.GetComponent<ESP_Pickup>();
                if (ESP != null)
                {
                    ESP.ChangeColor(Color);
                }
            }
        }

        internal static void Set_Pickup_ESP_Color(this GameObject obj, string Color)
        {
            Color hextocolor = ColorUtils.HexToColor(Color);
            if (obj != null)
            {
                var ESP = obj.GetComponent<ESP_Pickup>();
                if (ESP != null)
                {
                    ESP.ChangeColor(hextocolor);
                }
            }
        }

        internal static void Set_Pickup_ESP_Color(this List<GameObject> list, Color color)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    var ESP = obj.GetComponent<ESP_Pickup>();
                    if (ESP != null)
                    {
                        ESP.ChangeColor(color);
                    }
                }
            }
        }

        internal static void Set_Pickup_ESP_Color(this List<GameObject> list, string color)
        {
            Color hextocolor = ColorUtils.HexToColor(color);
            foreach (var obj in list)
            {
                var ESP = obj.GetComponent<ESP_Pickup>();
                if (ESP != null)
                {
                    ESP.ChangeColor(hextocolor);
                }
            }
        }

        internal static void Set_Trigger_ESP_Color(this GameObject obj, Color Color)
        {
            if (obj != null)
            {
                var ESP = obj.GetComponent<ESP_Trigger>();
                if (ESP != null)
                {
                    ESP.ChangeColor(Color);
                }
            }
        }

        internal static void Set_Trigger_ESP_Color(this GameObject obj, string Color)
        {
            if (obj != null)
            {
                var ESP = obj.GetComponent<ESP_Trigger>();
                if (ESP != null)
                {
                    ESP.ChangeColor(Color);
                }
            }
        }

        internal static void Set_Trigger_ESP_Color(this List<GameObject> list, Color color)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    var ESP = obj.GetComponent<ESP_Trigger>();
                    if (ESP != null)
                    {
                        ESP.ChangeColor(color);
                    }
                }
            }
        }

        internal static void Set_Trigger_ESP_Color(this List<GameObject> list, string color)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    var ESP = obj.GetComponent<ESP_Trigger>();
                    if (ESP != null)
                    {
                        ESP.ChangeColor(color);
                    }
                }
            }
        }

        internal static void Set_ItemTweaker_ESP_Color(this GameObject obj, Color Color)
        {
            if (obj != null)
            {
                var ESP = obj.GetComponent<ESP_ItemTweaker>();
                if (ESP != null)
                {
                    ESP.ChangeColor(Color);
                }
            }
        }

        internal static void Set_ItemTweaker_ESP_Color(this GameObject obj, string Color)
        {
            if (obj != null)
            {
                var ESP = obj.GetComponent<ESP_ItemTweaker>();
                if (ESP != null)
                {
                    ESP.ChangeColor(Color);
                }
            }
        }

        internal static void Set_ItemTweaker_ESP_Color(this List<GameObject> list, Color color)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    var ESP = obj.GetComponent<ESP_ItemTweaker>();
                    if (ESP != null)
                    {
                        ESP.ChangeColor(color);
                    }
                }
            }
        }

        internal static void Set_ItemTweaker_ESP_Color(this List<GameObject> list, string color)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    var ESP = obj.GetComponent<ESP_ItemTweaker>();
                    if (ESP != null)
                    {
                        ESP.ChangeColor(color);
                    }
                }
            }
        }

        internal static void Set_UdonBehaviour_ESP_Color(this GameObject obj, Color Color)
        {
            if (obj != null)
            {
                var ESP = obj.GetComponent<ESP_UdonBehaviour>();
                if (ESP != null)
                {
                    ESP.ChangeColor(Color);
                }
            }
        }

        internal static void Set_UdonBehaviour_ESP_Color(this GameObject obj, string Color)
        {
            if (obj != null)
            {
                var ESP = obj.GetComponent<ESP_UdonBehaviour>();
                if (ESP != null)
                {
                    ESP.ChangeColor(Color);
                }
            }
        }

        internal static void Set_UdonBehaviour_ESP_Color(this List<GameObject> list, Color color)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    var ESP = obj.GetComponent<ESP_UdonBehaviour>();
                    if (ESP != null)
                    {
                        ESP.ChangeColor(color);
                    }
                }
            }
        }

        internal static void Set_UdonBehaviour_ESP_Color(this List<GameObject> list, string color)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    var ESP = obj.GetComponent<ESP_UdonBehaviour>();
                    if (ESP != null)
                    {
                        ESP.ChangeColor(color);
                    }
                }
            }
        }

        internal static void Set_VRCInteractable_ESP_Color(this GameObject obj, Color Color)
        {
            if (obj != null)
            {
                var ESP = obj.GetComponent<ESP_VRCInteractable>();
                if (ESP != null)
                {
                    ESP.ChangeColor(Color);
                }
            }
        }

        internal static void Set_VRCInteractable_ESP_Color(this GameObject obj, string Color)
        {
            if (obj != null)
            {
                var ESP = obj.GetComponent<ESP_VRCInteractable>();
                if (ESP != null)
                {
                    ESP.ChangeColor(Color);
                }
            }
        }

        internal static void Set_VRCInteractable_ESP_Color(this List<GameObject> list, Color color)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    var ESP = obj.GetComponent<ESP_VRCInteractable>();
                    if (ESP != null)
                    {
                        ESP.ChangeColor(color);
                    }
                }
            }
        }

        internal static void Set_VRCInteractable_ESP_Color(this List<GameObject> list, string color)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                {
                    var ESP = obj.GetComponent<ESP_VRCInteractable>();
                    if (ESP != null)
                    {
                        ESP.ChangeColor(color);
                    }
                }
            }
        }
    }
}