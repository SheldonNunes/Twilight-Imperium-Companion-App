using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class RaceTabView : TabView<RaceTabViewModel>
	{

		private bool constructed;

		public RaceTabView() : base(3)
		{
			constructed = true;
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
			SelectedViewController = ViewControllers[2];

			var set = this.CreateBindingSet<RaceTabView, RaceTabViewModel>();
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
												 null,//UIImage.FromBundle(bundle),
												 _createdSoFarCount);
			//screen.TabBarItem.Image = screen.TabBarItem.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal);
			_createdSoFarCount++;
		}
	}
}

