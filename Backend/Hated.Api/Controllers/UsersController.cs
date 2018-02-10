using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Hated.Infrastructure.Commands.Users;
using Hated.Infrastructure.DTO;
using Hated.Infrastructure.Extensions;
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
            try
            {
                var user = await _userService.GetAsync(email);
                if (user == null)
                {
                    return NotFound();
                }
                return Json(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET users
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            
            try
            {
                var users = await _userService.GetAllAsync();
                if (users == null)
                {
                    return NotFound();
                }
                return Json(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        
        //Update
        //PUT users
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]UserDto updatedUser)
        {
            if (!updatedUser.Id.IsAuthorOrAdmin(User))
            {
                Unauthorized();
            }
            try
            {
                await _userService.UpdateAsync(updatedUser);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Delete
        //DELETE users/guid
        [Authorize]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync(Guid userId)
        {
            if (!userId.IsAuthorOrAdmin(User))
            {
                Unauthorized();
            }
            try
            {
                await _userService.DeleteAsync(userId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}