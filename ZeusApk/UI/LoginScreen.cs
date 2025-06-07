using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusApk.Repositories;
using ZeusApk.Services;

namespace ZeusApk.UI
{
    internal class LoginScreen
    {
        private readonly AuthService _authService;
        private IPostRepository _postRepository;

        public LoginScreen(AuthService authService, IPostRepository postRepository)
        {
            _authService = authService;
            _postRepository = postRepository;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Login ===");
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Senha: ");
            var password = Console.ReadLine();

            var user = _authService.Authenticate(email, password);

            if (user != null)
            {
                var userMenu = new UserMenu(email, _postRepository, user.isCompanhia);
                userMenu.Show();
            }
            else
            {
                Console.WriteLine("Usuário ou senha inválidos.");
            }
        }
    }
}
