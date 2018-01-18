using System;
using System.Threading.Tasks;
using Hated.Infrastructure.Commands.Users;
using Hated.Infrastructure.DTO;
using Hated.Infrastructure.Services;
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

        //Create
        //POST api/users
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]CreateUser newUser)
        {
            await _userService.RegisterAsync(newUser.Email, newUser.Username, newUser.Password);
            return Created($"api/users/{newUser.Email}", null);

        }

        //Read
        // GET api/users/email@email.com
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

        // GET api/users
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
        //PUT api/users
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]UserDto updatedUser)
        {
            await _userService.UpdateAsync(updatedUser);
            return Ok();
        }

        //Delete
        //DELETE api/users/guid
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync(Guid userId)
        {
            await _userService.DeleteAsync(userId);
            return Ok();
        }
    }
}