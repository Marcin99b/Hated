using System;
using System.Text.RegularExpressions;

namespace Hated.Infrastructure.Extensions
{
    public static class ValidationExtensions
    {
        public static void EmailValidation(this string email)
        {
            if (!Regex.IsMatch(email,
                "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"))
            {
                throw new Exception($"Email: {email} is not valid");
            }
        }

        public static void UsernameValidation(this string username, int min = 3, int max = 30)
        {
            if (username.Length < min)
            {
                throw new Exception($"Username: {username} lenght is lower than {min} or more than {max}");
            }
            if (username.Length > max)
            {
                throw new Exception($"Username: {username} lenght is more than 30");
            }
        }

        public static void PasswordValidation(this string password, int min = 6)
        {
            if (password.Length < min)
            {
                throw new Exception($"Password lenght is lower than {min}");
            }
        }

        public static void PostContentValidation(this string content, int min = 50)
        {
            if (content.Length < min)
            {
                throw new Exception($"Content lenght is lower than {min}");
            }
        }

        public static void PostTitleValidation(this string title, int min = 10)
        {
            if (title.Length < min)
            {
                throw new Exception($"Title lenght is lower than {min}");
            }
        }
    }
}
