using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpInvoker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new UdpClient();
            client.Connect(IPAddress.Loopback, 11000);
            var payload = Encoding.UTF8.GetBytes("hello");
            await client.SendAsync(payload, payload.Length);
            Console.WriteLine("ok");
        }
    }
}