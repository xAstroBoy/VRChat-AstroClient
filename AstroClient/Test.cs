using AstroClient.Tools.UdonEditor;
using AstroClient.Tools.UdonSearcher;
using AstroClient.xAstroBoy;

namespace AstroClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AstroClient.Tools.UdonEditor;
    using AstroClient.Tools.UdonSearcher;
    using AstroClient.xAstroBoy;
    using AstroClient.Tools.UdonEditor;
    using AstroClient.Tools.UdonSearcher;
    using AstroClient.xAstroBoy;

    internal class Test
    {

        private void SetAdminflag()
        {
            UdonHeapEditor.PatchHeap(UdonSearch.FindUdonVariable(Finder.Find("[ESSENTIALS]/Sync/PickupSync_SPH_SFB_SAC").gameObject, "__1_mp_asOwner_Boolean"), "__1_mp_asOwner_Boolean", true, null, null, true, true);
            UdonHeapEditor.PatchHeap(UdonSearch.FindUdonVariable(Finder.Find("[ESSENTIALS]/AdminTool/AdminPanel").gameObject, "_isAdmin"), "_isAdmin", true, null, null, true, true);


        }
    }
}
