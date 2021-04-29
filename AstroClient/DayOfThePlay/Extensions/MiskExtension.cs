using AstroClient.ConsoleUtils;
using MelonLoader;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;
using VRC.SDKBase;

namespace DayClientML2.Utility.Extensions
{
	public static class MiskExtension
	{
		public static GameObject GetUniqueGameObject(string name)
		{
			var Gameobjects = SceneManager.GetActiveScene().GetRootGameObjects().ToArray();
			//var Gameobjects = Resources.FindObjectsOfTypeAll<GameObject>().ToArray();
			for (int i = 0; i < Gameobjects.Length; i++)
				if (Networking.GetUniqueName(Gameobjects[i]) == name)
					return Gameobjects[i];
			return null;
		}

		public static void SetToolTipBasedOnToggle(this UiTooltip tooltip)
		{
			UiToggleButton componentInChildren = tooltip.gameObject.GetComponentInChildren<UiToggleButton>();

			if (componentInChildren != null && !string.IsNullOrEmpty(tooltip.GetAlternateText()))
			{
				string displayText = (!componentInChildren.field_Public_Boolean_0) ? tooltip.GetAlternateText() : tooltip.GetText();
				if (TooltipManager.field_Private_Static_Text_0 != null) //Only return type field of text
					TooltipManager.Method_Public_Static_Void_String_0(displayText); //Last function to take string parameter
				if (tooltip.GetToolTip() != null)
					tooltip.GetToolTip().text = displayText;
			}
		}

		internal static Text GetToolTip(this UiTooltip Instance)
		{
			return Instance.field_Public_Text_0;
		}

		internal static string GetText(this UiTooltip Instance)
		{
			return Instance.field_Public_String_0;
		}

		internal static string GetAlternateText(this UiTooltip Instance)
		{
			return Instance.field_Public_String_1;
		}

		internal static bool GetToggledOn(this UiTooltip Instance)
		{
			return Instance.field_Private_Boolean_0;
		}

		public static void EnterPortal(this PortalInternal Instance, string WorldID, string InstanceID)
		{
			Instance.Method_Private_Void_String_String_PDM_0(WorldID, InstanceID);
		}

		public static bool IsInVR()
		{
			return XRDevice.isPresent;
		}

		[Obsolete("This Doenst always works -Day <3")]
		public static bool IsCurrentWorldUdon()
		{
			return RoomManager.field_Internal_Static_ApiWorld_0.tags.Contains("Udon");
		}

		public static void Start(this IEnumerator e)
		{
			MelonCoroutines.Start(e);
		}

		internal static void LoadSprite(this Image Instance, string url)
		{
			MelonLoader.MelonCoroutines.Start(LoadSpriteEnum(Instance, url));
		}

		private static IEnumerator LoadSpriteEnum(this Image Instance, string url)
		{
			while (VRCPlayer.field_Internal_Static_VRCPlayer_0 != true) yield return null;
			var Sprite = new Sprite();
			WWW www = new WWW(url, null, new Il2CppSystem.Collections.Generic.Dictionary<string, string>());
			yield return www;
			{
				Sprite = Sprite.CreateSprite(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
			}
			Instance.sprite = Sprite;
			Instance.color = Color.white;
			yield break;
		}

		public static bool XRefScanForGlobal(this MethodBase methodBase, string searchTerm, bool ignoreCase = true)
		{
			if (!string.IsNullOrEmpty(searchTerm))
				return XrefScanner.XrefScan(methodBase).Any(
					xref => xref.Type == XrefType.Global && xref.ReadAsObject()?.ToString().IndexOf(
								searchTerm,
								ignoreCase
									? StringComparison.OrdinalIgnoreCase
									: StringComparison.Ordinal) >= 0);
			ModConsole.Error($"XRefScanForGlobal \"{methodBase}\" has an empty searchTerm. Returning false");
			return false;
		}

		public static bool XRefScanForMethod(this MethodBase methodBase, string methodName = null, string parentType = null, bool ignoreCase = true)
		{
			if (!string.IsNullOrEmpty(methodName)
				|| !string.IsNullOrEmpty(parentType))
				return XrefScanner.XrefScan(methodBase).Any(
					xref =>
					{
						if (xref.Type != XrefType.Method) return false;

						var found = false;
						MethodBase resolved = xref.TryResolve();
						if (resolved == null) return false;

						if (!string.IsNullOrEmpty(methodName))
							found = !string.IsNullOrEmpty(resolved.Name) && resolved.Name.IndexOf(
									methodName,
									ignoreCase
										? StringComparison.OrdinalIgnoreCase
										: StringComparison.Ordinal) >= 0;

						if (!string.IsNullOrEmpty(parentType))
							found = !string.IsNullOrEmpty(resolved.ReflectedType?.Name) && resolved.ReflectedType.Name.IndexOf(
									parentType,
									ignoreCase
										? StringComparison
											.OrdinalIgnoreCase
										: StringComparison.Ordinal)
								>= 0;

						return found;
					});
			ModConsole.Error($"XRefScanForMethod \"{methodBase}\" has all null/empty parameters. Returning false");
			return false;
		}

		public static int XRefScanMethodCount(this MethodBase methodBase, string methodName = null, string parentType = null, bool ignoreCase = true)
		{
			if (!string.IsNullOrEmpty(methodName)
				|| !string.IsNullOrEmpty(parentType))
				return XrefScanner.XrefScan(methodBase).Count(
					xref =>
					{
						if (xref.Type != XrefType.Method) return false;

						var found = false;
						MethodBase resolved = xref.TryResolve();
						if (resolved == null) return false;

						if (!string.IsNullOrEmpty(methodName))
							found = !string.IsNullOrEmpty(resolved.Name) && resolved.Name.IndexOf(
									methodName,
									ignoreCase
										? StringComparison.OrdinalIgnoreCase
										: StringComparison.Ordinal) >= 0;

						if (!string.IsNullOrEmpty(parentType))
							found = !string.IsNullOrEmpty(resolved.ReflectedType?.Name) && resolved.ReflectedType.Name.IndexOf(
									parentType,
									ignoreCase
										? StringComparison
											.OrdinalIgnoreCase
										: StringComparison.Ordinal)
								>= 0;

						return found;
					});
			ModConsole.Error($"XRefScanMethodCount \"{methodBase}\" has all null/empty parameters. Returning -1");
			return -1;
		}

		public static bool checkXref(this MethodBase m, string match)
		{
			try
			{
				return XrefScanner.XrefScan(m).Any(
					instance => instance.Type == XrefType.Global && instance.ReadAsObject() != null && instance.ReadAsObject().ToString()
								   .Equals(match, StringComparison.OrdinalIgnoreCase));
			}
			catch { }

			return false;
		}

		public static T Cast<T>(this object o)
		{
			return (T)o;
		}

		internal static bool IsRunningNotorious()
		{
			bool _return = false;
			_return = Assembly.GetExecutingAssembly().GetType("Notorious") != null;
			return _return;
		}

		internal static Sprite LoadSpriteFromDisk(this string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return null;
			}
			byte[] array = File.ReadAllBytes(path);
			if (array == null || array.Length == 0)
			{
				return null;
			}
			Texture2D texture2D = new Texture2D(2, 2);
			if (!Il2CppImageConversionManager.LoadImage(texture2D, array))
			{
				return null;
			}
			Sprite sprite = Sprite.CreateSprite(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100f, 0u, SpriteMeshType.FullRect, default(Vector4), generateFallbackPhysicsShape: false);
			sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			return sprite;
		}
	}
}