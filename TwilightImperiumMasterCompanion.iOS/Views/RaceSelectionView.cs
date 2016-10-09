using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using TwilightImperiumMasterCompanion.Core;
using System.Drawing;
using MvvmCross.Binding.iOS.Views;

namespace TwilightImperiumMasterCompanion.iOS
{
    public partial class RaceSelectionView : MvxViewController<RaceSelectionViewModel>
    {
		private MvxImageViewLoader _imageLoader;

        public RaceSelectionView (IntPtr handle) : base (handle)
        {
        }

		public sealed override void ViewDidLoad()
		{
			base.ViewDidLoad();

			raceCollectionView.RegisterClassForCell(typeof(RaceEmblemCell), RaceEmblemCell.CellId);
			var source = new RaceCollectionSource(raceCollectionView, ViewModel);
			raceCollectionView.Source = source;

			var set = this.CreateBindingSet<RaceSelectionView, RaceSelectionViewModel>();
			set.Bind(source).To(vm => vm.Races);
			set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.RaceSelectionChangedCommand);
			set.Apply();

			raceCollectionView.ReloadData();

			NavigationController.SetNavigationBarHidden(true, true);
		}
    }
}