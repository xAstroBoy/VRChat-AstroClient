namespace AstroClient.AstroMonos.Components.Cheats.Worlds.UdonTycoon
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using Il2CppSystem;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using WorldAddons.WorldsIds;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Math = System.Math;

    [RegisterComponent]
    public class UdonTycoon_PolyCollector : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public UdonTycoon_PolyCollector(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal int? CurrentCounter
        {
            [HideFromIl2Cpp]
            get
            {
                if (PolyCollector != null) return UdonHeapParser.Udon_Parse_Int32(PolyCollector, Counter);
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (PolyCollector != null)
                    if (value.HasValue)
                        UdonHeapEditor.PatchHeap(PolyCollector, Counter, Math.Abs(value.Value));
            }
        }

        private string Counter { [HideFromIl2Cpp] get; } = "_currentCounter";

        private static DisassembledUdonBehaviour PolyCollector { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

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
            else
            {
                Destroy(this);
            }
        }
    }
}