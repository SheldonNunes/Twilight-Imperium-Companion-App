using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using TwilightImperiumMasterCompanion.Core;
using Foundation;
using CoreGraphics;

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
			var source = new RaceCollectionSource(raceCollectionView, ViewModel);

			var circle = new RaceSelectionWheel(new CGRect(0, 50, 300, 300));


			var set = this.CreateBindingSet<RaceSelectionView, RaceSelectionViewModel>();
			//set.Bind(source).To(vm => vm.Races).WithConversion(new RaceListConverter());
			set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.RaceSelectionChangedCommand);
			set.Bind(circle).For(s => s.DataSource).To(vm => vm.Races);
			set.Bind().For(s => s.PortraitImageURL).To(vm => vm.SelectedRace.URIName);
			set.Apply();

			Add(circle);

			raceCollectionView.ReloadData();
			raceCollectionView.ContentInset = new UIEdgeInsets(0, 500, 0, 500);
			NavigationController.SetNavigationBarHidden(true, true);
		}
    }
}