namespace AstroClient.AstroMonos.Components.Tools.UdonDumper
{
    using System.IO;
    using System.Text;
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using CustomClasses;
    using Il2CppSystem;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;

    [RegisterComponent]
    public class UdonDumper : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public UdonDumper(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        internal  System.Collections.Generic.List<UdonBehaviour_Cached> TargetedUdons { [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = new System.Collections.Generic.List<UdonBehaviour_Cached>();
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.PrisonEscape))
            {
                foreach (var item in gameObject.transform.Get_UdonBehaviours())
                {

                    var obj = item.FindUdonEvent("_SetWantedSynced");
                    if (obj != null)
                    {
                        if (!TargetedUdons.Contains(obj))
                        {
                            ModConsole.DebugLog(
                                $"Found Behaviour with name {obj.gameObject.name}, having Event _SetWantedSynced");
                            TargetedUdons.Add(obj);
                        }
                    }
                }
                GenerateFile();
            }
            else
            {
                Destroy(this);
            }
        }

        internal System.Collections.Generic.List<UdonSymbolsAndTypes> AllSymbolsAndTypes {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; }= new System.Collections.Generic.List<UdonSymbolsAndTypes>();

         [HideFromIl2Cpp]
        private bool ContainsSymbol(string Symbol)
        {
            if (AllSymbolsAndTypes.Count != 0)
            {
                foreach (var item in AllSymbolsAndTypes)
                {
                    if (item.Symbol.Equals(Symbol))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
         [HideFromIl2Cpp]
        internal void GenerateFile()
        {
            foreach (var behaviour in TargetedUdons)
            {
                if (behaviour != null)
                {
                    if (behaviour.RawItem != null)
                    {
                        foreach (var symbol in behaviour.RawItem.IUdonSymbolTable.GetSymbols())
                        {
                            if (symbol != null)
                            {
                                var address = behaviour.RawItem.IUdonSymbolTable.GetAddressFromSymbol(symbol);
                                var UnboxVariable = behaviour.RawItem.IUdonHeap.GetHeapVariable(address);
                                if (UnboxVariable != null)
                                {
                                    if (!ContainsSymbol(symbol))
                                    {
                                        var entry = new UdonSymbolsAndTypes(symbol, UnboxVariable);
                                        AllSymbolsAndTypes.Add(entry);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            var builder = new StringBuilder();

            string GeneratedBehaviour = "RenameMePlease";
            builder.AppendLine("        // TODO: Bind UdonBehaviour with this section");
            builder.AppendLine("        // TODO: I HIGHLY RECCOMEND TO RENAME THIS VARIABLE BEFORE PASTING!");
            builder.AppendLine("        internal RawUdonBehaviour " + GeneratedBehaviour + " {[HideFromIl2Cpp] get; [HideFromIl2Cpp] set;} =  null;");

            foreach (var item in AllSymbolsAndTypes)
            {
                if (item != null)
                {
                    builder.AppendLine(UdonVariableGenerator.GetterBuilder(GeneratedBehaviour, item.Symbol, item.Type));
                }
            }

            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, @"AstroClient\GetterPropertyGenerated.cs"), builder.ToString());
            ModConsole.DebugLog("Generated Reader File!");

        }
        // Use this for initialization
    }
}