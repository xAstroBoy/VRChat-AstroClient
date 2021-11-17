namespace AstroClient.Exceptions
{
    using System;

    public class InvalidArrayItemCount : Exception
    {
        public InvalidArrayItemCount(string message) : base(message)
        {
        }
    }
}
