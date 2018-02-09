using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Hated.Infrastructure.Commands.Users;
using Hated.Infrastructure.DTO;
using Hated.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hated.Api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        //Read
        // GET users/email@email.com
        [HttpGet("{email}")]
        public async Task<IActionResult> GetAsync(string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user);
        }

        // GET users
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();
            if (users == null)
            {
                return NotFound();
            }

            return Json(users);
        }
        
        //Update
        //PUT users
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]UserDto updatedUser)
        {
            //var x = JwtSecurityTokenHandler.;
            await _userService.UpdateAsync(updatedUser);
            return Ok();
        }

        //Delete
        //DELETE users/guid
        [Authorize]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync(Guid userId)
        {
            await _userService.DeleteAsync(userId);
            return Ok();
        }
    }
}