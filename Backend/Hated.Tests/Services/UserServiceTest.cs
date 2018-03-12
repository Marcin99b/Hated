using System.Threading.Tasks;
using AutoMapper;
using Hated.Core.Domain;
using Hated.Core.Repositories;
using Hated.Infrastructure.Services;
using Hated.Infrastructure.Services.UserService;
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
            var encrypter = new Encrypter();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, encrypter, mapperMock.Object);
            
            await userService.RegisterAsync("test@email.com", "username", "secret");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
        
    }
}
