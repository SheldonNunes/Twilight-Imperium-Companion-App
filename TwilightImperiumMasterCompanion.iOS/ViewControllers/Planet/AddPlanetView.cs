using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using TwilightImperiumMasterCompanion.Core.ViewModels;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS.ViewControllers.Planet
{
    public partial class AddPlanetView : MvxTableViewController<AddPlanetViewModel>
    {
        public AddPlanetView()
        {
			this.Title = AddPlanetViewModel.Title;
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new MvxStandardTableViewSource(TableView, "TitleText Name;");
            TableView.Source = source;

            //Bindings
            var set = this.CreateBindingSet<AddPlanetView, AddPlanetViewModel>();
            set.Bind(source).For(v => v.ItemsSource).To(vm => vm.Planets);
            set.Apply();
        }
    }
}

