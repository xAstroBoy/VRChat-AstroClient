namespace AstroClient
{
    using AstroLibrary.Extensions;
    using MelonLoader;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AstroLibrary.Console;

    internal class DumpTool : GameEvents
    {
        internal override void OnApplicationLateStart()
        {
            DecompilerUtils.DumpClass<SyncPhysics>();
        }



    }
}



