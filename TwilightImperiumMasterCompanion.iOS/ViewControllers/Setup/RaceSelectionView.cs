using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
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
			var source = new MvxStandardTableViewSource(tableView, "TitleText Name; ImageUrl Name, Converter=RaceIconImagePath");

			var set = this.CreateBindingSet<RaceSelectionView, RaceSelectionViewModel>();
			tableView.Source = source;
			set.Bind(source).To(vm => vm.Races);
			set.Bind(this).For(v => v.Title).To(vm => vm.Title).OneTime();
            set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.NavigateToConfirmRaceView);
			set.Apply();
		}
	}
}

