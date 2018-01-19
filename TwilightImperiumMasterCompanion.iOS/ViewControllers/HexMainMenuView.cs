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
    [MvxModalPresentation(WrapInNavigationController = true, ModalPresentationStyle = UIModalPresentationStyle.OverFullScreen, ModalTransitionStyle = UIModalTransitionStyle.CrossDissolve)]
	public partial class HexMainMenuView : MvxViewController<HexMainMenuViewModel>
	{

		HexMenuViewComponent hexMenuView;

		public HexMainMenuView() : base("HexMainMenuView", null)
		{

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

            var navigationBar = NavigationController.NavigationBar;
            navigationBar.BarTintColor = UIColor.Clear;
			navigationBar.Translucent = true;
			navigationBar.ShadowImage = new UIImage();
			navigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);

            NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem(
							UIImage.FromBundle("HamburgerIcon"),
				UIBarButtonItemStyle.Plain, null), true);

			hexMenuView = new HexMenuViewComponent();
			View.AddSubview(hexMenuView);

			var set = this.CreateBindingSet<HexMainMenuView, HexMainMenuViewModel>();

            this.AddBindings(new Dictionary<object, string>()
            {
                { NavigationItem.LeftBarButtonItem, "Clicked CloseMenu"},
                { hexMenuView.Hexes[MenuPageType.Race], "TouchUpInside NavigateToRaceView" },
                { hexMenuView.Hexes[MenuPageType.Ship], "TouchUpInside NavigateToUnitView" },
                { hexMenuView.Hexes[MenuPageType.Rules], "TouchUpInside NavigateToRulesView" },
                { hexMenuView.Hexes[MenuPageType.Planet], "TouchUpInside NavigateToPlanetsView" },
				{ this, "ActiveMenu SelectedMenu"}
            });
		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();

			hexMenuView.Frame = new CGRect(0, 0, View.Frame.Width, View.Frame.Height);
			hexMenuView.Center = new CGPoint(View.Frame.GetMidX(), View.Frame.GetMidY());
		}
	}
}

