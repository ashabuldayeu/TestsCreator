using TestsCreator.Utils.UI.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TestsCreator.Utils.UI.Views
{
    public abstract class BaseView : Page
    {
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext is BaseViewModel vm)
            {
                vm.OnNavigatedTo(e.Parameter);
            }
            base.OnNavigatedTo(e);
        }

        protected void GoBack(Frame frame)
        {
            if (frame.CanGoBack)
            {
                frame.GoBack();
            }
            else
            {
                CloseAll(Frame);
            }
        }

        protected void CloseAll(Frame frame)
        {
            frame.Navigate(typeof(EmptyView), null);
            frame.BackStack.Clear();
        }
    }
}
