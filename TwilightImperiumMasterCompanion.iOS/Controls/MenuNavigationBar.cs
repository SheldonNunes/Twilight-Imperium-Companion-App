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

        public void Initialize(UIViewController viewController)
        {
            viewController.NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem(
                            UIImage.FromBundle("HamburgerIcon"),
                            UIBarButtonItemStyle.Plain,
                LeftBarButtonPressed), false);
        }
    }
}
