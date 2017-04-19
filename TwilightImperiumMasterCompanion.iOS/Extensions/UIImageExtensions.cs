using System;
using System.Runtime.InteropServices;
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

		public static UIColor GetPixelColor(this UIImage self, CGPoint pt)
		{
			var rawData = new byte[4];
			var handle = GCHandle.Alloc(rawData);
			UIColor resultColor = null;
			try
			{
				using (var colorSpace = CGColorSpace.CreateDeviceRGB())
				{
					using (var context = new CGBitmapContext(rawData, 1, 1, 8, 4, colorSpace, CGImageAlphaInfo.PremultipliedLast))
					{
						context.DrawImage(new CGRect(-pt.X, pt.Y - self.Size.Height, self.Size.Width, self.Size.Height), self.CGImage);
						float red = (rawData[0]) / 255.0f;
						float green = (rawData[1]) / 255.0f;
						float blue = (rawData[2]) / 255.0f;
						float alpha = (rawData[3]) / 255.0f;
						resultColor = UIColor.FromRGBA(red, green, blue, alpha);
					}
				}
			}
			finally
			{
				handle.Free();
			}
			return resultColor;
		}
	}
}
