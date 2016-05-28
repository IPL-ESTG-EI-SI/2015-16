using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Web;

namespace AuthService
{

    /// <summary>
    /// Summary description for SqlServerHelper
    /// </summary>
    public class SqlServerHelper
    {

        public SqlServerHelper()
        {
            //
            // TODO: Add constructor logic here
            //        
        }

        internal static string GetUserDescription(string login)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT * FROM Users where login = @login";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("login", login));
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("Description")))
                        return reader.GetString(reader.GetOrdinal("Description"));
                    else
                        return "";
                }

                return "USER DOES NOT EXIST!!";
            }
            catch
            {
                return "SOME ERROR HAPPENED";
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }

        internal static string SetUserCertificate(string login, string base64pkcs7Signature)
        {
            SignedCms signedCms = new SignedCms();
            string thumbprint;
            // verificar assinatura
            try
            {
                signedCms.Decode(Convert.FromBase64String(base64pkcs7Signature));
                signedCms.CheckSignature(false);
                thumbprint = Encoding.UTF8.GetString(signedCms.ContentInfo.Content);
            }
            catch (Exception)
            {
                return "Signature not Valid";
            }


            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "UPDATE Users SET Thumbprint = @thumbprint  WHERE Login = @login";
                cmd.Parameters.Add(new SqlParameter("thumbprint", thumbprint));
                cmd.Parameters.Add(new SqlParameter("login", login));
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                int rowAfected = cmd.ExecuteNonQuery();
                return "User Thumbprint Updated";
            }
            catch
            {
                return null;
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }

        internal static bool doesUserHaveRole(string login, string role)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT * FROM Users where login = @login";
                cmd.Parameters.Add(new SqlParameter("login", login));
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string userRole = reader.GetString(reader.GetOrdinal("Role"));
                    return role.Equals(userRole);
                }

                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }

        internal static string SetUserDescription(string login, string description)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "UPDATE Users SET Description = @description WHERE Login = @login";
                cmd.Parameters.Add(new SqlParameter("description", description));
                cmd.Parameters.Add(new SqlParameter("login", login));
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                int rowAfected = cmd.ExecuteNonQuery();
                return "User Description Updated";
            }
            catch
            {
                return null;
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }

        internal static User[] GetUsers()
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT * FROM Users ";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                reader = cmd.ExecuteReader();
                List<User> users = new List<User>();
                while (reader.Read())
                {
                    User user = new User();
                    user.Id = reader.GetSqlInt32(reader.GetOrdinal("Id")).Value;
                    user.Login = reader.GetString(reader.GetOrdinal("Login"));
                    user.Name = reader.GetString(reader.GetOrdinal("Name"));
                    user.Password = reader.GetString(reader.GetOrdinal("Password"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Description")))
                        user.Description = reader.GetString(reader.GetOrdinal("Description"));
                    users.Add(user);
                }

                return users.ToArray();
            }
            catch
            {
                return null;
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }


        /// <summary>
        /// Verify if user exists
        /// </summary>
        /// <param name="login">login</param>
        /// <param name="password">password</param>
        /// <returns>Returns the id of user or 0 if user do not exists</returns>
        public static int UserExists(string login, string password)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT id FROM Users where Login = @login AND Password = @password";
                cmd.Parameters.Add(new SqlParameter("login", login));
                cmd.Parameters.Add(new SqlParameter("password", password));
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                int id = (int)cmd.ExecuteScalar();
                return id;
            }
            catch
            {
                return 0;
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }


        /// <summary>
        /// Gets a User from Database 
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <returns>Returns a User if id exists or null</returns>
        public static User GetUser(int id)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT * FROM Users where id = @id";
                cmd.Parameters.Add(new SqlParameter("id", id));
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    User user = new User();
                    user.Id = reader.GetSqlInt32(reader.GetOrdinal("Id")).Value;
                    user.Login = reader.GetString(reader.GetOrdinal("Login"));
                    user.Name = reader.GetString(reader.GetOrdinal("Name"));
                    user.Password = reader.GetString(reader.GetOrdinal("Password"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Description")))
                        user.Description = reader.GetString(reader.GetOrdinal("Description"));
                    return user;
                }

                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }


        public static User GetUser(string base64pkcs7Signature)
        {
            SignedCms signedCms = new SignedCms();
            string thumbprint;
            string timestamp;
            // verificar assinatura
            try
            {
                signedCms.Decode(Convert.FromBase64String(base64pkcs7Signature));
                signedCms.CheckSignature(false);
                timestamp = Encoding.UTF8.GetString(signedCms.ContentInfo.Content);
                thumbprint = signedCms.Certificates[signedCms.Certificates.Count - 1].Thumbprint;
            }
            catch (Exception)
            {
                return null;
            }


            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT * FROM Users where Thumbprint = @thumbprint";
                cmd.Parameters.Add(new SqlParameter("thumbprint", thumbprint));
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;
                sqlConnection.Open();

                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("Timestamp")))
                    {
                        string dbTimestamp = reader.GetString(reader.GetOrdinal("Timestamp"));
                        DateTime dbDate = DateTime.ParseExact(dbTimestamp, "yyyyMMddHHmmssffff", null);
                        DateTime requestDate = DateTime.ParseExact(timestamp, "yyyyMMddHHmmssffff", null);
                        if (requestDate <= dbDate)
                        {
                            return null;
                        }
                    }


                    User user = new User();
                    user.Id = reader.GetSqlInt32(reader.GetOrdinal("Id")).Value;
                    user.Login = reader.GetString(reader.GetOrdinal("Login"));
                    user.Name = reader.GetString(reader.GetOrdinal("Name"));
                    user.Password = reader.GetString(reader.GetOrdinal("Password"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Description")))
                        user.Description = reader.GetString(reader.GetOrdinal("Description"));


                    SqlCommand updateCmd = new SqlCommand();
                    updateCmd.Connection = sqlConnection;
                    updateCmd.CommandText = "UPDATE Users SET Timestamp = @timestamp WHERE Thumbprint = @thumbprint";
                    updateCmd.Parameters.Add(new SqlParameter("timestamp", timestamp));
                    updateCmd.Parameters.Add(new SqlParameter("thumbprint", thumbprint));
                    updateCmd.ExecuteNonQuery();


                    return user;
                }

                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }
    }
}