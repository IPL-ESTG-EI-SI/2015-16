using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace EI.SI
{
    /// <summary>
    /// Server
    /// Symmetrics (Encryption)
    /// </summary>
    class ServerWithProtocolSI
    {
        public static string SEPARATOR = "...";

        /// <summary>
        /// IMPORTANTE: a cada RECEÇÃO deve seguir-se, obrigatóriamente, um ENVIO de dados
        /// IMPORTANT: each network .Read must be fallowed by a network .Write
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            byte[] msg;
            IPEndPoint listenEndPoint;
            TcpListener server = null;
            TcpClient client = null;
            NetworkStream netStream = null;
            ProtocolSI protocol = null;

            try
            {
                Console.WriteLine("SERVER");

                #region Defenitions
                // Binding IP/port
                listenEndPoint = new IPEndPoint(IPAddress.Any, 13000);
                
                // Client/Server Protocol to SI
                protocol = new ProtocolSI();


                #endregion

                Console.WriteLine(SEPARATOR);
                 
                #region TCP Listner
                // Start TcpListener
                server = new TcpListener(listenEndPoint);
                server.Start();

                // Waits for a client connection (bloqueant wait)
                Console.Write("waiting for a connection... ");
                client = server.AcceptTcpClient();
                netStream = client.GetStream();
                Console.WriteLine("ok");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Data (Unsecure channel)                

                SymmetricAlgorithm algorithm = new AesCryptoServiceProvider();    
                ProtocolSICmdType type;
                string received = "";
                byte[] packet;
                do
                {
                    int bytesRead = netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                    type = protocol.GetCmdType();

                    switch (type)
                    {
                        case ProtocolSICmdType.SECRET_KEY:
                            algorithm.Key = protocol.GetData();
                            received = "KEY";
                            break;
                        case ProtocolSICmdType.IV:
                            algorithm.IV = protocol.GetData();
                            received = "IV";
                            break;
                        case ProtocolSICmdType.MODE:
                           
                            received = "Mode";
                            break;
                        case ProtocolSICmdType.PADDING:
                            algorithm.Padding = (PaddingMode)Enum.Parse(typeof(PaddingMode), protocol.GetStringFromData());
                            received = "Padding";
                            break;
                    }
                    Console.WriteLine("Received "+received+" -- Sending ACK");
                    packet = protocol.Make(ProtocolSICmdType.ACK);
                    netStream.Write(packet, 0, packet.Length);

                } while (type != ProtocolSICmdType.EOT);
                Console.WriteLine("Received EOT -- Sending ACK");
                packet = protocol.Make(ProtocolSICmdType.ACK);
                netStream.Write(packet, 0, packet.Length);
                Console.WriteLine("Terminating");
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
                if (server != null)
                    server.Stop();
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Connection with client was closed.");
            }

            Console.WriteLine(SEPARATOR);
            Console.Write("End: Press a key...");
            Console.ReadKey();
        }

    }
}
