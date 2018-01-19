﻿using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Platform;
using TwilightImperiumMasterCompanion.Core;
using TwilightImperiumMasterCompanion.iOS.Controls;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
    [MvxTabPresentation(WrapInNavigationController = true)]
    public partial class RaceSetupView : MvxViewController<RaceSetupViewModel>
    {
        private readonly INavigationBar navigationBar;

        public RaceSetupView() : base("RaceSetupView", null)
        {
            this.Title = RaceSetupViewModel.Title;
            navigationBar = Mvx.Resolve<INavigationBar>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
           
            startingPlanetsCollectionView.RegisterNibForCell(PlanetCollectionViewCell.Nib, PlanetCollectionViewCell.CellIdentifier);
            var source = new MvxCollectionViewSource(startingPlanetsCollectionView, PlanetCollectionViewCell.CellIdentifier);
            startingPlanetsCollectionView.Source = source;

            startingUnitsCollectionView.RegisterNibForCell(PlanetCollectionViewCell.Nib, PlanetCollectionViewCell.CellIdentifier);
            var startingUnitsSource = new MvxCollectionViewSource(startingUnitsCollectionView, PlanetCollectionViewCell.CellIdentifier);
			startingUnitsCollectionView.Source = startingUnitsSource;

            navigationBar.Initialize(this);

            //Bindings
            var set = this.CreateBindingSet<RaceSetupView, RaceSetupViewModel>();
            set.Bind(source).For(v => v.ItemsSource).To(vm => vm.StartingPlanets);
            set.Bind(startingUnitsSource).For(v => v.ItemsSource).To(vm => vm.StartingUnits);
            set.Bind(startingTechnologiesTextView).For(v => v.Text).To(vm => vm.StartingTechnology).WithConversion("StringListToBulletPoint");
			set.Bind(NavigationItem.LeftBarButtonItem).To(vm => vm.ShowHexMainMenu);
			set.Apply();

			startingUnitsCollectionView.ReloadData();
			startingUnitsCollectionView.LayoutIfNeeded();
        }

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
			startingUnitViewHeightConstraint.Constant = startingUnitsCollectionView.CollectionViewLayout.CollectionViewContentSize.Height + 60;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }
    }
}

