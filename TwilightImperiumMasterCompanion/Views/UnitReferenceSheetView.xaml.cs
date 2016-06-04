using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TwilightImperiumMasterCompanion
{
	public partial class UnitReferenceSheetView : ContentPage
	{
		public UnitReferenceSheetView ()
		{
			InitializeComponent ();
			BindingContext = new UnitReferenceSheetViewModel ();
		}
	}
}

