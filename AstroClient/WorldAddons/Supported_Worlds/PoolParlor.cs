namespace AstroClient
{
	using AstroClient.Variables;
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using AstroLibrary.Finder;
	using System.Collections.Generic;

	public class PoolParlor : GameEvents
    {
        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            if (id == WorldIds.PoolParlor)
            {
                ModConsole.Log($"Recognized {Name} World, Patching Skins....");
				var result = UdonSearch.FindUdonEvent("CueSkinHook", "_CanUseCueSkin").Action;
				if (result != null)
				{
					var program = result._program;
					var symbol_table = program.SymbolTable;
					var heap = program.Heap;
					if(symbol_table != null && heap != null)
					{
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__1_const_intnl_SystemString", Utils.CurrentUser.DisplayName(), true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__16_intnl_SystemBoolean", true, true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__7_intnl_SystemBoolean", true, true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__22_intnl_SystemBoolean", true, true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__8_const_intnl_SystemString", Utils.CurrentUser.DisplayName(), true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__9_intnl_SystemBoolean", true, true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__6_intnl_SystemBoolean", true, true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__14_intnl_SystemBoolean", true, true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__8_intnl_SystemBoolean", true, true);
						UdonHeapEditor.PatchHeap(symbol_table, heap, "__20_intnl_SystemBoolean", true, true);

					}
				}
			}
        }
    }
}