namespace AstroClient.Headlight
{
    using System;
    using System.Windows.Forms;
    using AstroButtonAPI;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using UnityEngine;
    using VRC;
    using Object = UnityEngine.Object;

    internal class Headlight : GameEvents
    {
        internal static float LightRange = 10f;
        internal static Color LightColor = Color.white;
        internal static float LightIntensity = 1f;
        internal static float LightAngle = 80f;
        private static bool _DesktopHeadlight;

        internal static bool DesktopHeadlightBool
        {
            get
            {
                return _DesktopHeadlight;
            }
            set
            {
                if (DesktopHeadlightBtn != null)
                {
                    DesktopHeadlightBtn.SetToggleState(value);
                }
                DesktopHeadLight(value);
                _DesktopHeadlight = value;
            }
        }

        private static bool _VRHeadlight;

        internal static bool VRHeadLightBool
        {
            get
            {
                return _VRHeadlight;
            }
            set
            {
                if (VRHeadlightBtn != null)
                {
                    VRHeadlightBtn.SetToggleState(value);
                }
                VRHeadLight(value);
                _VRHeadlight = value;
            }
        }

        internal static QMSingleToggleButton DesktopHeadlightBtn;
        internal static QMSingleToggleButton VRHeadlightBtn;

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            DesktopHeadlightBool = false;
            VRHeadLightBool = false;
            VRLight.DestroyMeLocal();
            DesktopLight.DestroyMeLocal();
            DesktopLight = null;
            VRLight = null;
        }

        internal static void HeadlightButtonInit(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            QMNestedButton HeadlightConfig = new QMNestedButton(menu, x, y, "Custom Headlight", "Headlight Settings", null, null, null, null, btnHalf);

            QMNestedButton HeadlightColor = new QMNestedButton(HeadlightConfig, 4, 0, "Headlight Color", "Configure the Color For the Headlight", null, null, null);
            DesktopHeadlightBtn = new QMSingleToggleButton(HeadlightConfig, 0, 0, "Desktop Headlight On", () =>
           {
               DesktopHeadlightBool = true;
           }, "Desktop Headlight Off", () => { DesktopHeadlightBool = false; }, "Headlight for dark places or whatever", Color.green, Color.red, null, false, true);
            DesktopHeadlightBtn.SetResizeTextForBestFit(true);

            VRHeadlightBtn = new QMSingleToggleButton(HeadlightConfig, 0, 0.5f, "VR Headlight On", () =>
            {
                VRHeadLightBool = true;
            }, "VR Headlight Off", () => { VRHeadLightBool = false; }, "Headlight for dark places or whatever", Color.green, Color.red, null, false, true);
            VRHeadlightBtn.SetResizeTextForBestFit(true);

            _ = new QMSingleButton(HeadlightConfig, 1, 0, "+ \n Intensity \n +", () =>
              {
                  LightIntensity += 1f;
                  UpdateLights();
              }, "Increase Intensity of the Headlight");

            _ = new QMSingleButton(HeadlightConfig, 1, 1, "- \n Intensity \n -", () =>
              {
                  LightIntensity -= 1f;
                  UpdateLights();
              }, "Decrease Intensity of the Headlight");

            _ = new QMSingleButton(HeadlightConfig, 1, 2, "Reset", () =>
              {
                  LightIntensity = 1f;
                  UpdateLights();
              }, "Reset Intensity of the Headlight");

            _ = new QMSingleButton(HeadlightConfig, 2, 0, "+ \n Angle \n +", () =>
              {
                  LightAngle += 10f;
                  UpdateLights();
              }, "Increase Angle of the Headlight");

            _ = new QMSingleButton(HeadlightConfig, 2, 1, "- \n Angle \n -", () =>
              {
                  LightAngle -= 10f;
                  UpdateLights();
              }, "Decrease Angle of the Headlight");

            _ = new QMSingleButton(HeadlightConfig, 2, 2, "Reset", () =>
              {
                  LightAngle = 80f;
                  UpdateLights();
              }, "Reset Angle of the Headlight");

            _ = new QMSingleButton(HeadlightConfig, 3, 0, "+ \n Range \n +", () =>
              {
                  LightRange += 10f;
                  UpdateLights();
              }, "Increase Range of the Headlight");

            _ = new QMSingleButton(HeadlightConfig, 3, 1, "- \n Range \n -", () =>
              {
                  LightRange -= 10f;
                  UpdateLights();
              }, "Decrease Range of the Headlight");

            _ = new QMSingleButton(HeadlightConfig, 3, 2, "Reset", () =>
              {
                  LightRange = 10f;
                  UpdateLights();
              }, "Reset Range of the Headlight");

            _ = new QMSingleButton(HeadlightColor, 1, 0, "White", () =>
              {
                  LightColor = Color.white;
                  UpdateLights();
              }, "Changes Headlight Color", Color.white, Color.white);

            _ = new QMSingleButton(HeadlightColor, 2, 0, "Red", () =>
              {
                  LightColor = Color.red;
                  UpdateLights();
              }, "Changes Headlight Color", Color.red, Color.red);

            _ = new QMSingleButton(HeadlightColor, 3, 0, "Green", () =>
              {
                  LightColor = Color.green;
                  UpdateLights();
              }, "Changes Headlight Color", Color.green, Color.green);

            _ = new QMSingleButton(HeadlightColor, 4, 0, "Blue", () =>
              {
                  LightColor = Color.blue;
                  UpdateLights();
              }, "Changes Headlight Color", Color.blue, Color.blue);

            _ = new QMSingleButton(HeadlightColor, 1, 1, "Magenta", () =>
              {
                  LightColor = Color.magenta;
                  UpdateLights();
              }, "Changes Headlight Color", Color.magenta, Color.magenta);

            _ = new QMSingleButton(HeadlightColor, 2, 1, "Yellow", () =>
              {
                  LightColor = Color.yellow;
                  UpdateLights();
              }, "Changes Headlight Color", Color.yellow, Color.yellow);

            _ = new QMSingleButton(HeadlightColor, 3, 1, "Cyan", () =>
              {
                  LightColor = Color.cyan;
                  UpdateLights();
              }, "Changes Headlight Color", Color.cyan, Color.cyan);

            _ = new QMSingleButton(HeadlightColor, 4, 1, "Hex From Clipboard", () =>
              {
                  try
                  {
                      LightColor = ColorUtils.HexToColor(Clipboard.GetText());
                      UpdateLights();
                  }
                  catch (Exception)
                  {
                      ModConsole.Error("Error: [Invalid Hex Code]");
                  }
              }, "Changes Headlight Color");
        }

        internal static Light DesktopLight;
        internal static Light VRLight;

        internal static void UpdateLights()
        {
            if (DesktopLight != null)
            {
                DesktopLight.color = LightColor;
                DesktopLight.type = LightType.Spot;
                DesktopLight.shadows = LightShadows.None;
                DesktopLight.range = LightRange;
                DesktopLight.spotAngle = LightAngle;
                DesktopLight.intensity = LightIntensity;
            }
            if (VRLight != null)
            {
                VRLight.color = LightColor;
                VRLight.type = LightType.Spot;
                VRLight.shadows = LightShadows.None;
                VRLight.range = LightRange;
                VRLight.spotAngle = LightAngle;
                VRLight.intensity = LightIntensity;
            }
        }

        internal static void VRHeadLight(bool state)
        {
            if (Player.prop_Player_0 != null)
            {
                var PlayerHeadTransform = Utils.LocalPlayer.GetPlayer().Get_Player_Bone_Transform(HumanBodyBones.Head);
                if (PlayerHeadTransform != null)
                {
                    if (state)
                    {
                        Light light = PlayerHeadTransform.gameObject.AddComponent<Light>();
                        VRLight = light;
                        light.color = LightColor;
                        light.type = LightType.Spot;
                        light.shadows = LightShadows.None;
                        light.range = LightRange;
                        light.spotAngle = LightAngle;
                        light.intensity = LightIntensity;
                    }
                    else if (VRLight != null)
                    {
                        Object.Destroy(VRLight);
                    }
                }
            }
            else { ModConsole.DebugLog("[Headlight] I Can't find Player's GameObject, try again!"); }
        }

        private static void DesktopHeadLight(bool state)
        {
            if (Camera.main != null)
            {
                Transform cam = Camera.main.transform;
                if (cam != null)
                {
                    if (state)
                    {
                        Light light = cam.gameObject.AddComponent<Light>();
                        DesktopLight = light;
                        light.color = LightColor;
                        light.type = LightType.Spot;
                        light.shadows = LightShadows.None;
                        light.range = LightRange;
                        light.spotAngle = LightAngle;
                        light.intensity = LightIntensity;
                    }
                    else if (DesktopLight != null)
                    {
                        Object.Destroy(DesktopLight);
                    }
                }
                else
                {
                    ModConsole.Error("[Headlight] : Unable to Find Main Camera Transform.");
                    if (DesktopHeadlightBtn != null)
                    {
                        DesktopHeadlightBtn.SetToggleState(false);
                    }
                }
            }
            else
            {
                ModConsole.Error("[Headlight] : Unable to Find Main Camera.");
                if (DesktopHeadlightBtn != null)
                {
                    DesktopHeadlightBtn.SetToggleState(false);
                }
            }
        }
    }
}