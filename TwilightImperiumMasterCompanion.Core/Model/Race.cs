using System;
namespace TwilightImperiumMasterCompanion.Core
{
	public class Race
	{
		public readonly string Name;

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
