using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hated.Core.Repositories;

namespace Hated.Infrastructure.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUserRepository _userRepository;

        public RoleService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task SetAdmin(Guid id)
            => await SetRole(id, "Admin");

        public async Task SetUser(Guid id)
            => await SetRole(id, "User");

        private async Task SetRole(Guid id, string role)
        {
            var user = await _userRepository.GetAsync(id);
            user.SetRole(role);
            await _userRepository.UpdateAsync(user);
        }
    }
}
