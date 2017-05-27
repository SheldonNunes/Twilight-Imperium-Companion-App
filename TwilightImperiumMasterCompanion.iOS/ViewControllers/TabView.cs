using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class TabView<T> : MvxTabBarViewController<T> where T : MvxViewModel
	{
		private readonly int numberOfTabs;
		private readonly INavigationBar navigationBar;
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

		public TabView(int numberOfTabs)
		{
			navigationBar = Mvx.Resolve<INavigationBar>();
			this.numberOfTabs = numberOfTabs;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			navigationBar.Initialize(this);
			//var screenWidth = UIScreen.MainScreen.Bounds.Width;
			//var result = UIImageExtensions.CreateImageWithColor(UIColor.FromRGB(255, 172, 56), new CoreGraphics.CGSize(screenWidth / numberOfTabs, 49));
			//UITabBar.Appearance.SelectionIndicatorImage = (result);
		}
	}
}
