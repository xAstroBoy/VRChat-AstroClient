﻿using System.Linq;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using AstroMonos.Components.Spoofer;
    using Constants;
    using Tools.UdonEditor;
    using Tools.UdonSearcher;
    using WorldsIds;
    using xAstroBoy.Utility;

    internal class FurryTalkAndChill : AstroEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Furry_Talk_And_Chill)
            {
                if (Bools.IsDeveloper)
                {
                    Log.Write($"Recognized {Name} World, Hacking Admin Panel Behaviour..");

                    var PickupSync_SPH_SFB_SACBehaviour = UdonSearch.FindUdonEvent("PickupSync_SPH_SFB_SAC", "_start");
                    if (PickupSync_SPH_SFB_SACBehaviour != null)
                    {
                        var disassembledbehaviour = PickupSync_SPH_SFB_SACBehaviour.UdonBehaviour.ToRawUdonBehaviour();
                        if (disassembledbehaviour != null)
                        {
                            var List1 = UdonHeapParser.Udon_Parse<string[]>(disassembledbehaviour, _superSpecialSnowflakes).ToList();
                            if (List1 != null)
                            {
                                List1.Add(PlayerSpooferUtils.Original_DisplayName);
                                UdonHeapEditor.PatchHeap(disassembledbehaviour, _superSpecialSnowflakes, List1.ToArray());
                            }
                            UdonHeapEditor.PatchHeap(disassembledbehaviour, __0_mp_isAdmin_Boolean, true);
                            UdonHeapEditor.PatchHeap(disassembledbehaviour, _isAdmin, true);
                            UdonHeapEditor.PatchHeap(disassembledbehaviour, __0_ownerAndAdmin_Boolean, true);

                            var List2 = UdonHeapParser.Udon_Parse<string[]>(disassembledbehaviour, _permaBannedPlayers).ToList();;
                            if (List2 != null)
                            {
                                if (List2.Contains(PlayerSpooferUtils.Original_DisplayName))
                                {
                                    List2.Remove(PlayerSpooferUtils.Original_DisplayName);
                                    Log.Write("Removed Self from Current world Permanent Banned list...");
                                    UdonHeapEditor.PatchHeap(disassembledbehaviour, _permaBannedPlayers, List2.ToArray());
                                }
                            }

                            var List3 = UdonHeapParser.Udon_Parse<string[]>(disassembledbehaviour, __0_temp_StringArray).ToList();;
                            if (List3 != null)
                            {
                                List3.Add(PlayerSpooferUtils.Original_DisplayName);
                                UdonHeapEditor.PatchHeap(disassembledbehaviour, __0_temp_StringArray, List3.ToArray());
                            }

                            PickupSync_SPH_SFB_SACBehaviour.InvokeBehaviour();
                        }
                    }

                    var PanelBehaviour = UdonSearch.FindUdonEvent("AdminPanel", "_start");

                    if (PanelBehaviour != null)
                    {
                        var disassembledbehaviour = PanelBehaviour.UdonBehaviour.ToRawUdonBehaviour();
                        if (disassembledbehaviour != null)
                        {
                            var isCurrentAdmin = UdonHeapParser.Udon_Parse<bool>(disassembledbehaviour, _isAdmin);
                            if (isCurrentAdmin != null)
                            {
                                if (!isCurrentAdmin)
                                {
                                    UdonHeapEditor.PatchHeap(disassembledbehaviour, _isAdmin, true);

                                }

                            }
                            PanelBehaviour.InvokeBehaviour();

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