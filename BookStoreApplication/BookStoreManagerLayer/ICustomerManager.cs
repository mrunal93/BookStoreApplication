using ModelLayerBookStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreManagerLayer
{
    public interface ICustomerManager
    {
        CustomerRegistrationModelClass AddCustomerDetails(CustomerRegistrationModelClass customer);
        CustomerRegistrationModelClass UpdateCustomerDetail(CustomerRegistrationModelClass customer);
    }
}
