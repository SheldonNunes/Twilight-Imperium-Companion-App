using System;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class MenuNavigationBar : INavigationBar
	{
		public EventHandler LeftBarButtonPressed
		{
			get;
			set;
		}

		public void Initialize(UIViewController viewController, EventHandler leftBarButtonPressed)
		{
			LeftBarButtonPressed = leftBarButtonPressed;
			viewController.NavigationController.NavigationBar.TintColor = UIColor.White;
			viewController.NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem(
							UIImage.FromBundle("HamburgerIcon"),
							UIBarButtonItemStyle.Plain,
							LeftBarButtonPressed), true);
		}

	}
}
