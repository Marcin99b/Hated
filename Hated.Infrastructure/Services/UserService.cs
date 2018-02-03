using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hated.Core.Domain;
using Hated.Core.Repositories;
using Hated.Infrastructure.DTO;

namespace Hated.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IMapper mapper)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        //Create
        public async Task RegisterAsync(string email, string username, string password)
        {
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            var user = new User(email, username, hash, salt);
            await _userRepository.AddAsync(user);
        }

        //Login
        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new Exception("Email or password are invalid");
            }
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            if (user.Password == hash)
            {
                return;
            }
            throw new Exception("Email or password are invalid");
        }

        //Read
        public async Task<UserDto> GetAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            if (user == null)
            {
                throw new Exception($"User with id: {id} isn't exist");
            }
            
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new Exception($"User with email: {email} isn't exist");
            }
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => _mapper.Map<User, UserDto>(user));
        }
        

        //Update
        public async Task UpdateAsync(UserDto updatedUser)
        {
            var user = await _userRepository.GetAsync(updatedUser.Id);
            if (user == null)
            {
                throw new Exception($"User with id: {updatedUser.Id} isn't exist");
            }
            user.SetEmail(updatedUser.Email);
            user.SetUsername(updatedUser.Username);
            await _userRepository.UpdateAsync(user);
        }

        //Delete
        public async Task DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            if (user == null)
            {
                throw new Exception($"User with id: {id} isn't exist");
            }
            await _userRepository.RemoveAsync(user);
        }
        
    }
}
