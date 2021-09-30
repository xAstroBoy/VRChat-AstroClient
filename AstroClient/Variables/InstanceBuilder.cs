namespace AstroClient.Variables
{
    using AstroLibrary.Console;
    using UnityEngine;
    using Color = System.Drawing.Color;

    internal static class InstanceBuilder
    {
        internal static GameObject InstanceHolder;

        internal static void BuildInstanceContainer()
        {
            ModConsole.Log("Generating Instance Holder", Color.LimeGreen);
            InstanceHolder = new GameObject
            {
                name = "Instance Holder " + BuildInfo.Name
            };
            Object.DontDestroyOnLoad(InstanceHolder);
        }

        internal static GameObject GetInstanceHolder(string instancename = "INSTANCE_OBJECT_ADDED")
        {
            if (InstanceHolder != null)
            {
                if (instancename != "INSTANCE_OBJECT_ADDED")
                {
                    ModConsole.Log($"{instancename} is now Added!", Color.Orange);
                }
                Object.DontDestroyOnLoad(InstanceHolder);
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