using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Platform;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	[MvxTabPresentation(WrapInNavigationController = true)]
    public partial class RaceOverviewView : MvxViewController<RaceOverviewViewModel>
	{
		private readonly INavigationBar navigationBar;

		public RaceOverviewView() : base("RaceOverviewView", null)
		{
            this.Title = RaceOverviewViewModel.Title;
            navigationBar = Mvx.Resolve<INavigationBar>();
		}
		

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			navigationBar.Initialize(this);

			//Bindings
			//var set = this.CreateBindingSet<RaceOverviewView, RaceOverviewViewModel>();
			//set.Bind(this).For(v => v.Title).To(vm => vm.Title);
			//set.Apply();

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

