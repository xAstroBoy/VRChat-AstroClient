namespace AstroClient.Tools.UdonEditor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CustomClasses;
    using VRC.Udon;


    internal class AstroUdonVariable<T>
    {
        private uint address { get; set; }
        private RawUdonBehaviour rawUdonBehaviour { get; set; }


        internal AstroUdonVariable(RawUdonBehaviour rawUdonBehaviour, string symbol)
        {
            if (rawUdonBehaviour != null)
            {
                this.rawUdonBehaviour = rawUdonBehaviour;
                try
                {
                    address = rawUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol);
                }
                catch
                {
                    ModConsole.DebugLog($"{rawUdonBehaviour.udonBehaviour.name} Does not contain symbol {symbol}!");
                    this.rawUdonBehaviour = null;
                    this.address = 0;
                }
            }
        }
        internal AstroUdonVariable(RawUdonBehaviour rawUdonBehaviour, uint address)
        {
            if (rawUdonBehaviour != null)
            {
                this.rawUdonBehaviour = rawUdonBehaviour;
                this.address = address;
            }
        }

        internal T Value
        {
            get => rawUdonBehaviour.IUdonHeap.GetHeapVariable<T>(address);
            set => rawUdonBehaviour.IUdonHeap.SetHeapVariable<T>(address, value);
        }
    }
}
