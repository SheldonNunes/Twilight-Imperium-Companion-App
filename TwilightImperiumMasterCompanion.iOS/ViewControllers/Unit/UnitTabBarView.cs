using System;
using System.Collections.Generic;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Platform;
using TwilightImperiumMasterCompanion.Core;
using TwilightImperiumMasterCompanion.Core.Helpers;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
    [MvxRootPresentation]
	public partial class UnitTabBarView : MvxTabBarViewController<UnitTabBarViewModel>
	{
		private bool isPresentedFirstTime = true;
		private INavigationBar navigationBar;

		public UnitTabBarView()
		{
			navigationBar = Mvx.Resolve<INavigationBar>();
		}

		protected override void SetTitleAndTabBarItem(UIViewController viewController, string title, string iconName)
		{
			title = viewController.Title;
            iconName = IconImageNameBuilder.IconImageNameForString(title);
			base.SetTitleAndTabBarItem(viewController, title, iconName);
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			if (ViewModel != null && isPresentedFirstTime)
			{
				isPresentedFirstTime = false;
				ViewModel.ShowInitialViewModelsCommand.Execute(null);
			}

		}
	}
}

