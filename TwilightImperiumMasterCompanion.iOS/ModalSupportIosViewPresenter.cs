using System;
using System.Collections.Generic;
using System.Linq;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views.Presenters;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class ModalSupportIosViewPresenter : MvxModalSupportIosViewPresenter
	{
		private Stack<UIViewController> modalViewControllerStack;

		public ModalSupportIosViewPresenter(UIApplicationDelegate appDelegate, UIWindow window) : base(appDelegate, window)
		{
			modalViewControllerStack = new Stack<UIViewController>();
		}

		public override void ChangePresentation(MvxPresentationHint hint)
		{
			base.ChangePresentation(hint);
		}

		public override bool PresentModalViewController(UIViewController viewController, bool animated)
		{
			modalViewControllerStack.Push(viewController);
			return base.PresentModalViewController(viewController, false);
		}

		public override void Show(MvvmCross.iOS.Views.IMvxIosView view)
		{
			var request = view.Request;
			if (request.PresentationValues != null)
			{
				if (request.PresentationValues.ContainsKey("AnimateNavigation") && request.PresentationValues["AnimateNavigation"] == "true")
					MasterNavigationController.PushViewController(view as UIViewController, false);
			}
			else
			{
				base.Show(view);
			}
		}

		public override void CloseModalViewController()
		{
			var currentModalViewController = modalViewControllerStack.Pop();
			currentModalViewController.DismissModalViewController(false);
		}


		public override void Close(IMvxViewModel toClose)
		{
			if (modalViewControllerStack.Any())
			{
				CloseModalViewController();

				return;
			}
			base.Close(toClose);
		}
	}
}
