using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusApk.Repositories;
using ZeusApk.Models;

namespace ZeusApk.UI
{
    internal class ExploreScreen
    {
        private readonly IPostRepository _postRepository;
        private readonly string _userEmail;

        public ExploreScreen(IPostRepository postRepository, string userEmail)
        {
            _postRepository = postRepository;
            _userEmail = userEmail;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Explorar Posts ===");

            Console.Write("Filtrar por cidade (pressione ENTER para ignorar): ");
            var cidade = Console.ReadLine()?.Trim();

            Console.Write("Filtrar por bairro (pressione ENTER para ignorar): ");
            var bairro = Console.ReadLine()?.Trim();

            var posts = _postRepository.GetAll()
                .Where(p => p.UserEmail != _userEmail)
                .Where(p =>
                    (string.IsNullOrEmpty(cidade) || (p.Cidade != null && p.Cidade.Equals(cidade, StringComparison.OrdinalIgnoreCase))) &&
                    (string.IsNullOrEmpty(bairro) || (p.Bairro != null && p.Bairro.Equals(bairro, StringComparison.OrdinalIgnoreCase))))
                .ToList();

            Console.WriteLine($"\n=== {posts.Count} Posts Encontrados ===");
            if (!posts.Any())
            {
                Console.WriteLine("Nenhum post encontrado com os filtros aplicados.");
            }
            else
            {
                foreach (var post in posts)
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine($"Usuário: {post.UserEmail}");
                    if (post.InicioQueda != DateTime.MinValue) Console.WriteLine($"Início da Queda: {post.InicioQueda}");
                    Console.WriteLine($"Bairro: {post.Bairro}");
                    Console.WriteLine($"Cidade: {post.Cidade}");
                    Console.WriteLine($"Descrição: {post.Descricao}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}
