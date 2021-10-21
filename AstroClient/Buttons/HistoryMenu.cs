namespace AstroClient.Startup.Buttons
{
    #region Imports

    using AstroClient.Variables;
    using AstroLibrary;
    using AstroButtonAPI;
    using System.Reflection;
    using CheetoLibrary;

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