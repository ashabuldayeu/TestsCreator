using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace TestsCreator.Utils.UI.ViewModels
{
    public abstract class BaseViewModel : ViewModelBase
    {
        protected readonly INavigationService _navigationService;

        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        protected internal virtual void OnNavigatedTo(object parameter)
        {
            // empty by default
        }
    }
}
