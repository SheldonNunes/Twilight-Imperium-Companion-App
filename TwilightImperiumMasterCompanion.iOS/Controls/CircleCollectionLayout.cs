using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class CircleCollectionLayout : UICollectionViewLayout
	{
		private CGSize _cellSize;

		private List<NSIndexPath> deleteIndexPaths;
		private List<NSIndexPath> insertIndexPaths;

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

		public CircleCollectionLayout(CGSize cellSize)
		{
			_cellSize = cellSize;


		}

		public override bool ShouldInvalidateLayoutForBoundsChange(CGRect newBounds)
		{
			return false;
		}


		public override void PrepareLayout()
		{
			base.PrepareLayout();
			CollectionView.ScrollEnabled = false;
			CollectionView.ContentInset = new UIEdgeInsets(0,0,0,0);
			CGSize containerSize = CollectionView.Frame.Size;
			Center = new CGPoint(containerSize.Width / 2.0, containerSize.Height / 2.0);
			CellCount = CollectionView.NumberOfItemsInSection(0);
			Radius = Math.Min(containerSize.Width - _cellSize.Width, containerSize.Height - _cellSize.Height) / 2.0;
		}

		public override CGSize CollectionViewContentSize
		{
			get { return CollectionView.Frame.Size; }
		}

		public override UICollectionViewLayoutAttributes LayoutAttributesForItem(NSIndexPath indexPath)
		{
			var attributes = UICollectionViewLayoutAttributes.CreateForCell(indexPath);
			attributes.Size = _cellSize;

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

		public override void PrepareForCollectionViewUpdates(UICollectionViewUpdateItem[] updateItems)
		{
			base.PrepareForCollectionViewUpdates(updateItems);
			deleteIndexPaths = new List<NSIndexPath>();
			insertIndexPaths = new List<NSIndexPath>();

			foreach (var item in updateItems)
			{
				if (item.UpdateAction == UICollectionUpdateAction.Delete)
				{
					deleteIndexPaths.Add(item.IndexPathBeforeUpdate);
				}

				else if (item.UpdateAction == UICollectionUpdateAction.Insert)
				{
					insertIndexPaths.Add(item.IndexPathAfterUpdate);
				}
			}
		}

		public override void FinalizeCollectionViewUpdates()
		{
			base.FinalizeCollectionViewUpdates();
			deleteIndexPaths = null;
			insertIndexPaths = null;
		}

		public override UICollectionViewLayoutAttributes InitialLayoutAttributesForAppearingItem(NSIndexPath itemIndexPath)
		{
			var attributes = base.InitialLayoutAttributesForAppearingItem(itemIndexPath);

			if (insertIndexPaths.Contains(itemIndexPath))
			{
				attributes = LayoutAttributesForItem(itemIndexPath);
				attributes.Center = new CGPoint(Center.X, Center.Y);
			}
			return attributes;
		}


		public override UICollectionViewLayoutAttributes FinalLayoutAttributesForDisappearingItem(NSIndexPath itemIndexPath)
		{
			var attributes = base.FinalLayoutAttributesForDisappearingItem(itemIndexPath);

			if (deleteIndexPaths.Contains(itemIndexPath))
			{
				attributes = LayoutAttributesForItem(itemIndexPath);
				attributes.Center = new CGPoint(Center.X, Center.Y);
			}

			return attributes;
		}
	}
}
