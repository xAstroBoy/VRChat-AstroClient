namespace AstroClient.ClientUI.QuickMenuButtons
{
    #region Imports

    using System.Reflection;
    using AstroButtonAPI;
    using AstroLibrary.Console;
    using CheetoLibrary;
    using Variables;

    #endregion Imports

    /// <summary>
    /// Cheeto's temporary UI for new/wip features
    /// </summary>
    internal class ProtectionsMenu : GameEvents
    {

        internal static void InitButtons(QMGridTab tab)
        {
            QMNestedGridMenu protectionsButton = new QMNestedGridMenu(tab, 4, 2f, "Protections", "Protections Menu", null, UnityEngine.Color.yellow, null, null, true);

            QMToggleButton toggleBlockRPC = new QMToggleButton(protectionsButton, "RPC Block", () => { Bools.BlockRPC = true; }, () => { Bools.BlockRPC = false; }, "Toggle RPC Blocking", null, null, null, Bools.BlockRPC);
            toggleBlockRPC.SetToggleState(Bools.BlockUdon);

            QMToggleButton toggleBlockUdon = new QMToggleButton(protectionsButton, "Block Udon", () => { Bools.BlockUdon = true; }, () => { Bools.BlockUdon = false; }, "Block All Udon RPCs", null, null, null, Bools.BlockUdon);
            toggleBlockUdon.SetToggleState(Bools.BlockUdon);
            QMToggleButton toggleAntiPortal = new QMToggleButton(protectionsButton, "Anti Portal", () => { Bools.AntiPortal = true; }, () => { Bools.AntiPortal = false; }, "Anti-Portal", null, null, null, Bools.AntiPortal);
            toggleAntiPortal.SetToggleState(Bools.AntiPortal);

        }
    }
}