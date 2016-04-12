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

            RSACryptoServiceProvider asymmetricAlgorithm = new RSACryptoServiceProvider();
            string publicKey = asymmetricAlgorithm.ToXmlString(false);
            string asymmetricKeys = asymmetricAlgorithm.ToXmlString(true);
            string serverPublicKey;
            SymmetricAlgorithm symmetricAlgorithm = new AesCryptoServiceProvider();


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

                #region Exchange Public Keys

                byte[] packet = protocol.Make(ProtocolSICmdType.PUBLIC_KEY, publicKey);
                Console.Write("Sending Public Key");
                netStream.Write(packet, 0, packet.Length);
                Console.WriteLine("     SENT");

                Console.WriteLine("Receiving Server Public Key");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                serverPublicKey = protocol.GetStringFromData();

                #endregion

                #region Exchange Symmetric Algorithm Elements (SECURE)

                RSACryptoServiceProvider serverAlgorithm = new RSACryptoServiceProvider();
                serverAlgorithm.FromXmlString(serverPublicKey);

                byte[] encryptedData;
                // Sending KEY

                encryptedData = serverAlgorithm.Encrypt(symmetricAlgorithm.Key, true);
                packet = protocol.Make(ProtocolSICmdType.SECRET_KEY, encryptedData);
                sendPacketAndWaitForReply("KEY", packet);

                // Sending IV
                encryptedData = serverAlgorithm.Encrypt(symmetricAlgorithm.IV, true);
                packet = protocol.Make(ProtocolSICmdType.IV, encryptedData);
                sendPacketAndWaitForReply("IV", packet);

                // Sending Mode
                encryptedData = serverAlgorithm.Encrypt(Encoding.UTF8.GetBytes(symmetricAlgorithm.Mode.ToString()), true);
                packet = protocol.Make(ProtocolSICmdType.MODE, encryptedData);
                sendPacketAndWaitForReply("Mode", packet);

                // Sending Padding
                encryptedData = serverAlgorithm.Encrypt(Encoding.UTF8.GetBytes(symmetricAlgorithm.Padding.ToString()), true);
                packet = protocol.Make(ProtocolSICmdType.PADDING, encryptedData);
                sendPacketAndWaitForReply("Padding", packet);

                #endregion

                #region Exchange Data (secure channel)
                // Send data...
                SymmetricsSI symmetricsSI = new SymmetricsSI(symmetricAlgorithm);


                byte[] clearData = Encoding.UTF8.GetBytes("EI SI 2015/16");
                byte[] encrytedData = symmetricsSI.Encrypt(clearData);
                Console.Write("Sending  data... ");
                msg = protocol.Make(ProtocolSICmdType.DATA, encrytedData);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");
                Console.WriteLine("   Sent: encrypted = " + ProtocolSI.ToHexString(encrytedData));

                // Receive answer from server
                Console.Write("waiting for ACK...");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
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
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Connection with server was closed.");
            }

            Console.WriteLine(SEPARATOR);
            Console.Write("End: Press a key...");
            Console.ReadKey();
        }


        private static void sendPacketAndWaitForReply(string sending, byte[] packet)
        {
            Console.Write("Sending " + sending);
            netStream.Write(packet, 0, packet.Length);
            Console.WriteLine("     SENT");

            Console.Write("Receiving Reply");
            netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
            if (protocol.GetCmdType() == ProtocolSICmdType.ACK)
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
