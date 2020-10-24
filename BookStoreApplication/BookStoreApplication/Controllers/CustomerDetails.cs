using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BookStoreManagerLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayerBookStore;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetails : ControllerBase
    {
        public readonly ICustomerManager customerManager;
        
        public CustomerDetails (ICustomerManager customerManager)
        {
            this.customerManager = customerManager;
        }

        [HttpPost]
        [Route("AddCustomerDetails")]
        public IActionResult AddCustomerDetails(CustomerRegistrationModelClass customer)
        {
            var CustomerResult = this.customerManager.AddCustomerDetails(customer);

            try
            {
                if (CustomerResult != null)
                {
                    return this.Ok(new Response(HttpStatusCode.OK, "The Customer Data", CustomerResult));
                }
                return this.NotFound(new Response(HttpStatusCode.NotFound, "customer Data Not Found", CustomerResult));
            }
            catch (Exception)
            {
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of customer data not displayed", null));
            }
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public IActionResult UpdateCustomerDetails(CustomerRegistrationModelClass customer)
        {
            var CustomerResult = this.customerManager.UpdateCustomerDetail(customer);

            try
            {
                if (CustomerResult != null)
                {
                    return this.Ok(new Response(HttpStatusCode.OK, "The Customer Data", CustomerResult));
                }
                return this.NotFound(new Response(HttpStatusCode.NotFound, "customer Data Not Found", CustomerResult));
            }
            catch (Exception)
            {
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of customer data not displayed", null));
            }
        }
    }
}
