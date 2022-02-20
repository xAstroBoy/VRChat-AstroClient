namespace AstroClient.ClientResources.Startup
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Reflection;
    using System.Threading.Tasks;
    using ClientUI.LoadingScreen.Prefabs;
    using Il2CppSystem.Collections;
    using Loaders;
    using MelonLoader;
    using xAstroBoy.Utility;
    using IEnumerator = System.Collections.IEnumerator;

    internal class EventResourceLoader : AstroEvents
    {

        internal override void StartPreloadResources()
        {
            LoadClassResources(typeof(Bundles));
            LoadClassResources(typeof(Materials));
            LoadClassResources(typeof(Prefabs));
            LoadClassResources(typeof(LoadScreenPrefabs));
            LoadClassResources(typeof(Icons));
        }

        private void LoadClassResources(Type classtype)
        {
            MelonCoroutines.Start(LoadClassResourcesCoroutine(classtype));
        }

        private IEnumerator LoadClassResourcesCoroutine(Type classtype)
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
            yield return null;
        }
    }
}
