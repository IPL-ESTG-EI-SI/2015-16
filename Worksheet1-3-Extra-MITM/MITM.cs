using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Worksheet1_3_Extra_MITM
{
    class MITM
    {
        static void Main(string[] args)
        {
            int serverPort = 9999, clientPort = 9998, bytesRead;
            byte[] buffer;
            ProtocolSI protocolSI = new ProtocolSI();
            IPEndPoint endpointClient = new IPEndPoint(IPAddress.Any, clientPort);
            TcpListener listener = new TcpListener(endpointClient);

            Console.WriteLine("MITM Starting");
            listener.Start();
            Console.WriteLine("Server Started");
            Console.WriteLine("Waiting for Client");
            TcpClient clientForClient = listener.AcceptTcpClient();
            NetworkStream streamForClient = clientForClient.GetStream();

            IPEndPoint endpointServer = new IPEndPoint(IPAddress.Loopback, serverPort);
            TcpClient clientForServer = new TcpClient();
            Console.WriteLine("Conneting to Server");
            clientForServer.Connect(endpointServer);
            NetworkStream streamForServer = clientForServer.GetStream();

            Boolean endService = false;
            do
            {
                Console.WriteLine("Receiving Data");
                bytesRead = streamForClient.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                switch (protocolSI.GetCmdType())
                {
                    case ProtocolSICmdType.NORMAL:
                        Console.WriteLine("Received from Client: {0}",protocolSI.GetIntFromData());
                        Console.WriteLine("Sending it to Server");
                        streamForServer.Write(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        streamForServer.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        if (protocolSI.GetCmdType() == ProtocolSICmdType.ACK)
                        {
                            Console.WriteLine("Received ACK From server");
                        }
                        else
                        {
                            throw new Exception("Something unexpected happened.");
                        }
                        Console.WriteLine("Sending it to Client");
                        streamForClient.Write(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        break;
                    case ProtocolSICmdType.DATA:
                        Console.WriteLine("Received from Client: {0}", protocolSI.GetStringFromData());
                        Console.WriteLine("Sending it to Server");
                        streamForServer.Write(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        streamForServer.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        if (protocolSI.GetCmdType() == ProtocolSICmdType.ACK)
                        {
                            Console.WriteLine("Received ACK From server");
                        }
                        else
                        {
                            throw new Exception("Something unexpected happened.");
                        }
                        Console.WriteLine("Sending it to Client");
                        streamForClient.Write(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        break;
                    case ProtocolSICmdType.EOT:
                        Console.WriteLine("Received from EOT Client:");
                        Console.WriteLine("Sending it to Server");
                        streamForServer.Write(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        streamForServer.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        if (protocolSI.GetCmdType() == ProtocolSICmdType.ACK)
                        {
                            Console.WriteLine("Received ACK From server");
                        }
                        else
                        {
                            throw new Exception("Something unexpected happened.");
                        }
                        Console.WriteLine("Sending it to Client");
                        streamForClient.Write(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                        endService = true;
                        break;
                }
            } while (!endService);


            streamForServer.Close();
            clientForServer.Close();
            Console.WriteLine("Connection to Server Stopped");

            streamForClient.Close();
            clientForClient.Close();
            listener.Stop();
            Console.WriteLine("Connection to Client Stoped");
            Console.ReadKey();

        }
    }
}
