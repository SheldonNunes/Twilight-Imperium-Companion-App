using System;
using MvvmCross.Binding.iOS.Views;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class RaceCollectionSource : MvxCollectionViewSource
	{
		private RaceSelectionViewModel vm;

		public RaceCollectionSource(UICollectionView collectionView, RaceSelectionViewModel vm) : base(collectionView)
		{
			this.vm = vm;
		}

		public override UICollectionViewCell GetCell(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
		{
			var cell = (RaceEmblemCell)collectionView.DequeueReusableCell(RaceEmblemCell.CellId, indexPath);

			cell.Emblem = UIImage.FromBundle("Images/Races/Emblems/"+ vm.Races[indexPath.Row].URIName);
			return cell;
		}
	}
}
