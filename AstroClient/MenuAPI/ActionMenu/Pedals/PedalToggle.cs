namespace AstroActionMenu.Pedals
{
    using System;
    using Helpers;
    using Types;
    using UnityEngine;

    public sealed class PedalToggle : PedalStruct
    {
        public PedalToggle(string text, Action<bool> onToggle, bool toggled, Texture2D icon = null,
            bool locked = false)
        {
            this.text = text;
            this.toggled = toggled;
            this.icon = icon;
            triggerEvent = delegate
            {
                //ModConsole.Msg($"Old state: {this.toggled}, New state: {!this.toggled}");
                this.toggled = !this.toggled;
                if (this.toggled)
                    pedal.SetPedalTypeIcon(Utilities.GetExpressionsIcons().typeToggleOn);
                else
                    pedal.SetPedalTypeIcon(Utilities.GetExpressionsIcons().typeToggleOff);
                onToggle.Invoke(toggled);
            };
            Type = PedalType.Toggle;
            this.locked = locked;
        }

        public bool toggled { get; set; }

        public PedalOption pedal { get; set; }
    }
}