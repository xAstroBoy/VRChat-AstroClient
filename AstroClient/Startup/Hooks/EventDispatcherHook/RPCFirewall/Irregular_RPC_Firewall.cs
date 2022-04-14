using AstroClient.Startup.Hooks.EventDispatcherHook.Tools.Ext;
using VRC.SDKBase;

namespace AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal static class Irregular_RPC_Firewall
    {


        internal static bool isIrregularRPC(ref VRC_EventHandler.VrcEvent VrcEvent, ref VRC.Player Sender)
        {
            if (VrcEvent.Name.Length >= 100 || VrcEvent.ParameterString.Length >= 100)
            {
                if (VrcEvent != null)
                {
                    Log.Write($"Blocked Malicious RPC: {Sender.Get_SenderName()}");
                }
                else
                {
                    Log.Write($"Blocked Malicious RPC: NULL");
                }

                return true;
                
            }
            return false;
        }
    }
}
