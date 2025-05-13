using StrongWay.Services;
using StrongWay.Views.Pages;

namespace StrongWay
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

#if NET9_0
            // <protected override Window CreateWindow> for initializing.
#else
            MainPage = new AppShell();
#endif
        }

#if NET9_0
        /*
            For NET 9 this is the new way of initializing the MainPage as a new AppShell.
            Removes the obsolete warning.
         */
        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());
            return window;
        }
#endif

        protected override async void OnStart()
        {
            base.OnStart();

            /*
                Navigating from blank startup page to main page that is needed.
                 - The navigation is made here because needs to wait for Dependency Injection
                to be fully loaded in AppShell, so it needs to navigate OnStart when everything
                is prepared.
             */
            await Shell.Current.GoToAsync(nameof(MainPage));
        }
    }
}
