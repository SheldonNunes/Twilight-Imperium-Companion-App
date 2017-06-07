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
	public partial class UnitReferenceView : MvxViewController
	{
        private readonly INavigationBar navigationBar;

        public UnitReferenceView()
			: base("UnitReferenceView", null)
		{
            this.Title = UnitReferenceViewModel.Title;
			navigationBar = Mvx.Resolve<INavigationBar>();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
            navigationBar.Initialize(this);

            var source = new MvxSimpleTableViewSource(tableView, "UnitReferenceTableViewCell", "UnitReferenceTableViewCell");
			tableView.Source = source;

			var set = this.CreateBindingSet<UnitReferenceView, UnitReferenceViewModel>();
            set.Bind(source).For(v => v.ItemsSource).To(vm => vm.Units);
            set.Bind(NavigationItem.LeftBarButtonItem).To(vm => vm.ShowHexMainMenu);
            set.Bind(source).For(v => v.SelectionChangedCommand).To(vm => vm.ShowDetailView);
			set.Apply();
		}
	}
}

