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
		private RaceEmblemCell _selectedCell;

		public CGPoint Center
		{
			get;
			set;
		}

		public nint CellCount
		{
			get
			{
				return CollectionView.NumberOfItemsInSection(0) ;
			}
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
			return true;
		}

		public override void PrepareLayout()
		{
			base.PrepareLayout();
			CollectionView.AddGestureRecognizer(new UITapGestureRecognizer(TapRegistered) { NumberOfTapsRequired = 1, Enabled = true });
			CollectionView.ScrollEnabled = false;
			CollectionView.ContentInset = new UIEdgeInsets(0,0,0,0);
			CGSize containerSize = CollectionView.Frame.Size;
			Center = new CGPoint(containerSize.Width / 2.0, containerSize.Height / 2.0);

			Radius = Math.Min(containerSize.Width - _cellSize.Width, containerSize.Height - _cellSize.Height) / 2.0;
		}

		public void TapRegistered(UITapGestureRecognizer gesture)
		{
			switch (gesture.State)
			{
				case UIGestureRecognizerState.Ended:
					UIView.Animate(0.1, 0, UIViewAnimationOptions.CurveEaseInOut, () =>
					{
						CGPoint location = gesture.LocationInView(CollectionView);
						var selectedIndex = CollectionView.IndexPathForItemAtPoint(location);
						if (selectedIndex != null)
						{
							CollectionView.Source.ItemSelected(CollectionView, selectedIndex);
							if (_selectedCell != null)
							{
								_selectedCell.Center = _selectedCell.OriginalPosition;
							}
							_selectedCell = (RaceEmblemCell)CollectionView.CellForItem(selectedIndex);
							_selectedCell.OriginalPosition = _selectedCell.Center;
							_selectedCell.Center = Center;
						}
					}, null);
					//Do something
					break;

				default:
					//CollectionView.CancelInteractiveMovement();
					break;
			}
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
	}
}
