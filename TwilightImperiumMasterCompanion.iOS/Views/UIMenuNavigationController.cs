using Foundation;
using System;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class UIMenuNavigationController : UINavigationController
	{
		public UIMenuNavigationController() : base()
		{

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Title = "hello";
			//NavigationItem.SetRightBarButtonItem(new UIBarButtonItem(
			//	UIImage.FromBundle("HamburgerIcon"),
			//	UIBarButtonItemStyle.Plain,
			//	(sender, e) => { }), true);

			this.NavigationItem.SetRightBarButtonItem(
	new UIBarButtonItem(UIBarButtonSystemItem.Action, (sender, args) =>
	{
		// button was clicked
	})
, true);
		}
	}
}