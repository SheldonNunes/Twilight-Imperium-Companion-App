using System;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
    public class MenuNavigationBar : INavigationBar
    {

		public EventHandler RightBarButtonPressed
		{
			get;
			set;
		}


        public EventHandler LeftBarButtonPressed
        {
            get;
            set;
        }

        public void Initialize(UIViewController viewController)
        {
            viewController.NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem(
                            UIImage.FromBundle("HamburgerIcon"),
                            UIBarButtonItemStyle.Plain,
                LeftBarButtonPressed), false);

            viewController.NavigationItem.SetRightBarButtonItem(new UIBarButtonItem(
                UIBarButtonSystemItem.Add,
                RightBarButtonPressed), false);
        }
    }
}
