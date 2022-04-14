using AstroClient.AstroMonos.Components.Spoofer;
using AstroClient.CustomClasses;
using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using VRC.Udon;

namespace AstroClient.Startup.Hooks.EventDispatcherHook.Tools.Ext;

internal static class RPCFirewallExts
{



    internal static void Add_UdonFirewall_Rule(this UdonBehaviour_Cached item, bool AllowLocalSender = true, bool AllowRemoteSender = false, bool PrintRuleChanges = false)
    {
        GameObject_RPC_Firewall.Add_UdonFirewall_Rule(item, AllowLocalSender,AllowRemoteSender, PrintRuleChanges);
    }

    internal static void Remove_UdonFirewall_Rule(this UdonBehaviour_Cached item)
    {
        GameObject_RPC_Firewall.Remove_UdonFirewall_Rule(item);

    }
    internal static void Add_UdonFirewall_Rule(this UdonBehaviour udon, string EventKey, bool AllowLocalSender = true, bool AllowRemoteSender = false, bool PrintRuleChanges = false)
    {
        GameObject_RPC_Firewall.Add_UdonFirewall_Rule(udon,EventKey, AllowLocalSender, AllowRemoteSender, PrintRuleChanges);

    }

    internal static void Remove_UdonFirewall_Rule(this UdonBehaviour udon, string EventKey)
    {
        GameObject_RPC_Firewall.Remove_UdonFirewall_Rule(udon, EventKey);

    }





}