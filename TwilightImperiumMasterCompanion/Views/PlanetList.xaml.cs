using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TwilightImperiumMasterCompanion
{
	public partial class PlanetList : ContentPage
	{
		public PlanetList ()
		{
			InitializeComponent ();
			BindingContext = new PlanetListViewModel ();
		}
	}
}

