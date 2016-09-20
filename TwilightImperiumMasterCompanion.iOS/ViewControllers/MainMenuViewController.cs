using Foundation;
using System;
using UIKit;
using SpriteKit;
using System.Drawing;
using CoreAnimation;
using CoreGraphics;

namespace TwilightImperiumMasterCompanion.iOS
{
    public partial class MainMenuViewController : UIViewController
    {
        public MainMenuViewController (IntPtr handle) : base (handle)
        {
        }


		public override void LoadView()
		{
			var skView = new SKView();
			this.View = skView;
			base.LoadView();
		}

		public override void ViewWillAppear(bool animated)
		{
			NavigationController.SetNavigationBarHidden(true, false);
			base.ViewWillAppear(animated);
		}

		public override void ViewWillDisappear(bool animated)
		{
			NavigationController.SetNavigationBarHidden(false, false);
			base.ViewWillDisappear(animated);
		}

		public override void ViewDidLoad()
		{
			UIColor gradientColor = ColorConstants.TWILIGHT_IMPERIUM_BLUE;
			UIColor gradientColor2 = UIColor.FromRGBA(46, 92, 133, 0);

			var gradient = new CAGradientLayer();
			gradient.Frame = gradientBackground.Bounds;
			gradient.NeedsDisplayOnBoundsChange = true;
			gradient.MasksToBounds = true;
			gradient.Colors = new CGColor[] { gradientColor.CGColor, gradientColor.CGColor, gradientColor2.CGColor };
			gradientBackground.Layer.InsertSublayer(gradient, 0);

			joinGameButton.ShowsTouchWhenHighlighted = false;
			base.ViewDidLoad();
		}

		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();
			var scene = new StarScene((SizeF)starScene.Bounds.Size);
			starScene.PresentScene(scene);
			starScene.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0);
		}
    }
}