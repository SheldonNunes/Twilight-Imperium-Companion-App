using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class CircleCollectionView : UICollectionView
	{
		private NSIndexPath selectedIndexPath;
		private UIView interactiveView;
		private UICollectionViewCell interactiveCell;
		private CGPoint initialPosition;
		private NSIndexPath interactiveIndexPath;

		public CircleCollectionView(IntPtr handle) : base(handle)
		{
			var longPressGesture = new UIPanGestureRecognizer(HandleLongGesture);
			this.AddGestureRecognizer(longPressGesture);
		}

		private void HandleLongGesture(UIPanGestureRecognizer gesture)
		{
			switch (gesture.State)
			{

				case UIGestureRecognizerState.Began:
					selectedIndexPath = IndexPathForItemAtPoint(gesture.LocationInView(this));
					if (selectedIndexPath != null)
					{
						BeginInteractiveMovementForItem(selectedIndexPath);
					}
					break;
				case UIGestureRecognizerState.Changed:
					if (selectedIndexPath != null)
					{
						UpdateInteractiveMovement(gesture.LocationInView(this));
					}
					break;
				case UIGestureRecognizerState.Ended:
					if (selectedIndexPath != null)
					{
						EndInteractiveMovement();
					}
					break;
				default:
					CancelInteractiveMovement();
					break;
			}

		}

		public override bool BeginInteractiveMovementForItem(NSIndexPath indexPath)
		{
			interactiveIndexPath = indexPath;
			interactiveCell = CellForItem(interactiveIndexPath);
			interactiveView = interactiveCell.SnapshotView(false);
			interactiveView.Frame = interactiveCell.Frame;
			initialPosition = interactiveView.Center;

			AddSubview(interactiveView);
			BringSubviewToFront(interactiveView);

			interactiveCell.Hidden = true;

			return true;
		}

		public override void UpdateInteractiveMovement(CGPoint targetPosition)
		{
			interactiveView.Center = targetPosition;
			interactiveView.Transform = CGAffineTransform.MakeScale(1.5f, 1.5f);
		}

		public override void EndInteractiveMovement()
		{
			//var y = Bounds.GetMidX();
			//Todo did they drag to specified location
			interactiveView.Transform = CGAffineTransform.MakeScale(1, 1);
			if (Math.Abs(Bounds.GetMidX() - interactiveView.Center.X) < 40 && Math.Abs(Bounds.GetMidY() - interactiveView.Center.Y) < 40)
			{
				//the person has selected this.
				interactiveView.Center = new CGPoint(Bounds.GetMidX(), Bounds.GetMidY());
				Source.ItemSelected(this, interactiveIndexPath);

				//SelectItem(interactiveIndexPath, false, UICollectionViewScrollPosition.None);

			}
			else {
				UIView.Animate(0.1, 0, UIViewAnimationOptions.CurveEaseInOut, MoveViewBackToInitialPosition, CleanUp);
			}
		}

		public override void CancelInteractiveMovement()
		{
			CleanUp();
		}

		private void MoveViewBackToInitialPosition()
		{
			interactiveView.Center = initialPosition;
		}

		private void CleanUp()
		{
			interactiveCell.Hidden = false;
			interactiveView.RemoveFromSuperview();
			interactiveView = null;
			interactiveCell = null;
		}

	}
}
