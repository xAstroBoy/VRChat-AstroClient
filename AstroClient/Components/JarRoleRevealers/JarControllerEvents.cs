﻿namespace AstroClient.Components
{
    using AstroClient.Startup.Buttons;
    using AstroClientCore.Events;
    using System;

    internal class JarControllerEvents : GameEventsBehaviour
    {
        internal JarControllerEvents(IntPtr obj0) : base(obj0)
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