using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusApk.Models;

namespace ZeusApk.Repositories
{
    internal class MockUserRepository : IUserRepository
    {
        private List<User> _users = new()
        {
            new User { Email = "user@email.com", Password = "A6xnQhbz4Vx2HuGl4lXwZ5U2I8iziLRFnhP5eNfIRvQ=" },
            new User { Email = "gabriel@gabriel.com", Password = "A6xnQhbz4Vx2HuGl4lXwZ5U2I8iziLRFnhP5eNfIRvQ=" },
            new User { Email = "enel@enel.com", Password = "A6xnQhbz4Vx2HuGl4lXwZ5U2I8iziLRFnhP5eNfIRvQ=", isCompanhia = true }
        };

        public User GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }
    }
}
