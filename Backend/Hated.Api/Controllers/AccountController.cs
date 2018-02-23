using System;
using System.Collections.Generic;
using System.Net.Mime;
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
                return Created($"users/{newUser.Email}", null);
            }
            catch (Exception e)
            {
                return Json(new ExceptionDto
                {
                    Error = e.Message
                });
            }
        }

        //Token
        //POST account/login
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody]LoginUser loginUser)
        {
            try
            {
                await _userService.LoginAsync(loginUser.Email, loginUser.Password);
                var user = await _userService.GetAsync(loginUser.Email);
                var token = await _jwtHandler.CreateTokenByUserObject(user);
                return Json(token);
            }
            catch (Exception e)
            {
                return Json(new ExceptionDto
                {
                    Error = e.Message
                });
            }
        }

        //POST account/refreshtoken
        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshTokenAsync()
        {
            try
            {
                var token = await _jwtHandler.RefreshTokenAsync(User);
                return Json(token);
            }
            catch (Exception e)
            {
                return Json(new ExceptionDto
                {
                    Error = e.Message
                });
            }
        }
    }
}
