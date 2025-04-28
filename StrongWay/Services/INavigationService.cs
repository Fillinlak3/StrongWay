namespace StrongWay.Services
{
    public interface INavigationService
    {
        string GetPageRoute(AppPage page);
        Task NavigateToAsync(AppPage page);
        Task NavigateBackAsync();
    }
}
