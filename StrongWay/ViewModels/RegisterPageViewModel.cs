using Services.Logging;
using StrongWay.Services;

namespace StrongWay.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public RelayCommand NavigateToLoginPageCommand { get; private set; }

        public RegisterPageViewModel(INavigationService navigationService)
        {
            Logger.Log("RegisterPageViewModel", "Object created.");
            _navigationService = navigationService;

            NavigateToLoginPageCommand = new RelayCommand(NavigateToLoginPage);
        }

        private async void NavigateToLoginPage(object? parameter = null)
        {
            await _navigationService.NavigateToAsync(AppPage.Login);
        }
    }
}
