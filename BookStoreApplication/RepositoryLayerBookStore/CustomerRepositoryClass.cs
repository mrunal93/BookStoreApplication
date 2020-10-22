using Microsoft.Extensions.Configuration;
using ModelLayerBookStore;
using System;
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
            SqlCommand sqlCommand = new SqlCommand("sp_AddCustomerDetails",sqlConnection);
            return
        }
    }
}
