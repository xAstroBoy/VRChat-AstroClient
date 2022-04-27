using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;

namespace AstroClient.Kaned
{
    internal class KanedWIP
    {
        internal static KanedWIP i;
        internal static QMNestedGridMenu KWIPMenu { get; private set; }


        internal static void InitMenu(QMGridTab main)
        {
            i = new KanedWIP();
            KWIPMenu = new QMNestedGridMenu(main, "Kaned WIP", "WIP Features", null, UnityEngine.Color.red, null, null, false);
            
            //Init Various Parts
            Pathfinding.InitMenu(KWIPMenu);
        }
    }
}
