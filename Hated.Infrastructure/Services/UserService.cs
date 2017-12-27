using System;
using System.Threading.Tasks;
using Hated.Core.Domain;
using Hated.Core.Repositories;

namespace Hated.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<User> GetAsync(Guid id)
            => await _userRepository.GetAsync(id);

        public async Task<User> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new Exception($"User with email: {email} isn't exist");
            }
            return user;
        }
            


        public async Task RegisterAsync(string email, string username, string password)
        {
            var user = new User(email, username, password);

            if (_userRepository.GetAsync(user.Id).Result != null)
            {
                throw new Exception($"User with email: {user.Email} is exist");
            }
            await _userRepository.AddAsync(user);
        }
    }
}
