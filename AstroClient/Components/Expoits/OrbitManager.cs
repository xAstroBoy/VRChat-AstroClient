namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using System;
    using System.Runtime.InteropServices;
    using UnhollowerRuntimeLib;
    using VRC;

    public class NewOrbitManager : GameEventsBehaviour
    {
        #region Internal

        public Delegate ReferencedDelegate;
        public IntPtr MethodInfo;
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public NewOrbitManager(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        public NewOrbitManager(Delegate referencedDelegate, IntPtr methodInfo) : base(ClassInjector.DerivedConstructorPointer<NewOrbitManager>())
        {
            ClassInjector.DerivedConstructorBody(this);

            ReferencedDelegate = referencedDelegate;
            MethodInfo = methodInfo;
        }

        ~NewOrbitManager()
        {
            Marshal.FreeHGlobal(MethodInfo);
            MethodInfo = IntPtr.Zero;
            ReferencedDelegate = null;
            AntiGcList.Remove(this);
            AntiGcList = null;
        }

        #endregion Internal

        private static Player Target;

        public void Start()
        {
            ModConsole.Log("[NewOrbitManager] Initialized.");
        }

        public void Update()
        {

        }
    }
}
