using System;

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
            SetPassword(password);
            
            SetSalt(salt);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            Email = email;
            ChangedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username)
        {
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
