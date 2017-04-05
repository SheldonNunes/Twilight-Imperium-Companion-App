using System;
using CoreGraphics;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public static class UIImageExtensions
	{
		public static UIImage CreateImageWithColor(UIColor color, CGSize size)
		{
			var image = new UIImage();
			UIGraphics.BeginImageContextWithOptions(size, false, 0);
			color.SetFill();
			UIGraphics.RectFill(new CGRect(0, 0, size.Width, size.Height));

			image = UIGraphics.GetImageFromCurrentImageContext();

			UIGraphics.EndImageContext();
			return image;
		}
	}
}
