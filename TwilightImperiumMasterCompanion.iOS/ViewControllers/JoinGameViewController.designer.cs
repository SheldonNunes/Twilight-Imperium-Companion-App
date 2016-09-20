// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
    [Register ("JoinGameViewController")]
    partial class JoinGameViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint contentConstraintBottom { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView contentView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField hostCodeTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton joinButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField nameTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView rootView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (contentConstraintBottom != null) {
                contentConstraintBottom.Dispose ();
                contentConstraintBottom = null;
            }

            if (contentView != null) {
                contentView.Dispose ();
                contentView = null;
            }

            if (hostCodeTextField != null) {
                hostCodeTextField.Dispose ();
                hostCodeTextField = null;
            }

            if (imageView != null) {
                imageView.Dispose ();
                imageView = null;
            }

            if (joinButton != null) {
                joinButton.Dispose ();
                joinButton = null;
            }

            if (nameTextField != null) {
                nameTextField.Dispose ();
                nameTextField = null;
            }

            if (rootView != null) {
                rootView.Dispose ();
                rootView = null;
            }
        }
    }
}