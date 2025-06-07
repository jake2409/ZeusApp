using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ZeusApk.Services;

namespace ZeusApk.UI
{
    internal class RegisterScreen
    {
        private readonly AuthService _authService;

        public RegisterScreen(AuthService authService)
        {
            _authService = authService;
        }

        bool IsValidEmail(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                    throw new Exception("O e-mail não pode estar em branco.");

                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Cadastro ===");

            var email = "";
            while (true)
            {
                Console.Write("Email: ");
                email = Console.ReadLine();

                if (IsValidEmail(email)) break;

                Console.WriteLine("Email inválido. Por favor, insira um email válido.");
            }

            Console.Write("Senha: ");
            var password = Console.ReadLine();

            if (_authService.Register(email, HashPassword(password)))
            {
                Console.WriteLine("Cadastro realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuário já existe!");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
    }
}
