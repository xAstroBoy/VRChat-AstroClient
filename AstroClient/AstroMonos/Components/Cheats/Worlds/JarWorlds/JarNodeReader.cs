using AstroClient.ClientActions;
using UnityEngine;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds
{
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using Il2CppSystem;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using VRC.SDKBase;
    using VRC.Udon;
    using IntPtr = System.IntPtr;

    [RegisterComponent]
    public class JarNodeReader : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public JarNodeReader(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal VRCPlayerApi VRCPlayerAPI
        {
            [HideFromIl2Cpp]
            get
            {
                if (RawNode != null)
                {
                    var player = UdonHeapParser.Udon_Parse<VRCPlayerApi>(RawNode, "playerApi");
                    if (player != null) return player;
                }

                return null;
            }
        }

        internal UdonBehaviour Node { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal RawUdonBehaviour RawNode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        // Use this for initialization
        internal void Start()
        {
            Node = gameObject.GetComponent<UdonBehaviour>();
            if (Node != null) RawNode = Node.ToRawUdonBehaviour();
            HasSubscribed = true;
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

                        ClientEventActions.OnRoomLeft += OnRoomLeft;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;

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
    }
}