using ZeusApk.Repositories;
using ZeusApk.Services;
using ZeusApk.UI;

class Program
{
    static void Main()
    {
        var userRepository = new MockUserRepository();
        var postRepository = new MockPostRepository();

        var authService    = new AuthService(userRepository);

        var mainMenu       = new MainMenu(authService, postRepository);
        mainMenu.Show();
    }
}
