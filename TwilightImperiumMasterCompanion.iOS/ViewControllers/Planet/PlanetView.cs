using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Platform;
using TwilightImperiumMasterCompanion.Core.ViewModels;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS.ViewControllers.Planet
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class PlanetView : MvxViewController<PlanetViewModel>
    {
        private readonly INavigationBar navigationBar;

        public PlanetView() : base("PlanetView", null)
        {
            navigationBar = Mvx.Resolve<INavigationBar>();
            Title = PlanetViewModel.Title;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            navigationBar.Initialize(this);
			var source = new MvxSimpleTableViewSource(tableView, "PlanetTableViewCell", "PlanetTableViewCell");
			tableView.Source = source;

			//Bindings
			var set = this.CreateBindingSet<PlanetView, PlanetViewModel>();
            set.Bind(source).For(v => v.ItemsSource).To(vm => vm.PlayerPlanets);
			set.Bind(NavigationItem.LeftBarButtonItem).To(vm => vm.ShowHexMainMenu);
            set.Bind(NavigationItem.RightBarButtonItem).To(vm => vm.NavigateToAddPlanetView);
			set.Apply();
        }
    }
}

