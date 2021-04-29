namespace AstroClient
{
	using AstroClient.ConsoleUtils;
	using RubyButtonAPI;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnhollowerBaseLib;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class ColliderDisplay : GameEvents
	{
		private static string ShaderName
		{
			get { return "Legacy Shaders/Transparent/VertexLit"; }
		}

		private static void CreateMaterials()
		{
			Il2CppArrayBase<Shader> source = Resources.FindObjectsOfTypeAll<Shader>();
			Shader shader2 = Shader.Find(ColliderDisplay.ShaderName);
			bool flag = shader2 == null;
			if (flag)
			{
				ModConsole.Log("Failed to find shader with name " + ColliderDisplay.ShaderName + ". Valid shaders:\n" +
							   string.Join("\n", from shader in source
												 select shader.name));
				shader2 = source.FirstOrDefault((Shader shader) =>
					shader.isSupported && shader.name.Contains("Transparent"));
			}

			bool flag2 = shader2 == null;
			if (flag2)
			{
				ModConsole.Log("Failed to find transparent shader for colliders");
				shader2 = source.FirstOrDefault<Shader>();
			}
			else
			{
				ModConsole.Log("Creating material with shader " + shader2.name);
			}

			ColliderDisplay._triggerMaterial = new Material(shader2);
			ColliderDisplay._solidMaterial = new Material(shader2);
			ColliderDisplay._triggerMaterial.color = new Color(1f, 0f, 0f, 0.25f);
			ColliderDisplay._solidMaterial.color = new Color(0f, 1f, 0f, 0.25f);
			Resources.UnloadUnusedAssets();
		}

		public static void ToggleDisplays()
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

		public override void OnLevelLoaded()
		{
			ToggleDisplays(false);
			if (ToggleColliderDisplayBtn != null)
			{
				ToggleColliderDisplayBtn.setToggleState(false);
			}
			if (ToggleColliderInvisibleXRayBtn != null)
			{
				ToggleColliderInvisibleXRayBtn.setToggleState(false);
			}
			if (ToggleColliderXRayBtn != null)
			{
				ToggleColliderXRayBtn.setToggleState(false);
			}
		}

		public static void ToggleDisplays(bool value)
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

		public static void UpdateColliders(bool isOnUpdate = true)
		{
			if (!AutoUpdateColliderList)
			{
				return;
			}
			ColliderDisplay.CreateMaterials();
			int count = ColliderDisplay.SphereColliders.Count();
			int count2 = ColliderDisplay.BoxColliders.Count();
			int count3 = ColliderDisplay.CapsuleColliders.Count();
			ColliderDisplay.GetAllColliders<SphereCollider>(ColliderDisplay.SphereColliders);
			ColliderDisplay.GetAllColliders<BoxCollider>(ColliderDisplay.BoxColliders);
			ColliderDisplay.GetAllColliders<CapsuleCollider>(ColliderDisplay.CapsuleColliders);
			ColliderDisplay.Regenerate<SphereCollider, ColliderDisplay.Sphere>(ColliderDisplay.SphereCache, count, ColliderDisplay.SphereColliders);
			ColliderDisplay.Regenerate<BoxCollider, ColliderDisplay.Cube>(ColliderDisplay.CubeCache, count2, ColliderDisplay.BoxColliders);
			ColliderDisplay.Regenerate<CapsuleCollider, ColliderDisplay.Capsule>(ColliderDisplay.CapsuleCache, count3, ColliderDisplay.CapsuleColliders);
			if (!isOnUpdate)
			{
				ModConsole.Log(string.Format("Showing {0} sphere colliders, {1} box colliders, and {2} capsule colliders", ColliderDisplay.SphereColliders.Count, ColliderDisplay.BoxColliders.Count, ColliderDisplay.CapsuleColliders.Count));
			}
		}

		private static void GetAllColliders<T>(System.Collections.Generic.List<T> colliderList)
		{
			int sceneCount = SceneManager.sceneCount;
			for (int i = 0; i < sceneCount; i++)
			{
				Il2CppReferenceArray<GameObject> rootGameObjects = SceneManager.GetSceneAt(i).GetRootGameObjects();
				foreach (GameObject gameObject in rootGameObjects)
				{
					Il2CppArrayBase<T> componentsInChildren = gameObject.GetComponentsInChildren<T>();
					foreach (T t in componentsInChildren)
					{
						if (!colliderList.Contains(t))
						{
							colliderList.Add(t);
						}
					}
				}
			}
		}

		private static void Regenerate<T, TSelf>(System.Collections.Generic.IList<TSelf> cache, int oldCount, System.Collections.Generic.List<T> colliders) where T : Collider where TSelf : class, ColliderDisplay.IDisplay<T, TSelf>, new()
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

		public override void OnUpdate()
		{
			ColliderDisplay.Update<SphereCollider, ColliderDisplay.Sphere>(ColliderDisplay.SphereCache, ColliderDisplay.SphereColliders);
			ColliderDisplay.Update<BoxCollider, ColliderDisplay.Cube>(ColliderDisplay.CubeCache, ColliderDisplay.BoxColliders);
			ColliderDisplay.Update<CapsuleCollider, ColliderDisplay.Capsule>(ColliderDisplay.CapsuleCache, ColliderDisplay.CapsuleColliders);
		}

		private static void Update<T, TSelf>(System.Collections.Generic.IList<TSelf> cache, List<T> colliders) where T : Collider where TSelf : class, ColliderDisplay.IDisplay<T, TSelf>, new()
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

		public static void DisableAll()
		{
			int count = ColliderDisplay.SphereColliders.Count;
			int count2 = ColliderDisplay.BoxColliders.Count;
			int count3 = ColliderDisplay.CapsuleColliders.Count;
			ColliderDisplay.SphereColliders.Clear();
			ColliderDisplay.BoxColliders.Clear();
			ColliderDisplay.CapsuleColliders.Clear();
			ColliderDisplay.Regenerate<SphereCollider, ColliderDisplay.Sphere>(ColliderDisplay.SphereCache, count, ColliderDisplay.SphereColliders);
			ColliderDisplay.Regenerate<BoxCollider, ColliderDisplay.Cube>(ColliderDisplay.CubeCache, count2, ColliderDisplay.BoxColliders);
			ColliderDisplay.Regenerate<CapsuleCollider, ColliderDisplay.Capsule>(ColliderDisplay.CapsuleCache, count3, ColliderDisplay.CapsuleColliders);
			ModConsole.DebugLog(string.Format("No longer showing {0} sphere colliders, {1} box colliders, and {2} capsule colliders", count, count2, count3));
		}

		public static readonly HashSet<int> MyRenderers = new HashSet<int>();

		private static readonly List<ColliderDisplay.Sphere> SphereCache = new List<ColliderDisplay.Sphere>();

		private static readonly List<ColliderDisplay.Cube> CubeCache = new List<ColliderDisplay.Cube>();

		private static readonly List<ColliderDisplay.Capsule> CapsuleCache = new List<ColliderDisplay.Capsule>();

		private static readonly List<SphereCollider> SphereColliders = new List<SphereCollider>();

		private static readonly System.Collections.Generic.List<BoxCollider> BoxColliders = new List<BoxCollider>();

		private static readonly List<CapsuleCollider> CapsuleColliders = new List<CapsuleCollider>();

		private static Material _triggerMaterial;

		private static Material _solidMaterial;

		private interface IDisplay<in T, TSelf> where T : Collider where TSelf : class, ColliderDisplay.IDisplay<T, TSelf>, new()
		{
			bool Enabled { get; set; }

			void Update(T collider);
		}

		private class Sphere : ColliderDisplay.IDisplay<SphereCollider, ColliderDisplay.Sphere>
		{
			public bool Enabled
			{
				get
				{
					return this._transform.gameObject.activeSelf;
				}
				set
				{
					this._transform.gameObject.SetActive(value);
				}
			}

			public Sphere()
			{
				GameObject gameObject = GameObject.CreatePrimitive(0);
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				UnityEngine.Object.Destroy(gameObject.GetComponent<Collider>());
				this._transform = gameObject.transform;
				this._renderer = gameObject.GetComponent<Renderer>();
				ColliderDisplay.MyRenderers.Add((int)this._renderer.GetCachedPtr());
			}

			private static float Max(float a, float b, float c)
			{
				return (a > b) ? ((a > c) ? a : c) : ((b > c) ? b : c);
			}

			public void Update(SphereCollider collider)
			{
				Transform transform = collider.transform;
				Vector3 lossyScale = transform.lossyScale;
				float num = collider.radius * ColliderDisplay.Sphere.Max(lossyScale.x, lossyScale.y, lossyScale.z) * 2f;
				Vector3 position = transform.TransformPoint(collider.center);
				this._transform.localScale = Vector3.one * num;
				this._transform.position = position;
				this._renderer.sharedMaterial = (collider.isTrigger ? ColliderDisplay._triggerMaterial : ColliderDisplay._solidMaterial);
			}

			private readonly Transform _transform;

			private readonly Renderer _renderer;
		}

		private class Cube : ColliderDisplay.IDisplay<BoxCollider, ColliderDisplay.Cube>
		{
			public bool Enabled
			{
				get
				{
					return this._transform.gameObject.activeSelf;
				}
				set
				{
					this._transform.gameObject.SetActive(value);
				}
			}

			public Cube()
			{
				GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				UnityEngine.Object.Destroy(gameObject.GetComponent<Collider>());
				this._transform = gameObject.transform;
				this._renderer = gameObject.GetComponent<Renderer>();
				ColliderDisplay.MyRenderers.Add((int)this._renderer.GetCachedPtr());
			}

			public void Update(BoxCollider collider)
			{
				Transform transform = collider.transform;
				this._transform.localScale = Vector3.Scale(transform.lossyScale, collider.size);
				this._transform.position = transform.TransformPoint(collider.center);
				this._transform.rotation = transform.rotation;
				this._renderer.sharedMaterial = (collider.isTrigger ? ColliderDisplay._triggerMaterial : ColliderDisplay._solidMaterial);
			}

			private readonly Transform _transform;

			private readonly Renderer _renderer;
		}

		public class Capsule : ColliderDisplay.IDisplay<CapsuleCollider, ColliderDisplay.Capsule>
		{
			public bool Enabled
			{
				get
				{
					return this._parent.gameObject.activeSelf;
				}
				set
				{
					this._parent.gameObject.SetActive(value);
				}
			}

			public Capsule()
			{
				this._parent = new GameObject("Capsule").transform;
				UnityEngine.Object.DontDestroyOnLoad(this._parent);
				this._topSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
				this._topSphere.parent = this._parent;
				UnityEngine.Object.Destroy(this._topSphere.GetComponent<Collider>());
				this._bottomSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
				this._bottomSphere.parent = this._parent;
				UnityEngine.Object.Destroy(this._bottomSphere.GetComponent<Collider>());
				this._middleCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder).transform;
				this._middleCylinder.parent = this._parent;
				UnityEngine.Object.Destroy(this._middleCylinder.GetComponent<Collider>());
				this._bottomSphere.Rotate(180f, 0f, 0f);
				this._topRenderer = this._topSphere.GetComponent<Renderer>();
				this._bottomRenderer = this._bottomSphere.GetComponent<Renderer>();
				this._middleRenderer = this._middleCylinder.GetComponent<Renderer>();
				ColliderDisplay.MyRenderers.Add((int)this._topRenderer.GetCachedPtr());
				ColliderDisplay.MyRenderers.Add((int)this._bottomRenderer.GetCachedPtr());
				ColliderDisplay.MyRenderers.Add((int)this._middleRenderer.GetCachedPtr());
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
				float num2 = collider.radius * ColliderDisplay.Capsule.Max(lossyScale[(direction + 1) % 3], lossyScale[(direction + 2) % 3]);
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
				float num5 = num / 2f - num2;
				this._parent.position = position;
				this._parent.rotation = quaternion;
				this._topSphere.localScale = Vector3.one * num4;
				this._topSphere.localPosition = Vector3.up * num5;
				this._bottomSphere.localScale = Vector3.one * num4;
				this._bottomSphere.localPosition = -Vector3.up * num5;
				this._middleCylinder.localScale = new Vector3(num4, num5, num4);
				bool isTrigger = collider.isTrigger;
				if (isTrigger)
				{
					this._topRenderer.sharedMaterial = ColliderDisplay._triggerMaterial;
					this._bottomRenderer.sharedMaterial = ColliderDisplay._triggerMaterial;
					this._middleRenderer.sharedMaterial = ColliderDisplay._triggerMaterial;
				}
				else
				{
					this._topRenderer.sharedMaterial = ColliderDisplay._solidMaterial;
					this._bottomRenderer.sharedMaterial = ColliderDisplay._solidMaterial;
					this._middleRenderer.sharedMaterial = ColliderDisplay._solidMaterial;
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

		public static QMToggleButton ToggleColliderDisplayBtn;
		public static QMToggleButton ToggleColliderInvisibleXRayBtn;
		public static QMToggleButton ToggleColliderXRayBtn;
	}
}