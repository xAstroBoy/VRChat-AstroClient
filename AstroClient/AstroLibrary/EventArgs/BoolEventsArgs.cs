namespace AstroClientCore.Events
{
    using System;

    internal class BoolEventsArgs : EventArgs
    {
        internal bool value;

        internal BoolEventsArgs(bool value)
        {
            this.value = value;
        }
    }
}