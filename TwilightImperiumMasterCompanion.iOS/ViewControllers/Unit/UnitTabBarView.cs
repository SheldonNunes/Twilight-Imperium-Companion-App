using System;
using System.Collections.Generic;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Platform;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
    [MvxRootPresentation]
	public partial class UnitTabBarView : TabView<UnitTabBarViewModel>
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
		private bool constructed;

		public UnitTabBarView() : base(2)
		{
			constructed = true;
			navigationBar = Mvx.Resolve<INavigationBar>();
			ViewDidLoad();
		}

		sealed public override void ViewDidLoad()
		{
			if (!constructed)
				return;
			base.ViewDidLoad();

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

			var set = this.CreateBindingSet<UnitTabBarView, UnitTabBarViewModel>();
			set.Bind(NavigationItem.LeftBarButtonItem)
			   .To(vm => vm.ShowHexMainMenu);
			set.Apply();
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

