namespace TwilightImperiumMasterCompanion.Core
{
	public class Planet
	{

        public string Name
		{
			get;
			set;
		}

		public string Image
		{
            get { return "StartingPlanetIcon"; }
		}

		public string Description
		{
			get;
			set;
		}

		public int Resource
		{
			get;
			set;
		}

		public int Influence
		{
			get;
			set;
		}

		public Player Owner
		{
			get;
			set;
		}
	}
}

