using AstroClient.Tools.UdonEditor;

namespace AstroClient.WorldModifications.WorldHacks.Jar.AmongUS.UdonCheats
{
    using System.Linq;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds.Roles;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using xAstroBoy.Extensions;

    internal static class AmongUS_Utils
    {

        internal static int RemoveSyncVotedForText(string key)
        {
            var removedtext = key.ToLower().Replace("syncvotedfor", string.Empty).Replace(" ", string.Empty);
            _ = int.TryParse(removedtext, out var value);
            return value;
        }
        internal static void AllSkipVote()
        {
            if (JarRoleController.AmongUS_ESPs.Count() != 0)
            {
                for (int i = 0; i < JarRoleController.AmongUS_ESPs.Count; i++)
                {
                    AmongUS_ESP ActiveNode = JarRoleController.AmongUS_ESPs[i];
                    if (ActiveNode != null && ActiveNode.LinkedNode != null && ActiveNode.CurrentRole != AmongUs_Roles.None)
                    {
                        bool HasVoted = false;
                        UnhollowerBaseLib.Il2CppArrayBase<UdonBehaviour> list = ActiveNode.LinkedNode.Node.GetComponentsInChildren<UdonBehaviour>();
                        for (int i1 = 0; i1 < list.Count; i1++)
                        {
                            UdonBehaviour action = list[i1];
                            var eventKeys = action.Get_EventKeys();
                            if (eventKeys == null) continue;
                            for (int UdonKeys = 0; UdonKeys < eventKeys.Length; UdonKeys++)
                            {
                                var key = eventKeys[UdonKeys];

                                if (key.ToLower().StartsWith("syncabstainedvoting"))
                                {
                                    if (ActiveNode.AmongUSCanVote)
                                    {
                                        action.SendUdonEvent(key);
                                    }
                                    HasVoted = true;
                                    break;
                                }
                            }

                            if (HasVoted)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        internal static void AllVoteFor(AmongUS_ESP VictimComponent)
        {
            if (VictimComponent != null && VictimComponent.Player != null && VictimComponent.LinkedNode != null)
            {
                if (JarRoleController.AmongUS_ESPs.Count() != 0)
                {
                    for (int i = 0; i < JarRoleController.AmongUS_ESPs.Count; i++)
                    {
                        AmongUS_ESP ActiveNode = JarRoleController.AmongUS_ESPs[i];
                        if (ActiveNode != null && VictimComponent.LinkedNode.Node != null && ActiveNode.CurrentRole != AmongUs_Roles.None && ActiveNode != VictimComponent.LinkedNode.Node)
                        {
                            bool HasVoted = false;
                            UnhollowerBaseLib.Il2CppArrayBase<UdonBehaviour> list = ActiveNode.LinkedNode.Node.GetComponentsInChildren<UdonBehaviour>();
                            for (int i1 = 0; i1 < list.Count; i1++)
                            {
                                UdonBehaviour action = list[i1];
                                var eventKeys = action.Get_EventKeys();
                                if (eventKeys == null) continue;
                                for (int UdonKeys = 0; UdonKeys < eventKeys.Length; UdonKeys++)
                                {
                                    var key = eventKeys[UdonKeys];

                                    if (key.ToLower().StartsWith("syncvotedfor"))
                                    {
                                        var ExtractedNode = JarRoleController.AmongUS_GetLinkedComponent(RemoveSyncVotedForText(key));
                                        if (ExtractedNode != null && ExtractedNode.LinkedNode.Node != null && ExtractedNode.CurrentRole != AmongUs_Roles.None)
                                        {
                                            if (ExtractedNode.Player.DisplayName() == VictimComponent.Player.DisplayName())
                                            {
                                                //Log.Debug($"Executing Udon Event {action.name} with subaction {key} That Contains Player : {ExtractedNode.apiuser.displayName}");
                                                if (ActiveNode.AmongUSCanVote)
                                                {
                                                    action.SendUdonEvent(key);
                                                }
                                                HasVoted = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (HasVoted)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
