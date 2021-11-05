namespace AstroClient.ClientUI.QuickMenuButtons
{
    #region Imports

    using System.Reflection;
    using AstroButtonAPI;
    using CheetoLibrary;
    using Variables;

    #endregion Imports

    internal class HistoryMenu : GameEvents
    {
        internal static QMTabMenu SubMenu { get; private set; }

        internal static void InitButtons(float pos)
        {
            if (Bools.IsDeveloper)
            {
                SubMenu = new QMTabMenu(pos, "History Menu", null, null, null, CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.history.png"));
            }
        }
    }
}