// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace TwilightImperiumMasterCompanion.iOS
{
    [Register ("PurchaseUnitTableViewCell")]
    partial class PurchaseUnitTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel shipCost { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView shipImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel shipName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (shipCost != null) {
                shipCost.Dispose ();
                shipCost = null;
            }

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