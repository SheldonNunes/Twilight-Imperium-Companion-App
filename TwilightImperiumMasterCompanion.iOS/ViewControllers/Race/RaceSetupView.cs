using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using TwilightImperiumMasterCompanion.Core;
using TwilightImperiumMasterCompanion.iOS.Controls;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
    public partial class RaceSetupView : MvxViewController<RaceSetupViewModel>
    {
        
        public RaceSetupView() : base("RaceSetupView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            startingPlanetsCollectionView.RegisterNibForCell(PlanetCollectionViewCell.Nib, PlanetCollectionViewCell.CellIdentifier);
            var source = new MvxCollectionViewSource(startingPlanetsCollectionView, PlanetCollectionViewCell.CellIdentifier);
            startingPlanetsCollectionView.Source = source;
            startingPlanetsCollectionView.ReloadData();


            var set = this.CreateBindingSet<RaceSetupView, RaceSetupViewModel>();
            set.Bind(source).For(v => v.ItemsSource).To(vm => vm.StartingPlanets);
			set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

