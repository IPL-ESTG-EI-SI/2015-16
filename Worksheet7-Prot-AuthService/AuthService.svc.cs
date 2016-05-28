using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AuthService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class AuthService : IAuthService
    {

        /// <summary>
        /// Exemplo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string GetExemplo(string input)
        {
            return "*** " + input + " ***";
        }

        public string GetUserDescription(string login)
        {
            return SqlServerHelper.GetUserDescription(login);
        }

        public User[] GetUsers(string login, string password)
        {
            
            if (SqlServerHelper.UserExists(login, calculatePasswordHash(password)) <= 0)
            {
                return null;
            }
            if(SqlServerHelper.doesUserHaveRole(login, "admin"))
            {
                return SqlServerHelper.GetUsers();
            }
            return null;
        }

        public User[] GetUsersByCertificate(string base64pkcs7Signature)
        {
            User user = SqlServerHelper.GetUser(base64pkcs7Signature);
            if (user == null)
            {
                return null;
            }
            if (SqlServerHelper.doesUserHaveRole(user.Login, "admin"))
            {
                return SqlServerHelper.GetUsers();
            }
            return null;
        }

        public string SetUserCertificate(string login, string password, string base64pkcs7Signature)
        {
            if (SqlServerHelper.UserExists(login, calculatePasswordHash(password)) <= 0)
            {
                return null;
            }
            return SqlServerHelper.SetUserCertificate(login, base64pkcs7Signature);
        }

        public string SetUserDescription(string login, string password, string description)
        {
            if (SqlServerHelper.UserExists(login, calculatePasswordHash(password)) <= 0)
            {
                return null;
            }
            return SqlServerHelper.SetUserDescription(login, description);
        }

        private string calculatePasswordHash(string passInClearText)
        {
            SHA1 sha = SHA1.Create();
            byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(passInClearText));
            return Convert.ToBase64String(hash);
        }
    }

}
