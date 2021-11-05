namespace AstroClient.Components
{
    using AstroClientCore.Events;
    using System;
    using ClientUI.QuickMenuButtons.ESP;

    public class JarControllerEvents : GameEventsBehaviour
    {
        public JarControllerEvents(IntPtr obj0) : base(obj0)
        {
            JarRoleController.Event_OnViewRolesPropertyChanged += Internal_OnViewRolesPropertyChanged;
            PlayerESPMenu.Event_OnPlayerESPPropertyChanged += Internal_OnPlayerESPPropertyChanged;
        }

        private void Internal_OnViewRolesPropertyChanged(object sender, BoolEventsArgs e) => OnViewRolesPropertyChanged(e.value);

        private void Internal_OnPlayerESPPropertyChanged(object sender, BoolEventsArgs e) => OnPlayerESPPropertyChanged(e.value);

        internal virtual void OnPlayerESPPropertyChanged(bool value)
        {
        }
    }
}