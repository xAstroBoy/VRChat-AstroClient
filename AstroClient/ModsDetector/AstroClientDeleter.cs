using System.Linq;
using Il2CppSystem.IO;

namespace AstroClient.ModsDetector
{
    using AstroClient.Tools.Extensions;
    using System;
    using System.Collections;
    using System.Reflection;

    internal static class AstroClientDeleter
    {
        private static Assembly _AstroClient_1 = null;

        private static Assembly AstroClient_1
        {
            get
            {
                if (_AstroClient_1 == null)
                {
                    Assembly[] LoadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                    if (LoadedAssemblies != null)
                    {
                        for (int i = 0; i < LoadedAssemblies.Length; i++)
                        {
                            Assembly item = LoadedAssemblies[i];
                            var CopyrightAttrib = item.GetAssemblyAttribute<AssemblyCopyrightAttribute>();
                            if (item.FullName.Contains("AstroClient"))
                            {
                                if (CopyrightAttrib != null)
                                {
                                    if (CopyrightAttrib.Copyright.Equals("Created by xAstroBoy, Cheetos"))
                                    {
                                        return _AstroClient_1 = item;
                                    }
                                }
                            }
                        }
                    }
                }
                return _AstroClient_1;
            }
        }

        private static Assembly _AstroClient_2 = null;

        private static Assembly AstroClient_2
        {
            get
            {
                if (_AstroClient_2 == null)
                {
                    Assembly[] LoadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                    if (LoadedAssemblies != null)
                    {
                        for (int i = 0; i < LoadedAssemblies.Length; i++)
                        {
                            Assembly item = LoadedAssemblies[i];
                            var CopyrightAttrib = item.GetAssemblyAttribute<AssemblyCopyrightAttribute>();
                            if (item.FullName.Contains("AstroClient"))
                            {
                                if (CopyrightAttrib != null)
                                {
                                    if (CopyrightAttrib.Copyright.Equals("Created by Photon Bot"))
                                    {
                                        return _AstroClient_2 = item;
                                    }
                                }
                            }
                        }
                    }
                }
                return _AstroClient_2;
            }
        }
        internal static T GetAssemblyAttribute<T>(this System.Reflection.Assembly ass) where T : Attribute
        {
            object[] attributes = ass.GetCustomAttributes(typeof(T), false);
            if (attributes == null || attributes.Length == 0)
                return null;
            return attributes.OfType<T>().SingleOrDefault();
        }

        internal static IEnumerator DetectNewLeak()
        {
            while (AstroClient_1 == null) yield return null;
            if (AstroClient_1 != null)
            {
                //Log.Debug("Detected AstroClient 1 insallation!");
                // Delete here

                for (var i = 0; i < MelonLoader.MelonHandler.Mods.Count; i++)
                {
                    var melon = MelonLoader.MelonHandler.Mods[i];
                    if (melon.Assembly.Equals(AstroClient_1))
                    {
                        //Log.Debug($"Installation Path is : {melon.Location}");
                        //Console.ReadKey();
                        File.Delete(melon.Location);
                        yield return null;
                    }
                }
            }

            yield return null;
        }

        internal static IEnumerator DetecLeak()
        {
            while (AstroClient_2 == null) yield return null;
            if (AstroClient_2 != null)
            {
                //Log.Debug("Detected AstroClient  2 installation!");
                // Delete here

                for (var index = 0; index < MelonLoader.MelonHandler.Mods.Count; index++)
                {
                    var melon = MelonLoader.MelonHandler.Mods[index];
                    if (melon.Assembly.Equals(AstroClient_2))
                    {
                        //Log.Debug($"Installation Path is : {melon.Location}");
                        //Console.ReadKey();
                        File.Delete(melon.Location);
                        yield return null;
                    }
                }
            }

            yield return null;
        }
    }
}