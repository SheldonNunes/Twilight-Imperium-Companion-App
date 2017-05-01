using System;
using System.Collections.Generic;
using System.Windows.Input;
using CoreAnimation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class RaceSelectionView : MvxViewController<RaceSelectionViewModel>
	{
		public RaceSelectionView() : base("RaceSelectionView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Title = "Race Selection";

			var gradient = new CAGradientLayer();
			gradient.Frame = rootView.Bounds;
			gradient.Colors = new CoreGraphics.CGColor[] { ColorConstants.BLUE_PRIMARY.CGColor, ColorConstants.BLUE_FADED.CGColor };
			rootView.Layer.InsertSublayer(gradient, 0);

			abilitiesView.Layer.BorderWidth = 1;
			abilitiesView.Layer.BorderColor = UIColor.White.CGColor;

			confirmSelectionButton.Layer.BorderWidth = 1;
			confirmSelectionButton.Layer.BorderColor = UIColor.White.CGColor;

			this.AddBindings(new Dictionary<object, string>()
			{
				{ confirmSelectionButton, "TouchUpInside NavigateToRaceView" }
			});
			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

