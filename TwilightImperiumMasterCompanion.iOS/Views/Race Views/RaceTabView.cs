using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class RaceTabView : MvxTabBarViewController<RaceTabViewModel>
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

		public RaceTabView()
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
										CreateTab("Overview", "RaceOverviewTabIcon", ViewModel.RaceOverviewViewModel),
										CreateTab("Leaders", "RaceLeadersTabIcon", ViewModel.RaceLeadersViewModel),
										CreateTab("Setup", "RaceSetupTabIcon", ViewModel.RaceSetupViewModel),
								  };
			ViewControllers = viewControllers;
			CustomizableViewControllers = new UIViewController[] { };
			SelectedViewController = ViewControllers[0];

		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			//navigationBar.Initialize(this, (sender, e) => Test());

			//var set = this.CreateBindingSet<RaceTabView, RaceTabViewModel>();
			//set.Bind(NavigationItem.LeftBarButtonItem)
			//   .To(vm => vm.ShowHexMainMenu);
			//set.Apply();
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

