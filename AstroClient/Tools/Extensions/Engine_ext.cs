namespace AstroClient.Tools.Extensions
{
    #region Imports

    using System.Collections.Generic;
    using System.Windows.Forms;
    using AstroMonos;
    using Colors;
    using ObjectEditor.Cloner;
    using ObjectEditor.Online;
    using UnityEngine;
    using VRC.SDK3.Components;
    using VRC.SDKBase;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.PageGenerators;
    using xAstroBoy.Utility;
    using Color = System.Drawing.Color;

    #endregion Imports

    internal static class Engine_ext
    {
        internal static void DestroyChildren(this Transform parent)
        {
            for (var i = parent.childCount; i > 0; i--)
                UnityEngine.Object.DestroyImmediate(parent.GetChild(i - 1).gameObject);
        }

        internal static GameObject NoUnload(this GameObject obj)
        {
            obj.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            return obj;
        }

        internal static void PrintPath(this GameObject obj)
        {
            if (obj != null)
            {
                string path = GameObjectFinder.GetGameObjectPath(obj);
                if (!string.IsNullOrEmpty(path) && !string.IsNullOrWhiteSpace(path))
                {
                    ModConsole.Log($"{obj.name} Path is : {path}");
                }
            }
        }

        internal static void FlipTransformRotation(this  Transform transform)
        {
            Vector3 rot = transform.rotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y + 180, rot.z);
            transform.rotation = Quaternion.Euler(rot);

        }
        internal static string GetPath(this GameObject obj)
        {
            if (obj != null)
            {
                string path = GameObjectFinder.GetGameObjectPath(obj);
                return !string.IsNullOrEmpty(path) && !string.IsNullOrWhiteSpace(path) ? $"{obj.name} Path is : {path}" : "No Path Found";
            }
            return "Object is Null";
        }

        internal static UnityEngine.Color Get_Transform_Active_ToColor(this Transform obj)
        {
            return obj.gameObject.Get_GameObject_Active_ToColor();
        }

        internal static UnityEngine.Color Get_GameObject_Active_ToColor(this GameObject obj)
        {
            return obj != null ? obj.active ? UnityEngine.Color.green : UnityEngine.Color.red : UnityEngine.Color.red;
        }

        internal static UnityEngine.Color Get_AudioSource_Active_ToColor(this AudioSource obj)
        {
            return obj != null ? obj.enabled ? UnityEngine.Color.green : UnityEngine.Color.red : UnityEngine.Color.red;
        }

        internal static UnityEngine.Color Get_MonoBehaviour_Enabled_ToColor(this MonoBehaviour obj)
        {
            return obj != null ? obj.enabled ? UnityEngine.Color.green : UnityEngine.Color.red : UnityEngine.Color.red;
        }

        internal static bool? Is_DontDestroyOnLoad(this GameObject obj)
        {
            return obj != null ? obj.scene.name.Equals("DontDestroyOnLoad") : (bool?)null;
        }

        internal static bool? Is_DontDestroyOnLoad(this Transform obj)
        {
            return obj?.gameObject.Is_DontDestroyOnLoad();
        }

        internal static void Set_DontDestroyOnLoad(this Object obj)
        {
            UnityEngine.Object.DontDestroyOnLoad(obj);
        }

        internal static bool? Is_HideAndDontSave(this GameObject obj)
        {
            try
            {
                return obj != null ? obj.scene.name.Equals("HideAndDontSave") : (bool?)null;
            }
            catch { return false; }
        }

        internal static bool? Is_HideAndDontSave(this Transform obj)
        {
            return obj?.gameObject.Is_HideAndDontSave();
        }

        internal static bool? Is_CurrentWorld(this GameObject obj)
        {
            return obj != null ? !obj.Is_HideAndDontSave().Value && !obj.Is_DontDestroyOnLoad().Value : (bool?)null;
        }

        internal static bool? Is_CurrentWorld(this Transform obj)
        {
            return obj?.gameObject.Is_CurrentWorld();
        }

        internal static void CopyPath(this GameObject obj)
        {
            if (obj != null)
            {
                string path = GameObjectFinder.GetGameObjectPath(obj);
                if (!string.IsNullOrEmpty(path) && !string.IsNullOrWhiteSpace(path))
                {
                    ModConsole.Log($"{obj.name} Path is : {path}");
                    ModConsole.Log($"The Path has been copied on the clipboard.");
                    Clipboard.SetText(path);
                }
            }
        }

        internal static void CopyRotation(this GameObject obj)
        {
            if (obj != null)
            {
                ModConsole.Log($"{obj.name} rotation is : new Quaternion({obj.transform.rotation.x}f, {obj.transform.rotation.y}f, {obj.transform.rotation.z}f, {obj.transform.rotation.w}f)");
                ModConsole.Log($"The rotation has been copied on the clipboard.");
                Clipboard.SetText($"new Quaternion({obj.transform.rotation.x}f, {obj.transform.rotation.y}f, {obj.transform.rotation.z}f, {obj.transform.rotation.w}f)");
            }
        }

        internal static void CopyPosition(this GameObject obj)
        {
            if (obj != null)
            {
                ModConsole.Log($"{obj.name} position is : new Vector3({obj.transform.position.x}f, {obj.transform.position.y}f, {obj.transform.position.z}f)");
                ModConsole.Log($"The Position has been copied on the clipboard.");
                Clipboard.SetText($"new Vector3({obj.transform.position.x}f, {obj.transform.position.y}f, {obj.transform.position.z}f)");
            }
        }

        internal static void CopyLocalPosition(this GameObject obj)
        {
            if (obj != null)
            {
                ModConsole.Log($"{obj.name} Local position is : new Vector3({obj.transform.localPosition.x}f, {obj.transform.localPosition.y}f, {obj.transform.localPosition.z}f)");
                ModConsole.Log($"The Local Position has been copied on the clipboard.");
                Clipboard.SetText($"new Vector3({obj.transform.localPosition.x}f, {obj.transform.localPosition.y}f, {obj.transform.localPosition.z}f)");
            }
        }

        internal static void CopyLocalRotation(this GameObject obj)
        {
            if (obj != null)
            {
                ModConsole.Log($"{obj.name} localRotation is : new Quaternion({obj.transform.localRotation.x}f, {obj.transform.localRotation.y}f, {obj.transform.localRotation.z}f, {obj.transform.localRotation.w}f)");
                ModConsole.Log($"The localRotation has been copied on the clipboard.");
                Clipboard.SetText($"new Quaternion({obj.transform.localRotation.x}f, {obj.transform.localRotation.y}f, {obj.transform.localRotation.z}f, {obj.transform.localRotation.w}f)");
            }
        }

        internal static void DestroyObject(this GameObject obj)
        {
            if (!obj.DestroyMeOnline())
            {
                obj.DestroyMeLocal();
            }
        }

        internal static GameObject InstantiateObject(this GameObject obj)
        {
            return obj != null ? Object.Instantiate(obj) : null;
        }

        internal static GameObject InstantiateObject(this Transform obj)
        {
            return obj != null ? Object.Instantiate(obj.gameObject) : null;
        }

        internal static void CloneObject(this GameObject obj)
        {
            if (obj != null)
            {
                ObjectCloner.CloneGameObject(obj);
            }
        }

        internal static bool DestroyMeOnline(this GameObject obj)
        {
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
                return true;
            }
        }

        internal static void CopyFromLight(this Light NewLight, Light OriginalLight)
        {
            if (NewLight == null) return;
            if (OriginalLight == null) return;
            NewLight.type = OriginalLight.type;
            NewLight.shape = OriginalLight.shape;
            NewLight.spotAngle = OriginalLight.spotAngle;
            NewLight.innerSpotAngle = OriginalLight.innerSpotAngle;
            NewLight.color = OriginalLight.color;
            NewLight.colorTemperature = OriginalLight.colorTemperature;
            NewLight.useColorTemperature = OriginalLight.useColorTemperature;
            NewLight.intensity = OriginalLight.intensity;
            NewLight.bounceIntensity = OriginalLight.bounceIntensity;
            NewLight.useBoundingSphereOverride = OriginalLight.useBoundingSphereOverride;
            NewLight.boundingSphereOverride = OriginalLight.boundingSphereOverride;
            NewLight.shadowCustomResolution = OriginalLight.shadowCustomResolution;
            NewLight.shadowBias = OriginalLight.shadowBias;
            NewLight.shadowNormalBias = OriginalLight.shadowNormalBias;
            NewLight.shadowNearPlane = OriginalLight.shadowNearPlane;
            NewLight.useShadowMatrixOverride = OriginalLight.useShadowMatrixOverride;
            NewLight.shadowMatrixOverride = OriginalLight.shadowMatrixOverride;
            NewLight.range = OriginalLight.range;
            NewLight.flare = OriginalLight.flare;
            NewLight.bakingOutput = OriginalLight.bakingOutput;
            NewLight.cullingMask = OriginalLight.cullingMask;
            NewLight.renderingLayerMask = OriginalLight.renderingLayerMask;
            NewLight.lightShadowCasterMode = OriginalLight.lightShadowCasterMode;
            NewLight.shadows = OriginalLight.shadows;
            NewLight.shadowStrength = OriginalLight.shadowStrength;
            NewLight.shadowResolution = OriginalLight.shadowResolution;
            NewLight.shadowSoftness = OriginalLight.shadowSoftness;
            NewLight.shadowSoftnessFade = OriginalLight.shadowSoftnessFade;
            NewLight.layerShadowCullDistances = OriginalLight.layerShadowCullDistances;
            NewLight.cookieSize = OriginalLight.cookieSize;
            NewLight.cookie = OriginalLight.cookie;
            NewLight.renderMode = OriginalLight.renderMode;
            NewLight.bakedIndex = OriginalLight.bakedIndex;
            NewLight.shadowConstantBias = OriginalLight.shadowConstantBias;
            NewLight.shadowObjectSizeBias = OriginalLight.shadowObjectSizeBias;
            NewLight.attenuate = OriginalLight.attenuate;
            NewLight.m_BakedIndex = OriginalLight.m_BakedIndex;
            ModConsole.DebugLog($"Copied all Properties in {NewLight.name} from {OriginalLight.name}");

        }

        internal static void DestroyMeLocal<T>(this List<T> items, bool Silent = false) where T : Object
        {
            if(items != null && items.Count != 0)
            {
                foreach(var item in items)
                {
                    if(item != null)
                    {
                        item.DestroyMeLocal(Silent);
                    }
                }
            }
        }

        internal static void DestroyMeLocal(this Object obj, bool Silent = false)
        {
            if (obj != null)
            {
                string objname = obj.name;
                string typename = obj.GetType().ToString();

                if (ComponentHelper.RegisteredComponentsTypes.Contains(obj.GetType()))
                {
                    var item = obj as Component;
                    if (item != null)
                    {
                        Object.Destroy(item);
                    }

                    MiscUtils.DelayFunction(0.5f, () =>
                    {
                        if (item != null)
                        {
                            ModConsole.DebugLog($"Failed To Destroy Object {typename} Contained in {objname}", Color.Red);
                        }
                        else
                        {
                            if (!Silent)
                            {
                                ModConsole.DebugLog($"Destroyed Client-side Object {typename} Contained in {objname}", Color.Green);
                            }
                        }
                    });

                    return;
                }
                else if (obj is VRC.UI.Elements.UIPage page)
                {
                    if (page != null) // Special destroy system.
                    {
                        page.RemovePage();
                        Object.Destroy(page);
                    }

                    MiscUtils.DelayFunction(0.5f, () =>
                    {
                        if (page != null)
                        {
                            ModConsole.DebugLog($"Failed To Destroy Object {typename} Contained in {objname}", Color.Red);
                        }
                        else
                        {
                            if (!Silent)
                            {
                                ModConsole.DebugLog($"Destroyed Client-side Object {typename} Contained in {objname}", Color.Green);
                            }
                        }
                    });
                }

                else if (obj is GameObject o)
                {
                    if (o != null)
                    {
                        Object.Destroy(o);
                    }

                    MiscUtils.DelayFunction(0.5f, () =>
                    {
                        if (o != null)
                        {
                            ModConsole.DebugLog($"Failed To Destroy Object {typename} Contained in {objname}", Color.Red);
                        }
                        else
                        {
                            if (!Silent)
                            {
                                ModConsole.DebugLog($"Destroyed Client-side Object {typename} Contained in {objname}", Color.Green);
                            }
                        }
                    });
                }
                else if (obj is Transform item)
                {
                    if (item != null)
                    {
                        Object.Destroy(item.gameObject);
                    }
                    MiscUtils.DelayFunction(0.5f, () =>
                    {
                        if (item != null)
                        {
                            ModConsole.DebugLog($"Failed To Destroy Object {typename} Contained in {objname}", Color.Red);
                        }
                        else
                        {
                            if (!Silent)
                            {
                                ModConsole.DebugLog($"Destroyed Client-side Object {typename} Contained in {objname}", Color.Green);
                            }
                        }
                    });
                }
                else
                {
                    if (obj != null)
                    {
                        Object.Destroy(obj);
                    }
                    MiscUtils.DelayFunction(0.5f, () =>
                    {
                        if (obj != null)
                        {
                            ModConsole.DebugLog($"Failed To Destroy Object {typename} Contained in {objname}", Color.Red);
                            ModConsole.DebugLog("Try To Destroy His GameObject in case you are trying to destroy the transform.", Color.Yellow);
                        }
                        else
                        {
                            if (!Silent)
                            {
                                ModConsole.DebugLog($"Destroyed Client-side Object {typename} Contained in {objname}", Color.Green);
                            }
                        }
                    });
                }
            }
        }

        internal static void RenameObject(this GameObject obj, string newname)
        {
            if (obj != null)
            {
                var oldname = obj.name;
                ModConsole.DebugLog("Renamed object : " + oldname + " to " + newname);
                obj.name = newname;
            }
        }


        internal static List<Transform> Get_Childs(this GameObject obj)
        {
            return obj.transform.Get_Childs();
        }

        internal static List<Transform> Get_Childs(this Transform obj)
        {
            List<Transform> childs = new List<Transform>();
            for (var i = 0; i < obj.childCount; i++)
            {
                var item = obj.GetChild(i);
                if (item != null)
                {
                    childs.Add(item);
                }
            }
            return childs;
        }

        internal static List<Transform> Get_All_Childs(this Transform item)
        {
            CheckTransform(item);
            return _Transforms;
        }

        private static List<Transform> _Transforms;

        //Recursive
        private static void CheckTransform(Transform transform)
        {
            _Transforms = new List<Transform>();

            //MelonLoader.MelonLogger.ModConsole.Log("Debug: Start CheckTransform Recursive Checker");
            if (transform == null)
            {
                ModConsole.Log("Debug: CheckTransform transform is null");
                return;
            }

            GetChildren(transform);
        }

        private static void GetChildren(Transform transform)
        {
            //MelonLogger.ModConsole.Log("Debug: GetChildren current transform: " + transform.gameObject.name);

            if (!_Transforms.Contains(transform))
            {
                _Transforms.Add(transform);
            }

            for (var i = 0; i < transform.childCount; i++)
            {
                GetChildren(transform.GetChild(i));
            }
        }

        internal static UnityEngine.Color ToUnityEngineColor(this System.Drawing.Color Color)
        {
            return ColorUtils.ToUnityEngineColor(Color);
        }

        internal static bool isMirror(this GameObject item)
        {
            return item.GetComponent<VRC_MirrorReflection>() != null ||
                   item.GetComponent<MirrorReflection>() != null ||
                   item.GetComponent<VRCSDK2.VRC_MirrorReflection>() != null ||
                   item.GetComponent<VRCMirrorReflection>() != null;
        }

        internal static bool isMirror(this Transform item)
        {
            return item.gameObject.isMirror();
        }
    }
}