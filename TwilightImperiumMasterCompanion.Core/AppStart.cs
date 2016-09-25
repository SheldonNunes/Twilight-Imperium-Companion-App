using System;
using MvvmCross;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core
{
	public class AppStart : MvxNavigatingObject, IMvxAppStart
	{
		public async void Start(object hint = null)
		{
			ShowViewModel<MainViewModel>();
		}
	}
}
