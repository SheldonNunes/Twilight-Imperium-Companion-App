using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace TwilightImperiumMasterCompanion
{
	public partial class UserEmpireView : TabbedPage
	{
		public UserEmpireView ()
		{
			InitializeComponent ();
			BindingContext = new UserEmpireViewModel ();

			var planetNavigation = new NavigationPage ((Page)ViewFactory.CreatePage<PlanetListViewModel, PlanetList> ());
			planetNavigation.Title = "Planets";
			planetNavigation.Icon = "logo-planetx.png";

			var referenceSheet = new UnitReferenceSheetView ();
			referenceSheet.Icon = "logo-unitx.png";

			Children.Add (planetNavigation);
			Children.Add (referenceSheet);
		}
	}
}

