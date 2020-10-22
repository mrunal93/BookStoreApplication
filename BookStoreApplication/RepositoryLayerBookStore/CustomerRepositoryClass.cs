using Microsoft.Extensions.Configuration;
using ModelLayerBookStore;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RepositoryLayerBookStore
{
    public class CustomerRepositoryClass
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly SqlConnection sqlConnection;

        public CustomerRepositoryClass(IConfiguration configuration)
        {

            this.configuration = configuration;
            this.connectionString = this.configuration.GetConnectionString("UserDbConnection");
            this.sqlConnection = new SqlConnection(this.connectionString);
        }

        public CustomerRegistrationModelClass AddCustomerDetails (CustomerRegistrationModelClass customer)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("sp_AddCustomerDetails", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@name", customer.Name);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Address", customer.Address);
                sqlCommand.Parameters.AddWithValue("@pinCode", customer.PinCode);
                sqlCommand.Parameters.AddWithValue("@Email", customer.Email);
                sqlCommand.Parameters.AddWithValue("@type", customer.Type);
                sqlCommand.Parameters.AddWithValue("@landMark", customer.LandMark);
                sqlCommand.Parameters.AddWithValue("@city", customer.City);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return customer;
            }
            catch (Exception e)
            {

                throw new Exception("Customer Detail not Added" + e);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public CustomerRegistrationModelClass UpdateCustomerDetail (CustomerRegistrationModelClass customer)
        {

            try
            {
                SqlCommand sqlCommand = new SqlCommand("sp_AddCustomerDetails", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@name", customer.Name);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Address", customer.Address);
                sqlCommand.Parameters.AddWithValue("@pinCode", customer.PinCode);
                sqlCommand.Parameters.AddWithValue("@Email", customer.Email);
                sqlCommand.Parameters.AddWithValue("@type", customer.Type);
                sqlCommand.Parameters.AddWithValue("@landMark", customer.LandMark);
                sqlCommand.Parameters.AddWithValue("@city", customer.City);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return customer;
            }
            catch (Exception e)
            {

                throw new Exception("Customer Detail not Added" + e);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
