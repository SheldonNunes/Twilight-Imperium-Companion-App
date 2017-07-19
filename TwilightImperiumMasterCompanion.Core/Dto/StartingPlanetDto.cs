namespace TwilightImperiumMasterCompanion.Core.Dto
{
    public class StartingPlanetDto
    {
        public int PlanetId
        {
            get;
            set;
        }


		public string Title
		{
			get;
			set;
		}

        public string Image
		{
			get { return "StartingPlanetIcon"; }
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

		public int ExpansionLevel
		{
			get;
			set;
		}
    }
}
