namespace AstroClient
{
    using AstroLibrary.Console;
    using System.Threading.Tasks;
    using UnityEngine;

    public class ColorEditor
    {
        public static void ChangeObjColor(GameObject obj, Color color)
        {
            if (obj != null)
            {
                var rend = obj.GetComponentInChildren<Renderer>(true);
                if (rend != null)
                {
                    rend.material.SetColor("_Color", color);
                    rend.material.color = color;
                }
                else
                {
                    ModConsole.Warning("Unable to get " + obj.name + " Renderer component.");
                }
            }
        }

        public static async void BlinkColorObject(GameObject obj, Color BlinkColor, Color OriginalColor)
        {
            ModConsole.Log("Setting Color of object : " + obj.name + " to : " + BlinkColor.ToString());
            ChangeObjColor(obj, BlinkColor);
            await Task.Delay(3000);
            ModConsole.Log("Setting Color of object : " + obj.name + " to : " + BlinkColor.ToString());
            ChangeObjColor(obj, OriginalColor);
        }
    }
}