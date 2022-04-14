namespace AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall
{

    internal class FirewallRule
    {
        internal bool AllowLocalSender { get; set; } 
        internal bool AllowRemoteSender { get; set; }

        internal FirewallRule(bool AllowLocalSender = true, bool AllowRemoteSender = true)
        {
            this.AllowLocalSender = AllowLocalSender;
            this.AllowRemoteSender = AllowRemoteSender;
        }
    }

}