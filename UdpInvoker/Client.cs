using System.Net;
using System.Net.Sockets;

namespace UdpInvoker
{
    public class Client
    {
        private readonly UdpClient _udpClient;

        public Client()
        {
            _udpClient = new UdpClient();
        }

        public async void Connect(IPEndPoint remoteEp)
        {
            _udpClient.Connect(remoteEp);

            while (true)
            {
                var datagram = await _udpClient.ReceiveAsync();
            }
        }
    }
}