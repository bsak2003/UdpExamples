using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace UdpListener
{
    public class Listener
    {
        private readonly UdpClient _udpClient;
        private readonly HashSet<IPEndPoint> _clients;

        public Listener(int port)
        {
            _udpClient = new UdpClient(port);
            _clients = new HashSet<IPEndPoint>();
        }

        ~Listener()
        {
            _udpClient.Close();
        }

        public async void Listen()
        {
            Log.Information("Waiting for broadcast...");
            
            while (true)
            {
                var datagram = await _udpClient.ReceiveAsync();
                _clients.Add(datagram.RemoteEndPoint);
                Log.Information($"Received a datagram {Encoding.UTF8.GetString(datagram.Buffer)} from {datagram.RemoteEndPoint}");
            }
        }

        public async Task Broadcast(byte[] datagram)
        {
            foreach (var client in _clients)
            {
                await _udpClient.SendAsync(datagram, datagram.Length, client);
            }
        }
        
        public IEnumerable<IPEndPoint> GetClients() => _clients;
    }
}