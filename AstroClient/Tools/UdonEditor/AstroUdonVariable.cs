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

        /// <summary>
        /// This will verify if the Udon Heap will provide the heap variable.
        /// </summary>
        private bool isInitialized => rawUdonBehaviour.isHeapVariableValid<T>(address);
        


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
                    Log.Debug($"{rawUdonBehaviour.udonBehaviour.name} Does not contain symbol {symbol}!");
                    this.rawUdonBehaviour = null;
                    this.address = 0;
                }
                // Test if is able to give a valid result.
                if(!isInitialized)
                {
                    //Log.Debug($"{rawUdonBehaviour.udonBehaviour.name} symbol {symbol} is Unitialized!");
                    this.rawUdonBehaviour = null;
                    this.address = 0;
                }
            }
        }


        internal T Value
        {
            get => rawUdonBehaviour.IUdonHeap.GetHeapVariable<T>(address);
            set => rawUdonBehaviour.IUdonHeap.SetHeapVariable<T>(address, value);
        }
    }
}
