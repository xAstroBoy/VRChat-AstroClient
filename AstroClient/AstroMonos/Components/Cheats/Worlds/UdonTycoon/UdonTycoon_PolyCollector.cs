namespace AstroClient.AstroMonos.Components.Cheats.Worlds.UdonTycoon
{
    using System;
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using UnhollowerBaseLib.Attributes;
    using WorldAddons.WorldsIds;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class UdonTycoon_PolyCollector : AstroMonoBehaviour
    {
        public UdonTycoon_PolyCollector(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object>();

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.Udon_Tycoon))
            {
                var obj = gameObject.FindUdonEvent("_UpdateCounter");
                if (obj != null)
                {
                    PolyCollector = obj.UdonBehaviour.DisassembleUdonBehaviour();
                }
                else
                {
                    ModConsole.Error("Can't Find _polyCollector behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }
            }
            else { Destroy(this); }
        }

        internal int? CurrentCounter
        {
            [HideFromIl2Cpp]
            get
            {
                if (PolyCollector != null)
                {
                    return UdonHeapParser.Udon_Parse_Int32(PolyCollector, Counter);
                }
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (PolyCollector != null)
                {
                    if (value.HasValue)
                    {
                        UdonHeapEditor.PatchHeap(PolyCollector, Counter, Math.Abs(value.Value));
                    }
                }
            }
        }

        private string Counter { [HideFromIl2Cpp] get; } = "_currentCounter";

        private static DisassembledUdonBehaviour PolyCollector { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    }
}