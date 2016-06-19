using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using TwilightImperiumMasterCompanion.Core;

namespace TwilightImperiumMasterCompanion.iOS
{
	partial class PlanetViewController : UIViewController
	{
		public PlanetViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			Planet initialPlanet = new Planet ("Mecatol Rex", "Blah", 1, 1);
			PlanetName.Text = initialPlanet.PlanetName;
		}
			
	}
}
