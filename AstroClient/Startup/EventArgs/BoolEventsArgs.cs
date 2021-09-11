namespace AstroClientCore.Events
{
    using System;

    public class BoolEventsArgs : EventArgs
    {
        public bool value;

        public BoolEventsArgs(bool value)
        {
            this.value = value;
        }
    }
}