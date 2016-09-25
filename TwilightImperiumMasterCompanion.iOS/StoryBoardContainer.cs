using System;
using MvvmCross.iOS.Views;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class StoryBoardContainer : MvxIosViewsContainer
	{

		protected override IMvxIosView CreateViewOfType(Type viewType, MvvmCross.Core.ViewModels.MvxViewModelRequest request)
		{
			return (IMvxIosView)UIStoryboard.FromName("Main", null).InstantiateViewController(viewType.Name);
		}
	}
}
