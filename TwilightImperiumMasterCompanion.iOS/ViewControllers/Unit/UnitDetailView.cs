using System;
using MvvmCross.iOS.Views;
using TwilightImperiumMasterCompanion.Core.ViewModels.Unit;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS.ViewControllers.Unit
{
    public partial class UnitDetailView : MvxViewController<UnitDetailViewModel>
    {
        public UnitDetailView() : base("UnitDetailView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

