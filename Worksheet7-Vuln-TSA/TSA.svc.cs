using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TSA
{
    public class TSA : ITSA
    {
        const string filePFXCert = @"C://Temp/estg.dei.si.a.pfx";
        const string fileCERCert = @"C://Temp/estg.dei.si.a.cer";
        static readonly string pwdfilePFXCert = Properties.Settings.Default.PwdPFX;

        public string GetTimestamp(string base64Hash)
        {
            
            SHA1 sha1 = SHA1.Create();
            X509Certificate2 cert = new X509Certificate2(filePFXCert, pwdfilePFXCert);
            
            CmsSigner signer = new CmsSigner(cert);

            string timestampString = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            byte[] timestamp = Encoding.UTF8.GetBytes(timestampString);
            byte[] hash = Convert.FromBase64String(base64Hash);
            byte[] concatenatedBytes = new byte[hash.Length + timestamp.Length];
            Array.Copy(hash, 0, concatenatedBytes, 0, hash.Length);
            Array.Copy(timestamp, 0, concatenatedBytes, hash.Length, timestamp.Length);

            byte[] tsaHash = sha1.ComputeHash(concatenatedBytes);


            ContentInfo cinfo = new ContentInfo(tsaHash);


            SignedCms signedCms = new SignedCms(cinfo, false); 
            signedCms.ComputeSignature(signer, false);

            byte[] signedTSAHash = signedCms.Encode();

            byte[] concatenatedResponse = new byte[signedTSAHash.Length + timestamp.Length];
            Array.Copy(timestamp, 0, concatenatedResponse, 0, timestamp.Length);
            Array.Copy(signedTSAHash, 0, concatenatedResponse, timestamp.Length, signedTSAHash.Length);
            

            return Convert.ToBase64String(concatenatedResponse);
        }
    }
}
