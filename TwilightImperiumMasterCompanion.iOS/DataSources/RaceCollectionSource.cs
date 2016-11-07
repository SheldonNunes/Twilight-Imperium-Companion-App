using System;
using MvvmCross.Binding.iOS.Views;
using TwilightImperiumMasterCompanion.Core;
using UIKit;
using Foundation;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class RaceCollectionSource : MvxCollectionViewSource
	{
		private RaceSelectionViewModel vm;

		public RaceCollectionSource(UICollectionView collectionView, RaceSelectionViewModel vm) : base(collectionView)
		{
			this.vm = vm;
		}

		public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			base.ItemSelected(collectionView, indexPath);
			NSIndexPath[] path = new NSIndexPath[1] { indexPath };

			collectionView.SelectItem(indexPath, false, UICollectionViewScrollPosition.None);


			vm.Races.RemoveAt((int) indexPath.Item);
			collectionView.DeleteItems(path);
		}

		public override void ItemDeselected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			base.ItemDeselected(collectionView, indexPath);
		}

		protected override UICollectionViewCell GetOrCreateCellFor(UICollectionView collectionView, NSIndexPath indexPath, object item)
		{
			var cell = (RaceEmblemCell)collectionView.DequeueReusableCell(RaceEmblemCell.CellId, indexPath);
			cell.Emblem = UIImage.FromBundle("Images/Races/Emblems/" + vm.Races[indexPath.Row].URIName);
			return cell;
		}
	}
}
