using GalaSoft.MvvmLight.Views;
using TestsCreator.Client.Win.Code.Constants;
using TestsCreator.Utils.UI.ViewModels;

namespace TestsCreator.Client.Win.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        public ShellViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        protected override void OnNavigatedTo(object parameter)
        {
            base.OnNavigatedTo(parameter);
            // If not authenticated - navigate to Auth
            if (!IsUserLoggedIn())
            {
                _navigationService.NavigateTo(PageNames.AuthPage, null);
            }
        }

        private bool IsUserLoggedIn()
        {
            // Currently all requests - unathorized
            return false;
        }
    }
}
