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


		public override void DecelerationEnded(UIScrollView scrollView)
		{
			//todo correct this
			nfloat contentOffsetWhenFullyScrolledRight = scrollView.Frame.Size.Width - 50;

			if (scrollView.ContentOffset.X == contentOffsetWhenFullyScrolledRight)
			{
				NSIndexPath newIndexPath = NSIndexPath.FromRowSection(1, 0);

				CollectionView.ScrollToItem(newIndexPath, UICollectionViewScrollPosition.Left, true);
			}
			else if (scrollView.ContentOffset.X == 0)
			{
				NSIndexPath newIndexPath = NSIndexPath.FromRowSection(vm.Races.Count-1, 0);

				CollectionView.ScrollToItem(newIndexPath, UICollectionViewScrollPosition.Left, true);
				
			}
			//base.DecelerationEnded(scrollView);
		}
	}
}
