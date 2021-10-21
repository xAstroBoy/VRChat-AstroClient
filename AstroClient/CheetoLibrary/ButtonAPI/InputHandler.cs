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
                    ModConsole.Log("Current page information -------------");
                    ModConsole.Log("Name: " + QMUtils.QuickMenuController._currentRootPage.Name);
                    ModConsole.Log("Index: " + QMUtils.QuickMenuController._currentRootPageIndex);
                    ModConsole.Log("--------------------------------------");
                }
            }
        }
    }
}