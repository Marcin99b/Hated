using System.Threading.Tasks;
using Hated.Core.Domain;
using Hated.Core.Repositories;
using Hated.Infrastructure.Repositories;
using Hated.Infrastructure.Services;
using Moq;
using Xunit;

namespace Hated.Tests.Services
{
    public class UserServiceTest
    {
        [Fact]
        public async Task RegisteredUserShouldInvokeAddAsyncMethod()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(userRepositoryMock.Object);
            
            await userService.RegisterAsync("test@email.com", "user", "secret");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
