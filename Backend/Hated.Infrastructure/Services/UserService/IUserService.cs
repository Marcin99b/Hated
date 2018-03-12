using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services.UserService
{
    public interface IUserService : IService
    {
        Task RegisterAsync(string email, string username, string password);
        Task LoginAsync(string email, string password);
        Task<UserDto> GetAsync(Guid id);
        Task<UserDto> GetAsync(string email);
        Task<IEnumerable<UserDto>> GetAllAsync(int from, int number);
        Task UpdateAsync(UserDto updatedUser);
        Task DeleteAsync(Guid id);
    }
}
