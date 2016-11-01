using System;
using Foundation;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class CircleCollectionView : UICollectionView
	{
		private NSIndexPath selectedIndexPath;
		private UIView interactiveView;

		public CircleCollectionView(IntPtr handle) : base(handle)
		{
			var longPressGesture = new UILongPressGestureRecognizer(HandleLongGesture);
			this.AddGestureRecognizer(longPressGesture);
		}

		private void HandleLongGesture(UILongPressGestureRecognizer gesture)
		{
			switch (gesture.State)
			{

				case UIGestureRecognizerState.Began:
					selectedIndexPath = IndexPathForItemAtPoint(gesture.LocationInView(this));
					BeginInteractiveMovementForItem(selectedIndexPath);
					break;
				case UIGestureRecognizerState.Changed:
					UpdateInteractiveMovement(gesture.LocationInView(this));
					break;
				case UIGestureRecognizerState.Ended:
					EndInteractiveMovement();
					break;
				default:
					CancelInteractiveMovement();
					break;

			}

		}

		public override bool BeginInteractiveMovementForItem(NSIndexPath indexPath)
		{
			var interactiveIndexPath = indexPath;
			var interactiveCell = CellForItem(interactiveIndexPath);
			interactiveView = interactiveCell.SnapshotView(false);
			interactiveView.Frame = interactiveCell.Frame;

			AddSubview(interactiveView);
			BringSubviewToFront(interactiveView);

			//NSIndexPath[] test = new NSIndexPath[1];
			//test[0] = interactiveIndexPath;
			//DeleteItems(test);
			interactiveCell.Hidden = true;

			return true;
		}

		public override void UpdateInteractiveMovement(CoreGraphics.CGPoint targetPosition)
		{
			interactiveView.Center = targetPosition;
		}


	}
}
