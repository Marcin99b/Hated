using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;
using Newtonsoft.Json;
using Xunit;

namespace Hated.Tests.EndToEnd
{
    public class CrudUserTest : BaseMethodsToTests
    {
        [Fact]
        public async Task GetAllUsersShouldReturnListOfUsers()
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
            string emailTestedUser = Guid.NewGuid().ToString();
            var response = await CreateNewUser(emailTestedUser);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal($"api/users/{emailTestedUser}", response.Headers.Location.ToString());
            
            var createdUser = await GetUserAsync(emailTestedUser);

            Assert.Equal(emailTestedUser, createdUser.Email);
        }

        [Fact]
        public async Task UpdatedUserShouldBeUpdated()
        {
            string usernameAfterUpdate = Guid.NewGuid().ToString();
            testUserGenerate.Username = usernameAfterUpdate;
            
            var payload = GetPayload(testUserGenerate);
            var response = await Client.PutAsync("api/users", payload);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var updatedUser = await GetUserAsync(testUserGenerate.Email);
            Assert.Equal(usernameAfterUpdate, updatedUser.Username);
        }

        [Fact]
        public async Task DeletedUserShouldBeDelete()
        {
            var responseDeleted = await Client.DeleteAsync($"api/users/{testUserGenerate.Id}");

            Assert.Equal(HttpStatusCode.OK, responseDeleted.StatusCode);
            
        }
    }
}
