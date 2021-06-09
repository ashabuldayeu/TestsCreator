using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Concurrent;
using System.Linq;
using TestsCreator.Utils.UI.Services.Navigation.Attributes;
using Windows.UI.Xaml.Controls;

namespace TestsCreator.Utils.UI.Services.Navigation
{
    public class TestCreatorNavigationService : NavigationService, INavigationService
    {
        private readonly ConcurrentDictionary<string, Type> _pageTypeName = new ConcurrentDictionary<string, Type>();
        public override void NavigateTo(string pageKey, object parameter)
        {
            var presentationFrame = DetermineFrame(_pageTypeName[pageKey]);

            CurrentFrame = presentationFrame;

            base.NavigateTo(pageKey, parameter);
        }
        public new void Configure(string key, Type pageType)
        {
            _pageTypeName.TryAdd(key, pageType);
            base.Configure(key, pageType);
        }

        private static Frame DetermineFrame(Type type)
        {
            var attribute = type.GetCustomAttributes(false).FirstOrDefault(t => t is PresentationFrameAttribute) as PresentationFrameAttribute;

            return attribute is null
                ? FramesPool.GetDefaultFrame()
                : FramesPool.GetFrame(attribute.FrameName);
        }

    }
}
