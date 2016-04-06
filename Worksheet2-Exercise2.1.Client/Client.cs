using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace EI.SI
{
    /// <summary>
    /// Client
    /// Symmetrics (Encryption)
    /// </summary>
    class ClientWithProtocolSI
    {
        public static string SEPARATOR = "...";
        private static NetworkStream netStream = null;
        private static ProtocolSI protocol = null;
        /// <summary>
        /// IMPORTANTE: a cada RECEÇÃO deve seguir-se, obrigatóriamente, um ENVIO de dados
        /// IMPORTANT: each network .Read must be fallowed by a network .Write
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            byte[] msg;
            IPEndPoint serverEndPoint;
            TcpClient client = null;
            

            try
            {
                Console.WriteLine("CLIENT");

                #region Defenitions
                // Client/Server Protocol to SI
                protocol = new ProtocolSI();

                // Defenitions for TcpClient: IP:port (127.0.0.1:13000)
                serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13000);
                #endregion

                Console.WriteLine(SEPARATOR);

                #region TCP Connection
                // Connects to Server ...
                Console.Write("Connecting to server... ");
                client = new TcpClient();
                client.Connect(serverEndPoint);
                netStream = client.GetStream();
                Console.WriteLine("ok");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Data (Unsecure channel)

                // Creating the algorithm (Generates Key, IV,...)
                SymmetricAlgorithm algorithm = new AesCryptoServiceProvider();
                SymmetricsSI symmetricsSI = new SymmetricsSI(algorithm);

                // Sending KEY
                byte[] packet = protocol.Make(ProtocolSICmdType.SECRET_KEY, algorithm.Key);
                sendPacketAndWaitForReply("KEY", packet);

                // Sending IV
                packet = protocol.Make(ProtocolSICmdType.IV, algorithm.IV);
                sendPacketAndWaitForReply("IV", packet);

                // Sending Mode
                packet = protocol.Make(ProtocolSICmdType.MODE, algorithm.Mode.ToString());
                sendPacketAndWaitForReply("Mode", packet);

                // Sending Padding
                packet = protocol.Make(ProtocolSICmdType.PADDING, algorithm.Padding.ToString());
                sendPacketAndWaitForReply("Padding", packet);


                // Sending EOT
                packet = protocol.Make(ProtocolSICmdType.EOT);
                sendPacketAndWaitForReply("EOT", packet);

                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            finally
            {
                // Close connections
                if (netStream != null)
                    netStream.Dispose();
                if (client != null)
                    client.Close();
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Connection with server was closed.");
            }

            Console.WriteLine(SEPARATOR);
            Console.Write("End: Press a key...");
            Console.ReadKey();
        }


        private static void sendPacketAndWaitForReply(string sending, byte[] packet)
        {
            Console.Write("Sending "+sending);
            netStream.Write(packet, 0, packet.Length);
            Console.WriteLine("     SENT");

            Console.Write("Receiving Reply");
            netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
            if(protocol.GetCmdType() == ProtocolSICmdType.ACK)
            {
                Console.WriteLine("     ACK");
            }
            else
            {
                Console.WriteLine("     Not ACK - Something went wrong - TERMINATING");
                throw new Exception("Undetermined Issue ");
            }
        }
    }

    
}
