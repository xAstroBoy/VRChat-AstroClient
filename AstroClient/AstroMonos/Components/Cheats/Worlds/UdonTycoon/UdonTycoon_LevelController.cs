namespace AstroClient.AstroMonos.Components.Cheats.Worlds.UdonTycoon
{
    using System;
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using UnhollowerBaseLib.Attributes;
    using WorldAddons.WorldsIds;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class UdonTycoon_LevelController : AstroMonoBehaviour
    {
        public UdonTycoon_LevelController(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object>();

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.Udon_Tycoon))
            {
                var obj = gameObject.FindUdonEvent("_ConfirmAllPartsPlaced");
                if (obj != null)
                {
                    LevelController = obj.UdonBehaviour.DisassembleUdonBehaviour();
                }
                else
                {
                    ModConsole.Error("Can't Find LevelController behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }
            }
            else { Destroy(this); }
        }

        internal string PolyCounter1
        {
            [HideFromIl2Cpp]
            get
            {
                if (LevelController != null)
                {
                    return UdonHeapParser.Udon_Parse_string(LevelController, "__78_intnl_SystemString");
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (LevelController != null)
                {
                    UdonHeapEditor.PatchHeap(LevelController, "__78_intnl_SystemString", value);
                }
            }
        }


        internal int? PolyCounter2
        {
            [HideFromIl2Cpp]
            get
            {
                if (LevelController != null)
                {
                    return UdonHeapParser.Udon_Parse_Int32(LevelController, "_currentPolyCount");
                }
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (LevelController != null)
                {
                    if (value.HasValue)
                    {
                        UdonHeapEditor.PatchHeap(LevelController, "_currentPolyCount", Math.Abs(value.Value));
                    }
                }
            }
        }


        internal string PolyCounter3
        {
            [HideFromIl2Cpp]
            get
            {
                if (LevelController != null)
                {
                    return UdonHeapParser.Udon_Parse_string(LevelController, "__7_intnl_SystemString");
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (LevelController != null)
                {
                    UdonHeapEditor.PatchHeap(LevelController, "__7_intnl_SystemString", value);

                }
            }
        }





        private static DisassembledUdonBehaviour LevelController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    }
}