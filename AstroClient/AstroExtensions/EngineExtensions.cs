using UnityEngine;
using VRC.SDKBase;
using Color = System.Drawing.Color;

#region AstroClient Imports

using AstroClient.Cloner;
using AstroClient.ConsoleUtils;
using AstroClient.AstroUtils.ItemTweaker;
using AstroClient.ItemTweaker;

#endregion AstroClient Imports

namespace AstroClient.extensions
{
    public static class EngineExtensions
    {
        public static void DestroyObject(this GameObject obj)
        {
            if (!obj.DestroyMeOnline())
            {
                obj.DestroyMeLocal();
            }
        }

        public static GameObject InstantiateObject(this GameObject obj)
        {
            if (obj != null)
            {
                return UnityEngine.Object.Instantiate(obj);
            }
            return null;
        }

        public static void CloneObject(this GameObject obj)
        {
            if (obj != null)
            {
                ObjectCloner.CloneGameObject(obj);
            }
        }

        public static bool DestroyMeOnline(this GameObject obj)
        {
            bool refreshhandutils = false;
            if (Tweaker_Object.CurrentSelectedObject == obj.transform)
            {
                refreshhandutils = true;
            }
            var name = obj.name;
            if (obj != null)
            {
                OnlineEditor.TakeObjectOwnership(obj);
                Networking.Destroy(obj);
            }
            if (obj != null)
            {
                ModConsole.Log("Failed To Destroy Server-side  Object :  " + obj.name, Color.Red);
                return false;
            }
            else
            {
                ModConsole.Log("Destroyed Server-side Object : " + name, Color.Green);
                if (refreshhandutils)
                {
                    Tweaker_Object.CurrentSelectedObject = null;
                }
                return true;
            }
        }

        public static void DestroyMeLocal(this UnityEngine.Object obj)
        {
            if (obj != null)
            {
                var name = obj.name;
                if (obj != null)
                {
                    UnityEngine.Object.DestroyImmediate(obj);
                }
                if (obj != null)
                {
                    UnityEngine.Object.Destroy(obj);
                }
                if (obj != null)
                {
                    UnityEngine.Object.DestroyObject(obj);
                }
                if (obj != null)
                {
                    ModConsole.Log("Failed To Destroy Object : " + obj.name, Color.Red);
                    ModConsole.Log("Try To Destroy His GameObject in case you are trying to destroy the transform.", Color.Yellow);
                }
                else
                {
                    ModConsole.Log("Destroyed Client-side Object : " + name, Color.Green);
                }
            }
        }

        public static void RenameObject(this GameObject obj, string newname)
        {
            if (obj != null)
            {
                var oldname = obj.name;
                ModConsole.DebugLog("Renamed object : " + oldname + " to " + newname);
                obj.name = newname;
            }
        }

        public static void SetActiveStatus(this GameObject obj, bool SetActive)
        {
            if (obj != null)
            {
                obj.SetActive(SetActive);
                Tweaker_Object.UpdateCapturedButtonColor(obj.active);
            }
            if (ItemTweakerMain.ObjectActiveToggle != null)
            {
                ItemTweakerMain.ObjectActiveToggle.setToggleState(obj.active);
            }
        }
    }
}