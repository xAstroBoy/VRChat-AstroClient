using System;
using System.Runtime.InteropServices;
using UnhollowerRuntimeLib;
using UnityEngine;

namespace AstroClient.components
{
    public class ESP : MonoBehaviour
    {
        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<MonoBehaviour> AntiGcList;

        public ESP(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        public ESP(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<ESP>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~ESP()
        {
            Marshal.FreeHGlobal(MethodInfo);
            MethodInfo = IntPtr.Zero;
            ReferencedDelegate = null;
            AntiGcList.Remove(this);
            AntiGcList = null;
        }

        // Use this for initialization
        private void Start()
        {
            try
            {
                ESPManager.Register(this);
            }
            catch { }
        }

        private void OnDestroy()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}