using System;
using System.Drawing;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using TwilightImperiumMasterCompanion.Core;
using UIKit;
using CoreGraphics;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class RaceEmblemCell : MvxCollectionViewCell
	{
		public static readonly NSString CellId = new NSString("RaceEmblemCell");

		private UIImageView _emblem;

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
			_emblem.ContentMode = UIViewContentMode.ScaleAspectFit;

			SelectedBackgroundView = new UIView { BackgroundColor = ColorConstants.TWILIGHT_IMPERIUM_PURPLE };


			ContentView.AddSubview(_emblem);
		}

		public override void ApplyLayoutAttributes(UICollectionViewLayoutAttributes layoutAttributes)
		{
			base.ApplyLayoutAttributes(layoutAttributes);
			var circularlayoutAttributes = layoutAttributes as CircularCollectionViewLayoutAttributes;
			this.Layer.AnchorPoint = circularlayoutAttributes.AnchorPoint;
			this.Center = new CGPoint(Center.X, Center.Y + (circularlayoutAttributes.AnchorPoint.Y - 0.5) * this.Bounds.Height);
		}
	}
}
