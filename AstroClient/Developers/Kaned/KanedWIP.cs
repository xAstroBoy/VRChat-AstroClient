namespace AstroClient.Developers.Kaned
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Target;
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    internal class KanedWIP
    {
        internal static KanedWIP i;
        internal static QMNestedGridMenu KWIPMenu { get; private set; }


        internal static void InitMenu(QMGridTab main)
        {
            i = new KanedWIP();
            KWIPMenu = new QMNestedGridMenu(main, "Kaned WIP", "WIP Features", null, Color.red, null, null, false);
            
            //Init Various Parts
            Pathfinding.InitMenu(KWIPMenu);
        }
    }
}
