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
            Log.Debug($"Loading Resources from {classtype.FullName}");
            int fails = 0;
            PropertyInfo[] array = classtype.GetProperties(BindingFlags.NonPublic | BindingFlags.Static);
            for (int i = 0; i < array.Length; i++)
            {
                PropertyInfo item = array[i];
                if (item != null)
                {
                    try
                    {
                        //Log.Debug($"Loading {item.Name}");
                        var result = item.GetValue(classtype);
                        if (result != null)
                        {
                            Log.Debug($"Loaded {item.Name}", Color.GreenYellow);
                        }
                        else
                        {
                            Log.Debug($"Failed to load {item.Name}", Color.OrangeRed);
                            fails++;
                        }
                    }
                    catch
                    {
                        Log.Debug($"Failed loading {item.Name}", Color.OrangeRed);
                        fails++;

                    }

                }
            }
            if (fails != 0)
            {
                Log.Error($"Failed to load {fails} resources in {classtype.FullName}! It might affect the Client!");
            }
            stopwatch.Stop();
            Log.Debug($"Done Loading Resources from {classtype.FullName}, took {stopwatch.ElapsedMilliseconds}ms");
            yield return null;
        }
    }
}
