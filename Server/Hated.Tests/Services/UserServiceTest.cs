using System.Threading.Tasks;
using AutoMapper;
using Hated.Core.Domain;
using Hated.Core.Repositories;
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
            var encrypter = new Mock<IEncrypter>();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, encrypter.Object, mapperMock.Object);
            
            await userService.RegisterAsync("test@email.com", "user", "secret");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
        
    }
}
