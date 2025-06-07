using ZeusApk.Repositories;

namespace ZeusApk.UI
{
    internal class MyPostsScreen
    {
        private readonly IPostRepository _postRepository;
        private readonly string _userEmail;

        public MyPostsScreen(IPostRepository postRepository, string userEmail)
        {
            _postRepository = postRepository;
            _userEmail = userEmail;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine("=== Meus Posts ===");

            var posts = _postRepository.GetAll()
                .Where(p => p.UserEmail == _userEmail)
                .ToList();

            if (!posts.Any())
            {
                Console.WriteLine("Você ainda não criou nenhum post.");
            }
            else
            {
                foreach (var post in posts)
                {
                    Console.WriteLine("-------------------------------");
                    if (post.InicioQueda != DateTime.MinValue) Console.WriteLine($"Início da Queda: {post.InicioQueda}");
                    Console.WriteLine($"Bairro: {post.Bairro}");
                    Console.WriteLine($"Cidade: {post.Cidade}");
                    Console.WriteLine($"Descrição: {post.Descricao}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }
    }
}
