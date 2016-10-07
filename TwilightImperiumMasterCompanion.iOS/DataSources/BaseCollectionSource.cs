using System;
using MvvmCross.Binding.iOS.Views;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class BaseCollectionSource : MvxCollectionViewSource
	{
		public BaseCollectionSource(UICollectionView collectionView) : base(collectionView)
		{
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
		{
			//TODO Refactor to use a generic rather than specific cell id.
			var cell = (UICollectionViewCell) collectionView.DequeueReusableCell(RaceEmblemCell.CellId, indexPath);
			return cell;
		}
	}
}
