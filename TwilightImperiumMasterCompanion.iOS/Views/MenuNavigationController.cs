using Foundation;
using System;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
    public partial class MenuNavigationController : UINavigationController
    {
        public MenuNavigationController (IntPtr handle) : base (handle)
        {
			this.NavigationBar.ClipsToBounds = true;
			this.NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
			this.NavigationBar.ShadowImage = new UIImage();

			UINavigationBar.Appearance.TintColor = ColorConstants.WHITE;
			UINavigationBar.Appearance.SetTitleTextAttributes(
				new UITextAttributes() { TextColor = ColorConstants.WHITE });
        }

		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
		{
			return UIInterfaceOrientationMask.Portrait;
		}
    }
}