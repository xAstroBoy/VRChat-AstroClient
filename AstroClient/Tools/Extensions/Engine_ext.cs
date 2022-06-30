using System;
using System.Text;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.PlayerList;
using AstroClient.Startup.Hooks;
using AstroClient.xAstroBoy.Extensions;
using TMPro;
using UnhollowerBaseLib;
using VRC.Udon;

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
                string path = obj.GetPath();
                if (!string.IsNullOrEmpty(path) && !string.IsNullOrWhiteSpace(path))
                {
                    Log.Write($"{obj.name} Path is : {path}");
                }
            }
        }
        /// <summary>
        /// This gets the GameObject path 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static string GetPath(this GameObject obj)
        {
            return GetPath(obj.transform);
        }
        /// <summary>
        /// This gets the Transform path
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        internal static string GetPath(this Transform current)
        {
            if (current.parent == null)
                return current.name;
            return GetPath(current.parent) + "/" + current.name;
        }

        internal static string AddRichColorTag(this string text, Color color)
        {
            return $"<color=#{ColorUtils.ColorToHex(color)}>{text}</color>";

        }
        internal static string AddRichColorTag(this string text, UnityEngine.Color color)
        {
            return $"<color=#{ColorUtils.ColorToHex(color)}>{text}</color>";

        }

        // HTML Rainbow codes
        internal static string RainbowRichText(this string text)
        {
            var sb = new StringBuilder();
            var rainbow = new List<string>
            {
                "FF0000",
                "FF1F00",
                "FF3D00",
                "FF5C00",
                "FF7A00",
                "FF9900",
                "FFB800",
                "FFD600",
                "FFF500",
                "EBFF00",
                "CCFF00",
                "ADFF00",
                "8FFF00",
                "70FF00",
                "52FF00",
                "33FF00",
                "14FF00",
                "00FF0A",
                "00FF29",
                "00FF47",
                "00FF66",
                "00FF85",
                "00FFA3",
                "00FFC2",
                "00FFE0",
                "00FFFF",
                "00E0FF",
                "00C2FF",
                "00A3FF",
                "0085FF",
                "0066FF",
                "0047FF",
                "0029FF",
                "000AFF",
                "1400FF",
                "3300FF",
                "5200FF",
                "7000FF",
                "8F00FF",
                "AD00FF",
                "CC00FF",
                "EB00FF",
                "FF00F5",
                "FF00D6",
                "FF00B8",
                "FF0099",
                "FF007A",
                "FF005C",
            };
            var index = 0;
            foreach (var letter in text)
            {
                sb.Append($"<color=#{rainbow[index]}>{letter}</color>");
                index = (index + 1) % rainbow.Count;
            }

            return sb.ToString();
        }





public static void SetLayerRecursive(this GameObject gameObject, int layer)
        {
            gameObject.layer = layer;
            foreach (Il2CppObjectBase il2CppObjectBase in gameObject.transform)
                il2CppObjectBase.Cast<Transform>().gameObject.SetLayerRecursive(layer);
        }

        public static Vector3 SetZ(this Vector3 vector, float Z)
        {
            vector.Set(vector.x, vector.y, Z);
            return vector;
        }
        public static Vector3 SetY(this Vector3 vector, float Y)
        {
            vector.Set(vector.x, Y, vector.z);
            return vector;
        }
        public static Vector3 SetX(this Vector3 vector, float X)
        {
            vector.Set(X, vector.y, vector.z);
            return vector;
        }
        public static float RoundAmount(this float i, float nearestFactor) => (float)Math.Round((double)i / (double)nearestFactor) * nearestFactor;

        public static Vector3 RoundAmount(this Vector3 i, float nearestFactor) => new Vector3(i.x.RoundAmount(nearestFactor), i.y.RoundAmount(nearestFactor), i.z.RoundAmount(nearestFactor));

        public static Vector2 RoundAmount(this Vector2 i, float nearestFactor) => new Vector2(i.x.RoundAmount(nearestFactor), i.y.RoundAmount(nearestFactor));


        internal static void FlipTransformRotation(this  Transform transform)
        {
            Vector3 rot = transform.rotation.eulerAngles;
            rot = new Vector3(rot.x, rot.y + 180, rot.z);
            transform.rotation = Quaternion.Euler(rot);

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
                string path = obj.GetPath();
                if (!string.IsNullOrEmpty(path) && !string.IsNullOrWhiteSpace(path))
                {
                    Log.Write($"{obj.name} Path is : {path}");
                    Log.Write($"The Path has been copied on the clipboard.");
                    Clipboard.SetText(path);
                }
            }
        }

        internal static void CopyRotation(this GameObject obj)
        {
            if (obj != null)
            {
                Log.Write($"{obj.name} rotation is : new Quaternion({obj.transform.rotation.x}f, {obj.transform.rotation.y}f, {obj.transform.rotation.z}f, {obj.transform.rotation.w}f)");
                Log.Write($"The rotation has been copied on the clipboard.");
                Clipboard.SetText($"new Quaternion({obj.transform.rotation.x}f, {obj.transform.rotation.y}f, {obj.transform.rotation.z}f, {obj.transform.rotation.w}f)");
            }
        }

        internal static void CopyPosition(this GameObject obj)
        {
            if (obj != null)
            {
                Log.Write($"{obj.name} position is : new Vector3({obj.transform.position.x}f, {obj.transform.position.y}f, {obj.transform.position.z}f)");
                Log.Write($"The Position has been copied on the clipboard.");
                Clipboard.SetText($"new Vector3({obj.transform.position.x}f, {obj.transform.position.y}f, {obj.transform.position.z}f)");
            }
        }

        internal static void CopyLocalPosition(this GameObject obj)
        {
            if (obj != null)
            {
                Log.Write($"{obj.name} Local position is : new Vector3({obj.transform.localPosition.x}f, {obj.transform.localPosition.y}f, {obj.transform.localPosition.z}f)");
                Log.Write($"The Local Position has been copied on the clipboard.");
                Clipboard.SetText($"new Vector3({obj.transform.localPosition.x}f, {obj.transform.localPosition.y}f, {obj.transform.localPosition.z}f)");
            }
        }

        internal static void CopyLocalRotation(this GameObject obj)
        {
            if (obj != null)
            {
                Log.Write($"{obj.name} localRotation is : new Quaternion({obj.transform.localRotation.x}f, {obj.transform.localRotation.y}f, {obj.transform.localRotation.z}f, {obj.transform.localRotation.w}f)");
                Log.Write($"The localRotation has been copied on the clipboard.");
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

        internal static void CopyExistingComponents<T>(GameObject Original, GameObject Clone) where T : Component
        {
            var comp1base = Original.GetComponents<T>();
            for (var CompResult = 0; CompResult < comp1base.Count; CompResult++)
            {
                var result = comp1base[CompResult];
                Log.Debug($"Deep Cloning {typeof(T).FullName} Component..");
                Clone.AddComponent<T>().GetCopyOf(result);
            }
        }

        internal static void DestroyExistingComponents<T>(GameObject Clone) where T : Component
        {
            var comp1base = Clone.GetComponents<T>();
            for (var CompResult = 0; CompResult < comp1base.Count; CompResult++)
            {
                var result = comp1base[CompResult];
                if(result != null)
                {
                    Object.DestroyImmediate(result);
                }
            }

        }

        internal static void DestroyUdonComponents(GameObject Clone)
        {
            var comp1base = Clone.GetComponents<UdonBehaviour>();
            for (var CompResult = 0; CompResult < comp1base.Count; CompResult++)
            {
                var result = comp1base[CompResult];
                if (result != null)
                {
                    if (result._program != null)
                    {
                        Object.DestroyImmediate(result);
                    }
                }
            }

        }

        internal static void DeepCloneObject(GameObject original, GameObject clone)
        {
            // First purge the failed instantiated component clones
            DestroyUdonComponents(clone);
            DestroyExistingComponents<VRC_Pickup>(clone);
            DestroyExistingComponents<VRC.SDK3.Components.VRCObjectSync>(clone);
            DestroyExistingComponents<VRC.Networking.UdonSync>(clone);
            DestroyExistingComponents<VRC_Trigger>(clone);
            DestroyExistingComponents<VRC_Interactable>(clone);


            // Then use our deepcloner to add back the components properly cloned.
            CopyExistingComponents<UdonBehaviour>(original, clone);
            CopyExistingComponents<VRC_Pickup>(original, clone);
            CopyExistingComponents<VRC.SDK3.Components.VRCObjectSync>(original, clone);
            CopyExistingComponents<VRC.Networking.UdonSync>(original, clone);
            CopyExistingComponents<VRC_Trigger>(original, clone);
            CopyExistingComponents<VRC_Interactable>(original, clone);


        }

        internal static GameObject InstantiateObject(this GameObject original)
        {
            if(original != null)
            {
                var clone = Object.Instantiate(original);
                DeepCloneObject(original, clone);
                return clone;
            }
            return null;
        }

        internal static GameObject InstantiateObject(this Transform obj)
        {
            var result = InstantiateObject(obj.gameObject); ;
            return result;
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
                Log.Write("Failed To Destroy Server-side  Object :  " + obj.name, Color.Red);
                return false;
            }
            else
            {
                Log.Write("Destroyed Server-side Object : " + name, Color.Green);
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
            Log.Debug($"Copied all Properties in {NewLight.name} from {OriginalLight.name}");

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
                            Log.Debug($"Failed To Destroy Object {typename} Contained in {objname}", Color.Red);
                        }
                        else
                        {
                            if (!Silent)
                            {
                                Log.Debug($"Destroyed Client-side Object {typename} Contained in {objname}", Color.Green);
                            }
                        }
                    });

                    return;
                }
                else if (obj is GameObject o)
                {

                    if (o != null)
                    {
                        if (UnityDestroyBlock.MonitorDestroyingEvent)
                        {
                            foreach (var item in o.GetComponents<DontDestroyFlag>())
                            {
                                Object.DestroyImmediate(item);
                            }
                            foreach (var item in o.GetComponentsInChildren<DontDestroyFlag>(true))
                            {
                                Object.DestroyImmediate(item);
                            }

                        }

                        Object.Destroy(o);
                    }

                    MiscUtils.DelayFunction(0.5f, () =>
                    {
                        if (o != null)
                        {
                            Log.Debug($"Failed To Destroy Object {typename} Contained in {objname}", Color.Red);
                        }
                        else
                        {
                            if (!Silent)
                            {
                                Log.Debug($"Destroyed Client-side Object {typename} Contained in {objname}", Color.Green);
                            }
                        }
                    });
                }
                else if (obj is Transform item)
                {
                    if (item != null)
                    {
                        if (UnityDestroyBlock.MonitorDestroyingEvent)
                        {
                            foreach (var item2 in item.GetComponents<DontDestroyFlag>())
                            {
                                Object.DestroyImmediate(item2);
                            }
                            foreach (var item2 in item.GetComponentsInChildren<DontDestroyFlag>(true))
                            {
                                Object.DestroyImmediate(item2);
                            }

                        }

                        Object.Destroy(item.gameObject);
                    }

                    MiscUtils.DelayFunction(0.5f, () =>
                    {
                        if (item != null)
                        {
                            Log.Debug($"Failed To Destroy Object {typename} Contained in {objname}", Color.Red);
                        }
                        else
                        {
                            if (!Silent)
                            {
                                Log.Debug($"Destroyed Client-side Object {typename} Contained in {objname}", Color.Green);
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
                            Log.Debug($"Failed To Destroy Object {typename} Contained in {objname}", Color.Red);
                            Log.Debug("Try To Destroy His GameObject in case you are trying to destroy the transform.", Color.Yellow);
                        }
                        else
                        {
                            if (!Silent)
                            {
                                Log.Debug($"Destroyed Client-side Object {typename} Contained in {objname}", Color.Green);
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
                Log.Debug("Renamed object : " + oldname + " to " + newname);
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

            //MelonLoader.MelonLogger.Log.Write("Debug: Start CheckTransform Recursive Checker");
            if (transform == null)
            {
                Log.Write("Debug: CheckTransform transform is null");
                return;
            }

            GetChildren(transform);
        }

        private static void GetChildren(Transform transform)
        {
            //MelonLogger.Log.Write("Debug: GetChildren current transform: " + transform.gameObject.name);

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