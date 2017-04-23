using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views.Presenters;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class ModalSupportIosViewPresenter : MvxModalSupportIosViewPresenter
	{
		private UIViewController currentModalViewController;

		public ModalSupportIosViewPresenter(UIApplicationDelegate appDelegate, UIWindow window) : base(appDelegate, window)
		{
		}

		public override void ChangePresentation(MvxPresentationHint hint)
		{
			base.ChangePresentation(hint);
		}

		public override bool PresentModalViewController(UIViewController viewController, bool animated)
		{
			currentModalViewController = viewController;
			return base.PresentModalViewController(viewController, false);
		}

		public override void Close(IMvxViewModel toClose)
		{
			base.Close(toClose);
		}

		public override void CloseModalViewController()
		{
			bool flag = this.currentModalViewController != null;
			if (flag)
			{
				this.currentModalViewController.DismissModalViewController(false);
				this.currentModalViewController = null;
			}
			else
			{
				base.CloseModalViewController();
			}
		}


	}
}
