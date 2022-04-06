namespace AstroClient.AstroMonos.Components.Cheats.Worlds.UdonTycoon
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using Il2CppSystem;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Math = System.Math;

    [RegisterComponent]
    public class UdonTycoon_LevelController : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public UdonTycoon_LevelController(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        internal string PolyCounter1
        {
            [HideFromIl2Cpp]
            get
            {
                if (LevelController != null) return UdonHeapParser.Udon_Parse<string>(LevelController, "__78_intnl_SystemString");

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (LevelController != null) UdonHeapEditor.PatchHeap(LevelController, "__78_intnl_SystemString", value);
            }
        }

        internal int? PolyCounter2
        {
            [HideFromIl2Cpp]
            get
            {
                if (LevelController != null) return UdonHeapParser.Udon_Parse<int>(LevelController, "_currentPolyCount");
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (LevelController != null)
                    if (value.HasValue)
                        UdonHeapEditor.PatchHeap(LevelController, "_currentPolyCount", Math.Abs(value.Value));
            }
        }

        internal string PolyCounter3
        {
            [HideFromIl2Cpp]
            get
            {
                if (LevelController != null) return UdonHeapParser.Udon_Parse<string>(LevelController, "__7_intnl_SystemString");

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (LevelController != null) UdonHeapEditor.PatchHeap(LevelController, "__7_intnl_SystemString", value);
            }
        }

        private static RawUdonBehaviour LevelController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.Udon_Tycoon))
            {
                var obj = gameObject.FindUdonEvent("_ConfirmAllPartsPlaced");
                if (obj != null)
                {
                    LevelController = obj.UdonBehaviour.ToRawUdonBehaviour();
                }
                else
                {
                    Log.Error("Can't Find LevelController behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }
            }
            else
            {
                Destroy(this);
            }
        }
    }
}