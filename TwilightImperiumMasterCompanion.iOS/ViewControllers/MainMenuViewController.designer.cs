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
    [Register ("MainMenuViewController")]
    partial class MainMenuViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView backgroundImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView gradientBackground { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton joinGameButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SpriteKit.SKView starScene { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (backgroundImage != null) {
                backgroundImage.Dispose ();
                backgroundImage = null;
            }

            if (gradientBackground != null) {
                gradientBackground.Dispose ();
                gradientBackground = null;
            }

            if (joinGameButton != null) {
                joinGameButton.Dispose ();
                joinGameButton = null;
            }

            if (starScene != null) {
                starScene.Dispose ();
                starScene = null;
            }
        }
    }
}