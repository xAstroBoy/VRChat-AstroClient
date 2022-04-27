using AstroClient.ClientActions;
using UnityEngine;

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
    public class UdonTycoon_PolyCollector : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public UdonTycoon_PolyCollector(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }
        private bool _HasSubscribed = false;
        private bool HasSubscribed
        {
            [HideFromIl2Cpp]
            get => _HasSubscribed;
            [HideFromIl2Cpp]
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.Event_OnRoomLeft += OnRoomLeft;

                    }
                    else
                    {

                        ClientEventActions.Event_OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
            }
        }

        void OnDestroy()
        {
            HasSubscribed = false;
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }
        internal int? CurrentCounter
        {
            [HideFromIl2Cpp]
            get
            {
                if (PolyCollector != null) return UdonHeapParser.Udon_Parse<int>(PolyCollector, Counter);
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

        private static RawUdonBehaviour PolyCollector { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.Udon_Tycoon))
            {
                var obj = gameObject.FindUdonEvent("_UpdateCounter");
                if (obj != null)
                {
                    PolyCollector = obj.UdonBehaviour.ToRawUdonBehaviour();
                    HasSubscribed = true;
                }
                else
                {
                    Log.Error("Can't Find _polyCollector behaviour, Unable to Add Reader Component, did the author update the world?");
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