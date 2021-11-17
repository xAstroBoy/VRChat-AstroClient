namespace AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds
{
    using System;
    using AstroClient.Tools.UdonEditor;
    using UnhollowerBaseLib.Attributes;
    using VRC.Udon;

    [RegisterComponent]
    public class JarNodeReader : AstroMonoBehaviour
    {
        public JarNodeReader(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object>();

        // Use this for initialization
        internal void Start()
        {
            Node = this.gameObject.GetComponent<UdonBehaviour>();
            if (Node != null) DisassembledNode = Node.DisassembleUdonBehaviour();
        }

        internal VRC.SDKBase.VRCPlayerApi VRCPlayerAPI
        {
            [HideFromIl2Cpp]
            get
            {
                if (DisassembledNode != null)
                {
                    var player = UdonHeapParser.Udon_Parse_VRCPlayerApi(DisassembledNode, "playerApi");
                    if (player != null) return player;
                }
                return null;
            }
        }

        internal UdonBehaviour Node { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal DisassembledUdonBehaviour DisassembledNode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
    }
}