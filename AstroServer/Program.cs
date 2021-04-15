namespace AstroServer
{
    using System;

    class Program
    {
        internal static Server Server1;

        internal static void Main(string[] args)
        {
            Console.WriteLine("Starting Client Server..");
            Server1 = new Server();
        }
    }
}
