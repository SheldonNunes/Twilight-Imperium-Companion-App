using System;
using System.Collections.Generic;
using CoreGraphics;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
    [MvxModalPresentation(ModalPresentationStyle = UIModalPresentationStyle.OverFullScreen, ModalTransitionStyle = UIModalTransitionStyle.CrossDissolve)]
	public partial class HexMainMenuView : MvxViewController<HexMainMenuViewModel>
	{

		HexMenuViewComponent hexMenuView;

		public HexMainMenuView() : base("HexMainMenuView", null)
		{
			ModalPresentationStyle = UIModalPresentationStyle.OverFullScreen;
		}

		private MenuPageType activeMenu;
		public MenuPageType ActiveMenu
		{
			get { return activeMenu; }
			set
			{
				activeMenu = value;
				hexMenuView.Hexes[activeMenu].Selected = true;
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
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

			var set = this.CreateBindingSet<HexMainMenuView, HexMainMenuViewModel>();
			set.Bind(NavigationItem.LeftBarButtonItem)
			   .To(vm => vm.CloseMenu);
			//set.Bind(this).For(ActiveMenu).To(vm => vm.SelectedMenu)
			set.Apply();

			this.AddBindings(new Dictionary<object, string>()
			{
				{ hexMenuView.Hexes[MenuPageType.Race], "TouchUpInside NavigateToRaceView" },
				{ hexMenuView.Hexes[MenuPageType.Ship], "TouchUpInside NavigateToUnitView" },
				{ this, "ActiveMenu SelectedMenu"}
			});

			blurView.Effect = UIBlurEffect.FromStyle(UIBlurEffectStyle.Dark);
			//blurView.Alpha = 0;
			//hexMenuView.Alpha = 0;
		}

		//public override void ViewDidAppear(bool animated)
		//{
		//	base.ViewDidAppear(animated);
		//	UIView.Animate(0.25, 0, UIViewAnimationOptions.CurveEaseInOut, () => blurView.Alpha = 1, null);
		//	UIView.Animate(0.25, 0, UIViewAnimationOptions.CurveEaseInOut, () => hexMenuView.Alpha = 1, null);
		//}

		//public override void ViewWillDisappear(bool animated)
		//{
		//	UIView.AnimateAsync(5, () => blurView.Alpha = 0);
		//	UIView.Animate(0.25, 0, UIViewAnimationOptions.CurveEaseInOut, () => hexMenuView.Alpha = 0, null);
		//	base.ViewWillDisappear(animated);
		//}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();

			hexMenuView.Frame = new CGRect(0, 0, View.Frame.Width, View.Frame.Height);
			hexMenuView.Center = new CGPoint(View.Frame.GetMidX(), View.Frame.GetMidY());
		}
	}
}

