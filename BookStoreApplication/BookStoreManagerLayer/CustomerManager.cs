using ModelLayerBookStore;
using RepositoryLayerBookStore;
using System;

namespace BookStoreManagerLayer
{
    public class CustomerManager : ICustomerManager
    {
        public readonly ICustomerRepository customerRepository;
        public CustomerManager(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public CustomerRegistrationModelClass AddCustomerDetails(CustomerRegistrationModelClass customer)
        {
            return customerRepository.AddCustomerDetails(customer);
        }

        public CustomerRegistrationModelClass UpdateCustomerDetail(CustomerRegistrationModelClass customer)

        {
            return customerRepository.UpdateCustomerDetail(customer);
        }
    }
}
