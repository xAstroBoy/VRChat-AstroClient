namespace AstroClient.WorldLights
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using RubyButtonAPI;
    using System;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.Rendering;
    using static AstroClient.Variables.CustomLists;
    using static AstroClient.Variables.GlobalLists;

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
            //if (ToggleLightmaps != null)
            //{
            //    ToggleLightmaps.SetToggleState(AreLightMapsEnabled);
            //}
            if (ToggleFullbright != null)
            {
                ToggleFullbright.SetToggleState(false);
            }
            if (RenderFullbrightToggle != null)
            {
                RenderFullbrightToggle.SetToggleState(false);
            }
        }

        public static void ToggleFog(bool value)
        {
            if (!HasBackuppedRenderSettings)
            {
                BackupRenderSettings();
            }

            HasOriginalRenderEditSettings = false;
            FogEnabled = value;
            RenderSettings.fog = value;
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
                    NewSun = new Light();
                    IsUsingASpawnedSun = true;
                    if (NewSun != null)
                    {
                        NewSun.enabled = true;
                        NewSun.range = float.MaxValue;
                        NewSun.type = LightType.Directional;
                        NewSun.shadows = LightShadows.None;
                        NewSun.color = Color.white;
                        NewSun.intensity = 1f;
                    }
                    ModConsole.DebugLog("Attempting to Set Sun to RenderSettings.Sun");
                    NewSun.transform.SetParent(RenderSettings.sun.transform);
                    NewSun.transform.rotation = RenderSettings.sun.transform.rotation;
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
                    if (!IsUsingASpawnedSun)
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
                if (IsUsingASpawnedSun)
                {
                    UnityEngine.Object.DestroyImmediate(NewSun);
                    if (NewSun == null)
                    {
                        ModConsole.DebugLog("The Generated Sun has been destroyed  : " + NewSun.ToString());
                    }
                    else
                    {
                        ModConsole.DebugLog("Something went wrong while destroying the Generated Sun!");
                    }
                    IsUsingASpawnedSun = false;
                }
                UpdateFogSwitch();
                HasOriginalRenderEditSettings = true;
            }
        }

        public static void ToggleLightMaps(bool value)
        {
            AreLightMapsEnabled = value;
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
                if (value == _isHeadLightActive)
                {
                    return;
                }
                _isHeadLightActive = value;
                FullbrightByHead(value);
                if (ToggleFullbright != null)
                {
                    ToggleFullbright.SetToggleState(value);
                }
            }
        }

        public static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            var temp = new QMNestedButton(menu, x, y, "Light Menu", "Control Avatar & World Lights!", null, null, null, null, btnHalf);

            ToggleFullbright = new QMSingleToggleButton(temp, 1, 0, "Player Headlight: ON", () => { IsHeadLightActive = true;}, "Player Headlight: OFF", () => {IsHeadLightActive = false; }, "Toggle Player Headlight", Color.green, Color.red, null, false, true);

            RenderFullbrightToggle = new QMSingleToggleButton(temp, 1, 0.5f, "Render Fullbright: ON", () => { SetRenderSettings(); }, "Render Fullbright: OFF", () => { RestoreRenderSettings(); }, "Tweaks Level RenderSettings To Make the whole place Visible.", Color.green, Color.red, null, false, true);
            FogSwitch = new QMSingleToggleButton(temp, 1, 1f, "FOG: ON", () => { ToggleFog(true); }, "FOG: OFF", () => { ToggleFog(false); }, "Tweaks Level RenderSettings Fog.", Color.green, Color.red, null, false, true);


            new QMSingleButton(temp, 2, 0, "Spawn Flashlight", () => { Astro_Flashlight.SpawnFlashlight(); }, "Spawn a Flashlight", null, null, true);
            new QMSingleButton(temp, 2, 0.5f, "Destroy Spawned Flashlights", () => { Astro_Flashlight.DestroyAllFlashLights(); }, "Kill Spawned Flashlights", null, null, true);

            // TODO : make it less laggy and able to toggle em on/off without breaking itself.
            //ToggleLightmaps = new QMSingleToggleButton(temp, 1, 1f, "Baked Lightings: ON", () => { ToggleLightMaps(true); }, "Baked Lightings: OFF", () => { ToggleLightMaps(false); }, "Tries to toggle on/off LightMaps but is broken and buggy.", Color.green, Color.red, null, false, true);





        }

        private static Light NewSun { get; set; }
        private static bool IsUsingASpawnedSun { get; set; }
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
        public static QMSingleToggleButton FogSwitch { get; set; }


        private static Light FullBrightLight { get; set; }
        private static QMSingleToggleButton ToggleFullbright { get; set; }
        private static QMSingleToggleButton RenderFullbrightToggle { get; set; }
        private static QMSingleToggleButton ToggleLightmaps { get; set; }
    }
}