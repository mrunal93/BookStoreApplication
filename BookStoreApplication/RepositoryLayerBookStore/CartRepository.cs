using Microsoft.Extensions.Configuration;
using ModelLayerBookStore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayerBookStore
{
    public class CartRepository : ICartRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly SqlConnection sqlConnection;

        public CartRepository(IConfiguration configuration)
        {

            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("UserDbConnection");
            this.sqlConnection = new SqlConnection(this.connectionString);
        }

        public CartModelClass BookCart (CartModelClass cart)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("GetBookCart", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@cartId", cart.CardId);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    cart.Quantity = Convert.ToInt32(sqlDataReader["Quantity"]);
                    cart.BookId = Convert.ToInt32(sqlDataReader["TotalPrice"]);
                }
                return cart;
            }
            catch (Exception e)
            {

                throw new Exception("Value is not able to read" + e);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
