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
    public class WishListController : ControllerBase
    {

        public readonly IWhishListManager whish;

        public WishListController(IWhishListManager whish)
        {
            this.whish = whish;
        }

        [HttpPost]
        //[Route("Addwhis")]
        public IActionResult AddWhishList(WishListModelClass whis)
        {
            var userResult = this.whish.AddWhishList(whis);

            try
            {
                if (userResult != null)
                {
                    return this.Ok(new Response(HttpStatusCode.OK, "The  Data", userResult));
                }
                return this.NotFound(new Response(HttpStatusCode.NotFound, " Data Not Found", userResult));
            }
            catch (Exception)
            {
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of data not displayed", null));
            }
        }

        [HttpPut]
        //[Route("Addwhis")]
        public IActionResult UpdateWhishList(WishListModelClass whis)
        {
            var userResult = this.whish.UpdateWhishList(whis);

            try
            {
                if (userResult != null)
                {
                    return this.Ok(new Response(HttpStatusCode.OK, "The  Data", userResult));
                }
                return this.NotFound(new Response(HttpStatusCode.NotFound, " Data Not Found", userResult));
            }
            catch (Exception)
            {
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of data not displayed", null));
            }
        }

        [HttpDelete]
        //[Route("Addwhis")]
        public IActionResult DeleteWhishList(WishListModelClass whis)
        {
            var userResult = this.whish.DeleteWhishList(whis);
            try
            {
                if (userResult != null)
                {
                    return this.Ok(new Response(HttpStatusCode.OK, "The  Data", userResult));
                }
                return this.NotFound(new Response(HttpStatusCode.NotFound, " Data Not Found", userResult));
            }
            catch (Exception)
            {
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of data not displayed", null));
            }
        }
    }
}
