using AstroClient.ClientActions;

namespace AstroClient.AstroMonos
{
    #region Imports

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using ClientAttributes;
    using Components.Cheats.Worlds.JarWorlds;
    using Components.Malicious;
    using Components.Malicious.Orbit;
    using Constants;
    using UnhollowerRuntimeLib;

    #endregion Imports

    internal class ComponentHelper : AstroEvents
    {
        internal static void RegisterComponent<T>() where T : class
        {
            RegisterComponent(typeof(T));
        }
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationStart += OnApplicationStart;
            ClientEventActions.OnRoomJoined += OnRoomJoined;
            ClientEventActions.VRChat_OnUiManagerInit += VRChat_OnUiManagerInit;

        }

        internal static void RegisterComponent(Type type)
        {
            try
            {
                ClassInjector.RegisterTypeInIl2Cpp(type, true);
                Log.Debug($"Registered: {type}");
                if (!RegisteredComponentsTypes.Contains(type)) RegisteredComponentsTypes.Add(type);
            }
            catch (Exception e)
            {
                Log.Error($"Failed to Register: {type.FullName}");
                Log.Exception(e);
            }
        }

        private void OnApplicationStart()
        {
            var classes = Assembly.GetExecutingAssembly().GetTypes();
            for (int i = 0; i < classes.Length; i++)
            {
                Type c = classes[i];

                Attribute[] array = c.GetCustomAttributes().ToArray();
                for (int i1 = 0; i1 < array.Length; i1++)
                {
                    Attribute attribute = array[i1];
                    if (attribute.GetType().Equals(typeof(RegisterComponent))) RegisterComponent(c);
                }
            }


            if (Bools.AllowAttackerComponent) RegisterComponent<PlayerAttacker>();

            if (Bools.AllowOrbitComponent)
            {
                RegisterComponent<OrbitManager>();
                RegisterComponent<OrbitManager_Old>();
                RegisterComponent<Orbit>();
            }
        }

        private void VRChat_OnUiManagerInit()
        {
            if (Bools.AllowOrbitComponent) OrbitManager.MakeInstance();
        }

        private void OnRoomJoined()
        {
            if (Bools.AllowOrbitComponent) OrbitManager.MakeInstance();
        }

        internal static List<Type> RegisteredComponentsTypes { get; } = new List<Type>();
    }
}