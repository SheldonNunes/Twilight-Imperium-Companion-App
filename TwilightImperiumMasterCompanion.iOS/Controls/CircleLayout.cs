using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class CircleLayout : UICollectionViewLayout
	{
		const float ItemSize = 70.0f;

		int cellCount = 20;
		float radius;
		CGPoint center;

		public CircleLayout()
		{
		}

		public override void PrepareLayout()
		{
			base.PrepareLayout();

			CGSize size = CollectionView.Frame.Size;
			cellCount = (int)CollectionView.NumberOfItemsInSection(0);
			center = new CGPoint(size.Width / 2.0f, size.Height / 2.0f);
			radius = (int)Math.Min(size.Width, size.Height) / 1f;
		}

		public override CGSize CollectionViewContentSize
		{
			get
			{
				return CollectionView.Frame.Size;
			}
		}

		public override UICollectionViewLayoutAttributes LayoutAttributesForItem(NSIndexPath path)
		{
			UICollectionViewLayoutAttributes attributes = UICollectionViewLayoutAttributes.CreateForCell(path);
			attributes.Size = new CGSize(ItemSize, ItemSize);
			attributes.Center = new CGPoint(center.X + radius * (float)Math.Cos(2 * path.Row * Math.PI / cellCount),
											center.Y + radius * (float)Math.Sin(2 * path.Row * Math.PI / cellCount));
			return attributes;
		}

		public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(CGRect rect)
		{
			var attributes = new UICollectionViewLayoutAttributes[cellCount];

			for (int i = 0; i < cellCount; i++)
			{
				NSIndexPath indexPath = NSIndexPath.FromItemSection(i, 0);
				attributes[i] = LayoutAttributesForItem(indexPath);
			}

			return attributes;
		}
	}
}
