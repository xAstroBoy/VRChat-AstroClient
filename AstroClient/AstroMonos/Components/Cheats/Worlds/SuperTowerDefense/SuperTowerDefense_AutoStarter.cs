namespace AstroClient.AstroMonos.Components.Cheats.Worlds.SuperTowerDefense
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using Constants;
    using Il2CppSystem;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Math = System.Math;

    [RegisterComponent]
    public class SuperTowerDefense_AutoStarter : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public SuperTowerDefense_AutoStarter(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        internal bool? ToggleOn
        {
            [HideFromIl2Cpp]
            get
            {
                if (AutoStarterController != null) return UdonHeapParser.Udon_Parse_Boolean(AutoStarterController, ToggleStatusString);
                return null;
            }
        }

        internal string ToggleStatusString { get; } = "ToggledOn";
        internal CustomLists.UdonBehaviour_Cached AutoStarter_SetActive { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal CustomLists.UdonBehaviour_Cached AutoStarter_SetInactive { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal DisassembledUdonBehaviour AutoStarterController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.Super_Tower_defense))
            {
                var obj = gameObject.FindUdonEvent("SetInactive");
                if (obj != null)
                {
                    AutoStarter_SetInactive = obj;
                    AutoStarter_SetActive = gameObject.FindUdonEvent("SetActive");
                    AutoStarterController = obj.UdonBehaviour.DisassembleUdonBehaviour();
                }
                else
                {
                    ModConsole.Error("Can't Find AutoStarter behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }
            }
            else
            {
                Destroy(this);
            }
        }

        private bool _KeepAutoStartActive = false;
        internal bool KeepAutoStarterActive
        {
            get => _KeepAutoStartActive;
            set
            {
                _KeepAutoStartActive = value;
                if (value)
                {
                    KeepAutoStarterInactive = false;
                }
               
            }
        }

        private bool _KeepAutoStartInactive = false;
        internal bool KeepAutoStarterInactive
        {
            get => _KeepAutoStartInactive;
            set
            {
                _KeepAutoStartInactive = value;
                if (value)
                {
                    KeepAutoStarterActive = false;
                }
            }
        }
        private void Update()
        {
            if (AutoStarter_SetActive != null && AutoStarter_SetInactive != null)
                if (ToggleOn.HasValue)
                    if (ToggleOn.Value)
                    {
                        if (KeepAutoStarterInactive)
                        {
                            AutoStarter_SetInactive?.InvokeBehaviour();
                        }
                    }
                    else
                    {
                        if (KeepAutoStarterActive)
                        {
                            AutoStarter_SetActive?.InvokeBehaviour();
                        }
                    }
        }
    }
}