using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Worksheet1_3_Extra_Client
{
    class Client
    {
        static void Main(string[] args)
        {
            int port = 9998;
            byte[] buffer;
            ProtocolSI protocolSI = new ProtocolSI();
            int integerToSend = 42;
            String msg = "Hello World!";
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, port);
            TcpClient client = new TcpClient();
            Console.WriteLine("Conneting to Server");
            client.Connect(endpoint);
            NetworkStream stream = client.GetStream();

            Console.WriteLine("Connection OK");

            Console.WriteLine("Sending Integer");
            buffer = protocolSI.Make(ProtocolSICmdType.NORMAL, integerToSend);
            stream.Write(buffer, 0, buffer.Length);
            stream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
            if (protocolSI.GetCmdType() == ProtocolSICmdType.ACK)
            {
                Console.WriteLine("Received ACK");
            }
            else
            {
                throw new Exception("Something unexpected happened.");
            }

            Console.WriteLine("Sending String");
            buffer = protocolSI.Make(ProtocolSICmdType.DATA, msg);
            stream.Write(buffer, 0, buffer.Length);
            stream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
            if (protocolSI.GetCmdType() == ProtocolSICmdType.ACK)
            {
                Console.WriteLine("Received ACK");
            }
            else
            {
                throw new Exception("Something unexpected happened.");
            }

            Console.WriteLine("Sending EOT");
            buffer = protocolSI.Make(ProtocolSICmdType.EOT);
            stream.Write(buffer, 0, buffer.Length);

            stream.Close();
            client.Close();
            Console.WriteLine("Client Stopped");
            Console.ReadKey();
        }
    }
}
