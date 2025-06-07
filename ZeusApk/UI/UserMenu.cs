using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusApk.Repositories;

namespace ZeusApk.UI
{
    internal class UserMenu
    {
        private readonly string _userEmail;
        private readonly bool   _isCompanhia;
        private readonly IPostRepository _postRepository;

        public UserMenu(string email, IPostRepository postRepository, bool isCompanhia)
        {
            _userEmail      = email;
            _postRepository = postRepository;
            _isCompanhia    = isCompanhia;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"=== Menu do Usuário ({_userEmail}) ===");
                Console.WriteLine("1 - Postar");
                Console.WriteLine("2 - Explorar");
                Console.WriteLine("3 - Meus Posts");
                Console.WriteLine("4 - Sair");
                Console.Write("Escolha uma opção: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        if (_isCompanhia)
                        {
                            var postCompanyScreen = new PostCompanyScreen(_postRepository, _userEmail);
                            postCompanyScreen.Show();
                        }
                        else
                        {
                            var postScreen = new PostScreen(_postRepository, _userEmail);
                            postScreen.Show();
                        }
                        break;
                    case "2":
                        var exploreScreen = new ExploreScreen(_postRepository, _userEmail);
                        exploreScreen.Show();
                        break;
                    case "3":
                        var myPostsScreen = new MyPostsScreen(_postRepository, _userEmail);
                        myPostsScreen.Show();
                        break;
                    case "4":
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
