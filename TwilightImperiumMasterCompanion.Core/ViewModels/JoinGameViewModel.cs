using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace TwilightImperiumMasterCompanion.Core
{
	public class JoinGameViewModel : BaseViewModel
	{
		private string _name;

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				RaisePropertyChanged(() => Name);
			}
		}

		private string _code;

		public string Code
		{
			get { return _code; }
			set
			{
				_code = value;
				RaisePropertyChanged(() => Code);
			}
		}

		public ICommand NavigateToRaceSelectionCommand
		{
			get
			{
				return new MvxCommand(() => ShowViewModel<RaceSelectionViewModel>());
			}
		}

		public JoinGameViewModel()
		{
			
		}
	}
}
