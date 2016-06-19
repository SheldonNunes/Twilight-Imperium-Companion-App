using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using CoreGraphics;

namespace TwilightImperiumMasterCompanion.iOS
{
	partial class MainMenuController : UIViewController
	{
		public MainMenuController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

		}
			
		public override void ViewWillAppear (bool animated)
		{
			NavigationController.SetNavigationBarHidden (true, false);
			AddShadowAroundUIView (ContentView);
			base.ViewWillAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			NavigationController.SetNavigationBarHidden (false, true);
			base.ViewWillDisappear (animated);

		}

		private void AddShadowAroundUIView(UIView uiView){
			uiView.Layer.ShadowColor = UIColor.Black.CGColor;
			uiView.Layer.ShadowOpacity = 0.6f;
			uiView.Layer.ShadowRadius = 6.0f;
			uiView.Layer.ShadowOffset = new System.Drawing.SizeF(1f, 3f);
			uiView.Layer.MasksToBounds = false;

		}
	}
}
