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
    public class PuttPuttPond_GolfBallManipulator : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PuttPuttPond_GolfBallManipulator(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        private string playerName_address { [HideFromIl2Cpp] get; } = "__0_intnl_UnityEngineUIText";

        internal string playerName
        {
            [HideFromIl2Cpp]
            get
            {
                if (GolfBallFireworks != null) return UdonHeapParser.Udon_Parse<UnityEngine.UI.Text>(GolfBallFireworks, playerName_address).text;
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

        //  Just for fun!
        internal bool MakeBallShootFireworks { get; set; }

        private static RawUdonBehaviour GolfBallFireworks { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.PuttPuttPond))
            {
                var obj = gameObject.FindUdonEvent("LaunchFireworks");
                if (obj != null)
                {
                    GolfBallFireworks = obj.UdonBehaviour.ToRawUdonBehaviour();
                    Log.Debug("Added GolfBallManipulator to Golf Ball Successfully!");
                }
                else
                {
                    Log.Error("Can't Find PoolObject behaviour, Unable to Add Reader Component, did the author update the world?");
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