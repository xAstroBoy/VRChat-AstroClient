using UnityEngine;
using VRC.SDKBase;
using Color = System.Drawing.Color;

#region AstroClient Imports

using AstroClient.Cloner;
using AstroClient.ConsoleUtils;
using AstroClient.AstroUtils.ItemTweaker;
using AstroClient.ItemTweaker;
using System.Windows.Forms;
using AstroClient.Finder;

#endregion AstroClient Imports

namespace AstroClient.extensions
{
	public static class EngineExtensions
	{
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

		public static GameObject InstantiateObject(this Transform obj)
		{
			if (obj != null)
			{
				return UnityEngine.Object.Instantiate(obj.gameObject);
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
			if (Tweaker_Object.CurrentSelectedObject == obj)
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
					ModConsole.DebugLog("Failed To Destroy Object : " + obj.name, Color.Red);
					ModConsole.DebugLog("Try To Destroy His GameObject in case you are trying to destroy the transform.", Color.Yellow);
				}
				else
				{
					ModConsole.DebugLog("Destroyed Client-side Object : " + name, Color.Green);
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