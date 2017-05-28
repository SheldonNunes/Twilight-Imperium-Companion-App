using System;
using System.Collections.Generic;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Platform;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
    [MvxTabPresentation(WrapInNavigationController = true)]
    public partial class UnitPurchaseView : MvxViewController
	{
        private readonly INavigationBar navigationBar;

        public UnitPurchaseView() : base("UnitPurchaseView", null)
		{
            this.Title = UnitPurchaseViewModel.Title;
            navigationBar = Mvx.Resolve<INavigationBar>();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            navigationBar.Initialize(this);
            var source = new MvxSimpleTableViewSource(tableView, "PurchaseUnitTableViewCell", "PurchaseUnitTableViewCell");
			tableView.Source = source;

			//Bindings
            var set = this.CreateBindingSet<UnitPurchaseView, UnitPurchaseViewModel>();
			set.Bind(source).For(v => v.ItemsSource).To(vm => vm.Units);
			set.Bind(NavigationItem.LeftBarButtonItem).To(vm => vm.ShowHexMainMenu);
			set.Apply();

		}
	}
}

