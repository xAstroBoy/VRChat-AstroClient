namespace AstroClient.Experiments
{
	using AstroLibrary.Finder;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using AstroClient.Extensions;
	using AstroClient.ItemTweaker;
	using RubyButtonAPI;
	using UnityEngine;
	using AstroClient.Components;

	public class CameraOnTweakerExperiment : GameEvents
	{



		public static void CheckCamera()
		{
			if (userCameraParent != null)
			{
				if (!UserCamera.Is_DontDestroyOnLoad())
				{
					userCameraParent.Set_DontDestroyOnLoad();
				}
			}
			if (UserCamera != null)
			{
				if(UserCamera.Is_DontDestroyOnLoad())
				{
					UserCamera.Set_DontDestroyOnLoad();
				}
				foreach (var child in UserCamera.Get_All_Childs())
				{
					if (!child.Is_DontDestroyOnLoad())
					{
						child.Set_DontDestroyOnLoad();
					}
				}
			}
		}

		public static void Set_Camera_OnTweaker()
		{
			if (UserCamera != null)
			{
				Tweaker_Object.SetObjectToEdit(UserCamera.gameObject);
			}
		}



		public static void InitQMMenu(QMTabMenu tab, float x, float y, bool btnHalf)
		{
			var tmp = new QMNestedButton(tab, x, y, "Camera Experiments", "Edit Camera Behaviours", null, null, null, null, btnHalf);
			new QMSingleButton(tmp, 1, 0, "Set Camera (Tweaker)", () => { Set_Camera_OnTweaker(); CheckCamera(); }, "Sets Camera on the tweaker", null, null, true);
			new QMSingleButton(tmp, 1, 0.5f, "Reset Camera Parent", () => { UserCamera.parent = userCameraParent; CheckCamera(); }, "Restore Original parent", null, null, true);
			new QMSingleButton(tmp, 1, 1, "Free Camera", () => { UserCamera.parent = null; CheckCamera(); }, "Free The Camera", null, null, true);

		}



		public static Transform UserCamera
		{
			get
			{
				if(_UserCamera == null)
				{
					var camerapath1 = GameObjectFinder.Find("_Application/TrackingVolume/PlayerObjects/UserCamera").transform;
					if(camerapath1 != null)
					{
						return _UserCamera = camerapath1;
					}
					else
					{
						var camerapath2 = GameObjectFinder.Find("UserCamera/PhotoCamera").transform;
						if (camerapath2 != null)
						{
							return _UserCamera = camerapath2; 

						}
					}
					return null;
				}
				else
				{
					return _UserCamera;
				}
			}
		}


		private static Transform userCameraParent
		{
			get
			{
				return GameObjectFinder.Find("_Application/TrackingVolume/PlayerObjects").transform;
			}
		}


		private static Transform _UserCamera;
	}
}
