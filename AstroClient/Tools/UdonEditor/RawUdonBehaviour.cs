namespace AstroClient.Tools.UdonEditor
{
    using VRC.Udon.Common.Interfaces;

    internal class RawUdonBehaviour
    {
        internal IUdonProgram IUdonProgram { get; set; }
        internal IUdonSymbolTable IUdonSymbolTable { get; set; }
        internal IUdonHeap IUdonHeap { get; set; }

        internal RawUdonBehaviour(IUdonProgram IUdonProgram, IUdonSymbolTable IUdonSymbolTable, IUdonHeap IUdonHeap)
        {
            this.IUdonProgram = IUdonProgram;
            this.IUdonSymbolTable = IUdonSymbolTable;
            this.IUdonHeap = IUdonHeap;
        }
    }
}