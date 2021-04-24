using System;

namespace AstroLoaderServer
{
    internal class Program
    {
        internal static Server Server1;

        internal static void Main(string[] args)
        {
            Console.WriteLine("Starting Loder Server..");
            Server1 = new Server();
        }
    }
}