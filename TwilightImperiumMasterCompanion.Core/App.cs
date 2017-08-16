
using System;
using System.IO;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using SQLite;
using TwilightImperiumMasterCompanion.Core.DataAccess;
using TwilightImperiumMasterCompanion.Core.DataAccess.Scripts;

namespace TwilightImperiumMasterCompanion.Core
{
	public class App : MvxApplication
	{
		public override void Initialize()
		{
			base.Initialize();

			CreatableTypes().EndingWith("ViewModel").AsInterfaces().RegisterAsLazySingleton();
			CreatableTypes().EndingWith("DataAccess").AsInterfaces().RegisterAsLazySingleton();
			CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();
			Mvx.RegisterType<IScriptRepository, ScriptRepository>();

			RegisterAppStart(new AppStart());
		}
	}
}
