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
    [Register ("RaceSelectionView")]
    partial class RaceSelectionView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView abilitiesView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton confirmSelectionButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView raceIcon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView rootView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (abilitiesView != null) {
                abilitiesView.Dispose ();
                abilitiesView = null;
            }

            if (confirmSelectionButton != null) {
                confirmSelectionButton.Dispose ();
                confirmSelectionButton = null;
            }

            if (raceIcon != null) {
                raceIcon.Dispose ();
                raceIcon = null;
            }

            if (rootView != null) {
                rootView.Dispose ();
                rootView = null;
            }
        }
    }
}