using System;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
    public partial class PurchaseUnitTableViewCell : MvxTableViewCell
	{
        private const string BindingText =
            "ShipName Name;" +
            "ShipCost Cost, Converter=Unit;";

		public string ShipImageName
		{
			set { shipImage.Image = UIImage.FromBundle(value); }
		}

		public string ShipName
		{
			get { return shipName.Text; }
			set
			{
				shipName.Text = value;
				ShipImageName = value.Replace(" ", String.Empty) + "Icon";
			}
		}

		public string ShipCost
		{
			get { return shipCost.Text; }
			set { shipCost.Text = value; }
		}


		public PurchaseUnitTableViewCell(IntPtr handle) : base(BindingText, handle)
        {
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
