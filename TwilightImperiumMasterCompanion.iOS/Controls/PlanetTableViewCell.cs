using System;

using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS.Controls
{
    public partial class PlanetTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("PlanetTableViewCell");
        public static readonly UINib Nib;

        private const string BindingText =
            "PlanetName Name;" +
            "Resource Resource;" +
            "Influence Influence;";

		public string PlanetName
        {
            get { return planetName.Text; }
            set { planetName.Text = value; }
        }

		public string Resource
		{
            get { return resource.Text; }
			set { resource.Text = value; }
		}

        public string Influence
		{
            get { return influence.Text; }
			set { influence.Text = value; }
		}

        private bool exhausted;
        public bool Exhausted
        {
            get { return exhausted; }
            set { exhausted = value; }
        }


        static PlanetTableViewCell()
        {
            Nib = UINib.FromName("PlanetTableViewCell", NSBundle.MainBundle);
        }

        protected PlanetTableViewCell(IntPtr handle) : base(BindingText, handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
