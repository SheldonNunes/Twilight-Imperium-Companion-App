using System;
using System.Collections.Generic;
using CoreAnimation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class SelectStartingOptionView : MvxViewController
	{
		public SelectStartingOptionView() : base("SelectStartingOptionView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Title = "Twilight Imperium Companion";

			var gradient = new CAGradientLayer();
			gradient.Frame = rootView.Bounds;
			gradient.Colors = new CoreGraphics.CGColor[] { ColorConstants.BLUE_PRIMARY.CGColor, ColorConstants.BLUE_FADED.CGColor };
			rootView.Layer.InsertSublayer(gradient, 0);

			expansionsView.Layer.BorderWidth = 1;
			expansionsView.Layer.BorderColor = UIColor.White.CGColor;

			selectRaceButton.Layer.BorderWidth = 1;
			selectRaceButton.Layer.BorderColor = UIColor.White.CGColor;

			this.AddBindings(new Dictionary<object, string>()
			{
				{ selectRaceButton, "TouchUpInside NavigateToRaceSelectionView" }
			});
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

