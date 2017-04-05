using System;
using MvvmCross;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace TwilightImperiumMasterCompanion.Core
{
	public class App : MvxApplication
	{
		public override void Initialize()
		{
			base.Initialize();

			/*
			 * 
			 * CreatableTypes.EndingWith.AsInterfaces.Singltonlazyload
			 * */
			Mvx.RegisterType<IUnitReferenceViewModel, UnitReferenceViewModel>();
			Mvx.RegisterType<IPurchaseUnitViewModel, PurchaseUnitViewModel>();

			Mvx.RegisterType<IRaceRepository, RaceRepository>();

			RegisterAppStart(new AppStart());
		}
	}
}
