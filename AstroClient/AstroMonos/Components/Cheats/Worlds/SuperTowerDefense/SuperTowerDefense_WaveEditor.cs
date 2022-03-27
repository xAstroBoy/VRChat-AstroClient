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
    public class SuperTowerDefense_WaveEditor : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public SuperTowerDefense_WaveEditor(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        internal int? CurrentRound
        {
            [HideFromIl2Cpp]
            get
            {
                if (WaveController != null) return UdonHeapParser.Udon_Parse<int>(WaveController, Wave);
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (WaveController != null)
                    if (value.HasValue)
                        UdonHeapEditor.PatchHeap(WaveController, Wave, Math.Abs(value.Value));
            }
        }

        private string Wave { [HideFromIl2Cpp] get; } = "Wave";

        private RawUdonBehaviour WaveController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.Super_Tower_defense))
            {
                var obj = gameObject.FindUdonEvent("AskForNewWave");
                if (obj != null)
                {
                    WaveController = obj.UdonBehaviour.ToRawUdonBehaviour();
                }
                else
                {
                    ModConsole.Error("Can't Find WaveController behaviour, Unable to Add Reader Component, did the author update the world?");
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