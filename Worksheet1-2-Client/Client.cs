using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Worksheet1_2_Client
{
    class Client
    {
        static void Main(string[] args)
        {
            int port = 9999;
            int bufferSize = 1024;
            int bytesRead;
            byte[] buffer = new byte[bufferSize];
            int integerToSend = 42;
            byte[] encodedInteger = BitConverter.GetBytes(integerToSend);
            String msg = "Hello World!"; 
            byte[] encodedMsg = Encoding.UTF8.GetBytes(msg);
            String response;
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, port);
            TcpClient client = new TcpClient();
            client.Connect(endpoint);
            NetworkStream stream = client.GetStream();

            Console.WriteLine("Client Started");

            Console.WriteLine("Sending Integer");
            stream.Write(encodedInteger, 0, encodedInteger.Length);
            bytesRead = stream.Read(buffer, 0, bufferSize);
            response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received " + response);

            Console.WriteLine("Sending String");
            stream.Write(encodedMsg, 0, encodedMsg.Length);
            bytesRead = stream.Read(buffer, 0, bufferSize);
            response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received " + response);

            Console.WriteLine("Sending Byte[]");
            stream.Write(encodedInteger, 0, encodedInteger.Length);
            bytesRead = stream.Read(buffer, 0, bufferSize);
            response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received " + response);

            stream.Close();
            client.Close();
            Console.WriteLine("Client Stoped");
            Console.ReadKey();
        }
    }
}
