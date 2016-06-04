using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TwilightImperiumMasterCompanion
{
	public partial class SelectedPlanetView : ContentPage
	{
		public SelectedPlanetView (Planet planet)
		{
			this.BindingContext = new SelectedPlanetViewModel (planet);
			InitializeComponent ();

		}
	}
}

