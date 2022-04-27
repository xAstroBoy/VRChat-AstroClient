namespace AstroClient.AstroMonos.Components.Cheats.Worlds.SuperTowerDefense
{
    using System;
    using System.Collections.Generic;
    using AstroClient.Tools.UdonEditor;
    using AstroClient.Tools.UdonSearcher;
    using ClientAttributes;
    using Constants;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC.Udon;
    using Object = UnityEngine.Object;

    [RegisterComponent]
    public class SuperTowerDefense_NearbyCollider : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public SuperTowerDefense_NearbyCollider(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }
        private DisassembledUdonBehaviour NearbyColliderBehaviour { [HideFromIl2Cpp] get; [HideFromIl2Cpp]  set; }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        internal CustomLists.UdonBehaviour_Cached NearbyCollider_ResetBehavior { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private void Start()
        {
            NearbyCollider_ResetBehavior = UdonSearch.FindUdonEvent(gameObject, "Reset");
            NearbyColliderBehaviour = NearbyCollider_ResetBehavior.UdonBehaviour.DisassembleUdonBehaviour();
        }


        internal UnityEngine.Component[] CollidingTowers
        {
            [HideFromIl2Cpp]
            get
            {
                return UdonHeapParser.Udon_Parse_Component_Array(NearbyColliderBehaviour, "CollidingTowers");
            }
            [HideFromIl2Cpp]
            set
            {
                UdonHeapEditor.PatchHeap(NearbyColliderBehaviour, "CollidingTowers", value);
            }
        }
        internal BoxCollider __0_mp_other_Collider
        {
            [HideFromIl2Cpp]
            get
            {
                return UdonHeapParser.Udon_Parse_BoxCollider(NearbyColliderBehaviour, "__0_mp_other_Collider");
            }
            [HideFromIl2Cpp]
            set
            {
                UdonHeapEditor.PatchHeap(NearbyColliderBehaviour, "__0_mp_other_Collider", value);
            }
        }

        internal BoxCollider onTriggerEnterOther
        {
            [HideFromIl2Cpp]
            get
            {
                return UdonHeapParser.Udon_Parse_BoxCollider(NearbyColliderBehaviour, "__0_mp_other_Collider");
            }
            [HideFromIl2Cpp]
            set
            {
                UdonHeapEditor.PatchHeap(NearbyColliderBehaviour, "__0_mp_other_Collider", value);
            }
        }
    }
}