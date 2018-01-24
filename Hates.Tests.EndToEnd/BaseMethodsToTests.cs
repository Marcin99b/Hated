using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Hated.Infrastructure.Commands.Users;
using Hated.Infrastructure.DTO;
using Newtonsoft.Json;

namespace Hates.Tests.EndToEnd
{
    public class BaseMethodsToTests : ServerConfigAndRun
    {
        protected StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        //User are intergal object of all tests, because most what we testing, do created user
        protected async Task<HttpResponseMessage> CreateNewUser(string email)
        {
            var payload = GetPayload(new CreateUser
            {
                Email = email,
                Username = "testuser",
                Password = "secret"
            });
            return await Client.PostAsync("api/users", payload);
        }

        protected async Task<UserDto> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"api/users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }
    }
}
