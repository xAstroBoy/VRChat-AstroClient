using AstroClient.CheetoLibrary.Utility;
using AstroClient.Config;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;

namespace AstroClient.ClientUI.QuickMenuGUI.SettingsMenu
{
    #region Imports

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class Settings_Spoofs : AstroEvents
    {
        internal static void InitButtons(QMNestedGridMenu tab)
        {
            QMNestedGridMenu sub = new QMNestedGridMenu(tab, "Spoofs", "Spoof Menu");

            // Spoofs
            QMToggleButton toggleSpoofFPS = new QMToggleButton(sub, "FPS Spoof", () => { ConfigManager.General.SpoofFPS = true; }, () => { ConfigManager.General.SpoofFPS = false; }, "Toggle FPS Spoofing");
            toggleSpoofFPS.SetToggleState(ConfigManager.General.SpoofFPS, false);

            QMToggleButton toggleSpoofPing = new QMToggleButton(sub, "Ping Spoof", () => { ConfigManager.General.SpoofPing = true; }, () => { ConfigManager.General.SpoofPing = false; }, "Toggle Ping Spoofing");
            toggleSpoofPing.SetToggleState(ConfigManager.General.SpoofPing, false);

            QMToggleButton toggleSpoofQuest = new QMToggleButton(sub, "Quest Spoof", () => { ConfigManager.General.SpoofQuest = true; }, () => { ConfigManager.General.SpoofQuest = false; }, "Toggle Quest Spoofing\n(Requires Restart)");
            toggleSpoofQuest.SetToggleState(ConfigManager.General.SpoofQuest, false);

            _ = new QMSingleButton(sub, 2, 1, "Set\nFPS\nValue", () =>
            {
                CheetoUtils.PopupCall("Set FPS Value", "Done", "Enter FPS. . .", true, delegate (string text)
                {
                    float value = 0f;

                    try
                    {
                        value = float.Parse(text);
                    }
                    catch
                    {
                        Log.Error("Input value must be a float value!");
                    }
                    finally
                    {
                        ConfigManager.General.SpoofedFPS = value;
                    }
                });
            }, "Input an FPS value");

            _ = new QMSingleButton(sub, 3, 1, "Set\nPing\nValue", () =>
            {
                CheetoUtils.PopupCall("Set Ping Value", "Done", "Enter Ping. . .", true, delegate (string text)
                {
                    short value = 0;

                    try
                    {
                        value = short.Parse(text);
                    }
                    catch
                    {
                        Log.Error("Input value must be a short value!");
                    }
                    finally
                    {
                        ConfigManager.General.SpoofedPing = value;
                    }
                });
            }, "Input a Ping value");
        }
    }
}