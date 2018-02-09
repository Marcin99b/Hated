using System;
using System.Threading.Tasks;
using Hated.Infrastructure.Commands.Account;
using Hated.Infrastructure.Commands.Users;
using Hated.Infrastructure.DTO;
using Hated.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hated.Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;

        public AccountController(IUserService userService, IJwtHandler jwtHandler)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
        }

        //Create
        //POST account/register
        [HttpPost("register")]
        public async Task<IActionResult> AddAsync([FromBody]CreateUser newUser)
        {
            try
            {
                await _userService.RegisterAsync(newUser.Email, newUser.Username, newUser.Password);
            }
            catch (Exception e)
            {
                BadRequest(e);
            }
            return Created($"users/{newUser.Email}", null);
        }

        //Token
        //POST account/login
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginUser loginUser)
        {
            var token = new JwtDto();
            try
            {
                await _userService.LoginAsync(loginUser.Email, loginUser.Password);
                var user = await _userService.GetAsync(loginUser.Email);
                token = _jwtHandler.CreateToken(user.Id, "user");
                
            }
            catch (Exception e)
            {
                BadRequest(e);
            }
            return Json(token);
        }
    }
}
