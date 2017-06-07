using System;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using TwilightImperiumMasterCompanion.Core;

namespace TwilightImperiumMasterCompanion.iOS.ViewControllers.Race
{
    [MvxTabPresentation(WrapInNavigationController = true)]
    public class RaceLeadersPageView : MvxPageViewController<RaceLeadersPageViewModel>
    {
        public RaceLeadersPageView() : base()
        {
            this.Title = RaceLeadersPageViewModel.Title;

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.View.BackgroundColor = ColorConstants.WHITE;
        }

    }
}
