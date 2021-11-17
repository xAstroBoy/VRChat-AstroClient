namespace AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds
{
    using System;
    using AstroEventArgs;
    using ClientUI.Menu.ESP;

    public class JarControllerEvents : AstroMonoBehaviour
    {
        public JarControllerEvents(IntPtr obj0) : base(obj0)
        {
            JarRoleController.Event_OnViewRolesPropertyChanged += Internal_OnViewRolesPropertyChanged;
            PlayerESPMenu.Event_OnPlayerESPPropertyChanged += Internal_OnPlayerESPPropertyChanged;
        }

        private void Internal_OnViewRolesPropertyChanged(object sender, BoolEventsArgs e) => OnViewRolesPropertyChanged(e.value);

        private void Internal_OnPlayerESPPropertyChanged(object sender, BoolEventsArgs e) => OnPlayerESPPropertyChanged(e.value);

        internal virtual void OnPlayerESPPropertyChanged(bool value) { }
    }
}