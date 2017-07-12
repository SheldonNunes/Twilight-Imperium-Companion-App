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
    [Register ("RaceLeadersPageComponentView")]
    partial class RaceLeadersPageComponentView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView leaderDescription { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView leaderImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel leaderType { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (leaderDescription != null) {
                leaderDescription.Dispose ();
                leaderDescription = null;
            }

            if (leaderImage != null) {
                leaderImage.Dispose ();
                leaderImage = null;
            }

            if (leaderType != null) {
                leaderType.Dispose ();
                leaderType = null;
            }
        }
    }
}