namespace AstroClient
{
    using VRC.Udon.Common.Interfaces;

    internal class DisassembledUdonBehaviour
    {
        internal IUdonProgram IUdonProgram { get; set; }
        internal IUdonSymbolTable IUdonSymbolTable { get; set; }
        internal IUdonHeap IUdonHeap { get; set; }

        internal DisassembledUdonBehaviour(IUdonProgram IUdonProgram, IUdonSymbolTable IUdonSymbolTable, IUdonHeap IUdonHeap)
        {
            this.IUdonProgram = IUdonProgram;
            this.IUdonSymbolTable = IUdonSymbolTable;
            this.IUdonHeap = IUdonHeap;
        }
    }
}