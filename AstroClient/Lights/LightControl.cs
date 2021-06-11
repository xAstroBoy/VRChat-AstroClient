namespace AstroClient.WorldLights
{
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using RubyButtonAPI;
	using System;
	using System.Linq;
	using UnityEngine;
	using UnityEngine.Rendering;
	using static AstroClient.variables.CustomLists;
	using static AstroClient.variables.GlobalLists;

	public class LightControl : GameEvents
	{
		// TODO : Rewrite this Light Control Class (Borked ATM).


		public static void UpdateFogSwitch()
		{
			if (FogSwitch != null)
			{
				FogSwitch.SetToggleState(RenderSettings.fog);
			}
		}

		public override void OnSceneLoaded(int buildIndex, string sceneName)
		{
			FogEnabled = RenderSettings.fog;
			UpdateFogSwitch();
			HasOriginalRenderEditSettings = true;
			HasBackuppedRenderSettings = false;
			IsHeadLightActive = false;
			HasLightmapsStored = false;
			AreLightMapsEnabled = true;
			if (ToggleLightmaps != null)
			{
				ToggleLightmaps.SetToggleState(AreLightMapsEnabled);
			}
			if (ToggleFullbright != null)
			{
				ToggleFullbright.SetToggleState(false);
			}
			if (ModifyRenderOptions != null)
			{
				ModifyRenderOptions.SetToggleState(false);
			}
		}

		public static void ToggleFog()
		{
			if (!HasBackuppedRenderSettings)
			{
				BackupRenderSettings();
			}

			HasOriginalRenderEditSettings = false;
			FogEnabled = !FogEnabled;
			RenderSettings.fog = FogEnabled;
			UpdateFogSwitch();
		}

		public static void SetRenderSettings()
		{
			try
			{
				BackupRenderSettings();
				HasOriginalRenderEditSettings = false;
				RenderSettings.fog = false;
				RenderSettings.ambientLight = Color.white;
				RenderSettings.ambientGroundColor = Color.white;
				RenderSettings.ambientEquatorColor = Color.white;
				RenderSettings.ambientIntensity = 100f;
				RenderSettings.ambientSkyColor = Color.white;
				RenderSettings.subtractiveShadowColor = Color.white;
				RenderSettings.reflectionBounces = int.MaxValue;
				if (RenderSettings.sun != null)
				{
					RenderSettings.sun.enabled = true;
					RenderSettings.sun.range = float.MaxValue;
					RenderSettings.sun.shadows = LightShadows.None;
					RenderSettings.sun.type = LightType.Directional;
					RenderSettings.sun.color = Color.white;
					RenderSettings.sun.intensity = 1f;
				}
				else
				{
					ModConsole.DebugLog("Spawning a new sun!");
					newSun = new Light();
					isUsingASpawnedSun = true;
					if (newSun != null)
					{
						newSun.enabled = true;
						newSun.range = float.MaxValue;
						newSun.type = LightType.Directional;
						newSun.shadows = LightShadows.None;
						newSun.color = Color.white;
						newSun.intensity = 1f;
					}
					ModConsole.DebugLog("Attempting to Set Sun to RenderSettings.Sun");
					newSun.transform.SetParent(RenderSettings.sun.transform);
					newSun.transform.rotation = RenderSettings.sun.transform.rotation;
				}
				UpdateFogSwitch();
			}
			catch (Exception e)
			{
				ModConsole.Error("Exception : " + e.Message);
			}
		}

		public static void BackupRenderSettings()
		{
			if (HasOriginalRenderEditSettings && !HasBackuppedRenderSettings)
			{
				OrigfogMode = RenderSettings.fogMode;
				OrigambientMode = RenderSettings.ambientMode;
				OrigambientSkyColor = RenderSettings.ambientSkyColor;
				OrigambientEquatorColor = RenderSettings.ambientEquatorColor;
				OrigambientGroundColor = RenderSettings.ambientGroundColor;
				OrigambientIntensity = RenderSettings.ambientIntensity;
				OrigambientLight = RenderSettings.ambientLight;
				OrigsubtractiveShadowColor = RenderSettings.subtractiveShadowColor;
				OrigfogDensity = RenderSettings.fogDensity;
				OrigambientProbe = RenderSettings.ambientProbe;
				OrigcustomReflection = RenderSettings.customReflection;
				OrigreflectionIntensity = RenderSettings.reflectionIntensity;
				OrigreflectionBounces = RenderSettings.reflectionBounces;
				OrigdefaultReflectionMode = RenderSettings.defaultReflectionMode;
				OrigdefaultReflectionResolution = RenderSettings.defaultReflectionResolution;
				OrighaloStrength = RenderSettings.haloStrength;
				OrigflareStrength = RenderSettings.flareStrength;
				Origsun = RenderSettings.sun;
				if (RenderSettings.sun != null)
				{
					OriginalSunStatus = RenderSettings.sun.enabled;
					OriginalSunrange = RenderSettings.sun.range;
					Originalsunshadows = RenderSettings.sun.shadows;
					Originalsuntype = RenderSettings.sun.type;
					Originalsuncolor = RenderSettings.sun.color;
					Originalsunintensity = RenderSettings.sun.intensity;
				}
				OrigfogColor = RenderSettings.fogColor;
				OrigambientSkyboxAmount = RenderSettings.ambientSkyboxAmount;
				OrigfogEndDistance = RenderSettings.fogEndDistance;
				OrigfogStartDistance = RenderSettings.fogStartDistance;
				Origfog = RenderSettings.fog;
				OrigflareFadeSpeed = RenderSettings.flareFadeSpeed;
				HasBackuppedRenderSettings = true;
			}
		}

		public static void RestoreRenderSettings()
		{
			if (!HasOriginalRenderEditSettings)
			{
				RenderSettings.fogMode = OrigfogMode;
				RenderSettings.ambientMode = OrigambientMode;
				RenderSettings.ambientSkyColor = OrigambientSkyColor;
				RenderSettings.ambientEquatorColor = OrigambientEquatorColor;
				RenderSettings.ambientGroundColor = OrigambientGroundColor;
				RenderSettings.ambientIntensity = OrigambientIntensity;
				RenderSettings.ambientLight = OrigambientLight;
				RenderSettings.subtractiveShadowColor = OrigsubtractiveShadowColor;
				RenderSettings.fogDensity = OrigfogDensity;
				RenderSettings.ambientProbe = OrigambientProbe;
				RenderSettings.customReflection = OrigcustomReflection;
				RenderSettings.reflectionIntensity = OrigreflectionIntensity;
				RenderSettings.reflectionBounces = OrigreflectionBounces;
				RenderSettings.defaultReflectionMode = OrigdefaultReflectionMode;
				RenderSettings.defaultReflectionResolution = OrigdefaultReflectionResolution;
				RenderSettings.haloStrength = OrighaloStrength;
				RenderSettings.flareStrength = OrigflareStrength;
				RenderSettings.sun = Origsun;
				if (RenderSettings.sun != null)
				{
					if (!isUsingASpawnedSun)
					{
						RenderSettings.sun.enabled = OriginalSunStatus;
						RenderSettings.sun.range = OriginalSunrange;
						RenderSettings.sun.shadows = Originalsunshadows;
						RenderSettings.sun.type = Originalsuntype;
						RenderSettings.sun.color = Originalsuncolor;
						RenderSettings.sun.intensity = Originalsunintensity;
					}
				}
				RenderSettings.fogColor = OrigfogColor;
				RenderSettings.fogEndDistance = OrigfogEndDistance;
				RenderSettings.fogStartDistance = OrigfogStartDistance;
				RenderSettings.fog = Origfog;
				RenderSettings.flareFadeSpeed = OrigflareFadeSpeed;
				if (isUsingASpawnedSun)
				{
					UnityEngine.Object.DestroyImmediate(newSun);
					if (newSun == null)
					{
						ModConsole.DebugLog("The Generated Sun has been destroyed  : " + newSun.ToString());
					}
					else
					{
						ModConsole.DebugLog("Something went wrong while destroying the Generated Sun!");
					}
					isUsingASpawnedSun = false;
				}
				UpdateFogSwitch();
				HasOriginalRenderEditSettings = true;
			}
		}

		public static void ToggleLightMaps()
		{
			AreLightMapsEnabled = !AreLightMapsEnabled;
			if (!HasLightmapsStored)
			{
				FindLightmaps();
			}
			if (!AreLightMapsEnabled)
			{
				DisableLightMaps();
				ModConsole.DebugLog("Lightmaps should be deactivated");
			}
			else
			{
				EnableLightMaps();
				ModConsole.DebugLog("Lightmaps should be Enabled");
			}
		}

		public static void EnableLightMaps()
		{
			foreach (var obj in RenderObjects.Where(obj => obj.gameObject.RenderisSaved()))
			{
				var value = obj.gameObject.GetOriginalLightMapIndex();
				obj.lightmapIndex = value != -999999999 ? value : 0;
			}
		}

		public static void DisableLightMaps()
		{
			foreach (Renderer obj in RenderObjects)
			{
				obj.lightmapIndex = -1;
			}
		}

		public static void FindLightmaps()
		{
			if (!HasLightmapsStored)
			{
				foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>())
				{
					var renderer = obj.GetComponentInChildren<Renderer>(true);
					if (renderer != null)
					{
						if (!RenderObjects.Contains(renderer))
						{
							RenderObjects.Add(renderer);
						}
						var backup = new RendererSaver(obj, renderer.lightmapIndex);
						if (!RendererSaverIndex.Contains(backup))
						{
							RendererSaverIndex.Add(backup);
						}
					}
				}
				HasLightmapsStored = true;
			}
		}

		public static void FullbrightByHead(bool value)
		{
			if (Utils.LocalPlayer != null)
			{
				var PlayerHeadTransform = Utils.LocalPlayer.GetPlayer().Get_Player_Bone_Transform(HumanBodyBones.Head);
				if (PlayerHeadTransform != null)
				{
					if (FullBrightLight == null)
					{
						FullBrightLight = PlayerHeadTransform.gameObject.AddComponent<Light>();
					}
					if (value)
					{
						FullBrightLight.enabled = true;
						FullBrightLight.shadows = LightShadows.None;
						FullBrightLight.type = LightType.Spot;
						FullBrightLight.intensity = 1f;
						FullBrightLight.range = 999f;
						FullBrightLight.spotAngle = float.MaxValue;
						FullBrightLight.color = Color.white;
						ModConsole.DebugLog("Fullbright Enabled!");
					}
					else
					{
						FullBrightLight.DestroyMeLocal();
						ModConsole.DebugLog("Fullbright Deactivated!");
					}
				}
				else
				{
					ModConsole.DebugError("[Player Fullbright] : I Can't find Player's GameObject!");
				}
			}
			else
			{
				ModConsole.DebugError("[Player Fullbright] : I Can't find LocalPlayer!");

			}
		}

		private static bool _isHeadLightActive;

		public static bool IsHeadLightActive
		{
			get
			{
				return _isHeadLightActive;
			}
			set
			{
				if(value == _isHeadLightActive)
				{
					return;
				}
				_isHeadLightActive = value;
				FullbrightByHead(value);
				if(ToggleFullbright != null)
				{
					ToggleFullbright.SetToggleState(value);
				}
			}
		}

		public static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var temp = new QMNestedButton(menu, x, y, "Light Menu", "Control Avatar & World Lights!", null, null, null, null, btnHalf);
			ToggleFullbright = new QMToggleButton(temp, 1, 0, "Player Fullbright ON", () => { IsHeadLightActive = true; }, "Player Fullbright OFF", () => { IsHeadLightActive = false; }, "Toggles Player Fullbright", null, null, null, false);
			ModifyRenderOptions = new QMToggleButton(temp, 2, 0, "Render Fullbright ON", new Action(SetRenderSettings), "Render Fullbright OFF", new Action(RestoreRenderSettings), "Tweaks Level RenderSettings", null, null, null, false);
			ToggleLightmaps = new QMToggleButton(temp, 3, 0, "Baked Lightings ON", new Action(ToggleLightMaps), "Baked Lightings OFF", new Action(ToggleLightMaps), "Toggles Lightmaps (baked lightings)", null, null, null, false);
			FogSwitch = new QMToggleButton(temp, 4, 0, "Fog ON", new Action(ToggleFog), "Fog OFF", new Action(ToggleFog), "Toggles Fog", null, null, null, false);
		}

		private static Light newSun { get; set; }
		private static bool isUsingASpawnedSun { get; set; }
		private static bool HasOriginalRenderEditSettings { get; set; } = true;
		private static bool HasBackuppedRenderSettings { get; set; } = false;
		private static FogMode OrigfogMode { get; set; }
		private static AmbientMode OrigambientMode { get; set; }
		private static Color OrigambientSkyColor { get; set; }
		private static Color OrigambientEquatorColor { get; set; }
		private static Color OrigambientGroundColor { get; set; }
		private static float OrigambientIntensity { get; set; }
		private static Color OrigambientLight { get; set; }
		private static Color OrigsubtractiveShadowColor { get; set; }
		private static float OrigfogDensity { get; set; }
		private static SphericalHarmonicsL2 OrigambientProbe { get; set; }
		private static Cubemap OrigcustomReflection { get; set; }
		private static float OrigreflectionIntensity { get; set; }
		private static int OrigreflectionBounces { get; set; }
		private static DefaultReflectionMode OrigdefaultReflectionMode { get; set; }
		private static int OrigdefaultReflectionResolution { get; set; }
		private static float OrighaloStrength { get; set; }
		private static float OrigflareStrength { get; set; }
		private static Light Origsun { get; set; }
		private static Color OrigfogColor { get; set; }
		private static float OrigambientSkyboxAmount { get; set; }
		private static float OrigfogEndDistance { get; set; }
		private static float OrigfogStartDistance { get; set; }
		private static bool Origfog { get; set; }
		private static float OrigflareFadeSpeed { get; set; }

		private static bool OriginalSunStatus { get; set; }
		private static float OriginalSunrange { get; set; }
		private static LightShadows Originalsunshadows { get; set; }
		private static LightType Originalsuntype { get; set; }
		private static Color Originalsuncolor { get; set; }
		private static float Originalsunintensity { get; set; }
		private static bool FogEnabled { get; set; }

		private static bool HasLightmapsStored { get; set; } = false;
		private static bool AreLightMapsEnabled { get; set; } = true;
		public static QMToggleButton FogSwitch { get; set; }


		private static Light FullBrightLight{ get; set; }
		private static QMToggleButton ToggleFullbright{ get; set; }
		private static QMToggleButton ModifyRenderOptions{ get; set; }
		private static QMToggleButton ToggleLightmaps{ get; set; }
	}
}