namespace AstroClient.AstroMonos.Components.ESP
{
    using System;
    using AstroEventArgs;
    using Config;

    [RegisterComponent]
    public class EspEvents : AstroMonoBehaviour
    {
        public EspEvents(IntPtr obj0) : base(obj0)
        {
            ConfigManager.Event_OnPublicESPColorChanged += Internal_OnPublicESPColorChanged;
            ConfigManager.Event_OnFriendESPColorChanged += Internal_OnFriendESPColorChanged;
            ConfigManager.Event_OnBlockedESPColorChanged += Internal_OnBlockedESPColorChanged;
        }

        private void Internal_OnPublicESPColorChanged(object sender, ColorEventArgs e)
        {
            OnPublicESPColorChanged(e.Color);
        }

        private void Internal_OnBlockedESPColorChanged(object sender, ColorEventArgs e)
        {
            OnBlockedESPColorChanged(e.Color);
        }

        private void Internal_OnFriendESPColorChanged(object sender, ColorEventArgs e)
        {
            OnFriendESPColorChanged(e.Color);
        }

        internal virtual void OnPublicESPColorChanged(UnityEngine.Color color)
        {
        }

        internal virtual void OnBlockedESPColorChanged(UnityEngine.Color color)
        {
        }

        internal virtual void OnFriendESPColorChanged(UnityEngine.Color color)
        {
        }
    }
}