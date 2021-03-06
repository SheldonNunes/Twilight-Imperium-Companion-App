﻿using CoreAnimation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
    [MvxRootPresentation(WrapInNavigationController = true)]
	public partial class SelectStartingOptionView : MvxViewController
	{
		public SelectStartingOptionView() : base("SelectStartingOptionView", null)
		{
		}
        private CAGradientLayer gradient;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var set = this.CreateBindingSet<SelectStartingOptionView, SelectStartingOptionViewModel>();
			set.Bind(this).For(v => v.Title).To(vm => vm.Title).OneTime();
			set.Bind(shatteredEmpireSwitch).To(vm => vm.ShatteredEmpiresExpansionEnabled).OneWayToSource();
			set.Bind(shardsOfTheThroneSwitch).To(vm => vm.ShardsOfTheThroneExpansionEnabled).OneWayToSource();
			set.Bind(selectRaceButton).To(vm => vm.NavigateToRaceSelectionView);
			set.Apply();

			expansionsView.Layer.BorderWidth = 1;
			expansionsView.Layer.BorderColor = UIColor.White.CGColor;

			selectRaceButton.Layer.BorderWidth = 1;
			selectRaceButton.Layer.BorderColor = UIColor.White.CGColor;

            gradient = new CAGradientLayer();
            rootView.Layer.InsertSublayer(gradient, 0);
		}

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            		
            gradient.Frame = rootView.Bounds;
			gradient.Colors = new CoreGraphics.CGColor[] { ColorConstants.BLUE_PRIMARY.CGColor, ColorConstants.BLUE_FADED.CGColor };
			
        }
	}
}

