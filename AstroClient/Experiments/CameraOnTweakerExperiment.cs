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



		public override void OnLateUpdate()
		{
			if (PhotoCamera != null)
			{
				if (PhotoCameraPickup != null)
				{
					if (HasBackuppedLayer)
					{
						if (PhotoCameraPickup.pickupable)
						{
							PhotoCamera.layer = 13;
						}
						else
						{
							PhotoCamera.layer = OriginalLayer;
						}
					}
					else
					{
						OriginalLayer = PhotoCamera.layer;
					}

				}
			}
		}

		public static void Set_Camera_OnTweaker()
		{
			if (PhotoCamera != null)
			{
				Tweaker_Object.SetObjectToEdit(PhotoCamera);
			}

		}



		public static void InitQMMenu(QMTabMenu tab, float x, float y, bool btnHalf)
		{
			var tmp = new QMNestedButton(tab, x, y, "Tweaker Experiments", "Set UI Items on the tweaker (Dangerous)", null, null, null, null, btnHalf);
			new QMSingleButton(tmp, 1, 0, "Set Camera (Tweaker)", () => { Set_Camera_OnTweaker(); }, "Sets Camera on the tweaker", null, null, true);
		}

		public static GameObject PhotoCamera
		{
			get
			{
				if(_PhotoCamera == null)
				{
					var camerapath1 = GameObjectFinder.Find("_Application/TrackingVolume/PlayerObjects/UserCamera/PhotoCamera");
					if(camerapath1 != null)
					{
						return _PhotoCamera = camerapath1;
					}
					else
					{
						var camerapath2 = GameObjectFinder.Find("PhotoCamera/PhotoCamera");
						if (camerapath2 != null)
						{
							return _PhotoCamera = camerapath2; 

						}
					}
					return null;
				}
				else
				{
					return _PhotoCamera;
				}
			}
		}

		public static PickupController PhotoCameraPickup
		{
			get
			{
				if (_PhotoCameraPickup == null)
				{
					var control = _PhotoCamera.GetComponent<PickupController>();
					if(control == null)
					{
						control = _PhotoCamera.AddComponent<PickupController>();
					}
					return _PhotoCameraPickup = control;
				}
				else
				{
					return _PhotoCameraPickup;
				}
			}
		}



		private static PickupController _PhotoCameraPickup;
		private static GameObject _PhotoCamera;
		private static int OriginalLayer;
		private bool HasBackuppedLayer;
	}
}
