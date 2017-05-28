using System;
using TwilightImperiumMasterCompanion.UITests;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace MentorTablet.UITests
{
	public class HomeScreen : BaseScreen
	{
		private readonly Query questionnaireLogo = e => e.Id("Questionnaire Logo");

		public HomeScreen(IApp app)
			: base(app)
		{
			app.WaitForElement(questionnaireLogo);
			app.Screenshot("On the Questionnaire page");
		}

	}
}
