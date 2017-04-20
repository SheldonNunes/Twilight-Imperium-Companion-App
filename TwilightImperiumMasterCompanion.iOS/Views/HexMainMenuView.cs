using System;
using CoreGraphics;
using MvvmCross.iOS.Views;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class HexMainMenuView : UIViewController
	{
		HexMenuViewComponent centerHex;
		HexMenuViewComponent raceHex;
		HexMenuViewComponent rulesHex;
		HexMenuViewComponent shipHex;
		HexMenuViewComponent planetHex;
		HexMenuViewComponent galaxyHex;
		HexMenuViewComponent researchHex;

		private int CENTER_HEX_SIZE = 150;
		private int ALT_HEX_SIZE = 120;
		public HexMainMenuView() : base("HexMainMenuView", null)
		{
		}

		UIImageView backgroundHexBase;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			View.BackgroundColor = UIColor.Clear;

			hexNavigationBar.BarTintColor = UIColor.Clear;
			hexNavigationBar.Translucent = true;
			hexNavigationBar.ShadowImage = new UIImage();
			hexNavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
			navigationItem.SetLeftBarButtonItem(new UIBarButtonItem(
							UIImage.FromBundle("HamburgerIcon"),
							UIBarButtonItemStyle.Plain,
							Test), true);

			backgroundHexBase = new UIImageView();
			backgroundHexBase.Image = UIImage.FromBundle("HexagonBase");


			centerHex = new HexMenuViewComponent();
			raceHex = new HexMenuViewComponent();
			rulesHex = new HexMenuViewComponent();
			shipHex = new HexMenuViewComponent();
			planetHex = new HexMenuViewComponent();
			researchHex = new HexMenuViewComponent();
			galaxyHex = new HexMenuViewComponent();

			//centerHex.Frame = new CGRect(50, 50, 100, 100);
			View.AddSubview(backgroundHexBase);
			View.AddSubview(centerHex);
			View.AddSubview(raceHex);
			View.AddSubview(rulesHex);
			View.AddSubview(shipHex);
			View.AddSubview(planetHex);
			View.AddSubview(researchHex);
			View.AddSubview(galaxyHex);


			rulesHex.HexImage = UIImage.FromBundle("RulesIcon");
			raceHex.HexImage = UIImage.FromBundle("RaceIcon");
			shipHex.HexImage = UIImage.FromBundle("ShipIcon");
			planetHex.HexImage = UIImage.FromBundle("PlanetIcon");
			researchHex.HexImage = UIImage.FromBundle("ResearchIcon");
			galaxyHex.HexImage = UIImage.FromBundle("GalaxyMapIcon");

			rulesHex.HexText = "Rules";
			raceHex.HexText = "Race";
			shipHex.HexText = "Units";
			planetHex.HexText = "Planets";
			researchHex.HexText = "Research";
			galaxyHex.HexText = "Galaxy";

		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
			var smallestScreenDimension = Math.Min(View.Frame.Width, View.Frame.Height);
			//backgroundHexBase.Frame = new CGRect(0, 0, 200, 200);
			backgroundHexBase.Frame = new CGRect(0, 0, smallestScreenDimension / 1 + 10, smallestScreenDimension / 1);
			backgroundHexBase.Center = new CGPoint(View.Frame.GetMidX(), View.Frame.GetMidY());

			CENTER_HEX_SIZE = (int)(smallestScreenDimension / 2.5);
			ALT_HEX_SIZE = (int)(smallestScreenDimension / 2.75);

			var centerHexHeight = Math.Sqrt(3) * CENTER_HEX_SIZE / 2;
			var altHexHeight = Math.Sqrt(3) * ALT_HEX_SIZE / 2;

			centerHex.Frame = new CGRect(0, 0, CENTER_HEX_SIZE, CENTER_HEX_SIZE);
			rulesHex.Frame = new CGRect(0, 0, ALT_HEX_SIZE, ALT_HEX_SIZE);
			raceHex.Frame = new CGRect(0, 0, ALT_HEX_SIZE, ALT_HEX_SIZE);
			shipHex.Frame = new CGRect(0, 0, ALT_HEX_SIZE, ALT_HEX_SIZE);
			planetHex.Frame = new CGRect(0, 0, ALT_HEX_SIZE, ALT_HEX_SIZE);
			researchHex.Frame = new CGRect(0, 0, ALT_HEX_SIZE, ALT_HEX_SIZE);
			galaxyHex.Frame = new CGRect(0, 0, ALT_HEX_SIZE, ALT_HEX_SIZE);


			centerHex.Center = new CGPoint(View.Frame.GetMidX(), View.Frame.GetMidY());
			rulesHex.Center = new CGPoint(View.Frame.GetMidX(), View.Frame.GetMidY() + (centerHexHeight + altHexHeight) / 2.0 + 3);
			raceHex.Center = new CGPoint(View.Frame.GetMidX(), View.Frame.GetMidY() - (centerHexHeight + altHexHeight) / 2.0 - 3);
			shipHex.Center = new CGPoint(View.Frame.GetMidX() + Math.Cos(Math.PI / 6) * centerHexHeight / 2 + altHexHeight / 2 - 3, View.Frame.GetMidY() + centerHexHeight * 0.25 + altHexHeight * 0.25);
			planetHex.Center = new CGPoint(View.Frame.GetMidX() + Math.Cos(Math.PI / 6) * centerHexHeight / 2 + altHexHeight / 2 - 3, View.Frame.GetMidY() - centerHexHeight * 0.25 - altHexHeight * 0.25);
			researchHex.Center = new CGPoint(View.Frame.GetMidX() - Math.Cos(Math.PI / 6) * centerHexHeight / 2 - altHexHeight / 2 + 3, View.Frame.GetMidY() + centerHexHeight * 0.25 + altHexHeight * 0.25);
			galaxyHex.Center = new CGPoint(View.Frame.GetMidX() - Math.Cos(Math.PI / 6) * centerHexHeight / 2 - altHexHeight / 2 + 3, View.Frame.GetMidY() - centerHexHeight * 0.25 - altHexHeight * 0.25);


			//var navigation = new MenuNavigationBar();
			//navigation.Initialize(this, (sender, e) => Test());

		}

		public void Test(object sender, EventArgs e)
		{
		}


		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			//unitHexMenuViewComponent = new HexMenuViewComponent(Handle);
			//unitHexMenuViewComponent.Hex = new UIImageView(UIImage.FromBundle("HexagonActive"));
			//unitHexMenuViewComponent.HexLabel = "Hello";
			//unitHexMenuViewComponent.HexImage = UIImage.FromBundle("PlanetIcon");

			UIView.Animate(0.5, 0, UIViewAnimationOptions.CurveEaseInOut, () => blurView.Effect = UIBlurEffect.FromStyle(UIBlurEffectStyle.ExtraDark), null);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

