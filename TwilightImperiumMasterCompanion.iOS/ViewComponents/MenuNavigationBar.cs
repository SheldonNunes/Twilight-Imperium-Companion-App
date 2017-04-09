using System;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class MenuNavigationBar : INavigationBar
	{

		public void Initialize(UIViewController viewController)
		{

			viewController.NavigationController.NavigationBar.TintColor = UIColor.White;

			viewController.NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem(
							UIImage.FromBundle("HamburgerIcon"),
							UIBarButtonItemStyle.Plain,
							(sender, e) => { }), true);
		}
	}
}
