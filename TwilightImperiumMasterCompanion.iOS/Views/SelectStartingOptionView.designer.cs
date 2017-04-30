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
    [Register ("SelectStartingOptionView")]
    partial class SelectStartingOptionView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView expansionsView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView rootView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton selectRaceButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel shatteredEmpiresLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (expansionsView != null) {
                expansionsView.Dispose ();
                expansionsView = null;
            }

            if (rootView != null) {
                rootView.Dispose ();
                rootView = null;
            }

            if (selectRaceButton != null) {
                selectRaceButton.Dispose ();
                selectRaceButton = null;
            }

            if (shatteredEmpiresLabel != null) {
                shatteredEmpiresLabel.Dispose ();
                shatteredEmpiresLabel = null;
            }
        }
    }
}