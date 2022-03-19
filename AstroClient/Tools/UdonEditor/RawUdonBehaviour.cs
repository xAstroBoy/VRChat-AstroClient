namespace AstroClient.Tools.UdonEditor
{
    using UnityEngine;
    using VRC.Udon.Common.Interfaces;

    internal class RawUdonBehaviour
    {
        internal IUdonProgram IUdonProgram { get; set; }
        internal IUdonSymbolTable IUdonSymbolTable { get; set; }
        internal IUdonHeap IUdonHeap { get; set; }

        internal Transform Parent { get; set; }

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

        internal RawUdonBehaviour(IUdonProgram IUdonProgram, IUdonSymbolTable IUdonSymbolTable, IUdonHeap IUdonHeap, Transform Parent)
        {
            this.IUdonProgram = IUdonProgram;
            this.IUdonSymbolTable = IUdonSymbolTable;
            this.IUdonHeap = IUdonHeap;
            this.Parent = Parent;
        }
    }
}