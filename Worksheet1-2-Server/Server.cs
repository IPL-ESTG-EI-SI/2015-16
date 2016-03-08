using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Worksheet1_2_Server
{
    class Server
    {
        static void Main(string[] args)
        {
            int port = 9999;
            int bufferSize = 1024;
            int bytesRead;
            byte[] buffer = new byte[bufferSize];
            String ACK = "ACK";
            byte[] encodedACK = Encoding.UTF8.GetBytes(ACK);
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, port);
            TcpListener listener = new TcpListener(endpoint);
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            NetworkStream stream = client.GetStream();

            Console.WriteLine("Server Started");

            bytesRead = stream.Read(buffer, 0, bufferSize);
            int integerReceived = BitConverter.ToInt32(buffer, 0);
            Console.WriteLine("Received [int] - " + integerReceived);
            stream.Write(encodedACK, 0, encodedACK.Length);

            bytesRead = stream.Read(buffer, 0, bufferSize);
            String stringReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received [string] - " + stringReceived);
            stream.Write(encodedACK, 0, encodedACK.Length);

            bytesRead = stream.Read(buffer, 0, bufferSize);
            int decodedByteArray = BitConverter.ToInt32(buffer, 0);
            Console.WriteLine("Received [byte[]] - " + decodedByteArray);
            stream.Write(encodedACK, 0, encodedACK.Length);

            stream.Close();
            client.Close();
            listener.Stop();
            Console.WriteLine("Server Stoped");
            Console.ReadKey();

        }
    }
}
