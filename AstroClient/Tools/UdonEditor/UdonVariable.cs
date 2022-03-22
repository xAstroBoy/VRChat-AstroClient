namespace AstroClient.Tools.UdonEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CustomClasses;
    using VRC.Udon;


    internal class UdonVariable<T>
    {
        private uint address { get; set; }
        private RawUdonBehaviour rawUdonBehaviour { get; set; }


        internal UdonVariable(RawUdonBehaviour rawUdonBehaviour, string symbol)
        {
            if (rawUdonBehaviour != null)
            {
                this.rawUdonBehaviour = rawUdonBehaviour;
                address = rawUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol);
            }
        }

        internal T Value
        {
            get => rawUdonBehaviour.IUdonHeap.GetHeapVariable<T>(address);
            set => rawUdonBehaviour.IUdonHeap.SetHeapVariable<T>(address, value);
        }
    }
}
