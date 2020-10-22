using Microsoft.Extensions.Configuration;
using ModelLayerBookStore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayerBookStore
{
    public class WishListRepository : IWishListRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly SqlConnection sqlConnection;

        public WishListRepository(IConfiguration configuration)
        {

            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("UserDbConnection");
            this.sqlConnection = new SqlConnection(this.connectionString);
        }

        public WishListModelClass BookCart(WishListModelClass cart)
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
                    cart.TotalPrice = Convert.ToInt32(sqlDataReader["TotalPrice"]);
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
