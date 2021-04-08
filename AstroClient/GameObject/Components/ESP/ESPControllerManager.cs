using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnhollowerRuntimeLib;
using UnityEngine;
using Color = System.Drawing.Color;

#region AstroClient Imports

using static AstroClient.variables.InstanceBuilder;
using AstroClient.ConsoleUtils;

#endregion AstroClient Imports

namespace AstroClient.components
{
    public class ESPManager : GameEventsBehaviour
    {
        #region Internal

        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public ESPManager(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        public ESPManager(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<ESPManager>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~ESPManager()
        {
            Marshal.FreeHGlobal(MethodInfo);
            MethodInfo = IntPtr.Zero;
            ReferencedDelegate = null;
            AntiGcList.Remove(this);
            AntiGcList = null;
        }

        #endregion Internal

        #region Module

        public static Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> ESPEditorBehaviours;

        public void Start()
        {
            ESPEditorBehaviours = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>();
            Instance = this;
        }

        public static void MakeInstance()
        {
            if (Instance == null)
            {
                string name = "ESPManager";
                var gameobj = GetInstanceHolder(name);
                Instance = gameobj.AddComponent<ESPManager>() as ESPManager;
                UnityEngine.Object.DontDestroyOnLoad(gameobj);
                if (Instance != null)
                {
                    ModConsole.Log("[ " + name.ToUpper() + " STATUS ] : READY", Color.LawnGreen);
                }
                else
                {
                    ModConsole.Log("[ " + name.ToUpper() + " STATUS ] : ERROR", Color.OrangeRed);
                }
            }
        }

        public static void Update()
        {
        }

        public static void OnLevelLoad()
        {
            ESPEditorBehaviours.Clear();
            ESPEditors.Clear();
        }

        public static void Register(ESP ObjectEditorBehaviour)
        {
            ESPEditorBehaviours.Add(ObjectEditorBehaviour);
        }

        public static void Deregister(ESP ObjectEditorBehaviour)
        {
            ESPEditorBehaviours.Remove(ObjectEditorBehaviour);
        }

        public static List<GameObject> ESPEditors = new List<GameObject>();

        public static ESPManager Instance { get; set; }

        #endregion Module
    }
}