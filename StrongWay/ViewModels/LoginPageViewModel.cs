using Services.Logging;
using StrongWay.Services;

namespace StrongWay.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public RelayCommand NavigateToRegisterPageCommand { get; private set; }

        public LoginPageViewModel(INavigationService navigationService)
        {
            Logger.Log("LoginPageViewModel", "Object created.");
            _navigationService = navigationService;

            NavigateToRegisterPageCommand = new RelayCommand(NavigateToRegisterPage);
        }

        private async void NavigateToRegisterPage(object? parameter = null)
            => await _navigationService.NavigateToAsync(AppPage.Register);
    }
}
