using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Hated.Infrastructure.Commands.Users;
using Hated.Infrastructure.DTO;
using Newtonsoft.Json;
using Xunit;

namespace Hates.Tests.EndToEnd
{
    public class GetUserTest : ServerConfigAndRun
    {
        [Fact]
        public async Task ValidUserShouldBeReturned()
        {
            string email = "user1@email.com";
            var user = await GetUserAsync(email);
            Assert.Equal(email, user.Email);
        }
        
        [Fact]
        public async Task GetUsersShouldReturnListOfUsers()
        {
            var response = await Client.GetAsync("api/users");
            var responseString = await response.Content.ReadAsStringAsync();

            var users = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(responseString);
            var user = users.FirstOrDefault();

            Assert.IsType<UserDto>(user);
        }

        [Fact]
        public async Task CreatedUserShouldBeCreated()
        {
            var userToCreate = new CreateUser
            {
                Email = "test@test.com",
                Username = "testuser",
                Password = "secret"
            };
            var payload = GetPayload(userToCreate);
            var response = await Client.PostAsync("api/users", payload);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal($"api/users/{userToCreate.Email}", response.Headers.Location.ToString());


            var createdUser = await GetUserAsync(userToCreate.Email);

            Assert.Equal(userToCreate.Email, createdUser.Email);
        }

        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"api/users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }
    }
}
