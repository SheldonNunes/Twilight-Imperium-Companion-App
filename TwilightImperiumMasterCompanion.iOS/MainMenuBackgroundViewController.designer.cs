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
    [Register ("MainMenuBackgroundViewController")]
    partial class MainMenuBackgroundViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView backgroundImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView menuContainer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        SpriteKit.SKView starScene { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (backgroundImage != null) {
                backgroundImage.Dispose ();
                backgroundImage = null;
            }

            if (menuContainer != null) {
                menuContainer.Dispose ();
                menuContainer = null;
            }

            if (starScene != null) {
                starScene.Dispose ();
                starScene = null;
            }
        }
    }
}