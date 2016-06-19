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
	[Register ("MainMenuController")]
	partial class MainMenuController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView ContentView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView Footer { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView Header { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton HostGameButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView MainMenu { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ContentView != null) {
				ContentView.Dispose ();
				ContentView = null;
			}
			if (Footer != null) {
				Footer.Dispose ();
				Footer = null;
			}
			if (Header != null) {
				Header.Dispose ();
				Header = null;
			}
			if (HostGameButton != null) {
				HostGameButton.Dispose ();
				HostGameButton = null;
			}
			if (MainMenu != null) {
				MainMenu.Dispose ();
				MainMenu = null;
			}
		}
	}
}
