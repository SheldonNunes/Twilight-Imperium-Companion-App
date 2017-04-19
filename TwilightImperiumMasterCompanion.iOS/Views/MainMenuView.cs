using System;
using MvvmCross.iOS.Views;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class MainMenuView : UIViewController
	{
		//UIVisualEffectView blurView;

		public MainMenuView() : base("MainMenuView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.View.BackgroundColor = UIColor.Clear;
			menuView.Frame = UIScreen.MainScreen.Bounds;


			//blurView = new UIVisualEffectView();
			//blurView.Frame = UIScreen.MainScreen.Bounds;

            //this.View.AddSubview(blurView);
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			UIView.Animate(0.5, 0, UIViewAnimationOptions.CurveEaseInOut, () => blurView.Effect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Dark), null);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

