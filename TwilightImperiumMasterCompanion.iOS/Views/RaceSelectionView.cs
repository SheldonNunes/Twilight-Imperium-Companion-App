using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using TwilightImperiumMasterCompanion.Core;
using Foundation;
using CoreGraphics;
using System.Linq;

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
				//PortraitImageView.Image = UIImage.FromBundle("Images/Races/Portraits/" +  _portraitImageURL);
			}
		}

		private string _selectYourRaceLabel;

		public string SelectYourRaceLabel
		{
			get
			{
				return _selectYourRaceLabel;
			}
			set
			{
				
				_selectYourRaceLabel = value;
				selectYourRaceLabel.Text = _selectYourRaceLabel;
			}
		}

		public RaceSelectionView(IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			raceCollectionView.CollectionViewLayout = new CircleCollectionLayout(new CGSize(50,50));
			raceCollectionView.RegisterClassForCell(typeof(RaceEmblemCell), RaceEmblemCell.CellId);
			var source = new RaceCollectionSource(raceCollectionView, ViewModel);

			raceCollectionView.Source = source;

			var set = this.CreateBindingSet<RaceSelectionView, RaceSelectionViewModel>();
			set.Bind(source).To(vm => vm.Races);

			set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.RaceSelectionChangedCommand);
			//set.Bind(selectYourRaceLabel).To(vm => vm.SelectedRace.Name).OneWay();
			set.Bind().For(s => s.SelectYourRaceLabel).To(vm => vm.SelectedRace.Name);
			//set.Bind().For(s => s.PortraitImageURL).To(vm => vm.SelectedRace.URIName);
			set.Apply();

			raceCollectionView.ReloadData();

			NavigationController.SetNavigationBarHidden(true, true);
		}

    }
}