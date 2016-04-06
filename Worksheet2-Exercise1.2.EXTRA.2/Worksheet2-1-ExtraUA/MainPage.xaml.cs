using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Worksheet2_1_ExtraUA
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        SymmetricKeyAlgorithmProvider algorithm;
        UInt32 keyLength = 256;                  
        BinaryStringEncoding encoding;
        IBuffer iv = null;
        CryptographicKey key;
        IBuffer bufferEncrypted;
        private enum ALGORITHMS { AES, TRIPLEDES, DES, RC2 };
        public MainPage()
        {
            this.InitializeComponent();
           
            encoding = BinaryStringEncoding.Utf8;

            foreach (var item in Enum.GetValues(typeof(ALGORITHMS)))
            {
                cbAlgorithm.Items.Add(item);
            }
            cbAlgorithm.SelectedIndex = 0;
        }

       
        private void button_Click(object sender, RoutedEventArgs e)
        {

            switch ((ALGORITHMS)cbAlgorithm.SelectedItem)
            {
                case ALGORITHMS.AES: algorithm = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesEcbPkcs7); break;
                case ALGORITHMS.TRIPLEDES: algorithm = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.TripleDesEcbPkcs7); break;
                case ALGORITHMS.DES: algorithm = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.DesEcbPkcs7); break;
                case ALGORITHMS.RC2: algorithm = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.Rc2EcbPkcs7); break;
            }
            bufferEncrypted = this.Encrypt(textBox.Text);

            tbEncrypted.Text = Encoding.UTF8.GetString(bufferEncrypted.ToArray());
            TBEncryptedBase64.Text = Convert.ToBase64String(bufferEncrypted.ToArray());

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string decrypted = this.Decrypt();
            TBDecrypted.Text = decrypted;
        }

        public IBuffer Encrypt(String plaintText)
        {
            IBuffer buffMsg = CryptographicBuffer.ConvertStringToBinary(plaintText, encoding);
            IBuffer keyMaterial = CryptographicBuffer.GenerateRandom(keyLength);
            key = algorithm.CreateSymmetricKey(keyMaterial);
            bufferEncrypted = CryptographicEngine.Encrypt(key, buffMsg, iv);
            return bufferEncrypted;
        }

        public string Decrypt()
        {
            IBuffer buffDecrypted;
            buffDecrypted = CryptographicEngine.Decrypt(key, bufferEncrypted, iv);
            return CryptographicBuffer.ConvertBinaryToString(encoding, buffDecrypted);
        }
    }


}
