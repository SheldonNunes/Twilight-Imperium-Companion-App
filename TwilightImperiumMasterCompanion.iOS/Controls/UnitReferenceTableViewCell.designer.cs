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
    [Register ("UnitReferenceTableViewCell")]
    partial class UnitReferenceTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel shipBattle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel shipCapacity { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel shipCost { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView shipImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel shipMove { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel shipName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (shipBattle != null) {
                shipBattle.Dispose ();
                shipBattle = null;
            }

            if (shipCapacity != null) {
                shipCapacity.Dispose ();
                shipCapacity = null;
            }

            if (shipCost != null) {
                shipCost.Dispose ();
                shipCost = null;
            }

            if (shipImage != null) {
                shipImage.Dispose ();
                shipImage = null;
            }

            if (shipMove != null) {
                shipMove.Dispose ();
                shipMove = null;
            }

            if (shipName != null) {
                shipName.Dispose ();
                shipName = null;
            }
        }
    }
}