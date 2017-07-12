using System;
using System.Collections.Generic;
using TwilightImperiumMasterCompanion.Core.Enum;
using TwilightImperiumMasterCompanion.Core.Helpers;

namespace TwilightImperiumMasterCompanion.Core.Model
{
    public class Leader
    {
		public int RaceLeaderID
		{
			get;
			set;
		}

        public string Image
        {
            get { return IconImageNameBuilder.IconImageNameForString(LeaderType); }
        }

        public string LeaderType
        {
            get;
            set;
        }

        public List<LeaderAbility> Abilities
        {
            get;
            set;
        }
    }
}
