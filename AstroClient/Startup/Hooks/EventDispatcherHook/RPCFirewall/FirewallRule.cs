namespace AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall
{

    internal class FirewallRule
    {
        internal bool AllowLocalSender = true;
        internal bool AllowRemoteSender = false;

        internal FirewallRule(bool AllowLocalSender = true, bool AllowRemoteSender = false)
        {
            this.AllowLocalSender = AllowLocalSender;
            this.AllowRemoteSender = AllowRemoteSender;
        }
    }

}