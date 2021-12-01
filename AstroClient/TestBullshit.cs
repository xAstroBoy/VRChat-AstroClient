namespace AstroClient
{
    using AstroClient.Tools.UdonEditor;
    using AstroClient.Tools.UdonSearcher;
    internal class BullshitTest : AstroEvents
    {
        internal override void OnApplicationStart()
		{



            UdonHeapEditor.PatchHeap(UdonUnpacker_Utils.DisassembleUdonBehaviour(UdonSearch.FindUdonEvent("1", "update", true).UdonBehaviour), "__value_1", System.Int64.MaxValue);

        }


    }
}