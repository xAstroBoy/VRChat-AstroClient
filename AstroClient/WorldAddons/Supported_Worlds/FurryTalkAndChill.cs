namespace AstroClient
{
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Finder;
    using System.Collections.Generic;
    using AstroLibrary.Extensions;
    using AstroClient.Udon;
    using AstroLibrary.Utility;
    using AstroMonos.Components.Spoofer;

    internal class FurryTalkAndChill : GameEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Furry_Talk_And_Chill)
            {
                if (Bools.IsDeveloper)
                {
                    ModConsole.Log($"Recognized {Name} World, Hacking Admin Panel Behaviour..");

                    string displayname = string.Empty;
                    if (PlayerSpooferUtils.SpooferInstance.IsSpooferActive)
                    {
                        displayname = PlayerSpooferUtils.SpooferInstance.Original_DisplayName;
                    }
                    else
                    {
                        displayname = PlayerUtils.GetAPIUser().displayName;
                    }

                    var PickupSync_SPH_SFB_SACBehaviour = UdonSearch.FindUdonEvent("PickupSync_SPH_SFB_SAC", "_start");
                    if(PickupSync_SPH_SFB_SACBehaviour != null)
                    {
                        var disassembledbehaviour = PickupSync_SPH_SFB_SACBehaviour.UdonBehaviour.DisassembleUdonBehaviour();
                        if (disassembledbehaviour != null)
                        {
                            var List1 = UdonHeapParser.Udon_Parse_string_List(disassembledbehaviour, _superSpecialSnowflakes);
                            if(List1 != null)
                            {
                                List1.Add(displayname);
                                UdonHeapEditor.PatchHeap(disassembledbehaviour, _superSpecialSnowflakes, List1.ToArray(), true);
                            }
                            UdonHeapEditor.PatchHeap(disassembledbehaviour, __0_mp_isAdmin_Boolean, true, true);
                            UdonHeapEditor.PatchHeap(disassembledbehaviour, _isAdmin, true, true);
                            UdonHeapEditor.PatchHeap(disassembledbehaviour, __0_ownerAndAdmin_Boolean, true, true);

                            var List2 = UdonHeapParser.Udon_Parse_string_List(disassembledbehaviour, _permaBannedPlayers);
                            if (List2 != null)
                            {
                                if (List2.Contains(displayname))
                                {
                                    List2.Remove(displayname);
                                    ModConsole.Log("Removed Self from Current world Permanent Banned list...");
                                    UdonHeapEditor.PatchHeap(disassembledbehaviour, _permaBannedPlayers, List2.ToArray(), true);
                                }
                            }

                            var List3 = UdonHeapParser.Udon_Parse_string_List(disassembledbehaviour, __0_temp_StringArray);
                            if (List3 != null)
                            {
                                List3.Add(displayname);
                                UdonHeapEditor.PatchHeap(disassembledbehaviour, __0_temp_StringArray, List3.ToArray(), true);
                            }

                            PickupSync_SPH_SFB_SACBehaviour.ExecuteUdonEvent();
                        }
                    }

                    var PanelBehaviour = UdonSearch.FindUdonEvent("AdminPanel", "_start");

                    if (PanelBehaviour != null)
                    {
                        var disassembledbehaviour = PanelBehaviour.UdonBehaviour.DisassembleUdonBehaviour();
                        if (disassembledbehaviour != null)
                        {
                            var isCurrentAdmin = UdonHeapParser.Udon_Parse_Boolean(disassembledbehaviour, _isAdmin);
                            if (isCurrentAdmin != null)
                            {
                                if (!isCurrentAdmin.Value)
                                {
                                    UdonHeapEditor.PatchHeap(disassembledbehaviour, _isAdmin, true, true);

                                }

                            }
                            PanelBehaviour.ExecuteUdonEvent();

                        }

                    }

                }
            }
        }

        // AdminPanel stuff
        private string _isAdmin { get; } = "_isAdmin";

        private string _superSpecialSnowflakes { get; } = "_superSpecialSnowflakes"; // Idk if is admin list

        private string __0_mp_isAdmin_Boolean { get; } = "__0_mp_isAdmin_Boolean"; // Idk if is admin list

        private string __0_ownerAndAdmin_Boolean { get; } = "__0_ownerAndAdmin_Boolean"; // Idk if is admin list

        private string _permaBannedPlayers { get; } = "_permaBannedPlayers";

        private string __0_temp_StringArray { get; } = "__0_temp_StringArray";
    }
}