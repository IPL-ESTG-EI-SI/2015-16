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
            IPEndPoint listenEndPoint;
            TcpListener server = null;
            TcpClient client = null;
            
            
            RSACryptoServiceProvider asymmetricAlgorithm = new RSACryptoServiceProvider();
            string publicKey = asymmetricAlgorithm.ToXmlString(false);
            string asymmetricKeys = asymmetricAlgorithm.ToXmlString(true);
            string clientPublicKey ;
            SymmetricAlgorithm symmetricAlgorithm = new AesCryptoServiceProvider();



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

                #region Exchange Public Keys

                Console.WriteLine("Receiving Client Public Key");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                clientPublicKey = protocol.GetStringFromData();


                byte[] packet = protocol.Make(ProtocolSICmdType.PUBLIC_KEY, publicKey);
                Console.Write("Sending Public Key");
                netStream.Write(packet, 0, packet.Length);
                Console.WriteLine("     SENT");
                #endregion

                #region Exchange Symmetric Algorithm Elements (SECURE)

                
                ProtocolSICmdType type;
                string received = "";
                byte[] data;
                do
                {
                    int bytesRead = netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                    type = protocol.GetCmdType();

                    switch (type)
                    {
                        case ProtocolSICmdType.SECRET_KEY:
                            symmetricAlgorithm.Key = asymmetricAlgorithm.Decrypt(protocol.GetData(),true);
                            received = "KEY";
                            break;
                        case ProtocolSICmdType.IV:
                            symmetricAlgorithm.IV = asymmetricAlgorithm.Decrypt(protocol.GetData(), true);
                            received = "IV";
                            break;
                        case ProtocolSICmdType.MODE:
                            data = asymmetricAlgorithm.Decrypt(protocol.GetData(),true);
                            symmetricAlgorithm.Mode = (CipherMode)Enum.Parse(typeof(CipherMode),Encoding.UTF8.GetString(data));
                            received = "Mode";
                            break;
                        case ProtocolSICmdType.PADDING:
                            data = asymmetricAlgorithm.Decrypt(protocol.GetData(), true);
                            symmetricAlgorithm.Padding = (PaddingMode)Enum.Parse(typeof(PaddingMode), Encoding.UTF8.GetString(data));
                            received = "Padding";
                            break;                      
                    }
                    Console.WriteLine("Received " + received + " -- Sending ACK");
                    packet = protocol.Make(ProtocolSICmdType.ACK);
                    netStream.Write(packet, 0, packet.Length);

                } while (type != ProtocolSICmdType.PADDING);

                Console.WriteLine("Received All Parameters");

                #endregion


                #region Exchange Data (SECURE channel)                
                // Receive the cipher data
                SymmetricsSI symmetricsSI = new SymmetricsSI(symmetricAlgorithm);


                Console.Write("waiting for data...");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                byte[] encryptedData = protocol.GetData();
                data = symmetricsSI.Decrypt(encryptedData);
                Console.WriteLine("ok");
                Console.WriteLine("   Received: {0} ", Encoding.UTF8.GetString(data));

                // Answer with a ACK
                Console.Write("Sending a ACK... ");
                msg = protocol.Make(ProtocolSICmdType.ACK);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");
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
