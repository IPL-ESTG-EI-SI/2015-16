using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Worksheet1_3_Extra_Server
{
    class Server
    {
        static void Main(string[] args)
        {
            int port = 9999, bytesRead;
            byte[] buffer;
            ProtocolSI protocolSI = new ProtocolSI();
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, port);
            TcpListener listener = new TcpListener(endpoint);

            Console.WriteLine("Server Starting");
            listener.Start();
            Console.WriteLine("Server Started");
            Console.WriteLine("Waiting for Client");
            TcpClient client = listener.AcceptTcpClient();
            NetworkStream stream = client.GetStream();



            int intReceived = -1;
            String stringReceived = "";

            do
            {
                Console.WriteLine("Receiving Data");
                bytesRead = stream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                switch (protocolSI.GetCmdType())
                {
                    case ProtocolSICmdType.NORMAL:
                        intReceived = protocolSI.GetIntFromData();
                        buffer = protocolSI.Make(ProtocolSICmdType.ACK);
                        stream.Write(buffer, 0, buffer.Length);
                        break;
                    case ProtocolSICmdType.DATA:
                        stringReceived = protocolSI.GetStringFromData();
                        buffer = protocolSI.Make(ProtocolSICmdType.ACK);
                        stream.Write(buffer, 0, buffer.Length);
                        break;
                    case ProtocolSICmdType.EOT:
                        buffer = protocolSI.Make(ProtocolSICmdType.ACK);
                        stream.Write(buffer, 0, buffer.Length);
                        break;
                }
            } while (protocolSI.GetCmdType() != ProtocolSICmdType.EOT);


            Console.WriteLine("Integer Received: {0}", intReceived);
            Console.WriteLine("String Received: {0}", stringReceived);
            Console.WriteLine("End Of Transmition Received");

            stream.Close();
            client.Close();
            listener.Stop();
            Console.WriteLine("Server Stoped");
            Console.ReadKey();
        }
    }
}
