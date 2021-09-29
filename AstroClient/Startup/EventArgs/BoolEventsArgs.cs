namespace AstroClientCore.Events
{
    using System;

    internal class BoolEventsArgs : EventArgs
    {
        public bool value;

        public BoolEventsArgs(bool value)
        {
            this.value = value;
        }
    }
}