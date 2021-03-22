using AstroClient.ConsoleUtils;
using UnityEngine;
using Color = System.Drawing.Color;

namespace AstroClient.variables
{
    public static class InstanceBuilder
    {
        public static GameObject InstanceHolder;

        public static void BuildInstanceContainer()
        {
            ModConsole.Log("Generating Instance Holder", Color.LimeGreen);
            InstanceHolder = new GameObject();
            InstanceHolder.name = "Instance Holder " + BuildInfo.Name;
            UnityEngine.Object.DontDestroyOnLoad(InstanceHolder);
        }

        public static GameObject GetInstanceHolder(string instancename = "INSTANCE_OBJECT_ADDED")
        {
            if (InstanceHolder != null)
            {
                if (instancename != "INSTANCE_OBJECT_ADDED")
                {
                    ModConsole.Log(instancename + " is now Added!", Color.Orange);
                }
                UnityEngine.Object.DontDestroyOnLoad(InstanceHolder);
                return InstanceHolder;
            }
            else
            {
                BuildInstanceContainer();
                return GetInstanceHolder();
            }
        }
    }
}