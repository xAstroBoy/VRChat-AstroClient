namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PuttPuttPond
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using Il2CppSystem;
    using Il2CppSystem.Collections.Generic;
    using Mono.CSharp;
    using Spoofer;
    using UnhollowerBaseLib.Attributes;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Math = System.Math;

    [RegisterComponent]
    public class PuttPuttPond_PoolObjectEditor : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PuttPuttPond_PoolObjectEditor(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        private string isPatron_address { [HideFromIl2Cpp] get; } = "isPatron";

        internal bool? isPatron
        {
            [HideFromIl2Cpp]
            get
            {
                if (PoolObject != null) return UdonHeapParser.Udon_Parse_Boolean(PoolObject, isPatron_address);
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (PoolObject != null)
                    if (value.HasValue)
                        UdonHeapEditor.PatchHeap(PoolObject, isPatron_address, value.Value);
            }
        }
        private string cachedIsPatron_address { [HideFromIl2Cpp] get; } = "cachedIsPatron";

        internal bool? cachedIsPatron
        {
            [HideFromIl2Cpp]
            get
            {
                if (PoolObject != null) return UdonHeapParser.Udon_Parse_Boolean(PoolObject, cachedIsPatron_address);
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (PoolObject != null)
                    if (value.HasValue)
                        UdonHeapEditor.PatchHeap(PoolObject, cachedIsPatron_address, value.Value);
            }
        }

        private string playerName_address { [HideFromIl2Cpp] get; } = "playerName";

        internal string playerName
        {
            [HideFromIl2Cpp]
            get
            {
                if (PoolObject != null) return UdonHeapParser.Udon_Parse_string(PoolObject, playerName_address);
                return null;
            }
        }

        internal bool? isSelf
        {
            [HideFromIl2Cpp]
            get
            {
                if (playerName != null)
                {
                    if (!PlayerSpooferUtils.IsSpooferActive)
                    {
                        if (playerName.Equals(PlayerSpooferUtils.Original_DisplayName))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return null;
            }
        }

        private static RawUdonBehaviour PoolObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.PuttPuttPond))
            {
                var obj = gameObject.FindUdonEvent("_HideGolfBall");
                if (obj != null)
                {
                    PoolObject = obj.UdonBehaviour.ToRawUdonBehaviour();
                }
                else
                {
                    ModConsole.Error("Can't Find PoolObject behaviour, Unable to Add Reader Component, did the author update the world?");
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