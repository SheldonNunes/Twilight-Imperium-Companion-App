﻿using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class UnitTabBarView : MvxTabBarViewController<UnitTabBarViewModel>
	{
		public override UIViewController SelectedViewController
		{
			get
			{
				return base.SelectedViewController;
			}
			set
			{
				base.SelectedViewController = value;
				this.Title = value.Title;
			}
		}

		private readonly INavigationBar navigationBar;

		public UnitTabBarView() : base()
		{
			navigationBar = Mvx.Resolve<INavigationBar>();
            ViewDidLoad();


		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			if (ViewModel == null)
				return;
			

			var viewControllers = new UIViewController[]
								  {
										CreateTab("Unit Reference", "UnitReferenceTabIcon", ViewModel.UnitReferenceViewModel),
										CreateTab("Purchase", "PurchaseTabIcon", ViewModel.PurchaseUnitViewModel),
								  };
			ViewControllers = viewControllers;
			CustomizableViewControllers = new UIViewController[] { };
			SelectedViewController = ViewControllers[0];
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			navigationBar.Initialize(this);
		}

		private int _createdSoFarCount = 0;

		private UIViewController CreateTab(string title, string bundle, IMvxViewModel viewModel)
		{
			var screen = this.CreateViewControllerFor(viewModel) as UIViewController;
			SetTitleAndTabBarItem(screen, title, bundle);
			return screen;
		}

		private void SetTitleAndTabBarItem(UIViewController screen, string title, string bundle)
		{
			screen.Title = title;
			screen.TabBarItem = new UITabBarItem(title,
												 UIImage.FromBundle(bundle),
												 _createdSoFarCount);
			screen.TabBarItem.Image = screen.TabBarItem.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
			_createdSoFarCount++;
		}
	}
}
