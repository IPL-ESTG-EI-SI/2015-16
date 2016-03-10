using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Worksheet1_2_Extra_Server
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
            String stringReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received [string] - " + stringReceived);
            int key = 5;
            Console.WriteLine("Decrypted [string] - " + CeaserCypherDecrypt(stringReceived,key));


            stream.Write(encodedACK, 0, encodedACK.Length);


            stream.Close();
            client.Close();
            listener.Stop();
            Console.WriteLine("Server Stoped");
            Console.ReadKey();
        }

        static string CeaserCypherDecrypt(string input, int key)
        {
            char[] buffer = input.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                letter = (char)(letter - key);
                if (letter > 65535)
                {
                    letter = (char)(letter - 65535);
                }
                else if (letter < 0)
                {
                    letter = (char)(letter + 65535);
                }
                buffer[i] = letter;
            }
            return new string(buffer);
        }
    }
}
