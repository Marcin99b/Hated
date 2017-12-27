using System;
using System.Threading.Tasks;
using Hated.Core.Domain;

namespace Hated.Infrastructure.Services
{
    public interface IUserService
    {
        //TODO change to user dto
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task RegisterAsync(string email, string username, string password);
    }
}
