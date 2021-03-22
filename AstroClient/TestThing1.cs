namespace AstroClient
{
    using AstroClient.ConsoleUtils;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TestBase : CheetoComponent
    {
        public override void Start()
        {
            ModConsole.DebugLog("TestThing1 Start()");
        }
    }

    public class TestEvents: CheetoEvents
    {
        public override void Start()
        {
            ModConsole.DebugLog("TestThing2 Start()");
        }
    }

    public class TestHooks : CheetoHooks
    {
        public override void Start()
        {
            ModConsole.DebugLog("TestThing3 Start()");
        }
    }
}
