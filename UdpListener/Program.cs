using System;
using Serilog;

namespace UdpListener
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            var listener = new Listener(11000);
            
            listener.Listen();

            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Show connected clients.");
            Console.WriteLine("Q. Quit the application");
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                        case ConsoleKey.D1:
                        {
                            foreach(var client in listener.GetClients()) Console.WriteLine($"Client {client}");
                            break;
                        }

                        case ConsoleKey.Q:
                            return;
                }
            }
        }
    }
}