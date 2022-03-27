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
    public class JarNodeReader : AstroMonoBehaviour
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
        }

        internal override void OnRoomLeft()
        {
            Destroy(this);
        }
    }
}