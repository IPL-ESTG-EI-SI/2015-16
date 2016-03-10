using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Worksheet1_2_Extra_Client
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
            String msg = "SI@EI-15/16";
            
            String response;
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, port);
            TcpClient client = new TcpClient();
            client.Connect(endpoint);
            NetworkStream stream = client.GetStream();

            Console.WriteLine("Client Started");

            Console.WriteLine("Encrypting String {0}",msg);
            int key = 5;
            string encryptedString = CeaserCypherEncrypt(msg, key);
            byte[] encodedMsg = Encoding.UTF8.GetBytes(encryptedString);
            Console.WriteLine("Sending String {0}",encryptedString);

            stream.Write(encodedMsg, 0, encodedMsg.Length);
            bytesRead = stream.Read(buffer, 0, bufferSize);
            response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received " + response);

          

            stream.Close();
            client.Close();
            Console.WriteLine("Client Stoped");
            Console.ReadKey();
        }

        static string CeaserCypherEncrypt(string input, int key)
        {
            char[] buffer = input.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                letter = (char)(letter + key);
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
