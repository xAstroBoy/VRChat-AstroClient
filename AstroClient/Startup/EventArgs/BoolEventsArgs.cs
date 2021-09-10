namespace AstroClientCore.Events
{
    using System;
    using VRC.Core;

    public class BoolEventsArgs : EventArgs
    {
        public bool value;

        public BoolEventsArgs(bool value)
        {
            this.value = value;
        }
    }
}