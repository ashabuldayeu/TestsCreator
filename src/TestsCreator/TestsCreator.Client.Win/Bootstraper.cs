using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using TestsCreator.Client.Win.Code.Constants;
using TestsCreator.Client.Win.ViewModels;
using TestsCreator.Client.Win.Views;
using TestsCreator.Utils.UI.Services.Navigation;

namespace TestsCreator.Client.Win
{
    public class Bootstraper
    {
        public Bootstraper()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var nav = new TestCreatorNavigationService();

            nav.Configure(PageNames.AuthPage, typeof(AuthView));
            nav.Configure(PageNames.ShellPage, typeof(ShellView));

            SimpleIoc.Default.Register<INavigationService>(() => nav);

            SimpleIoc.Default.Register<ShellViewModel>();
        }

        public ShellViewModel ShellViewModelInstance => ServiceLocator.Current.GetInstance<ShellViewModel>();
    }
}
