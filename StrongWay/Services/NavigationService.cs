using StrongWay.Views.Pages;

namespace StrongWay.Services
{
    public class NavigationService : INavigationService
    {
        public string GetPageRoute(AppPage page)
        {
            return page switch
            {
                AppPage.Login => nameof(LoginPage),
                AppPage.Register => nameof(RegisterPage),
                AppPage.Main => nameof(MainPage),
                _ => throw new ArgumentException("Invalid page", nameof(page))
            };
        }

        public async Task NavigateToAsync(AppPage page)
            => await Shell.Current.GoToAsync(GetPageRoute(page));

        public async Task NavigateBackAsync()
            => await Shell.Current.GoToAsync("..");
    }
}
