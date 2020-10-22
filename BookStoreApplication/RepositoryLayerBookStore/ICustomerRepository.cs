using ModelLayerBookStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayerBookStore
{
    public interface ICustomerRepository
    {
        CustomerRegistrationModelClass AddCustomerDetails(CustomerRegistrationModelClass customer);
        CustomerRegistrationModelClass UpdateCustomerDetail(CustomerRegistrationModelClass customer);
    }
}
