using System;
using System.Threading.Tasks;
using Hated.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hated.Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IJwtHandler _jwtHandler;

        public AccountController(IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }

        //Token
        //GET account/token/email@email.com
        [HttpGet("token/{email}")]
        public IActionResult GetAsync(string email)
        {
            var token = _jwtHandler.CreateToken(email, "user");
            return Json(token);
        }
    }
}
