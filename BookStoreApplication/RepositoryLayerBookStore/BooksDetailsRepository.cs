using Microsoft.Extensions.Configuration;
using ModelLayerBookStore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayerBookStore
{
    public class BooksDetailsRepository : IBookDetailsRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly SqlConnection sqlConnection;

        public BooksDetailsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("UserDbConnection");
            this.sqlConnection = new SqlConnection(this.connectionString);
        }

        public BooksDetailsModel AddBookDetails (BooksDetailsModel books)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("sp_AddBookDetails", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@BookAuther", books.BookAutherName);
                sqlCommand.Parameters.AddWithValue("@BookDes", books.BookDescription);
                sqlCommand.Parameters.AddWithValue("@bookName", books.BookName);
                sqlCommand.Parameters.AddWithValue("@BookPrice", books.BookPrice);
                sqlCommand.Parameters.AddWithValue("@BookQuantity", books.BookQuantity);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return books;
            }
            catch (Exception e)
            {

                throw new Exception("Value not added" + e);
            }
        }

        public BooksDetailsModel UpdateBookDetails(BooksDetailsModel books)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("sp_AddBookDetails", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@bookid", books.BookId);
                sqlCommand.Parameters.AddWithValue("@BookAuther", books.BookAutherName);
                sqlCommand.Parameters.AddWithValue("@BookDes", books.BookDescription);
                sqlCommand.Parameters.AddWithValue("@bookName", books.BookName);
                sqlCommand.Parameters.AddWithValue("@BookPrice", books.BookPrice);
                sqlCommand.Parameters.AddWithValue("@BookQuantity", books.BookQuantity);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return books;
            }
            catch (Exception e)
            {
                throw new Exception("value Not been Updated" + e);
            }
        }
    }
}
