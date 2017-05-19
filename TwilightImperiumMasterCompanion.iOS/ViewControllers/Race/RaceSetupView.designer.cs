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

namespace TwilightImperiumMasterCompanion.iOS
{
    [Register ("RaceSetupView")]
    partial class RaceSetupView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView startingPlanetsCollectionView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (startingPlanetsCollectionView != null) {
                startingPlanetsCollectionView.Dispose ();
                startingPlanetsCollectionView = null;
            }
        }
    }
}