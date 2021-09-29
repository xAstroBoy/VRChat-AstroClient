namespace AstroClient.Startup.Buttons
{
    #region Imports

    using AstroClient.Variables;
    using AstroLibrary;
    using RubyButtonAPI;
    using System.Reflection;

    #endregion Imports

    internal class HistoryMenu : GameEvents
    {
        internal static  QMTabMenu SubMenu { get; private set; }

        internal static  void InitButtons(float pos)
        {
            if (Bools.IsDeveloper)
            {
                SubMenu = new QMTabMenu(pos, "History Menu", null, null, null, CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.history.png"));
            }
        }
    }
}