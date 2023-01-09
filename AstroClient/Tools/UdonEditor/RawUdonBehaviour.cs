using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Extensions;
using FakeUdon;
using VRC.Udon.Common;

namespace AstroClient.Tools.UdonEditor
{
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;

    internal class RawUdonBehaviour
    {
        internal UdonProgram UdonProgram { get; set; }

        internal FakeUdonProgram FakeUdonProgram { get; set; }
        internal UdonSymbolTable UdonSymbolTable { get; set; }


        internal UdonHeap UdonHeap { get; set; }

        internal FakeUdonHeap FakeUdonHeap { get; set; }


        private Transform Parent { get; set; }
        private UdonBehaviour behaviour { get; set; }

        internal GameObject gameObject => Parent.gameObject;

        internal Transform transform => Parent;

        internal UdonBehaviour udonBehaviour => behaviour;



        internal bool isFakeUdon { get; private set; } = false;

        internal int SymbolsAmount
        {
            get
            {
                if(UdonSymbolTable != null)
                {
                    return UdonSymbolTable.GetSymbols().Length;
                }
                return 0;
            }
        } 

        /// <summary>
        /// Check if a symbol is existing.
        /// </summary>
        /// <param name="Symbol"></param>
        /// <returns></returns>
        internal bool HasSymbol(string Symbol)
        {
            if (UdonSymbolTable != null)
            {
                var SymbolArray = UdonSymbolTable.GetSymbols();
                for (var symbolsitems = 0; symbolsitems < SymbolArray.Length; symbolsitems++)
                {
                    var item = SymbolArray[symbolsitems];
                    if(item.isMatchWholeWord(Symbol))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal RawUdonBehaviour(UdonBehaviour behaviour, UdonProgram UdonProgram,  UdonSymbolTable UdonSymbolTable, UdonHeap UdonHeap, Transform Parent)
        {
            this.UdonProgram = UdonProgram;
            this.UdonSymbolTable = UdonSymbolTable;
            this.UdonHeap = UdonHeap;
            this.Parent = Parent;
            this.behaviour = behaviour;
        }
        internal RawUdonBehaviour(UdonBehaviour behaviour, FakeUdonProgram UdonProgram, UdonSymbolTable UdonSymbolTable, FakeUdonHeap UdonHeap, Transform Parent)
        {
            this.FakeUdonProgram = UdonProgram;
            this.UdonSymbolTable = UdonSymbolTable;
            this.FakeUdonHeap = UdonHeap;
            this.Parent = Parent;
            this.behaviour = behaviour;
            isFakeUdon = true;
        }

    }
}
