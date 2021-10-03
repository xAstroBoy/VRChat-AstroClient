namespace AstroClient
{
    using AstroLibrary.Console;
    using AstroButtonAPI;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnhollowerBaseLib;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    internal class ColliderDisplay : GameEvents
    {
        private static string ShaderName
        {
            get { return "Legacy Shaders/Transparent/VertexLit"; }
        }

        private static void CreateMaterials()
        {
            Il2CppArrayBase<Shader> source = Resources.FindObjectsOfTypeAll<Shader>();
            Shader shader2 = Shader.Find(ShaderName);
            bool flag = shader2 == null;
            if (flag)
            {
                ModConsole.Log("Failed to find shader with name " + ShaderName + ". Valid shaders:\n" +
                               string.Join("\n", from shader in source
                                                 select shader.name));
                shader2 = source.FirstOrDefault((Shader shader) =>
                    shader.isSupported && shader.name.Contains("Transparent"));
            }

            bool flag2 = shader2 == null;
            if (flag2)
            {
                ModConsole.Log("Failed to find transparent shader for colliders");
                shader2 = source.FirstOrDefault();
            }
            else
            {
                ModConsole.Log("Creating material with shader " + shader2.name);
            }

            _triggerMaterial = new Material(shader2);
            _solidMaterial = new Material(shader2);
            _triggerMaterial.color = new Color(1f, 0f, 0f, 0.25f);
            _solidMaterial.color = new Color(0f, 1f, 0f, 0.25f);
            _ = Resources.UnloadUnusedAssets();
        }

        internal static void ToggleDisplays()
        {
            AutoUpdateColliderList = !AutoUpdateColliderList;
            if (!AutoUpdateColliderList)
            {
                DisableAll();
            }
            else
            {
                UpdateColliders(false);
            }
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            ToggleDisplays(false);
            if (ToggleColliderDisplayBtn != null)
            {
                ToggleColliderDisplayBtn.SetToggleState(false);
            }
            if (ToggleColliderInvisibleXRayBtn != null)
            {
                ToggleColliderInvisibleXRayBtn.SetToggleState(false);
            }
            if (ToggleColliderXRayBtn != null)
            {
                ToggleColliderXRayBtn.SetToggleState(false);
            }
        }

        internal static void ToggleDisplays(bool value)
        {
            AutoUpdateColliderList = value;
            if (!value)
            {
                DisableAll();
            }
            else
            {
                UpdateColliders(false);
            }
        }

        private static bool AutoUpdateColliderList = false;

        internal static void UpdateColliders(bool isOnUpdate = true)
        {
            if (!AutoUpdateColliderList)
            {
                return;
            }
            CreateMaterials();
            int count = SphereColliders.Count();
            int count2 = BoxColliders.Count();
            int count3 = CapsuleColliders.Count();
            GetAllColliders(SphereColliders);
            GetAllColliders(BoxColliders);
            GetAllColliders(CapsuleColliders);
            Regenerate(SphereCache, count, SphereColliders);
            Regenerate(CubeCache, count2, BoxColliders);
            Regenerate(CapsuleCache, count3, CapsuleColliders);
            if (!isOnUpdate)
            {
                ModConsole.Log(string.Format("Showing {0} sphere colliders, {1} box colliders, and {2} capsule colliders", SphereColliders.Count, BoxColliders.Count, CapsuleColliders.Count));
            }
        }

        private static void GetAllColliders<T>(List<T> colliderList)
        {
            int sceneCount = SceneManager.sceneCount;
            for (int i = 0; i < sceneCount; i++)
            {
                Il2CppReferenceArray<GameObject> rootGameObjects = SceneManager.GetSceneAt(i).GetRootGameObjects();
                for (int i2 = 0; i2 < rootGameObjects.Count; i2++)
                {
                    GameObject gameObject = rootGameObjects[i2];
                    Il2CppArrayBase<T> componentsInChildren = gameObject.GetComponentsInChildren<T>();
                    for (int i1 = 0; i1 < componentsInChildren.Count; i1++)
                    {
                        T t = componentsInChildren[i1];
                        if (!colliderList.Contains(t))
                        {
                            colliderList.Add(t);
                        }
                    }
                }
            }
        }

        private static void Regenerate<T, TSelf>(IList<TSelf> cache, int oldCount, List<T> colliders) where T : Collider where TSelf : class, IDisplay<T, TSelf>, new()
        {
            bool flag = colliders.Count < oldCount;
            if (flag)
            {
                for (int i = colliders.Count; i < oldCount; i++)
                {
                    cache[i].Enabled = false;
                }
            }
            else
            {
                bool flag2 = colliders.Count <= cache.Count;
                if (flag2)
                {
                    for (int j = oldCount; j < colliders.Count; j++)
                    {
                        cache[j].Enabled = true;
                    }
                }
                else
                {
                    for (int k = oldCount; k < cache.Count; k++)
                    {
                        cache[k].Enabled = true;
                    }
                    while (cache.Count < colliders.Count)
                    {
                        cache.Add(Activator.CreateInstance<TSelf>());
                    }
                }
            }
        }

        internal override void OnUpdate()
        {
            Update(SphereCache, SphereColliders);
            Update(CubeCache, BoxColliders);
            Update(CapsuleCache, CapsuleColliders);
        }

        private static void Update<T, TSelf>(IList<TSelf> cache, List<T> colliders) where T : Collider where TSelf : class, IDisplay<T, TSelf>, new()
        {
            int num = 0;
            for (int i = colliders.Count - 1; i >= 0; i--)
            {
                bool flag = colliders[i] == null || !colliders[i].enabled;
                if (flag)
                {
                    colliders.RemoveAt(i);
                    cache[colliders.Count].Enabled = false;
                }
                else
                {
                    cache[num++].Update(colliders[i]);
                }
            }
        }

        internal static void DisableAll()
        {
            int count = SphereColliders.Count;
            int count2 = BoxColliders.Count;
            int count3 = CapsuleColliders.Count;
            SphereColliders.Clear();
            BoxColliders.Clear();
            CapsuleColliders.Clear();
            Regenerate(SphereCache, count, SphereColliders);
            Regenerate(CubeCache, count2, BoxColliders);
            Regenerate(CapsuleCache, count3, CapsuleColliders);
            ModConsole.DebugLog(string.Format("No longer showing {0} sphere colliders, {1} box colliders, and {2} capsule colliders", count, count2, count3));
        }

        internal static readonly HashSet<int> MyRenderers = new HashSet<int>();

        private static readonly List<Sphere> SphereCache = new List<Sphere>();

        private static readonly List<Cube> CubeCache = new List<Cube>();

        private static readonly List<Capsule> CapsuleCache = new List<Capsule>();

        private static readonly List<SphereCollider> SphereColliders = new List<SphereCollider>();

        private static readonly List<BoxCollider> BoxColliders = new List<BoxCollider>();

        private static readonly List<CapsuleCollider> CapsuleColliders = new List<CapsuleCollider>();

        private static Material _triggerMaterial;

        private static Material _solidMaterial;

        private interface IDisplay<in T, TSelf> where T : Collider where TSelf : class, IDisplay<T, TSelf>, new()
        {
            bool Enabled { get; set; }

            void Update(T collider);
        }

        private class Sphere : IDisplay<SphereCollider, Sphere>
        {
            public bool Enabled
            {
                get
                {
                    return _transform.gameObject.activeSelf;
                }
                set
                {
                    _transform.gameObject.SetActive(value);
                }
            }

            public Sphere()
            {
                GameObject gameObject = GameObject.CreatePrimitive(0);
                UnityEngine.Object.DontDestroyOnLoad(gameObject);
                UnityEngine.Object.Destroy(gameObject.GetComponent<Collider>());
                _transform = gameObject.transform;
                _renderer = gameObject.GetComponent<Renderer>();
                _ = MyRenderers.Add((int)_renderer.GetCachedPtr());
            }

            private static float Max(float a, float b, float c)
            {
                return (a > b) ? ((a > c) ? a : c) : ((b > c) ? b : c);
            }

            public void Update(SphereCollider collider)
            {
                Transform transform = collider.transform;
                Vector3 lossyScale = transform.lossyScale;
                float num = collider.radius * Max(lossyScale.x, lossyScale.y, lossyScale.z) * 2f;
                Vector3 position = transform.TransformPoint(collider.center);
                _transform.localScale = Vector3.one * num;
                _transform.position = position;
                _renderer.sharedMaterial = collider.isTrigger ? _triggerMaterial : _solidMaterial;
            }

            private readonly Transform _transform;

            private readonly Renderer _renderer;
        }

        private class Cube : IDisplay<BoxCollider, Cube>
        {
            public bool Enabled
            {
                get
                {
                    return _transform.gameObject.activeSelf;
                }
                set
                {
                    _transform.gameObject.SetActive(value);
                }
            }

            public Cube()
            {
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                UnityEngine.Object.DontDestroyOnLoad(gameObject);
                UnityEngine.Object.Destroy(gameObject.GetComponent<Collider>());
                _transform = gameObject.transform;
                _renderer = gameObject.GetComponent<Renderer>();
                _ = MyRenderers.Add((int)_renderer.GetCachedPtr());
            }

            public void Update(BoxCollider collider)
            {
                Transform transform = collider.transform;
                _transform.localScale = Vector3.Scale(transform.lossyScale, collider.size);
                _transform.position = transform.TransformPoint(collider.center);
                _transform.rotation = transform.rotation;
                _renderer.sharedMaterial = collider.isTrigger ? _triggerMaterial : _solidMaterial;
            }

            private readonly Transform _transform;

            private readonly Renderer _renderer;
        }

        internal class Capsule : IDisplay<CapsuleCollider, Capsule>
        {
            public bool Enabled
            {
                get
                {
                    return _parent.gameObject.activeSelf;
                }
                set
                {
                    _parent.gameObject.SetActive(value);
                }
            }

            public Capsule()
            {
                _parent = new GameObject("Capsule").transform;
                UnityEngine.Object.DontDestroyOnLoad(_parent);
                _topSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
                _topSphere.parent = _parent;
                UnityEngine.Object.Destroy(_topSphere.GetComponent<Collider>());
                _bottomSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
                _bottomSphere.parent = _parent;
                UnityEngine.Object.Destroy(_bottomSphere.GetComponent<Collider>());
                _middleCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder).transform;
                _middleCylinder.parent = _parent;
                UnityEngine.Object.Destroy(_middleCylinder.GetComponent<Collider>());
                _bottomSphere.Rotate(180f, 0f, 0f);
                _topRenderer = _topSphere.GetComponent<Renderer>();
                _bottomRenderer = _bottomSphere.GetComponent<Renderer>();
                _middleRenderer = _middleCylinder.GetComponent<Renderer>();
                _ = MyRenderers.Add((int)_topRenderer.GetCachedPtr());
                _ = MyRenderers.Add((int)_bottomRenderer.GetCachedPtr());
                _ = MyRenderers.Add((int)_middleRenderer.GetCachedPtr());
            }

            private static float Max(float a, float b)
            {
                return (a > b) ? a : b;
            }

            public void Update(CapsuleCollider collider)
            {
                Transform transform = collider.transform;
                Vector3 lossyScale = transform.lossyScale;
                int direction = collider.direction;
                Vector3 position = transform.TransformPoint(collider.center);
                Quaternion quaternion = transform.rotation;
                float num = collider.height * lossyScale[direction];
                float num2 = collider.radius * Max(lossyScale[(direction + 1) % 3], lossyScale[(direction + 2) % 3]);
                int num3 = direction;
                if (num3 != 0)
                {
                    if (num3 == 2)
                    {
                        quaternion *= new Quaternion(0.707106769f, 0f, 0f, -0.707106769f);
                    }
                }
                else
                {
                    quaternion *= new Quaternion(0.707106769f, -0.707106769f, 0f, 0f);
                }
                float num4 = num2 * 2f;
                float num5 = (num / 2f) - num2;
                _parent.position = position;
                _parent.rotation = quaternion;
                _topSphere.localScale = Vector3.one * num4;
                _topSphere.localPosition = Vector3.up * num5;
                _bottomSphere.localScale = Vector3.one * num4;
                _bottomSphere.localPosition = -Vector3.up * num5;
                _middleCylinder.localScale = new Vector3(num4, num5, num4);
                bool isTrigger = collider.isTrigger;
                if (isTrigger)
                {
                    _topRenderer.sharedMaterial = _triggerMaterial;
                    _bottomRenderer.sharedMaterial = _triggerMaterial;
                    _middleRenderer.sharedMaterial = _triggerMaterial;
                }
                else
                {
                    _topRenderer.sharedMaterial = _solidMaterial;
                    _bottomRenderer.sharedMaterial = _solidMaterial;
                    _middleRenderer.sharedMaterial = _solidMaterial;
                }
            }

            private readonly Transform _parent;

            private readonly Transform _topSphere;

            private readonly Transform _bottomSphere;

            private readonly Transform _middleCylinder;

            private readonly Renderer _topRenderer;

            private readonly Renderer _bottomRenderer;

            private readonly Renderer _middleRenderer;
        }

        internal static QMToggleButton ToggleColliderDisplayBtn;
        internal static QMToggleButton ToggleColliderInvisibleXRayBtn;
        internal static QMToggleButton ToggleColliderXRayBtn;
    }
}