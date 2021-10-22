namespace AstroClient.Startup.Buttons
{
    #region Imports

    using AstroLibrary;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using AstroButtonAPI;
    using UnityEngine;
    using CheetoLibrary;

    #endregion Imports

    internal class FlightMenu : GameEvents
    {
        private static QMNestedButton mainButton;

        private static QMSlider desktopSpeedSlider;

        private static QMSlider vrSpeedSlider;

        private static QMSingleButton setPCSpeedButton;

        private static QMSingleButton setVRSpeedButton;

        internal static void InitButtons(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            mainButton = new QMNestedButton(menu, x, y, "Fly Menu", "Fly Options", null, null, null, null, btnHalf);

            desktopSpeedSlider = new QMSlider(QuickMenuUtils.QuickMenu.transform.Find(mainButton.GetMenuName()), "PC Speed", 400, -620, delegate (float value) { Flight.SetDesktopFlySpeed(value); }, ConfigManager.Flight.VRFlySpeed, 40, 1, true);
            desktopSpeedSlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);

            setPCSpeedButton = new QMSingleButton(mainButton, 1, 2, "Set\nPC\nSpeed", delegate ()
            {
                CheetoUtils.PopupCall("Set PC Speed", "Done", "Enter Speed. . .", true, delegate (string text)
                {
                    float value = 0f;

                    try
                    {
                        value = float.Parse(text);
                    }
                    catch
                    {
                        ModConsole.Error("Input value must be a float value!");
                    }
                    finally
                    {
                        desktopSpeedSlider.SetValue(value);
                        Flight.SetDesktopFlySpeed(value);
                    }
                });
            }, "Manually input a PC speed");

            vrSpeedSlider = new QMSlider(QuickMenuUtils.QuickMenu.transform.Find(mainButton.GetMenuName()), "VR Speed", 400, -820, delegate (float value) { Flight.SetVRFlySpeed(value); }, ConfigManager.Flight.VRFlySpeed, 40, 1, true);
            vrSpeedSlider.Slider.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);

            setVRSpeedButton = new QMSingleButton(mainButton, 2, 2, "Set\nVR\nSpeed", delegate ()
            {
                CheetoUtils.PopupCall("Set VR Speed", "Done", "Enter Speed. . .", true, delegate (string text)
                {
                    float value = 0f;

                    try
                    {
                        value = float.Parse(text);
                    }
                    catch
                    {
                        ModConsole.Error("Input value must be a float value!");
                    }
                    finally
                    {
                        vrSpeedSlider.SetValue(value);
                        Flight.SetVRFlySpeed(value);
                    }
                });
            }, "Manually input a VR speed");
        }
    }
}