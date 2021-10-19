namespace CheetoLibrary.ButtonAPI
{
    using System;

    public class CheetoUIException : Exception
    {
        public CheetoUIException(string msg) : base(msg)
        {
        }
    }
}