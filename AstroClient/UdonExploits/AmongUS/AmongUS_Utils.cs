namespace AstroClient.UdonExploits.AmongUS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AstroMonos.Components.Cheats.Worlds.JarWorlds;
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
            if (JarRoleController.RoleEspComponents.Count() != 0)
            {
                for (int i = 0; i < JarRoleController.RoleEspComponents.Count; i++)
                {
                    JarRoleESP ActiveNode = JarRoleController.RoleEspComponents[i];
                    if (ActiveNode != null && ActiveNode.LinkedNode != null && ActiveNode.AmongUsCurrentRole != JarRoleESP.AmongUsRoles.None && ActiveNode.AmongUsCurrentRole != JarRoleESP.AmongUsRoles.Unassigned)
                    {
                        bool HasVoted = false;
                        UnhollowerBaseLib.Il2CppArrayBase<UdonBehaviour> list = ActiveNode.LinkedNode.Node.GetComponentsInChildren<UdonBehaviour>();
                        for (int i1 = 0; i1 < list.Count; i1++)
                        {
                            UdonBehaviour action = list[i1];
                            foreach (var subaction in action._eventTable)
                            {
                                if (subaction.Key.ToLower().StartsWith("syncabstainedvoting"))
                                {
                                    if (ActiveNode.AmongUSCanVote)
                                    {
                                        action.SendCustomNetworkEvent(NetworkEventTarget.All, subaction.Key);
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

        internal static void AllVoteFor(JarRoleESP VictimComponent)
        {
            if (VictimComponent != null && VictimComponent.Player != null && VictimComponent.LinkedNode != null)
            {
                if (JarRoleController.RoleEspComponents.Count() != 0)
                {
                    for (int i = 0; i < JarRoleController.RoleEspComponents.Count; i++)
                    {
                        JarRoleESP ActiveNode = JarRoleController.RoleEspComponents[i];
                        if (ActiveNode != null && VictimComponent.LinkedNode.Node != null && ActiveNode.AmongUsCurrentRole != JarRoleESP.AmongUsRoles.None && ActiveNode.AmongUsCurrentRole != JarRoleESP.AmongUsRoles.Unassigned && ActiveNode != VictimComponent.LinkedNode.Node)
                        {
                            bool HasVoted = false;
                            UnhollowerBaseLib.Il2CppArrayBase<UdonBehaviour> list = ActiveNode.LinkedNode.Node.GetComponentsInChildren<UdonBehaviour>();
                            for (int i1 = 0; i1 < list.Count; i1++)
                            {
                                UdonBehaviour action = list[i1];
                                foreach (var subaction in action._eventTable)
                                {
                                    if (subaction.Key.ToLower().StartsWith("syncvotedfor"))
                                    {
                                        var ExtractedNode = JarRoleController.GetLinkedComponent(RemoveSyncVotedForText(subaction.key));
                                        if (ExtractedNode != null && ExtractedNode.LinkedNode.Node != null && ExtractedNode.AmongUsCurrentRole != JarRoleESP.AmongUsRoles.None && ExtractedNode.AmongUsCurrentRole != JarRoleESP.AmongUsRoles.Unassigned)
                                        {
                                            if (ExtractedNode.Player.DisplayName() == VictimComponent.Player.DisplayName())
                                            {
                                                //ModConsole.DebugLog($"Executing Udon Event {action.name} with subaction {subaction.key} That Contains Player : {ExtractedNode.apiuser.displayName}");
                                                if (ActiveNode.AmongUSCanVote)
                                                {
                                                    action.SendCustomNetworkEvent(NetworkEventTarget.All, subaction.Key);
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
