namespace AstroLibrary.Extensions
{
	#region Imports

	using AstroClient;
	using AstroClient.Cloner;
	using AstroClient.Startup;
	using AstroLibrary.Console;
	using AstroLibrary.Finder;
	using AstroLibrary.Utility;
	using System.Collections.Generic;
	using System.Windows.Forms;
	using UnityEngine;
	using VRC.SDKBase;
	using Color = System.Drawing.Color;

	#endregion Imports

	public static class Engine_ext
	{
		public static void DestroyChildren(this Transform parent)
		{
			for (var i = parent.childCount; i > 0; i--)
				UnityEngine.Object.DestroyImmediate(parent.GetChild(i - 1).gameObject);
		}

		public static GameObject NoUnload(this GameObject obj)
		{
			obj.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			return obj;
		}

		public static void PrintPath(this GameObject obj)
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

		public static string GetPath(this GameObject obj)
		{
			if (obj != null)
			{
				string path = GameObjectFinder.GetGameObjectPath(obj);
				if (!string.IsNullOrEmpty(path) && !string.IsNullOrWhiteSpace(path))
				{
					return $"{obj.name} Path is : {path}";
				}
				return "No Path Found";
			}
			return "Object is Null";
		}

		public static UnityEngine.Color Get_Transform_Active_ToColor(this Transform obj)
		{
			return obj.gameObject.Get_GameObject_Active_ToColor();
		}

		public static UnityEngine.Color Get_GameObject_Active_ToColor(this GameObject obj)
		{
			return obj != null ? obj.active ? UnityEngine.Color.green : UnityEngine.Color.red : UnityEngine.Color.red;
		}

		public static UnityEngine.Color Get_MonoBehaviour_Enabled_ToColor(this MonoBehaviour obj)
		{
			return obj != null ? obj.enabled ? UnityEngine.Color.green : UnityEngine.Color.red : UnityEngine.Color.red;
		}

		public static bool Is_DontDestroyOnLoad(this GameObject obj)
		{
			return obj.scene.name.Equals("DontDestroyOnLoad");
		}

		public static bool Is_DontDestroyOnLoad(this Transform obj)
		{
			return obj.gameObject.Is_DontDestroyOnLoad();
		}

		public static void Set_DontDestroyOnLoad(this Object obj)
		{
			UnityEngine.Object.DontDestroyOnLoad(obj);
		}

		public static void CopyPath(this GameObject obj)
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

		public static void CopyRotation(this GameObject obj)
		{
			if (obj != null)
			{
				ModConsole.Log($"{obj.name} rotation is : new Quaternion({obj.transform.rotation.x}f, {obj.transform.rotation.y}f, {obj.transform.rotation.z}f, {obj.transform.rotation.w}f)");
				ModConsole.Log($"The rotation has been copied on the clipboard.");
				Clipboard.SetText($"new Quaternion({obj.transform.rotation.x}f, {obj.transform.rotation.y}f, {obj.transform.rotation.z}f, {obj.transform.rotation.w}f)");
			}
		}

		public static void CopyPosition(this GameObject obj)
		{
			if (obj != null)
			{
				ModConsole.Log($"{obj.name} position is : new Vector3({obj.transform.position.x}f, {obj.transform.position.y}f, {obj.transform.position.z}f)");
				ModConsole.Log($"The Position has been copied on the clipboard.");
				Clipboard.SetText($"new Vector3({obj.transform.position.x}f, {obj.transform.position.y}f, {obj.transform.position.z}f)");
			}
		}

		public static void CopyLocalPosition(this GameObject obj)
		{
			if (obj != null)
			{
				ModConsole.Log($"{obj.name} Local position is : new Vector3({obj.transform.localPosition.x}f, {obj.transform.localPosition.y}f, {obj.transform.localPosition.z}f)");
				ModConsole.Log($"The Local Position has been copied on the clipboard.");
				Clipboard.SetText($"new Vector3({obj.transform.localPosition.x}f, {obj.transform.localPosition.y}f, {obj.transform.localPosition.z}f)");
			}
		}

		public static void CopyLocalRotation(this GameObject obj)
		{
			if (obj != null)
			{
				ModConsole.Log($"{obj.name} localRotation is : new Quaternion({obj.transform.localRotation.x}f, {obj.transform.localRotation.y}f, {obj.transform.localRotation.z}f, {obj.transform.localRotation.w}f)");
				ModConsole.Log($"The localRotation has been copied on the clipboard.");
				Clipboard.SetText($"new Quaternion({obj.transform.localRotation.x}f, {obj.transform.localRotation.y}f, {obj.transform.localRotation.z}f, {obj.transform.localRotation.w}f)");
			}
		}

		public static void DestroyObject(this GameObject obj)
		{
			if (!obj.DestroyMeOnline())
			{
				obj.DestroyMeLocal();
			}
		}

		public static GameObject InstantiateObject(this GameObject obj)
		{
			return obj != null ? Object.Instantiate(obj) : null;
		}

		public static GameObject InstantiateObject(this Transform obj)
		{
			return obj != null ? Object.Instantiate(obj.gameObject) : null;
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

		public static void DestroyMeLocal(this Object obj)
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
					MiscUtility.DelayFunction(0.5f, () =>
					{
						if (item != null)
						{
							ModConsole.DebugLog($"Failed To Destroy Object {typename} Contained in {objname}", Color.Red);
						}
						else
						{
							ModConsole.DebugLog($"Destroyed Client-side Object {typename} Contained in {objname}", Color.Green);
						}
					});

					return;
				}
				else if (obj is GameObject)
				{
					var item = obj as GameObject;
					if (item != null)
					{
						Object.Destroy(item);
					}
					MiscUtility.DelayFunction(0.5f, () =>
					{
						if (item != null)
						{
							ModConsole.DebugLog($"Failed To Destroy Object {typename} Contained in {objname}", Color.Red);
						}
						else
						{
							ModConsole.DebugLog($"Destroyed Client-side Object {typename} Contained in {objname}", Color.Green);
						}
					});
				}
				else if (obj is Transform)
				{
					var item = obj as Transform;
					if (item != null)
					{
						Object.Destroy(item.gameObject);
					}
					MiscUtility.DelayFunction(0.5f, () =>
					{
						if (item != null)
						{
							ModConsole.DebugLog($"Failed To Destroy Object {typename} Contained in {objname}", Color.Red);
						}
						else
						{
							ModConsole.DebugLog($"Destroyed Client-side Object {typename} Contained in {objname}", Color.Green);
						}
					});
				}
				else
				{
					if (obj != null)
					{
						Object.Destroy(obj);
					}
					MiscUtility.DelayFunction(0.5f, () =>
					{
						if (obj != null)
						{
							ModConsole.DebugLog($"Failed To Destroy Object {typename} Contained in {objname}", Color.Red);
							ModConsole.DebugLog("Try To Destroy His GameObject in case you are trying to destroy the transform.", Color.Yellow);
						}
						else
						{
							ModConsole.DebugLog($"Destroyed Client-side Object {typename} Contained in {objname}", Color.Green);
						}
					});
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

		public static List<Transform> Get_Childs(this Transform obj)
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

		public static List<Transform> Get_All_Childs(this Transform item)
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
	}
}