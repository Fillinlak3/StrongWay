using StrongWay.Views.Pages;

namespace StrongWay
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            /*
                Registering routes in cs instead of xaml makes the app faster.
             */
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }
    }
}
