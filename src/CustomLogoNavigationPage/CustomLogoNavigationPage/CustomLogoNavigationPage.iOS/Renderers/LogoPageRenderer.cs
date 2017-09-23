using CoreGraphics;
using CustomLogoNavigationPage.iOS.Renderers;
using CustomLogoNavigationPage.Views;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MainView), typeof(LogoPageRenderer))]
namespace CustomLogoNavigationPage.iOS.Renderers
{
    public class LogoPageRenderer : PageRenderer
    {
        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            if (NavigationController != null)
            {
                NavigationController.NavigationBar.Frame = new CGRect(0, 0, this.View.Frame.Size.Width, 72.0);
                NavigationController.NavigationBar.SetTitleVerticalPositionAdjustment(-5, UIBarMetrics.Default);
                var navigationItem = NavigationController.TopViewController.NavigationItem;
                var leftNativeButtons = (navigationItem.LeftBarButtonItems ?? new UIBarButtonItem[] { }).ToList();
                var rightNativeButtons = (navigationItem.RightBarButtonItems ?? new UIBarButtonItem[] { }).ToList();

                leftNativeButtons.ForEach(x => x.ImageInsets = new UIEdgeInsets(-8, 0, 0, 0));
                rightNativeButtons.ForEach(x => x.ImageInsets = new UIEdgeInsets(-8, 0, 0, 0));
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var image = UIImage.FromBundle("xamarin-logo.png");
            var imageView = new UIImageView(new CGRect(0, 0, 140, 70));

            imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            imageView.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);

            if (NavigationController != null)
            {
                NavigationController.TopViewController.NavigationItem.TitleView = imageView;
            }
        }
    }
}