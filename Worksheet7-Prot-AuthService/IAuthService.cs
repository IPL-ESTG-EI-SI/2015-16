using System.Runtime.Serialization;
using System.ServiceModel;

namespace AuthService
{
    [ServiceContract]
    public interface IAuthService
    {
        /// <summary>
        /// Exemplo 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperationContract]
        string GetExemplo(string input);

        [OperationContract]
        string GetUserDescription(string login);

        [OperationContract]
        string SetUserDescription(string login, string password, string description);

        [OperationContract]
        User[] GetUsers(string login, string password);

        [OperationContract]
        User[] GetUsersByCertificate(string base64pkcs7Signature);

        [OperationContract]
        string SetUserCertificate(string login, string password, string base64pkcs7Signature);

    }

}
