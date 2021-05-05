namespace AstroClient.Prefabs
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;

	public static class PrefabLoader
	{

		public static GameObject LoadFromAssembly(string filename)
		{
			return Resources.Load<GameObject>(Assembly.GetExecutingAssembly().GetManifestResourceNames().Single(str => str.EndsWith(filename)));
		}

		public static GameObject InstantiateButton()
		{
			return GameObject.Instantiate(Resources.Load<GameObject>((Environment.CurrentDirectory + @"\AstroClient\Resources\Button")));
		}



	}
}
