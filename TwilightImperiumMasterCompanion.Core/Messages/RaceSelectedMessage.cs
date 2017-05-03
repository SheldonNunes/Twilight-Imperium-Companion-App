using System;
using MvvmCross.Plugins.Messenger;

namespace TwilightImperiumMasterCompanion.Core
{
	public class RaceSelectedMessage : MvxMessage
	{
		public Race SelectedRace
		{
			get;
			private set;
		}

		public RaceSelectedMessage(object sender, Race selectedRace) : base(sender)
		{
			SelectedRace = selectedRace;
		}
	}
}
