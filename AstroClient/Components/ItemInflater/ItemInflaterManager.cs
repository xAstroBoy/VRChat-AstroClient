namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using static AstroClient.Variables.InstanceBuilder;
    using Color = System.Drawing.Color;

    [RegisterComponent]
    public class ItemInflaterManager : GameEventsBehaviour
    {
        #region Internal

        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public ItemInflaterManager(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        public ItemInflaterManager(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<ItemInflaterManager>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~ItemInflaterManager()
        {
            Marshal.FreeHGlobal(MethodInfo);
            MethodInfo = IntPtr.Zero;
            ReferencedDelegate = null;
            _ = AntiGcList.Remove(this);
            AntiGcList = null;
        }

        #endregion Internal

        #region Module

        internal static Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> ObjectEditorBehaviors;

        internal void Start()
        {
            ObjectEditorBehaviors = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>();
            Instance = this;
        }

        internal static void MakeInstance()
        {
            if (Instance == null)
            {
                string name = "ItemInflaterManager";
                var gameobj = GetInstanceHolder(name);
                Instance = gameobj.AddComponent<ItemInflaterManager>();
                DontDestroyOnLoad(gameobj);
                if (Instance != null)
                {
                    ModConsole.DebugLog("[ " + name.ToUpper() + " STATUS ] : READY", Color.LawnGreen);
                }
                else
                {
                    ModConsole.DebugLog("[ " + name.ToUpper() + " STATUS ] : ERROR", Color.OrangeRed);
                }
            }
        }

        internal static void Update()
        {
        }

        internal static void AddObject(GameObject obj, bool ShouldFloat)
        {
            if (obj != null)
            {
                if (Instance != null)
                {
                    if (!ObjectEditors.Contains(obj))
                    {
                        ItemInflater ObjectEditor = obj.AddComponent<ItemInflater>();
                        ObjectEditor.Manager = Instance;
                        ObjectEditors.Add(obj);
                    }
                }
                else
                {
                    ModConsole.Log("ObjectEditorManager Instance is Null!");
                }
            }
        }

        internal static void RemoveObject(GameObject obj)
        {
            if (ObjectEditors.Contains(obj))
            {
                DestroyImmediate(obj.GetComponent<ItemInflater>());
                _ = ObjectEditors.Remove(obj);
            }
        }

        internal static void KillObjectEditors()
        {
            foreach (var obj in ObjectEditors)
            {
                DestroyImmediate(obj.GetComponent<ItemInflater>());
            }
            ObjectEditors.Clear();
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            ObjectEditors.Clear();
            ClearList();
        }

        internal static void Register(ItemInflater ObjectEditorBehaviour)
        {
            ObjectEditorBehaviors.Add(ObjectEditorBehaviour);
        }

        internal static void Deregister(ItemInflater ObjectEditorBehaviour)
        {
            _ = ObjectEditorBehaviors.Remove(ObjectEditorBehaviour);
        }

        internal static void ClearList()
        {
            ObjectEditorBehaviors.Clear();
        }

        internal static List<GameObject> ObjectEditors = new List<GameObject>();

        internal static ItemInflaterManager Instance { get; set; }

        #endregion Module
    }
}