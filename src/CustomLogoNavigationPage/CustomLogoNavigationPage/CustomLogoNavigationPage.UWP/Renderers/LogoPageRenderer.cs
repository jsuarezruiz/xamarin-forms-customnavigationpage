using CustomLogoNavigationPage.UWP.Renderers;
using CustomLogoNavigationPage.Views;
using System;
using System.Reflection;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(LogoPageRenderer))]
namespace CustomLogoNavigationPage.UWP.Renderers
{
    public class LogoPageRenderer : NavigationPageRenderer
    {
        private CommandBar _commandBar;

        public LogoPageRenderer()
        {
            ElementChanged += OnElementChanged;
        }

        private void OnElementChanged(object sender, VisualElementChangedEventArgs e)
        {
            ElementChanged -= OnElementChanged;
            ContainerElement.Loaded += OnContainerElementLoaded;
        }

        private void OnContainerElementLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ContainerElement.Loaded -= OnContainerElementLoaded;
            _commandBar = typeof(PageControl).GetTypeInfo().GetDeclaredField("_commandBar").GetValue(ContainerElement) as CommandBar;
            var commandBarContent = ((Border)_commandBar.Content);

            var image = new Windows.UI.Xaml.Controls.Image();
            image.Source = new BitmapImage(new Uri("ms-appx:///Assets/xamarin-logo.png"));

            commandBarContent.Child = image;
        }
    }
}