using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusApk.Models;

namespace ZeusApk.Repositories
{
    internal interface IUserRepository
    {
        User GetUserByEmail(string email);
        void AddUser(User user);
    }
}
