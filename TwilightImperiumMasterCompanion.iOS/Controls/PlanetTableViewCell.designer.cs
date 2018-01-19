// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace TwilightImperiumMasterCompanion.iOS.Controls
{
    [Register ("PlanetTableViewCell")]
    partial class PlanetTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel influence { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel planetName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel resource { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (influence != null) {
                influence.Dispose ();
                influence = null;
            }

            if (planetName != null) {
                planetName.Dispose ();
                planetName = null;
            }

            if (resource != null) {
                resource.Dispose ();
                resource = null;
            }
        }
    }
}