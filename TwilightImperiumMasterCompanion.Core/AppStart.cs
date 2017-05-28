using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core
{
	public class AppStart : MvxNavigatingObject, IMvxAppStart
	{
		public void Start(object hint = null)
		{
			ShowViewModel<SelectStartingOptionViewModel>();
		}
	}
}
