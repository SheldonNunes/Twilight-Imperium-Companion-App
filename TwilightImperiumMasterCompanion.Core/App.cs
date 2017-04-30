using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace TwilightImperiumMasterCompanion.Core
{
	public class App : MvxApplication
	{
		public override void Initialize()
		{
			base.Initialize();

			CreatableTypes().EndingWith("ViewModel").AsInterfaces().RegisterAsLazySingleton();
			Mvx.RegisterType<IRaceRepository, RaceRepository>();
			RegisterAppStart(new AppStart());
		}
	}
}
