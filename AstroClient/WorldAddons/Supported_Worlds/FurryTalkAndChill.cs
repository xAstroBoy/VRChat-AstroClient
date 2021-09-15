namespace AstroClient
{
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Finder;
    using System.Collections.Generic;
    using AstroLibrary.Extensions;
    using AstroClient.Udon;

    public class FurryTalkAndChill : GameEvents
    {
        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Furry_Talk_And_Chill)
            {
                if (Bools.IsDeveloper)
                {
                    ModConsole.Log($"Recognized {Name} World, Hacking Admin Panel Behaviour..");

                    var PanelBehaviour = UdonSearch.FindUdonEvent("AdminPanel", "_MakeLocalPlayerAdmin");

                    if (PanelBehaviour != null)
                    {
                        var disassembledbehaviour = PanelBehaviour.UdonBehaviour.DisassembleUdonBehaviour();
                        if (disassembledbehaviour != null)
                        {
                            var isCurrentAdmin = UdonHeapParser.Udon_Parse_Boolean(disassembledbehaviour, AdminSymbol);
                            if(isCurrentAdmin != null)
                            {
                                if(!isCurrentAdmin.Value)
                                {
                                    ModConsole.Log("Unlocking Admin Panel (Forcing Admin access...)");
                                    UdonHeapEditor.PatchHeap(disassembledbehaviour, AdminSymbol, true, true);

                                }

                            }
                        }
                    }
                }
            }
        }

        private string AdminSymbol { get; } = "_isAdmin";
    }
}