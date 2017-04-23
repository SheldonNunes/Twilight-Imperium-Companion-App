using System;
using System.Collections.Generic;
using CoreGraphics;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class HexMainMenuView : MvxViewController<HexMainMenuViewModel>, IMvxModalIosView
	{

		HexMenuViewComponent hexMenuView;

		public HexMainMenuView() : base("HexMainMenuView", null)
		{
			ModalPresentationStyle = UIModalPresentationStyle.OverFullScreen;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//blurView.BackgroundColor = UIColor.Blue;

			View.BackgroundColor = UIColor.Clear;
			hexNavigationBar.BarTintColor = UIColor.Clear;
			hexNavigationBar.Translucent = true;
			hexNavigationBar.ShadowImage = new UIImage();
			hexNavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
			navigationItem.SetLeftBarButtonItem(new UIBarButtonItem(
							UIImage.FromBundle("HamburgerIcon"),
				UIBarButtonItemStyle.Plain, null), true);
			
			hexMenuView = new HexMenuViewComponent();
			View.AddSubview(hexMenuView);

			this.AddBindings(new Dictionary<object, string>()
			{
				{ navigationItem.LeftBarButtonItem, "Clicked CloseMenu"}
			});
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			blurView.Effect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Dark);


			//UIView.Animate(0.25, 0, UIViewAnimationOptions.CurveLinear, () => , null);
		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();

			hexMenuView.Frame = new CGRect(0, 0, View.Frame.Width, View.Frame.Height);
			hexMenuView.Center = new CGPoint(View.Frame.GetMidX(), View.Frame.GetMidY());
		}
	}
}

