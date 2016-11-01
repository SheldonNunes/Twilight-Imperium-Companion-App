using System;
using MvvmCross.Binding.iOS.Views;
using TwilightImperiumMasterCompanion.Core;
using UIKit;
using Foundation;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class RaceCollectionSource : MvxCollectionViewSource
	{
		public RaceCollectionSource(UICollectionView collectionView) : base(collectionView)
		{
		}
	}
}
