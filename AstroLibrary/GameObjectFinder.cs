namespace AstroLibrary.Finder
{
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	public static class GameObjectFinder
	{
		public static GameObject Find(string path)
		{
			var obj = GameObject.Find(path);
			if (obj != null)
			{
				return obj;
			}
			else
			{
				ModConsole.DebugWarning("[WARNING (Find) ]  Gameobject on path [ " + path + " ]  is Invalid, No Object Found!");
				return null;
			}
		}


		public static List<GameObject> GetRootSceneObjects()
		{
			return SceneManager.GetActiveScene().GetRootGameObjects().ToList();
		}


		public static List<GameObject> GetRootSceneObjects_Without_Avatars()
		{
			return SceneManager.GetActiveScene().GetRootGameObjects().Where(x => !x.gameObject.name.Contains("VRCPlayer")).ToList();
		}



		public static List<T> GetRootGameObjectsComponents<T>(bool IncludeInactive = true, bool IncludeAvatarComponents = false) where T : Component
		{
			try
			{
				var results = new List<T>();
				foreach (var obj in GameObjectFinder.GetRootSceneObjects())
				{
					if (!IncludeAvatarComponents)
					{
						if (!obj.name.Contains("VRCPlayer"))
						{
							var objects = obj.GetComponentsInChildren<T>(IncludeInactive).ToList();
							if (objects.Count != 0)
							{
								foreach (var audio in objects)
								{

									if (!results.Contains(audio))
									{
										results.Add(audio);
									}
								}
							}
						}
					}
					else
					{
						var objects = obj.GetComponentsInChildren<T>(IncludeInactive).ToList();
						if (objects.Count != 0)
						{
							foreach (var audio in objects)
							{

								if (!results.Contains(audio))
								{
									results.Add(audio);
								}
							}
						}
					}
				}
				return results;

			}
			catch (Exception e)
			{
				ModConsole.Error("Error parsing Components from Root Objects");
				ModConsole.ErrorExc(e);
				return null;
			}
			return null;
		}

		public static GameObject FindRootSceneObject(string name)
		{
			GameObject obj = SceneManager.GetActiveScene().GetRootGameObjects().Where(x => x.gameObject.name == name).First();

			if (obj == null)
			{
				ModConsole.DebugWarning("[WARNING (FindRootSceneObject) ]  Root Gameobject name [ " + name + " ]  is Invalid, No Object Found!");
			}

			return obj;
		}

		public static Transform FindObject(this Transform transform, string path)
		{
			Transform obj = transform.Find(path);

			if (obj == null)
			{
				ModConsole.DebugWarning($"[WARNING (FindObject) ]  Transform {transform.name} Doesnt have a object in path [ {path} ] !");
			}

			return obj;
		}

		public static List<GameObject> ListFind(string path)
		{
			List<GameObject> list = new List<GameObject>();

			var obj = GameObject.Find(path);
			if (obj != null)
			{
				foreach (var item in obj.GetComponentsInChildren<Transform>())
				{
					list.AddGameObject(item.gameObject);
				}
				return list;
			}
			else
			{
				ModConsole.DebugWarning("[WARNING (ListFind) ] Gameobject on path [ " + path + " ]  is Invalid, No Object Found!");
				return list;
			}
		}

		/// <summary>
		/// This is obsolete.
		/// Use root object finder, then find the object from there
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		[Obsolete ("Use root object finder, then find the object from there")]
		public static GameObject InactiveFind(string path)
		{
			foreach (GameObject gameObj in Resources.FindObjectsOfTypeAll<GameObject>())
			{
				if (GetGameObjectPath(gameObj).Equals(path))
				{
					ModConsole.Log($"FOUND: {GetGameObjectPath(gameObj)}");
					return gameObj;
				}
			}
			ModConsole.DebugWarning("[WARNING (InactiveFind) ]  Gameobject on path [ " + path + " ]  is Invalid, No Object Found!");
			return null;
		}

		public static string GetGameObjectPath(GameObject obj)
		{
			string path = "/" + obj.name;
			while (obj.transform.parent != null)
			{
				obj = obj.transform.parent.gameObject;
				path = "/" + obj.name + path;
			}
			return path;
		}
	}
}