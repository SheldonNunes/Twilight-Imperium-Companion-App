using System;
using System.Collections.Generic;
using Foundation;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class PlanetDataSource : UITableViewSource
	{
		private List<Planet> planets;
		NSString cellIdentifier = new NSString("PlanetCell");

		public PlanetDataSource(List<Planet> planets, UITableViewController callingController)
		{
			this.planets = planets;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier) as UITableViewCell;

			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
			}

			var planet = planets[indexPath.Row];
			cell.TextLabel.Text = planet.PlanetName;

			//todo get image for planet

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return planets.Count;
		}
	}
}

