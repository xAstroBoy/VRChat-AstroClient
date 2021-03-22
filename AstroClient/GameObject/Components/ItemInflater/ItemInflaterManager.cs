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
    public class ItemInflaterManager : MonoBehaviour
    {
        #region Internal

        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<MonoBehaviour> AntiGcList;

        public ItemInflaterManager(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>(1);
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
            AntiGcList.Remove(this);
            AntiGcList = null;
        }

        #endregion Internal

        #region Module

        public static Il2CppSystem.Collections.Generic.List<MonoBehaviour> ObjectEditorBehaviors;

        public void Start()
        {
            ObjectEditorBehaviors = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>();
            Instance = this;
        }

        public static void MakeInstance()
        {
            if (Instance == null)
            {
                string name = "ItemInflaterManager";
                var gameobj = GetInstanceHolder(name);
                Instance = gameobj.AddComponent<ItemInflaterManager>() as ItemInflaterManager;
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

        public static void AddObject(GameObject obj, bool ShouldFloat)
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

        public static void RemoveObject(GameObject obj)
        {
            if (ObjectEditors.Contains(obj))
            {
                DestroyImmediate(obj.GetComponent<ItemInflater>());
                ObjectEditors.Remove(obj);
            }
        }

        public static void KillObjectEditors()
        {
            foreach (var obj in ObjectEditors)
            {
                DestroyImmediate(obj.GetComponent<ItemInflater>());
            }
            ObjectEditors.Clear();
        }

        public static void OnLevelLoad()
        {
            ObjectEditors.Clear();
            ClearList();
        }

        public static void Register(ItemInflater ObjectEditorBehaviour)
        {
            ObjectEditorBehaviors.Add(ObjectEditorBehaviour);
        }

        public static void Deregister(ItemInflater ObjectEditorBehaviour)
        {
            ObjectEditorBehaviors.Remove(ObjectEditorBehaviour);
        }

        public static void ClearList()
        {
            ObjectEditorBehaviors.Clear();
        }

        public static List<GameObject> ObjectEditors = new List<GameObject>();

        public static ItemInflaterManager Instance { get; set; }

        #endregion Module
    }
}