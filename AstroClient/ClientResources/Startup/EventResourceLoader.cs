namespace AstroClient.ClientResources.Loaders
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
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
            int fails = 0;
            foreach (var item in classtype.GetProperties(BindingFlags.NonPublic | BindingFlags.Static))
            {
                if (item != null)
                {
                    try
                    {
                        //ModConsole.DebugLog($"Loading {item.Name}");
                        var result = item.GetValue(classtype);
                        if (result != null)
                        {
                            ModConsole.DebugLog($"Loaded {item.Name}", Color.GreenYellow);
                        }
                        else
                        {
                            ModConsole.DebugLog($"Failed to load {item.Name}", Color.OrangeRed);
                            fails++;
                        }
                    }
                    catch
                    {
                        ModConsole.DebugLog($"Failed loading {item.Name}", Color.OrangeRed);
                        fails++;

                    }

                }
            }
            if (fails != 0)
            {
                ModConsole.DebugError($"Failed to load {fails} resources in {classtype.FullName}! It might affect the Client!");
            }
            stopwatch.Stop();
            ModConsole.DebugLog($"Done Loading Resources from {classtype.FullName}, took {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
