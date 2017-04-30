using System;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class LinkerPleaseInclude
	{
		public void Include(UIBarButtonItem barButtonItem) {
			barButtonItem.Clicked += (sender, e) => barButtonItem.Title = "";
		}
	}
}
