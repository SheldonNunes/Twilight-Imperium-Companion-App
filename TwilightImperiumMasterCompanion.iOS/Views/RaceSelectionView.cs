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

			var test = new CircularCollectionViewLayout();

			var circleCollection = new UICollectionView(new CGRect(0, 50, 320, 300), new CircularCollectionViewLayout());

			var circle = new RaceSelectionWheel(new CGRect(0, 50, 320, 300));


			var set = this.CreateBindingSet<RaceSelectionView, RaceSelectionViewModel>();
			//set.Bind(source).To(vm => vm.Races).WithConversion(new RaceListConverter());
			//set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.RaceSelectionChangedCommand);
			set.Bind(circleCollection).For(s => s.DataSource).To(vm => vm.Races);
			set.Bind().For(s => s.PortraitImageURL).To(vm => vm.SelectedRace.URIName);
			set.Apply();

			Add(circleCollection);

			NavigationController.SetNavigationBarHidden(true, true);
		}
    }
}