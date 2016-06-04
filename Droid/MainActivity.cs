using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Ioc;

namespace TwilightImperiumMasterCompanion.Droid
{
	[Activity (Label = "TwilightImperiumMasterCompanion.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : XLabs.Forms.XFormsApplicationDroid
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			if (!Resolver.IsSet)
				SetIoc ();

			LoadApplication (new App ());
		}

		private void SetIoc(){
			var resolverContainer = new SimpleContainer ();
			Resolver.SetResolver (resolverContainer.GetResolver ());
		}
	}
}

