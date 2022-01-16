namespace AstroClient
{
    using AstroClient.Udon;
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using System.Collections.Generic;

    internal class Valkyrie_Defense : GameEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Valkyrie_Defense)
            {
                ModConsole.Log($"Recognized {Name} World, Patching Balance....");
                var result = UdonSearch.FindUdonEvent("PlayerManager", "AddMoney").UdonBehaviour;
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