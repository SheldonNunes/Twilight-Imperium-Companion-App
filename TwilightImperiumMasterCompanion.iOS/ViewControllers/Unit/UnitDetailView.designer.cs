// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS.ViewControllers.Unit
{
    [Register ("UnitDetailView")]
    partial class UnitDetailView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView shipImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel shipName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (shipImage != null) {
                shipImage.Dispose ();
                shipImage = null;
            }

            if (shipName != null) {
                shipName.Dispose ();
                shipName = null;
            }
        }
    }
}