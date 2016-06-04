using System;
using XLabs.Forms.Mvvm;
using System.Collections.Generic;

namespace TwilightImperiumMasterCompanion
{
	public class UnitReferenceSheetViewModel : ViewModel
	{
		public List<Unit> Units {
			get;
			set;
		}

		public Fighter Fighter {
			get;
			set;
		}

		public Ship Cruiser {
			get;
			set;
		}

		public Ship Destroyer {
			get;
			set;
		}

		public Ship Carrier {
			get;
			set;
		}

		public Ship Dreadnaught {
			get;
			set;
		}

		public Ship WarSun {
			get;
			set;
		}

		public Installation SpaceDock{
			get;
			set;
		}

		public Installation PDS {
			get;
			set;
		}

		public GroundUnits GroundForce {
			get;
			set;
		}

		public GroundUnits MechUnit {
			get;
			set;
		}


		public UnitReferenceSheetViewModel ()
		{
			

			Fighter = new Fighter ("Figher", 1, 9, 1);
			Destroyer = new Ship ("Destroyer", 1, 2, 9, 1);
			Cruiser = new Ship ("Cruiser", 3, 1, 9, 1);
			Dreadnaught = new Ship ("Dreadnaught",5, 1, 5, 2);
			WarSun = new Ship ("WarSun",12, 2, 3, 2);

			Units = new List<Unit>{ Fighter, Destroyer, Cruiser, Dreadnaught, WarSun };



		}
	}
}

