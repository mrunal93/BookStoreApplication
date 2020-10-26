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
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        public readonly ILoginManager loginManager;

        public UserLoginController(ILoginManager loginManager)
        {
            this.loginManager = loginManager;
        }

        [HttpPost]
        [Route("LoginUP")]
        public IActionResult AddUserLogin(LoginModelClass login)
        {
            var userResult = this.loginManager.AddLoginDetails(login);

            try
            {
                if (userResult != null)
                {
                    return this.Ok(new Response(HttpStatusCode.OK, "The  Data", userResult));
                }
                return this.NotFound(new Response(HttpStatusCode.NotFound, "Parking Data Not Found", userResult));
            }
            catch (Exception)
            {
                return this.BadRequest(new Response(HttpStatusCode.BadRequest, "List of Parking not displayed", null));
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult UserLoginData(LoginModelClass user)
        {

            var userResult = loginManager.AddLoginDetails(user);
            try
            {
                if (userResult != null)
                {
                    var jsonToken = loginManager.GenerateToken(userResult, "User");

                    return Ok(new Response(HttpStatusCode.OK, "login done successfully", jsonToken));
                }
                return NotFound(new Response(HttpStatusCode.NotFound, "List not fount", userResult));

            }
            catch (System.Exception)
            {
                return BadRequest(new Response(HttpStatusCode.BadRequest, "List canot display", null));
            }
        }
    }
}
