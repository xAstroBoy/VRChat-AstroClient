namespace AstroClient.AstroMonos.Components.Cheats.Worlds.SuperTowerDefense
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
    public class SuperTowerDefense_TowerPickupEditor : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public SuperTowerDefense_TowerPickupEditor(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal override void OnRoomLeft()
        {
            Destroy(this);
        }


        internal bool? __0_validPlacement_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (CurrentTower != null) return UdonHeapParser.Udon_Parse_Boolean(CurrentTower, "__0_validPlacement_Boolean");
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (CurrentTower != null)
                    if (value.HasValue)
                        UdonHeapEditor.PatchHeap(CurrentTower, "__0_validPlacement_Boolean", value.Value);
            }
        }

        internal bool? previouslyValidPlacement
        {
            [HideFromIl2Cpp]
            get
            {
                if (CurrentTower != null) return UdonHeapParser.Udon_Parse_Boolean(CurrentTower, "previouslyValidPlacement");
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (CurrentTower != null)
                    if (value.HasValue)
                        UdonHeapEditor.PatchHeap(CurrentTower, "previouslyValidPlacement", value.Value);
            }
        }


        internal bool? __70_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (CurrentTower != null) return UdonHeapParser.Udon_Parse_Boolean(CurrentTower, "__70_intnl_SystemBoolean");
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (CurrentTower != null)
                    if (value.HasValue)
                        UdonHeapEditor.PatchHeap(CurrentTower, "__70_intnl_SystemBoolean", value.Value);
            }
        }

        internal bool? __0_intnl_returnValSymbol_Boolean

        {
            [HideFromIl2Cpp]
            get
            {
                if (CurrentTower != null) return UdonHeapParser.Udon_Parse_Boolean(CurrentTower, "__0_intnl_returnValSymbol_Boolean");
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (CurrentTower != null)
                    if (value.HasValue)
                        UdonHeapEditor.PatchHeap(CurrentTower, "__0_intnl_returnValSymbol_Boolean", value.Value);
            }
        }
        internal bool? __3_intnl_SystemBoolean

        {
            [HideFromIl2Cpp]
            get
            {
                if (CurrentTower != null) return UdonHeapParser.Udon_Parse_Boolean(CurrentTower, "__3_intnl_SystemBoolean");
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (CurrentTower != null)
                    if (value.HasValue)
                        UdonHeapEditor.PatchHeap(CurrentTower, "__3_intnl_SystemBoolean", value.Value);
            }
        }



        internal DisassembledUdonBehaviour CurrentTower { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.Super_Tower_defense))
            {
                var obj = gameObject.FindUdonEvent("_onPickup");
                if (obj != null)
                {
                    CurrentTower = obj.UdonBehaviour.DisassembleUdonBehaviour();
                }
                else
                {
                    ModConsole.Error("Can't Find CurrentTower behaviour, Unable to Add Reader Component, did the author update the world?");
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