using System;
using System.Drawing;
using Foundation;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class RaceEmblemCell : UICollectionViewCell
	{
		private UIImageView _emblem;

		public static readonly NSString CellId = new NSString("RaceEmblemCell");

		public UIImage Emblem
		{
			get
			{
				return _emblem.Image;
			}
			set
			{
				_emblem.Image = value;
				SetNeedsDisplay();
			}
		}

		[Export("initWithFrame:")]
		RaceEmblemCell(RectangleF frame) : base(frame)
		{
			_emblem = new UIImageView(ContentView.Frame);
			_emblem.Image = UIImage.FromBundle("Images/Emblems/baraony-of-letnev-emblem.png");

			BackgroundView = new UIView { BackgroundColor = UIColor.Orange };

			SelectedBackgroundView = new UIView { BackgroundColor = UIColor.Green };


			ContentView.AddSubview(_emblem);
		}

		public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
			BackgroundView = new UIView { BackgroundColor = UIColor.Purple};
			base.TouchesBegan(touches, evt);
		}
	}
}
