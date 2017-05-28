using System;

using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class UnitReferenceTableViewCell : MvxTableViewCell
	{
		private const string BindingText = 
			"ShipName Name;" +
            "ShipCost Cost, Converter=Unit;" +
			"ShipMove Movement, Converter=Unit;" +
			"ShipBattle Battle, Converter=Unit;" +
			"ShipCapacity Capacity, Converter=Unit;";

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
				ShipImageName = value.Replace(" ", String.Empty)+ "Icon";
			}
		}

		public string ShipCost
		{
			get { return shipCost.Text; }
			set { shipCost.Text = value; }
		}

		public string ShipMove
		{
			get { return shipMove.Text; }
			set { shipMove.Text = value; }
		}

		public string ShipBattle
		{
			get { return shipBattle.Text; }
			set { shipBattle.Text = value; }
		}

		public string ShipCapacity
		{
			get { return shipCapacity.Text; }
			set { shipCapacity.Text = value; }
		}

		public UnitReferenceTableViewCell(IntPtr handle) : base(BindingText, handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
