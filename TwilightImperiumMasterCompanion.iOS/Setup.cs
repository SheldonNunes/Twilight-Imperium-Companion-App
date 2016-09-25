using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class Setup : MvxIosSetup
	{
		private MvxApplicationDelegate _applicationDelegate;
		private UIWindow _window;

		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
			: base(applicationDelegate, window)
		{
			_applicationDelegate = applicationDelegate;
			_window = window;
			
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}

		protected override void InitializeIoC()
		{
			base.InitializeIoC();
		}

		protected override IMvxIosViewsContainer CreateIosViewsContainer()
		{
			return new StoryBoardContainer();
		}
	}
}
