using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayerBookStore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        public string EncodePassword(string password)
        {
            byte[] encPassword = new byte[password.Length];
            encPassword = Encoding.UTF8.GetBytes(password);
            string encodedPassword = Convert.ToBase64String(encPassword);
            return encodedPassword;
        }

        public LoginModelClass AddLoginDetails (LoginModelClass login)
        {
            try
            {
                var encodePassword = this.EncodePassword(login.Password);
                SqlCommand sqlCommand = new SqlCommand("sp_AddUserLogin", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Email", login.Email);
                sqlCommand.Parameters.AddWithValue("@password", encodePassword);
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
        public string GenerateToken(LoginModelClass login, string type)
        {
            try
            {
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>();
                claims.Add(new Claim("Email", login.Email.ToString()));
                claims.Add(new Claim("Password", login.Password.ToString()));
                var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                    configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddHours(120),
                    signingCredentials: signingCreds);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
