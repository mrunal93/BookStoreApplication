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

        public CartModelClass GetBookCart (CartModelClass cart)
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
                    cart.BookId = Convert.ToInt32(sqlDataReader["BookId"]);
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

        public CartModelClass UpdateCart(CartModelClass whis)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("sp_UpdateWishList", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@quantity", whis.Quantity);
                sqlCommand.Parameters.AddWithValue("@bookId", whis.BookId);
                sqlCommand.Parameters.AddWithValue("@cartid", whis.CardId);


                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return whis;
            }
            catch (Exception e)
            {
                throw new Exception("WishList not Details Added" + e);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public CartModelClass AddCart(CartModelClass whis)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("sp_AddCart", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@quantity", whis.Quantity);
                sqlCommand.Parameters.AddWithValue("@bookId", whis.BookId);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return whis;
            }
            catch (Exception e)
            {
                throw new Exception("WishList not Details Added" + e);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public CartModelClass DeleteCart(CartModelClass whis)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("sp_DeleteCart", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@cartId", whis.CardId);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return whis;
            }
            catch (Exception e)
            {
                throw new Exception("WishList not Details Added" + e);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
