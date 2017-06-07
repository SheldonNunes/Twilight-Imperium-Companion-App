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
    [Register ("LeaderCollectionViewCell")]
    partial class LeaderCollectionViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView leaderAbilities { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView leaderImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel leaderNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel leaderTypeLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (leaderAbilities != null) {
                leaderAbilities.Dispose ();
                leaderAbilities = null;
            }

            if (leaderImageView != null) {
                leaderImageView.Dispose ();
                leaderImageView = null;
            }

            if (leaderNameLabel != null) {
                leaderNameLabel.Dispose ();
                leaderNameLabel = null;
            }

            if (leaderTypeLabel != null) {
                leaderTypeLabel.Dispose ();
                leaderTypeLabel = null;
            }
        }
    }
}