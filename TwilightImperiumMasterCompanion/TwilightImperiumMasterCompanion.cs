using System;

using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace TwilightImperiumMasterCompanion
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			RegisterViews();
			MainPage = new NavigationPage((Page) ViewFactory.CreatePage<UserEmpireViewModel, UserEmpireView>());
				//new NavigationPage((Page)ViewFactory.CreatePage<PlanetListViewModel, PlanetList>());
		}

		private void RegisterViews()
		{
			ViewFactory.Register<UserEmpireView, UserEmpireViewModel> ();
			ViewFactory.Register<PlanetList, PlanetListViewModel>();

		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

