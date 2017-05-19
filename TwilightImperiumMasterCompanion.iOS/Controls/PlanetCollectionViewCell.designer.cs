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
    [Register ("PlanetCollectionViewCell")]
    partial class PlanetCollectionViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel planetName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (planetName != null) {
                planetName.Dispose ();
                planetName = null;
            }
        }
    }
}