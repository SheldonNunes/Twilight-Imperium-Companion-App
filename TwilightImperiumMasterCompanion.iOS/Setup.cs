using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class Setup : MvxIosSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
			: base(applicationDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}

		protected override void InitializeIoC()
		{
			base.InitializeIoC();

			Mvx.RegisterType<INavigationBar, MenuNavigationBar>();
		}

	}
}
