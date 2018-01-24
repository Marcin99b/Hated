using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;
using Newtonsoft.Json;
using Xunit;

namespace Hates.Tests.EndToEnd
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
            var user = await CreateAndGetRandomUser();
            string usernameAfterUpdate = Guid.NewGuid().ToString();
            user.Username = usernameAfterUpdate;
            
            var payload = GetPayload(user);
            var response = await Client.PutAsync("api/users", payload);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var updatedUser = await GetUserAsync(user.Email);
            Assert.Equal(usernameAfterUpdate, updatedUser.Username);
        }

        [Fact]
        public async Task DeletedUserShouldBeDelete()
        {
            var user = await CreateAndGetRandomUser();
            
            var responseDeleted = await Client.DeleteAsync($"api/users/{user.Id}");

            Assert.Equal(HttpStatusCode.OK, responseDeleted.StatusCode);
            
        }

        
    }
}
