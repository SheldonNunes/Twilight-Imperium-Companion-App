using Foundation;
using System;
using UIKit;
using MvvmCross;
using MvvmCross.iOS.Views;
using TwilightImperiumMasterCompanion.Core;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class MainView : UINavigationController
    {
        public MainView (IntPtr handle) : base (handle)
        {
			this.NavigationBar.ClipsToBounds = true;
			this.NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
			this.NavigationBar.ShadowImage = new UIImage();

			UINavigationBar.Appearance.TintColor = ColorConstants.WHITE;
			UINavigationBar.Appearance.SetTitleTextAttributes(
				new UITextAttributes() { TextColor = ColorConstants.WHITE });
        }
    }
}