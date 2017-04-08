using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using TwilightImperiumMasterCompanion.Core;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.iOS
{
	[MvxFromStoryboard(StoryboardName = "UnitReference")]
	public partial class UnitTabBarController : MvxTabBarViewController<UnitTabBarViewModel>
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

		public UnitTabBarController(IntPtr handle) : base(handle)
		{
			
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



			NavigationController.NavigationBar.TintColor = UIColor.White;

			NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem(
				UIImage.FromBundle("HamburgerIcon"),
				UIBarButtonItemStyle.Plain,
				(sender, e) => { }), true);

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
