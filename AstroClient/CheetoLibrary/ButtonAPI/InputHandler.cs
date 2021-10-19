namespace CheetoLibrary.ButtonAPI
{
    using AstroClient;
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using UnityEngine;

    internal class InputHandler : GameEvents
    {
        internal override void OnLateUpdate()
        {
            if (!WorldUtils.IsInWorld) return;
            if (Event.current.control && Event.current.shift && Bools.IsDeveloper)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    ModConsole.Log("Current page name: " + QMUtils.QuickMenuInstance._menuStateController._currentRootPage.Name);
                    ModConsole.Log("Current page Index: " + QMUtils.QuickMenuInstance._menuStateController._currentRootPageIndex);
                }
            }
        }
    }
}