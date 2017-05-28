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

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView startingTechnologiesTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView startingUnitsCollectionView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint startingUnitViewHeightConstraint { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (startingPlanetsCollectionView != null) {
                startingPlanetsCollectionView.Dispose ();
                startingPlanetsCollectionView = null;
            }

            if (startingTechnologiesTextView != null) {
                startingTechnologiesTextView.Dispose ();
                startingTechnologiesTextView = null;
            }

            if (startingUnitsCollectionView != null) {
                startingUnitsCollectionView.Dispose ();
                startingUnitsCollectionView = null;
            }

            if (startingUnitViewHeightConstraint != null) {
                startingUnitViewHeightConstraint.Dispose ();
                startingUnitViewHeightConstraint = null;
            }
        }
    }
}