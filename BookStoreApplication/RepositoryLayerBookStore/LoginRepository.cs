using Microsoft.Extensions.Configuration;
using ModelLayerBookStore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RepositoryLayerBookStore
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly SqlConnection sqlConnection;

        public LoginRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("UserDbConnection");
            this.sqlConnection = new SqlConnection(this.connectionString);
        }

        public LoginModelClass AddLoginDetails (LoginModelClass login)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("sp_AddUserLogin", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Email", login.Email);
                sqlCommand.Parameters.AddWithValue("@password", login.Password);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return login;
            }
            catch (Exception e)
            {

                throw new Exception("Login Details Added" + e);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public LoginModelClass UpdateLoginUser (LoginModelClass login)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("sp_AddUserLogin", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Email", login.Email);
                sqlCommand.Parameters.AddWithValue("@password", login.Password);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return login;
            }
            catch (Exception e)
            {

                throw new Exception("Login Details Added" + e);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

    }
}
