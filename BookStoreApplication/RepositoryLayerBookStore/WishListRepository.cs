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

        public WishListModelClass GetWhishList(WishListModelClass cart)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("sp_WishList", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@cartId", cart.WhishListId);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    cart.BookId = Convert.ToInt32(sqlDataReader["Quantity"]);
                    cart.WhishListId = Convert.ToInt32(sqlDataReader["TotalPrice"]);
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
        
       

        public WishListModelClass UpdateWhishList(WishListModelClass whis)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("sp_UpdateWishList", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Bookid", whis.BookId);
                sqlCommand.Parameters.AddWithValue("@Whisid", whis.WhishListId);

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

        public WishListModelClass AddWhishList(WishListModelClass whis)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("sp_AddWishList", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Bookid", whis.BookId);
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

        public WishListModelClass DeleteWhishList(WishListModelClass whis)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("sp_DeleteWishList", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@whisid", whis.WhishListId);

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
