using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using TwilightImperiumMasterCompanion.Core;

namespace TwilightImperiumMasterCompanion.iOS
{
    public partial class RaceSelectionView : MvxViewController<RaceSelectionViewModel>
    {
		private string _portraitImageURL;

		public string PortraitImageURL
		{
			get
			{
				return _portraitImageURL; }
			set
			{
				_portraitImageURL = value;
				PortraitImageView.Image = UIImage.FromBundle("Images/Races/Portraits/" +  _portraitImageURL);
			}
		}


        public RaceSelectionView (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			raceCollectionView.RegisterClassForCell(typeof(RaceEmblemCell), RaceEmblemCell.CellId);
			var source = new RaceCollectionSource(raceCollectionView, ViewModel);
			raceCollectionView.Source = source;

			var set = this.CreateBindingSet<RaceSelectionView, RaceSelectionViewModel>();
			set.Bind(source).To(vm => vm.Races);
			set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.RaceSelectionChangedCommand);
			set.Bind().For(s => s.PortraitImageURL).To(vm => vm.SelectedRace.URIName);
			set.Apply();

			raceCollectionView.ReloadData();

			NavigationController.SetNavigationBarHidden(true, true);
		}
    }
}