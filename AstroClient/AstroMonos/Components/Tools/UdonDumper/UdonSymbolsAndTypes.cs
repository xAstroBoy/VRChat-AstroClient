namespace AstroClient.AstroMonos.Components.Tools.UdonDumper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class UdonSymbolsAndTypes
    {

        internal string Symbol { get; set; }
        internal Il2CppSystem.Object Type { get; set; }
        internal UdonSymbolsAndTypes(string Symbol, Il2CppSystem.Object Type)
        {
            this.Symbol = Symbol;
            this.Type = Type;
        }
    }
}
