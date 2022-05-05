using DotNetJwtAuth.Models;
using DotNetJwtAuth.Repository;
using DotNetJwtAuth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNetJwtAuth.Controllers
{
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "User or password invalid" });

          //  var token = TokenService.CreateToken(user);
            var token = TokenService.GetTokenFromAuthServer(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous()
        {
            return "You are Anonymous";
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated()
        {
            var user = "authenticated";
            return user;
        }

        [HttpGet]
        [Route("User")]
        [Authorize(Roles = "User")]
        public string User()
        {
            return "You are a User";
        }

        [HttpGet]
        [Route("Users")]
        [Authorize]
        // [Authorize(Roles = "User")]
        public async Task<ActionResult<dynamic>> Users()
        {
            // return "You are a User";
            var users = UserRepository.GetAll();
            return users;
        }

        [HttpGet]
        [Route("Elevated")]
        [Authorize(Roles = "Manager,Admin")]
        public string Elevated() => "Authenticated but not a User";

        [HttpGet]
        [Route("Manager")]
        [Authorize(Roles = "Manager")]
        public string Manager() => "Manager";

    }
}
