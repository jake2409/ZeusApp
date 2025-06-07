using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusApk.Models;
using ZeusApk.Repositories;

namespace ZeusApk.UI
{
    internal class PostScreen
    {
        private readonly IPostRepository _postRepository;
        private readonly string _userEmail;

        public PostScreen(IPostRepository postRepository, string userEmail)
        {
            _postRepository = postRepository;
            _userEmail = userEmail;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Criar Novo Post ===");

            Console.Write("Horário de início da queda (ex: 2025-05-30 14:00): ");
            DateTime inicio;
            while (!DateTime.TryParse(Console.ReadLine(), out inicio))
            {
                Console.Write("Data inválida. Tente novamente: ");
            }

            Console.Write("Bairro: ");
            var bairro = Console.ReadLine();

            Console.Write("Cidade: ");
            var cidade = Console.ReadLine();

            Console.Write("Descrição do ocorrido: ");
            var descricao = Console.ReadLine();

            var post = new Post
            {
                UserEmail = _userEmail,
                InicioQueda = inicio,
                Bairro = bairro,
                Cidade = cidade,
                Descricao = descricao
            };

            _postRepository.Add(post);
            Console.WriteLine("✅ Post cadastrado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}
