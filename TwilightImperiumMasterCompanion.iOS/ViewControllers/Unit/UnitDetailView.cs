using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using TwilightImperiumMasterCompanion.Core;
using TwilightImperiumMasterCompanion.Core.ViewModels.Unit;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS.ViewControllers.Unit
{
    public partial class UnitDetailView : MvxViewController<UnitDetailViewModel>
    {
        private MvxImageViewLoader imageLoader;

        public UnitDetailView() : base("UnitDetailView", null)
        {
            this.imageLoader = new MvxImageViewLoader(() => shipImage);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


			//Bindings
			var set = this.CreateBindingSet<UnitDetailView, UnitDetailViewModel>();
            set.Bind(shipName).For(v => v.Text).To(vm => vm.SelectedUnit.Name);
            set.Bind(imageLoader).To(vm => vm.SelectedUnit.Name).WithConversion<IconImagePathValueConverter>();

			set.Apply();

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

