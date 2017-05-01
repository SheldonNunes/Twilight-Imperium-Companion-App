using CoreAnimation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using TwilightImperiumMasterCompanion.Core;
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

			var set = this.CreateBindingSet<SelectStartingOptionView, SelectStartingOptionViewModel>();
			set.Bind(this).For(v => v.Title).To(vm => vm.Title).OneTime();
			set.Bind(shatteredEmpireSwitch).To(vm => vm.ShatteredEmpiresExpansionEnabled).OneWayToSource();
			set.Bind(shardsOfTheThroneSwitch).To(vm => vm.ShardsOfTheThroneExpansionEnabled).OneWayToSource();
			set.Bind(selectRaceButton).To(vm => vm.NavigateToRaceSelectionView);
			set.Apply();

			var gradient = new CAGradientLayer();
			gradient.Frame = rootView.Bounds;
			gradient.Colors = new CoreGraphics.CGColor[] { ColorConstants.BLUE_PRIMARY.CGColor, ColorConstants.BLUE_FADED.CGColor };
			rootView.Layer.InsertSublayer(gradient, 0);

			expansionsView.Layer.BorderWidth = 1;
			expansionsView.Layer.BorderColor = UIColor.White.CGColor;

			selectRaceButton.Layer.BorderWidth = 1;
			selectRaceButton.Layer.BorderColor = UIColor.White.CGColor;
		}
	}
}

