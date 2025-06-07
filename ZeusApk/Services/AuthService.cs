using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ZeusApk.Models;
using ZeusApk.Repositories;

namespace ZeusApk.Services
{
    internal class AuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public User Authenticate(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null || user.Password != HashPassword(password))
                return null;
            return user;
        }

        public bool Register(string email, string password)
        {
            var existing = _userRepository.GetUserByEmail(email);
            if (existing != null) return false;

            _userRepository.AddUser(new User { Email = email, Password = password });
            return true;
        }
    }
}
