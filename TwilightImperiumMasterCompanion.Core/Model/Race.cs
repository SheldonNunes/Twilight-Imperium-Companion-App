﻿using System;
namespace TwilightImperiumMasterCompanion.Core
{
	public class Race
	{
		public readonly string Name;

		public string EmblemImageURI
		{
			get;
			set;
		}

		public string RaceImageURI
		{
			get;
			set;
		}

		public Race(string name)
		{
			this.Name = name;
		}
	}
}