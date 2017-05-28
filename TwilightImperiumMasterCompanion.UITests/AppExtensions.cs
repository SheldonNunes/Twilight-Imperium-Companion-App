using System;
using MentorTablet.UITests;
using Xamarin.UITest;

namespace TwilightImperiumMasterCompanion.UITests
{
	public static class AppExtensions
	{
		public static HomeScreen HomeScreen(this IApp app)
		{
			try
			{
				var page = new HomeScreen(app);
				return page;
			}
			catch
			{
				throw new Exception("The Login page was not found.");
			}
		}
	}
}
