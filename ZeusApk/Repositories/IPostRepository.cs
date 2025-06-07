using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusApk.Models;

namespace ZeusApk.Repositories
{
    internal interface IPostRepository
    {
        void Add(Post post);
        List<Post> GetAll();
        List<Post> GetByUser(string userEmail);
    }
}
