using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core
{
	public class MainViewModel : BaseViewModel
	{
		
		public ICommand JoinGameCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<JoinGameViewModel>());
			}
		}

		public MainViewModel()
		{
		}
	}
}
