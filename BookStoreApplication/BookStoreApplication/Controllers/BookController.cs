using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BookStoreManagerLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayerBookStore;

namespace BookStoreApplication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly IBookDetailsManager bookDetailsManager;

        public BookController(IBookDetailsManager bookDetailsManager)
        {
            this.bookDetailsManager = bookDetailsManager;
        }

        [HttpPost]
        [Route("AddBookDetails")]
        public IActionResult AddCustomerDetails(BooksDetailsModel customer)
        {
            var BookResult = this.bookDetailsManager.AddBookDetails(customer);

            try
            {
                if (BookResult != null)
                {
                    return this.Ok(new Response(HttpStatusCode.OK, "The Customer Data", BookResult));
                }
                return this.NotFound(new Response(HttpStatusCode.NotFound, "customer Data Not Found", BookResult));
            }
            catch (Exception)
            {
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of customer data not displayed", null));
            }
        }

        [HttpPut]
        [Route("UpdateBooksDetails")]
        public IActionResult UpdateCustomerDetails(BooksDetailsModel customer)
        {
            var CustomerResult = this.bookDetailsManager.UpdateBookDetails(customer);

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
