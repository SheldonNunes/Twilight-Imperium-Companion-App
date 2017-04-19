using System;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class HexImageView : UIImageView
	{
		public HexImageView()
		{
		}

		public override bool PointInside(CoreGraphics.CGPoint point, UIEvent uievent)
		{
			var color = this.Image.GetPixelColor(point);
			return base.PointInside(point, uievent);

		}
	}


}
