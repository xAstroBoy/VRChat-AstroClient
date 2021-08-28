namespace AstroClient
{
    using AstroClient.Udon;
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using System.Collections.Generic;

    public class Valkyrie_Defense : GameEvents
    {
        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            if (id == WorldIds.Valkyrie_Defense)
            {
                ModConsole.Log($"Recognized {Name} World, Patching Balance....");
                var result = UdonSearch.FindUdonEvent("PlayerManager", "AddMoney").Action;
                if (result != null)
                {
                    var disassembled = result.DisassembleUdonBehaviour();
                    if (disassembled != null)
                    {
                        UdonHeapEditor.PatchHeap(disassembled, "money_now", 999999999, true);

                    }
                }
            }
        }
    }
}