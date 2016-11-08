using System;
namespace TwilightImperiumMasterCompanion.Core
{
	public class Race
	{
		public string Name
		{
			get;
			private set;
		}

		public string URIName
		{
			get;
			set;
		}

		public Race(string name, string uriName)
		{
			this.Name = name;
			this.URIName = uriName + ".png";
		}

	}
}
