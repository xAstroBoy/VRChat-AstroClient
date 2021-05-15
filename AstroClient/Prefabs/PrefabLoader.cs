namespace AstroClient.Prefabs
{
	using AstroLibrary.Console;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;
	using AstroExtensions;
	using AstroClient.extensions;

	public class PrefabLoader : GameEvents
	{

		public static GameObject LoadFromAssembly(string filename)
		{
			return Resources.Load<GameObject>(Assembly.GetExecutingAssembly().GetManifestResourceNames().Single(str => str.EndsWith(filename)));
		}

		private static GameObject ButtonPrefab;
		private static AssetBundle buttonBundle;
		public static GameObject InstantiateButton()
		{
			if(File.Exists(Environment.CurrentDirectory + @"\AstroClient\buttons"))
			{
				ModConsole.DebugLog("Found Button Bundle");
			}
			if (ButtonPrefab == null)
			{
				var stream = File.ReadAllBytes(Environment.CurrentDirectory + @"\AstroClient\buttons");
				buttonBundle = AssetBundle.LoadFromMemory(stream.ToArray(), 0);
				buttonBundle.hideFlags |= HideFlags.DontUnloadUnusedAsset;
				foreach (var assetname in buttonBundle.AllAssetNames())
				{
					ModConsole.DebugLog("Searching for Prefab File in path : " + assetname);
					if (assetname.ToLower().EndsWith(".prefab"))
					{
						ButtonPrefab = buttonBundle.LoadAsset<GameObject>(assetname);
						return ButtonPrefab.InstantiateObject();
					}
				}
			}
			else
			{
				return ButtonPrefab.InstantiateObject();
			}
			return null;
		}


	}
}
