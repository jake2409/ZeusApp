using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusApk.Repositories;
using ZeusApk.Services;

namespace ZeusApk.UI
{
    internal class MainMenu
    {
        private readonly AuthService _authService;
        private readonly RegisterScreen _registerScreen;
        private readonly LoginScreen _loginScreen;

        public MainMenu(AuthService authService, IPostRepository postRepository)
        {
            _authService = authService;
            _registerScreen = new RegisterScreen(authService);
            _loginScreen = new LoginScreen(authService, postRepository);
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Bem-vindo ao Sistema ===");
                Console.WriteLine("1 - Login");
                Console.WriteLine("2 - Cadastro");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha uma opção: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        _loginScreen.Show();
                        break;
                    case "2":
                        _registerScreen.Show();
                        break;
                    case "3":
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
