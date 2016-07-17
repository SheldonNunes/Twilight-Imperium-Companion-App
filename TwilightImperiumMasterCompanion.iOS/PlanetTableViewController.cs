using Foundation;
using System;
using UIKit;
using TwilightImperiumMasterCompanion.Core;

namespace TwilightImperiumMasterCompanion.iOS
{
    public partial class PlanetTableViewController : UITableViewController
    {
		PlanetDataService planetDataService = new PlanetDataService();
        public PlanetTableViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			var planets = planetDataService.GetPlanets();
			var datasource = new PlanetDataSource(planets, this);

			TableView.Source = datasource;

			base.ViewDidLoad();
		}
    }
}