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
    using Moderation;
    using Mono.CSharp;
    using VRC.Core;
    using VRC.Management;

    internal class DumpTool : GameEvents
    {
        internal override void OnApplicationLateStart()
        {
            
            ModConsole.Log("Finished Dumping Classes.");
            Console.ReadKey();
        }


    }
}



