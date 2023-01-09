namespace AstroClient.Tools.UdonEditor
{
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
                    address = rawUdonBehaviour.UdonSymbolTable.GetAddressFromSymbol(symbol);
                }
                catch
                {
                    Log.Debug($"{rawUdonBehaviour.udonBehaviour.name} Does not contain symbol {symbol}!");
                    this.rawUdonBehaviour = null;
                    this.address = 0;
                }
                // Test if is able to give a valid result.
                if (!isInitialized)
                {
                    //Log.Debug($"{rawUdonBehaviour.udonBehaviour.name} symbol {symbol} is Unitialized!");
                    this.rawUdonBehaviour = null;
                    this.address = 0;
                }
            }
        }

        internal T Value
        {
            get
            {
                if (!rawUdonBehaviour.isFakeUdon)
                {
                    return rawUdonBehaviour.UdonHeap.GetHeapVariable<T>(address);
                }
                return rawUdonBehaviour.FakeUdonHeap.GetHeapVariable<T>(address);
            }
            set
            {
                if (!rawUdonBehaviour.isFakeUdon)
                {
                    rawUdonBehaviour.UdonHeap.SetHeapVariable<T>(address, value);
                }
                else
                {
                    rawUdonBehaviour.FakeUdonHeap.SetHeapVariable<T>(address, value);
                }
            }
        }
    }
}