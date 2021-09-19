﻿namespace AstroClient.Startup
{
    #region Imports

    using AstroClient.Cheetos;
    using AstroClient.Components;
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using UnhollowerRuntimeLib;

    #endregion Imports

    public class ComponentHelper : GameEvents
    {
        public static void RegisterComponent<T>() where T : class
        {
            RegisterComponent(typeof(T));
        }

        public static void RegisterComponent(Type type)
        {
            try
            {
                ClassInjector.RegisterTypeInIl2Cpp(type);
                ModConsole.DebugLog($"Registered: {type}");
                if (!RegisteredComponentsTypes.Contains(type))
                {
                    RegisteredComponentsTypes.Add(type);
                }
            }
            catch (Exception e)
            {
                ModConsole.Error($"Failed to Register: {type.FullName}");
                ModConsole.ErrorExc(e);
            }
        }

        public override void OnApplicationStart()
        {
            RegisterComponent<GameEventsBehaviour>();
            RegisterComponent<JarControllerEvents>();

            var classes = Assembly.GetExecutingAssembly().GetTypes();

            for (int i = 0; i < classes.Length; i++)
            {
                Type c = classes[i];

                Attribute[] array = c.GetCustomAttributes().ToArray();
                for (int i1 = 0; i1 < array.Length; i1++)
                {
                    Attribute attribute = array[i1];
                    if (attribute.GetType().Equals(typeof(RegisterComponent)))
                    {
                        RegisterComponent(c);
                    }
                }
            }

            //RegisterComponent<Murder4PatronUnlocker>();

            if (Bools.AllowAttackerComponent)
            {
                RegisterComponent<PlayerAttackerManager>();
                RegisterComponent<PlayerAttacker>();
            }

            if (Bools.AllowOrbitComponent)
            {
                RegisterComponent<OrbitManager>();
                RegisterComponent<OrbitManager_Old>();
                RegisterComponent<Orbit>();
            }
        }

        public override void OnUpdate()
        {
            RocketManager.MakeInstance();
            CrazyObjectManager.MakeInstance();
            ObjectSpinnerManager.MakeInstance();
            ItemInflaterManager.MakeInstance();
            if (Bools.AllowAttackerComponent)
            {
                PlayerAttackerManager.MakeInstance();
            }
            if (Bools.AllowOrbitComponent)
            {
                OrbitManager.MakeInstance();
            }
            PlayerWatcherManager.MakeInstance();
        }

        public static List<Type> RegisteredComponentsTypes { get; } = new List<Type>();
    }
}