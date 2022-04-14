using AstroClient.AstroMonos.Components.Spoofer;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;

namespace AstroClient.Startup.Hooks.EventDispatcherHook.Tools.Ext;

internal static class RPCExtensions
{
    internal static string Get_ActionText(this VRC_EventHandler.VrcEvent Event)
    {
        try
        {
            if (Event.ParameterBytes != null && Event.ParameterBytes.Count != 0)
            {
                var actionstring = System.Text.Encoding.UTF8.GetString(Event.ParameterBytes);
                return actionstring.Length >= 6 ? actionstring.Substring(6) : "Unknown Event";
            }
        }
        catch{}
        return "null";

    }
    internal static GameObject Get_Parameter_GameObject(this VRC_EventHandler.VrcEvent Event)
    {
        try
        {
            if(Event.ParameterObject != null)
            {
                return Event.ParameterObject;
            }
        }
        catch { }
        return null;

    }
    internal static string Get_Parameter_GameObject_Name(this VRC_EventHandler.VrcEvent Event)
    {
        try
        {
            return Event.Get_Parameter_GameObject().name;
        }
        catch { }
        return null;

    }
    internal static string Get_EventType(this VRC_EventHandler.VrcEvent Event)
    {
        try
        {
            return Event.EventType != null ? Event.EventType.ToString() : "null";
        }
        catch { }
        return null;

    }

    internal static string Get_VrcBroadcastType(this VRC_EventHandler.VrcBroadcastType Event)
    {
        try
        {
            return Event != null ? Event.ToString() : "null";
        }
        catch { }
        return null;

    }
    internal static string Get_parameterString(this VRC_EventHandler.VrcEvent Event)
    {
        try
        {
            return Event.ParameterString ?? "null";
        }
        catch { }
        return null;

    }


    internal static string Get_SenderName(this Player player)
    {
        var sender = player.GetVRCPlayerApi();
        if (sender != null)
        {
            if (sender.isLocal)
            {
                if (PlayerSpooferUtils.IsSpooferActive)
                {
                    return PlayerSpooferUtils.Original_DisplayName;
                }
                else
                {
                    return sender.displayName;
                }
            }
            else
            {
                return sender.displayName;
            }
        }
        return "null";
        
    }

}