﻿using System;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using Foundation;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class CircularCollectionViewLayout : UICollectionViewLayout
	{
		private readonly CGSize _itemSize;
		private nfloat _angleAtExtreme;

		private int _radius;

		public int Radius
		{
			get
			{
				return _radius; 
			}
			set 
			{ 
				_radius = value;
				AnglePerItem = 360 / (CollectionView.NumberOfItemsInSection(0) + 1); //Math.Atan(_itemSize.Width / Radius);
				this.InvalidateLayout();
			}
		}

		public double AnglePerItem
		{
			get;
			set;
		}

		public double Angle;

		private List<CircularCollectionViewLayoutAttributes> AttributesList
		{
			get;
			set;
		}

		public CircularCollectionViewLayout(CGSize CellSize )
		{
			_itemSize = CellSize;
		}

		public override CGSize CollectionViewContentSize
		{
			get
			{
				return new CGSize(_itemSize.Width * CollectionView.NumberOfItemsInSection(0), CollectionView.Bounds.Height);
			}
		}

		public override UICollectionViewLayoutAttributes LayoutAttributesForItem(Foundation.NSIndexPath indexPath)
		{
			return new CircularCollectionViewLayoutAttributes();
		}

		public override void PrepareLayout()
		{
			base.PrepareLayout();
			_angleAtExtreme = (nfloat) (CollectionView.NumberOfItemsInSection(0) > 0 ?
			                            -(CollectionView.NumberOfItemsInSection(0) - 1) * AnglePerItem : 0);
			Angle = _angleAtExtreme * CollectionView.ContentOffset.X / (CollectionViewContentSize.Width - CollectionView.Bounds.Width);
			Radius = 200;
			var centerX = CollectionView.ContentOffset.X + (CollectionView.Bounds.Width / 2.0);
			var anchorPointY = ((_itemSize.Height / 2.0) + Radius) / _itemSize.Height;
			AttributesList = new List<CircularCollectionViewLayoutAttributes>();

			for (int i = 0; i < CollectionView.NumberOfItemsInSection(0); i++)
			{
				CircularCollectionViewLayoutAttributes attributes = CircularCollectionViewLayoutAttributes.CreateForCell<CircularCollectionViewLayoutAttributes>(NSIndexPath.FromRowSection(i, 0));
				attributes.Size = this._itemSize;
				attributes.Center = new CGPoint(centerX, CollectionView.Bounds.GetMidY());
				attributes.Angle = (float) ( Angle + (AnglePerItem * i));
				attributes.AnchorPoint = new CGPoint(0.5, anchorPointY);
				AttributesList.Add(attributes);
			}
		}

		//public override CGPoint TargetContentOffset(CGPoint proposedContentOffset, CGPoint scrollingVelocity)
		//{
		//	var finalContentOffset = proposedContentOffset;

		//	var factor = -_angleAtExtreme / (CollectionViewContentSize.Width - CollectionView.Bounds.Width);

		//	var proposedAngle = proposedContentOffset.X * factor;

		//	var ratio = proposedAngle / AnglePerItem;

		//	double multipler;

		//	if (scrollingVelocity.X > 0)
		//	{
		//		multipler = Math.Ceiling(ratio);
		//	}
		//	else if (scrollingVelocity.X < 0)
		//	{
		//		multipler = Math.Floor(ratio);
		//	}
		//	else {
		//		multipler = Math.Round(ratio);
		//	}
		//	finalContentOffset.X = (float) (multipler * AnglePerItem / factor);
		//	return finalContentOffset;
		//}
		
		public override bool ShouldInvalidateLayoutForBoundsChange(CGRect newBounds)
		{
			return true;
		}
		
		public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(CGRect rect)
		{
			return AttributesList.ToArray();
		}

		public override UICollectionViewLayoutAttributes InitialLayoutAttributesForAppearingItem(NSIndexPath itemIndexPath)
		{
			return AttributesList[itemIndexPath.Row];
		}

	}

	class CircularCollectionViewLayoutAttributes : UICollectionViewLayoutAttributes
	{
		private nfloat _angle;

		public nfloat Angle
		{
			get { return _angle; }
			set
			{
				//Transform with rotation and make sure angles that are higher are shown above
				_angle = value;
				ZIndex = (int)Angle * 100000;
				Transform = CGAffineTransform.MakeRotation(Angle);
			}
		}

		public CGPoint AnchorPoint
		{
			get;
			set;
		}

		public CircularCollectionViewLayoutAttributes()
		{
			AnchorPoint = new CGPoint(0.5, 0.5);
		}

		public override Foundation.NSObject Copy(Foundation.NSZone zone)
		{
			var copiedAttributes = base.Copy(zone) as CircularCollectionViewLayoutAttributes;
			copiedAttributes.AnchorPoint = this.AnchorPoint;
			copiedAttributes.Angle = this.Angle;
			return copiedAttributes;
		}

  
}

}