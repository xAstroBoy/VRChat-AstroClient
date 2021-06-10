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

		public static QMToggleButton FogSwitch;

		public static bool FogEnabled;

		public static void UpdateFogSwitch()
		{
			if (FogSwitch != null)
			{
				FogSwitch.SetToggleState(RenderSettings.fog);
			}
		}

		public override void OnLevelLoaded()
		{
			FogEnabled = RenderSettings.fog;
			UpdateFogSwitch();
			HasOriginalRenderEditSettings = true;
			HasBackuppedRenderSettings = false;
			isHeadLightActive = false;
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
			var PlayerHeadTransform = Utils.LocalPlayer.GetPlayer().Get_Player_Bone_Transform(HumanBodyBones.Head);
			if (PlayerHeadTransform != null)
			{
				if (light == null)
				{
					light = PlayerHeadTransform.gameObject.AddComponent<Light>();
					light.name = "Fullbright";
				}
				if (value)
				{
					light.enabled = true;
					light.shadows = LightShadows.None;
					light.type = LightType.Spot;
					light.intensity = 1f;
					light.range = 999f;
					light.spotAngle = float.MaxValue;
					light.color = Color.white;
					ModConsole.DebugLog("Fullbright Enabled!");
				}
				else
				{
					light.enabled = false;
					ModConsole.DebugLog("Fullbright Deactivated!");
				}
			}
			else
			{
				ModConsole.Error("[Player Fullbright] : I Can't find Player's GameObject!");
			}
		}

		private static bool _isHeadLightActive;

		public static bool isHeadLightActive
		{
			get
			{
				return _isHeadLightActive;
			}
			set
			{
				_isHeadLightActive = value;
				FullbrightByHead(value);
			}
		}

		public static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
		{
			var temp = new QMNestedButton(menu, x, y, "Light Menu", "Control Avatar & World Lights!", null, null, null, null, btnHalf);
			ToggleFullbright = new QMToggleButton(temp, 1, 0, "Player Fullbright ON", () => { isHeadLightActive = true; }, "Player Fullbright OFF", () => { isHeadLightActive = false; }, "Toggles Player Fullbright", null, null, null, false);
			ModifyRenderOptions = new QMToggleButton(temp, 2, 0, "Render Fullbright ON", new Action(SetRenderSettings), "Render Fullbright OFF", new Action(RestoreRenderSettings), "Tweaks Level RenderSettings", null, null, null, false);
			ToggleLightmaps = new QMToggleButton(temp, 3, 0, "Baked Lightings ON", new Action(ToggleLightMaps), "Baked Lightings OFF", new Action(ToggleLightMaps), "Toggles Lightmaps (baked lightings)", null, null, null, false);
			FogSwitch = new QMToggleButton(temp, 4, 0, "Fog ON", new Action(ToggleFog), "Fog OFF", new Action(ToggleFog), "Toggles Fog", null, null, null, false);
		}

		public static Light newSun { get; set; }
		public static bool isUsingASpawnedSun { get; set; }
		public static bool HasOriginalRenderEditSettings { get; set; } = true;
		public static bool HasBackuppedRenderSettings { get; set; } = false;
		public static FogMode OrigfogMode { get; set; }
		public static AmbientMode OrigambientMode { get; set; }
		public static Color OrigambientSkyColor { get; set; }
		public static Color OrigambientEquatorColor { get; set; }
		public static Color OrigambientGroundColor { get; set; }
		public static float OrigambientIntensity { get; set; }
		public static Color OrigambientLight { get; set; }
		public static Color OrigsubtractiveShadowColor { get; set; }
		public static float OrigfogDensity { get; set; }
		public static SphericalHarmonicsL2 OrigambientProbe { get; set; }
		public static Cubemap OrigcustomReflection { get; set; }
		public static float OrigreflectionIntensity { get; set; }
		public static int OrigreflectionBounces { get; set; }
		public static DefaultReflectionMode OrigdefaultReflectionMode { get; set; }
		public static int OrigdefaultReflectionResolution { get; set; }
		public static float OrighaloStrength { get; set; }
		public static float OrigflareStrength { get; set; }
		public static Light Origsun { get; set; }
		public static Color OrigfogColor { get; set; }
		public static float OrigambientSkyboxAmount { get; set; }
		public static float OrigfogEndDistance { get; set; }
		public static float OrigfogStartDistance { get; set; }
		public static bool Origfog { get; set; }
		public static float OrigflareFadeSpeed { get; set; }

		public static bool OriginalSunStatus { get; set; }
		public static float OriginalSunrange { get; set; }
		public static LightShadows Originalsunshadows { get; set; }
		public static LightType Originalsuntype { get; set; }
		public static Color Originalsuncolor { get; set; }
		public static float Originalsunintensity { get; set; }

		public static bool HasLightmapsStored { get; set; } = false;
		public static bool AreLightMapsEnabled { get; set; } = true;
		public static float FullbrightRange { get; set; } = float.MaxValue; // default : 180f
		public static float FullbrightSpotAngle { get; set; } = 180f;

		public static Light light;
		public static QMToggleButton ToggleFullbright;
		public static QMToggleButton ModifyRenderOptions;
		public static QMToggleButton ToggleLightmaps;
	}
}