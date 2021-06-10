namespace AstroClient.WorldLights
{
	using AstroClient.Extensions;
	using AstroClient.Skyboxes;
	using AstroLibrary.Console;
	using RubyButtonAPI;
	using System;
	using System.Linq;
	using UnityEngine;
	using UnityEngine.Rendering;
	using VRC;
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
            if (Player.prop_Player_0 != null)
            {
                var PlayerHeadTransform = LocalPlayerUtils.GetPlayerBoneTransform(HumanBodyBones.Head);
                if (light == null)
                {
                    light = PlayerHeadTransform.gameObject.AddComponent<Light>();
                    light.name = "Fullbright";
                }

				if (PlayerHeadTransform != null)
				{
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
            else { ModConsole.DebugLog("[Player Fullbright] : Player is null!!"); }
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
            SkyboxEditor.CustomSkyboxesMenu(temp, 1, 1, false);
        }

        public static Light newSun;
        public static bool isUsingASpawnedSun;
        public static bool HasOriginalRenderEditSettings = true;
        public static bool HasBackuppedRenderSettings = false;
        public static FogMode OrigfogMode;
        public static AmbientMode OrigambientMode;
        public static Color OrigambientSkyColor;
        public static Color OrigambientEquatorColor;
        public static Color OrigambientGroundColor;
        public static float OrigambientIntensity;
        public static Color OrigambientLight;
        public static Color OrigsubtractiveShadowColor;
        public static float OrigfogDensity;
        public static SphericalHarmonicsL2 OrigambientProbe;
        public static Cubemap OrigcustomReflection;
        public static float OrigreflectionIntensity;
        public static int OrigreflectionBounces;
        public static DefaultReflectionMode OrigdefaultReflectionMode;
        public static int OrigdefaultReflectionResolution;
        public static float OrighaloStrength;
        public static float OrigflareStrength;
        public static Light Origsun;
        public static Color OrigfogColor;
        public static float OrigambientSkyboxAmount;
        public static float OrigfogEndDistance;
        public static float OrigfogStartDistance;
        public static bool Origfog;
        public static float OrigflareFadeSpeed;

        public static bool OriginalSunStatus;
        public static float OriginalSunrange = float.MaxValue;
        public static LightShadows Originalsunshadows;
        public static LightType Originalsuntype;
        public static Color Originalsuncolor;
        public static float Originalsunintensity;

        public static bool HasLightmapsStored = false;
        public static bool AreLightMapsEnabled = true;
        public static float FullbrightRange = float.MaxValue; // default : 180f
        public static float FullbrightSpotAngle = 180f;


        public static Light light;
        public static QMToggleButton ToggleFullbright;
        public static QMToggleButton ModifyRenderOptions;
        public static QMToggleButton ToggleLightmaps;
    }
}