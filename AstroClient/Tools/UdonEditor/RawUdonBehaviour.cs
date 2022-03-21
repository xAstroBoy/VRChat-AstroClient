namespace AstroClient.Tools.UdonEditor
{
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;

    internal class RawUdonBehaviour
    {
        internal IUdonProgram IUdonProgram { get; set; }
        internal IUdonSymbolTable IUdonSymbolTable { get; set; }
        internal IUdonHeap IUdonHeap { get; set; }

        private Transform Parent { get; set; }
        private UdonBehaviour behaviour { get; set; }
        internal GameObject gameObject
        {
            get
            {
                return Parent.gameObject;
            }
        }

        internal Transform transform
        {
            get
            {
                return Parent;
            }
        }

        internal UdonBehaviour udonBehaviour
        {
            get
            {
                return behaviour;
            }
        }

        internal RawUdonBehaviour(UdonBehaviour behaviour, IUdonProgram IUdonProgram, IUdonSymbolTable IUdonSymbolTable, IUdonHeap IUdonHeap, Transform Parent)
        {
            this.IUdonProgram = IUdonProgram;
            this.IUdonSymbolTable = IUdonSymbolTable;
            this.IUdonHeap = IUdonHeap;
            this.Parent = Parent;
            this.behaviour = behaviour;
        }
    }
}