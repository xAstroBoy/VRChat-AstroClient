namespace AstroClient
{
    using AstroLibrary;
    using AstroLibrary.Utility;
    using System.Collections.Generic;
    using AstroButtonAPI;
    using MelonLoader;

    internal class TabFixes : GameEvents
    {
        internal static bool HasFixed { get; private set; }
        
        internal override void OnQuickMenuOpen()
        {
            if (!HasFixed)
            {

                HasFixed = true;
            }

        }
    }
}