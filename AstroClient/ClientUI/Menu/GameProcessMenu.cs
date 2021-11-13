namespace AstroClient.ClientUI.QuickMenuButtons
{
    #region Imports

    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using AstroButtonAPI;
    using AstroLibrary.Console;
    using CheetoLibrary;
    using UnityEngine;
    using Variables;

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class GameProcessMenu : GameEvents
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