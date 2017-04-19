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
    [Register ("HexMenuViewComponent")]
    partial class HexMenuViewComponent
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView hexIconImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView hexImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView rootView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (hexIconImage != null) {
                hexIconImage.Dispose ();
                hexIconImage = null;
            }

            if (hexImageView != null) {
                hexImageView.Dispose ();
                hexImageView = null;
            }

            if (rootView != null) {
                rootView.Dispose ();
                rootView = null;
            }
        }
    }
}