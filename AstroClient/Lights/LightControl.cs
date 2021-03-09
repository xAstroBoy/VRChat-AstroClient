using RubyButtonAPI;
using System;
using UnityEngine;
using UnityEngine.Rendering;

#region AstroClient Imports

using VRC;
using AstroClient.ConsoleUtils;
using static AstroClient.ConsoleUtils.ModConsole;
using static AstroClient.variables.CustomLists;
using static AstroClient.variables.GlobalLists;

#endregion AstroClient Imports

namespace AstroClient.WorldLights
{
    public class LightControl
    {
        public static QMToggleButton FogSwitch;

        public static bool FogEnabled;

        public static void UpdateFogSwitch()
        {
            if (FogSwitch != null)
            {
                FogSwitch.setToggleState(RenderSettings.fog);
            }
        }

        public static void OnLevelLoad()
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
                ToggleLightmaps.setToggleState(AreLightMapsEnabled);
            }
            if (ToggleFullbright != null)
            {
                ToggleFullbright.setToggleState(false);
            }
            if (ModifyRenderOptions != null)
            {
                ModifyRenderOptions.setToggleState(false);
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
                    ModConsole.Log("Spawning a new sun!");
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
                    ModConsole.Log("Attempting to Set Sun to RenderSettings.Sun");
                    newSun.transform.SetParent(RenderSettings.sun.transform);
                    newSun.transform.rotation = RenderSettings.sun.transform.rotation;
                }
                if (Camera.main != null)
                {
                    Camera.main.farClipPlane = 600f;
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
                Origskybox = RenderSettings.skybox;
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
                OrigFarClipPlane = Camera.main.farClipPlane;
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
                RenderSettings.skybox = Origskybox;
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
                Camera.main.farClipPlane = OrigFarClipPlane;
                if (isUsingASpawnedSun)
                {
                    UnityEngine.Object.DestroyImmediate(newSun);
                    if (newSun == null)
                    {
                        ModConsole.Log("The Generated Sun has been destroyed  : " + newSun.ToString());
                    }
                    else
                    {
                        ModConsole.Log("Something went wrong while destroying the Generated Sun!");
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
                ModConsole.Log("Lightmaps should be deactivated");
            }
            else
            {
                EnableLightMaps();
                ModConsole.Log("Lightmaps should be Enabled");
            }
        }

        public static void EnableLightMaps()
        {
            foreach (var obj in RenderObjects)
            {
                if (obj.gameObject.RenderisSaved())
                {
                    var value = obj.gameObject.GetOriginalLightMapIndex();
                    if (value != -999999999)
                    {
                        obj.lightmapIndex = value;
                    }
                    else
                    {
                        obj.lightmapIndex = 0;
                    }
                }
            }
        }

        public static void DisableLightMaps()
        {
            foreach (var obj in RenderObjects)
            {
                obj.lightmapIndex = -1;
            }
        }

        public static void FindLightmaps()
        {
            if (!HasLightmapsStored)
            {
                var Objects = Resources.FindObjectsOfTypeAll<GameObject>();
                foreach (var obj in Objects)
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

        public static void FullbrightByHead()
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
                    if (isHeadLightActive)
                    {
                        light.enabled = true;
                        light.shadows = LightShadows.None;
                        light.type = LightType.Spot;
                        light.intensity = 1f;
                        light.range = 999f;
                        light.spotAngle = float.MaxValue;
                        light.color = Color.white;
                        ModConsole.Log("Fullbright Enabled!");
                    }
                    else
                    {
                        light.enabled = false;
                        ModConsole.Log("Fullbright Deactivated!");
                    }
                }
            }
            else { ModConsole.Log("I Can't find Player's GameObject, try again!"); }
        }

        public static void ToggleFullbrightHeadLight()
        {
            if (VRCPlayer.field_Internal_Static_VRCPlayer_0 != null)
            {
                isHeadLightActive = !isHeadLightActive;
                FullbrightByHead();
            }
        }

        public static void InitButtons(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var temp = new QMNestedButton(menu, x, y, "Light Menu", "Control Avatar & World Lights!", null, null, null, null, btnHalf);
            ToggleFullbright = new QMToggleButton(temp, 1, 0, "Player Fullbright ON", new Action(ToggleFullbrightHeadLight), "Player Fullbright OFF", new Action(ToggleFullbrightHeadLight), "Toggles Player Fullbright", null, null, null, false);
            ModifyRenderOptions = new QMToggleButton(temp, 2, 0, "Render Fullbright ON", new Action(SetRenderSettings), "Render Fullbright OFF", new Action(RestoreRenderSettings), "Tweaks Level RenderSettings", null, null, null, false);
            ToggleLightmaps = new QMToggleButton(temp, 3, 0, "Baked Lightings ON", new Action(ToggleLightMaps), "Baked Lightings OFF", new Action(ToggleLightMaps), "Toggles Lightmaps (baked lightings)", null, null, null, false);
            FogSwitch = new QMToggleButton(temp, 4, 0, "Fog ON", new Action(ToggleFog), "Fog OFF", new Action(ToggleFog), "Toggles Fog", null, null, null, false);
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
        public static Material Origskybox;
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
        public static float OrigFarClipPlane;

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
        public static bool isHeadLightActive = false;

        public static Light light;
        public static QMToggleButton ToggleFullbright;
        public static QMToggleButton ModifyRenderOptions;
        public static QMToggleButton ToggleLightmaps;
    }
}