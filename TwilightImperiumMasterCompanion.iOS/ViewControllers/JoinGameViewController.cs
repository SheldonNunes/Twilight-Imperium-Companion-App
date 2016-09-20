using Foundation;
using System;
using UIKit;
using CoreGraphics;
using System.Drawing;
using CoreAnimation;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class JoinGameViewController : BaseViewController
    {
		private nfloat _originalContentConstraintBottomConstant;


        public JoinGameViewController (IntPtr handle) : base (handle)
        {        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			rootView.BackgroundColor = ColorConstants.TWILIGHT_IMPERIUM_BLUE;
			_originalContentConstraintBottomConstant = contentConstraintBottom.Constant;

			var viewTouchRegister = new UITapGestureRecognizer(() => View.EndEditing(true));
			viewTouchRegister.CancelsTouchesInView = false; //for iOS5
			View.AddGestureRecognizer(viewTouchRegister);

			nameTextField.ShouldReturn += (textField) => hostCodeTextField.BecomeFirstResponder();
			hostCodeTextField.ShouldReturn += (textField) => { 
				joinButton.SendActionForControlEvents(UIControlEvent.TouchUpInside); 
				return true; 
			};

		}

		protected override void OnKeyboardChanged(bool visible, nfloat height)
		{
			if (visible)
			{
				contentConstraintBottom.Constant = _originalContentConstraintBottomConstant + height;
			}
			else {
				contentConstraintBottom.Constant = _originalContentConstraintBottomConstant;
			}
			contentView.LayoutIfNeeded();
			base.OnKeyboardChanged(visible, height);
		}


    }
}