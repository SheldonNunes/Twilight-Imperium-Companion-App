using System.Collections.Generic;
using CoreAnimation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class ConfirmRaceView : MvxViewController<ConfirmRaceViewModel>
	{
		public ConfirmRaceView() : base("ConfirmRaceView", null)
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

			var set = this.CreateBindingSet<ConfirmRaceView, ConfirmRaceViewModel>();
			set.Bind(this).For(v => v.Title).To(vm => vm.Title).OneTime();
			set.Bind(confirmSelectionButton).To(vm => vm.NavigateToRaceView);
			set.Bind(raceNameLabel).For(v => v.Text).To(vm => vm.SelectedRace.Name);
			set.Bind(abilitiesTextView).For(v => v.Text).To(vm => vm.RaceAbilities).WithConversion(new RaceAbilityConverter());
			set.Bind(raceIcon).To(vm => vm.SelectedRace.Name).WithConversion("RaceIconImagePath");
			set.Apply();
		}
	}
}

