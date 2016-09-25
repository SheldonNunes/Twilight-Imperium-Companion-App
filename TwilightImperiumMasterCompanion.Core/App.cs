using System;
using MvvmCross;
using MvvmCross.Core.ViewModels;

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

			RegisterAppStart(new AppStart());
		}
	}
}
