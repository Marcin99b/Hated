using System;
using System.Threading.Tasks;
using Xunit;

namespace Hated.Tests.EndToEnd
{
    public class AccountAndTokenTest : BaseMethodsToTests
    {
        [Fact]
        public async Task CreatedUserShouldCanGetToken()
        {
            var email = Guid.NewGuid().ToString();
            var password = Guid.NewGuid().ToString();
            await CreateNewUser(email, null, password);
            var token = await GetTokenByLoginUserAsync(email, password);
            Assert.NotNull(token);
        }

        [Fact]
        public async Task LoginShouldAddAuthorizationToRequest()
        {
            var email = Guid.NewGuid().ToString();
            var password = Guid.NewGuid().ToString();
            await CreateNewUser(email, null, password);
            await LoginUserAsync(email, password);
            Assert.NotNull(Client.DefaultRequestHeaders.Authorization);
        }
    }
}
