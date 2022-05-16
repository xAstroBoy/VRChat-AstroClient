using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using AstroClient.Tools.Extensions;

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

        internal GameObject gameObject => Parent.gameObject;

        internal Transform transform => Parent;

        internal UdonBehaviour udonBehaviour => behaviour;


        internal Dictionary<string, uint> SymbolsDictionary = new Dictionary<string, uint>();


        /// <summary>
        /// Check if a symbol is existing.
        /// </summary>
        /// <param name="Symbol"></param>
        /// <returns></returns>
        internal bool HasSymbol(string Symbol)
        {
            if(SymbolsDictionary.Count != 0)
            {
                return SymbolsDictionary.ContainsKey(Symbol.ToLower());
            }
            return false;
        }

        internal RawUdonBehaviour(UdonBehaviour behaviour, IUdonProgram IUdonProgram, IUdonSymbolTable IUdonSymbolTable, IUdonHeap IUdonHeap, Transform Parent)
        {
            this.IUdonProgram = IUdonProgram;
            this.IUdonSymbolTable = IUdonSymbolTable;
            this.IUdonHeap = IUdonHeap;
            this.Parent = Parent;
            this.behaviour = behaviour;

            // This part extracts the symbols to facilitate everything.
            if (IUdonSymbolTable != null)
            {
                var SymbolArray = IUdonSymbolTable.GetSymbols();
                for (var symbolsitems = 0; symbolsitems < SymbolArray.Length; symbolsitems++)
                {
                    var item = SymbolArray[symbolsitems];
                    var address = IUdonSymbolTable.GetAddressFromSymbol(item);
                    if (address != null)
                    {
                        if (!SymbolsDictionary.ContainsKey(item.ToLower()))
                        {
                            SymbolsDictionary.Add(item.ToLower(), address);
                        }
                    }
                }
            }
        }
    }
}
