namespace AstroClient.Headlight
{
    using AstroButtonAPI;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System;
    using System.Windows.Forms;
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

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            DesktopHeadlightBool = false;
            VRHeadLightBool = false;
            VRLight.DestroyMeLocal();
            DesktopLight.DestroyMeLocal();
            DesktopLight = null;
            VRLight = null;
        }

        private static QMWings WingMenu;
        internal static QMWingToggleButton DesktopHeadlightBtn;
        internal static QMWingToggleButton VRHeadlightBtn;

        private static void InitWings()
        {
            WingMenu = new QMWings(1012, true, "Headlight", "Headlight Options", null, null);
            VRHeadlightBtn = new QMWingToggleButton(WingMenu, "VR headlight", () => { VRHeadLightBool = true; }, () => { VRHeadLightBool = false; }, "Toggle VR Headlight");
            DesktopHeadlightBtn = new QMWingToggleButton(WingMenu, "Desktop Headlight", () => { DesktopHeadlightBool = true; }, () => { DesktopHeadlightBool = false; }, "Toggle Desktop Headlight");
            WingMenu.SetActive(false);
        }

        internal static void HeadlightButtonInit(QMGridTab menu, float x, float y, bool btnHalf)
        {
            QMNestedButton HeadlightConfig = new QMNestedButton(menu, x, y, "Custom Headlight", "Headlight Settings", null, null, null, null, btnHalf);
            HeadlightConfig.AddOpenAction(() =>
            {
                WingMenu.SetActive(true);
                WingMenu.ShowLeftWingPage();
            });
            HeadlightConfig.SetBackButtonAction(menu, () =>
            {
                if (WingMenu != null)
                {
                    WingMenu.SetActive(false);
                    WingMenu.ClickBackButton();
                }
            });
            QMNestedButton HeadlightColor = new QMNestedButton(HeadlightConfig, 4, 0, "Headlight Color", "Configure the Color For the Headlight", null, null, null);

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
            InitWings();
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
                var PlayerHeadTransform = PlayerCameraEditor.PlayerCameraObject.transform;
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
                Transform cam = PlayerCameraEditor.PlayerCameraObject.transform;
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