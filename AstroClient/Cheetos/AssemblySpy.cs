using DayClientML2.Utility.Extensions;

namespace AstroClient.Cheetos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class AssemblySpy : Overridables
    {
        public List<Assembly> assembllies { get; private set; } = new List<Assembly>();

        public AssemblySpy() : base()
        {
        }

        public override void OnUpdate()
        {
            assembllies = AppDomain.CurrentDomain.GetAssemblies().ToList();
        }

        public static List<Assembly> GetAssemblies()
        {
            return (Instance as AssemblySpy).assembllies;
        }
    }
}
