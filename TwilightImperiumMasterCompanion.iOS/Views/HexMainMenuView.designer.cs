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
    [Register ("HexMainMenuView")]
    partial class HexMainMenuView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIVisualEffectView blurView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationBar hexNavigationBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem navigationItem { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (blurView != null) {
                blurView.Dispose ();
                blurView = null;
            }

            if (hexNavigationBar != null) {
                hexNavigationBar.Dispose ();
                hexNavigationBar = null;
            }

            if (navigationItem != null) {
                navigationItem.Dispose ();
                navigationItem = null;
            }
        }
    }
}