namespace AstroClient.ClientUI.Menu.Menus.Quickmenu
{
    #region Imports

    using System.Diagnostics;
    using System.IO;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class GameProcessMenu : AstroEvents
    {
        internal static void InitButtons(QMGridTab tab)
        {
            QMNestedGridMenu menu = new QMNestedGridMenu(tab, 4, 2f, "Process", "Process Menu", null, UnityEngine.Color.red, null, null, true);

            new QMSingleButton(menu, 0, 0, "Close Game", () => { Process.GetCurrentProcess().Kill(); }, "Close the game");

            new QMSingleButton(menu, 0, 1, "Restart Game", () =>
            {
                _ = Process.Start(Directory.GetParent(Application.dataPath) + "\\VRChat.exe");
                Process.GetCurrentProcess().Kill();
            }, "Restart the game");
        }
    }
}