using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReturnOrder.Models;
using ReturnOrder.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private IConfiguration _configuration;
        private IAuthRepo _repo;
        public UserLoginController(IConfiguration configuration, IAuthRepo repo)
        {
            _configuration = configuration;
            _repo = repo;
        }
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    HttpContext.Response.Cookies.Delete("Token");
        //    return View();
        //}

        [HttpPost]
        public IActionResult Login(User user)
        {
            try
            {
               var token = _repo.GetToken(user);
                ErrorDto err = new ErrorDto();

                if (token !=null )
                {
                    HttpContext.Response.Cookies.Append("Token", token);
                    err.Id = "login";
                    err.Message = "Success";
                    
                }
                else
                {
                    err.Id = "login";
                    err.Message = "Invalid";
                }
                return Ok(err);

            }
            catch (Exception e)
            {
                return BadRequest("InternalServerError" + e);
            }

        }
    }
}
