using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusApk.Models;

namespace ZeusApk.Repositories
{
    internal class MockPostRepository : IPostRepository
    {
        private readonly List<Post> _posts = new();

        public void Add(Post post)
        {
            _posts.Add(post);
        }

        public List<Post> GetAll()
        {
            return _posts;
        }

        public List<Post> GetByUser(string userEmail)
        {
            return _posts.Where(p => p.UserEmail == userEmail).ToList();
        }

    }
}
