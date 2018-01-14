using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string username, string password);
        Task<UserDto> GetAsync(Guid id);
        Task<UserDto> GetAsync(string email);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task UpdateAsync(UserDto updatedUser);
        Task DeleteAsync(Guid id);
    }
}
