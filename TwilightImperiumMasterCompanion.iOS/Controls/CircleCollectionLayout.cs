using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class CircleCollectionLayout : UICollectionViewLayout
	{
		public CGPoint Center
		{
			get;
			set;
		}

		public nint CellCount
		{
			get;
			set;
		}

		public double Radius
		{
			get;
			set;
		}

		public override void PrepareLayout()
		{
			base.PrepareLayout();

			CGSize containerSize = CollectionView.Frame.Size;
			Center = new CGPoint(containerSize.Width / 2.0, containerSize.Height / 2.0);
			CellCount = CollectionView.NumberOfItemsInSection(0);
			Radius = Math.Min(containerSize.Width, containerSize.Height) / 2.0;

		}

		public override CGSize CollectionViewContentSize
		{
			get { return CollectionView.Frame.Size; }
		}

		public override UICollectionViewLayoutAttributes LayoutAttributesForItem(NSIndexPath indexPath)
		{
			var attributes = UICollectionViewLayoutAttributes.CreateForCell(indexPath);
			//TODO replace with size of item.
			attributes.Size = new CGSize(50, 50);

			var x = Center.X + Radius * Math.Cos(2 * indexPath.Item * Math.PI / CellCount);
			var y = Center.Y + Radius * Math.Sin(2 * indexPath.Item * Math.PI / CellCount);
			attributes.Center = new CGPoint(x, y);
			return attributes;
		}

		public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(CGRect rect)
		{
			UICollectionViewLayoutAttributes[] attributes = new UICollectionViewLayoutAttributes[CellCount];
			for (int i = 0; i < CellCount; i++)
			{
				var indexPath = NSIndexPath.FromItemSection(i, 0);
				attributes[i] = LayoutAttributesForItem(indexPath);
			}
			return attributes;
		}
	}
}
