using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeusApk.Models;
using ZeusApk.Repositories;

namespace ZeusApk.UI
{
    internal class PostCompanyScreen
    {
        private readonly IPostRepository _postRepository;
        private readonly string _userEmail;

        public PostCompanyScreen(IPostRepository postRepository, string userEmail)
        {
            _postRepository = postRepository;
            _userEmail      = userEmail;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Criar Novo Post ===");
            Console.WriteLine("Local para criar um comunicado respectivo a uma comunidade.");
            Console.Write("Bairro: ");
            var bairro = Console.ReadLine();

            Console.Write("Cidade: ");
            var cidade = Console.ReadLine();

            Console.Write("Descrição do comunicado: ");
            var descricao = Console.ReadLine();

            var post = new Post
            {
                UserEmail = _userEmail,
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
