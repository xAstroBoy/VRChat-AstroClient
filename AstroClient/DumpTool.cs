namespace AstroClient
{
    using System;
    using Tools.Decompiler;

    internal class DumpTool : AstroEvents
    {
        internal override void OnApplicationLateStart()
        {
            DecompilerUtils.DumpClass<VRCInput>();
            ModConsole.Log("Finished Dumping Classes.");
            Console.ReadKey();
        }


    }
}



