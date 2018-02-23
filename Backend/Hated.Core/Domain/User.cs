using System;
using SimpleValidator.Extensions;

namespace Hated.Core.Domain
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Username { get; protected set; }
        public string Role { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime ChangedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public User(string email, string username, string password, string salt)
        {
            Id = Guid.NewGuid();
            SetEmail(email);
            SetUsername(username);
            SetRole("User");
            SetPassword(password);
            SetSalt(salt);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if (!email.IsEmail())
            {
                throw new Exception($"Email: {email} is not valid");
            }
            Email = email;
            ChangedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username)
        {
            if (!username.IsMinLength(3))
            {
                throw new Exception($"Username: {username} lenght is lower than 3");
            }
            if (!username.IsMaxLength(30))
            {
                throw new Exception($"Username: {username} lenght is more than 30");
            }

            Username = username;
            ChangedAt = DateTime.UtcNow;
        }

        public void SetRole(string role)
        {
            Role = role;
            ChangedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password)
        {
            if (!password.IsMinLength(6))
            {
                throw new Exception($"Password lenght is lower than 6");
            }
            Password = password;
            ChangedAt = DateTime.UtcNow;
        }

        public void SetSalt(string salt)
        {
            Salt = salt;
            ChangedAt = DateTime.UtcNow;
        }
    }
}
