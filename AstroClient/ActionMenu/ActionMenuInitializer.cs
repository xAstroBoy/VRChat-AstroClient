namespace AstroClient.ActionMenu
{
    using AstroActionMenu.Api;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class ActionMenuInitializer : GameEvents
    {
        // This is a Test.

        internal override void OnApplicationStart()
        {
            AMUtils.AddToModsFolder("Test", () => { }, null, true);
        }

    }
}
