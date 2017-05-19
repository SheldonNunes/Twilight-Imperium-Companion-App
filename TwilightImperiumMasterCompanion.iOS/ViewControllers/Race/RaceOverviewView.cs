using System;
using MvvmCross.iOS.Views;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class RaceOverviewView : MvxViewController
	{
		public RaceOverviewView() : base("RaceOverviewView", null)
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

