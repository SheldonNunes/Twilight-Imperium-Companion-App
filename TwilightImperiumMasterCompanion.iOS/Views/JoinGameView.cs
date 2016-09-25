using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using TwilightImperiumMasterCompanion.Core;
using MvvmCross.Binding.BindingContext;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class JoinGameView : BaseView<JoinGameViewModel>
    {
		private nfloat _originalContentConstraintBottomConstant;

        public JoinGameView (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var set = this.CreateBindingSet<JoinGameView, JoinGameViewModel>();
			set.Bind(nameTextField).To(vm => vm.Name).OneWayToSource();
			set.Bind(hostCodeTextField).To(vm => vm.Code).OneWayToSource();
			set.Apply();

			rootView.BackgroundColor = ColorConstants.TWILIGHT_IMPERIUM_BLUE;
			_originalContentConstraintBottomConstant = contentConstraintBottom.Constant;

			var viewTouchRegister = new UITapGestureRecognizer(() => View.EndEditing(true));
			viewTouchRegister.CancelsTouchesInView = false; //for iOS5
			View.AddGestureRecognizer(viewTouchRegister);

			nameTextField.ShouldReturn += (textField) => hostCodeTextField.BecomeFirstResponder();
			hostCodeTextField.ShouldReturn += (textField) =>
			{
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