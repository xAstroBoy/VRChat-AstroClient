namespace AstroClient
{
	using AstroClient.ConsoleUtils;
	using System.Collections.Generic;
	using UnhollowerBaseLib;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	public static class XRay
	{
		private static Dictionary<int, Renderer> OriginallyEnabled { get; } = new Dictionary<int, Renderer>();

		private static Dictionary<int, Renderer> OriginallyDisabled { get; } = new Dictionary<int, Renderer>();

		public static void ToggleEnabledRenderers()
		{
			XRay.ToggleRenderers(XRay.OriginallyEnabled, true);
		}

		public static void ToggleDisabledRenderers()
		{
			XRay.ToggleRenderers(XRay.OriginallyDisabled, false);
		}

		private static void ToggleRenderers(IDictionary<int, Renderer> mutableRendererCollection, bool toggleEnabled)
		{
			string arg = toggleEnabled ? "enabled" : "disabled";
			bool flag = mutableRendererCollection.Count != 0;
			if (flag)
			{
				ModConsole.Log(string.Format("Setting {0} renderers back to {1}", mutableRendererCollection.Count, toggleEnabled));
				foreach (Renderer renderer in mutableRendererCollection.Values)
				{
					bool flag2 = renderer == null;
					if (!flag2)
					{
						renderer.enabled = toggleEnabled;
					}
				}
				mutableRendererCollection.Clear();
			}
			else
			{
				int num = 0;
				foreach (Renderer renderer2 in XRay.AllRenderers())
				{
					bool flag3 = renderer2.enabled != toggleEnabled;
					if (!flag3)
					{
						int num2 = (int)renderer2.GetCachedPtr();
						bool flag4 = XRay.OriginallyEnabled.ContainsKey(num2);
						if (!flag4)
						{
							bool flag5 = XRay.OriginallyDisabled.ContainsKey(num2);
							if (!flag5)
							{
								bool flag6 = ColliderDisplay.MyRenderers.Contains(num2);
								if (!flag6)
								{
									mutableRendererCollection.Add(num2, renderer2);
									renderer2.enabled = !toggleEnabled;
									num++;
								}
							}
						}
					}
				}
				ModConsole.Log(string.Format("Toggled {0} {1} renderers", num, arg));
			}
		}

		private static List<Renderer> AllRenderers()
		{
			List<Renderer> list = new List<Renderer>();
			int sceneCount = SceneManager.sceneCount;
			for (int i = 0; i < sceneCount; i++)
			{
				Il2CppReferenceArray<GameObject> rootGameObjects = SceneManager.GetSceneAt(i).GetRootGameObjects();
				foreach (GameObject go in rootGameObjects)
				{
					XRay.IterateObject(go, list);
				}
			}
			return list;
		}

		private static void IterateObject(GameObject go, List<Renderer> mutableRendererCollection)
		{
			Renderer component = go.GetComponent<Renderer>();
			bool flag = component != null;
			if (flag)
			{
				mutableRendererCollection.Add(component);
			}
			int childCount = go.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = go.transform.GetChild(i);
				XRay.IterateObject(child.gameObject, mutableRendererCollection);
			}
		}
	}
}