namespace AstroClient.ClientResources.Loaders
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using CheetoLibrary.Misc;
    using ClientAttributes;
    using xAstroBoy.Utility;

    internal class EventResourceLoader : AstroEvents
    {
        internal override void OnApplicationStart()
        {
            MiscUtils.DelayFunction(0, () =>
            {
                LoadClassResources(typeof(Bundles));
                LoadClassResources(typeof(Materials));
                LoadClassResources(typeof(Prefabs));
                LoadClassResources(typeof(Icons));
            });
        }

        private void LoadClassResources(Type classtype)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ModConsole.DebugLog($"Loading Resources from {classtype.FullName}");
            foreach (var item in classtype.GetProperties(BindingFlags.NonPublic | BindingFlags.Static))
            {
                if (item != null)
                {
                    ModConsole.DebugLog($"Loading {item.Name}");
                    _ = item.GetValue(classtype);
                }
            }
            stopwatch.Stop();
            ModConsole.DebugLog($"Done Loading Resources from {classtype.FullName}, took {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
