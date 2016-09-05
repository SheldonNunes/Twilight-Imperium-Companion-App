using Foundation;
using System;
using UIKit;
using SpriteKit;
using System.Drawing;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class MainMenuBackgroundViewController : UIViewController
	{
		public MainMenuBackgroundViewController(IntPtr handle) : base(handle)
		{
		}

		public override void LoadView()
		{
			var skView = new SKView();
			this.View = skView;
			base.LoadView();
		}

		public override void ViewDidLoad()
		{
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