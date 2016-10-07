using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using TwilightImperiumMasterCompanion.Core;
using System.Drawing;

namespace TwilightImperiumMasterCompanion.iOS
{
    public partial class RaceSelectionView : MvxViewController<RaceSelectionViewModel>
    {
        public RaceSelectionView (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var source = new BaseCollectionSource(raceCollectionView);
			raceCollectionView.RegisterClassForCell(typeof(RaceEmblemCell), RaceEmblemCell.CellId);
			raceCollectionView.Source = source;

			var set = this.CreateBindingSet<RaceSelectionView, RaceSelectionViewModel>();
			//set.Bind(test.Name).To(vm => vm.SelectedRace).TwoWay();
			set.Bind(source).To(vm => vm.Races);
			set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.RaceSelectionChangedCommand);
			set.Apply();

			NavigationController.SetNavigationBarHidden(true, true);
		}
    }
}