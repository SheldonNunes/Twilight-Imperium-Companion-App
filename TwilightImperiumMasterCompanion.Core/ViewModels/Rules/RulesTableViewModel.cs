using System;
using System.Collections.Generic;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Model;
using TwilightImperiumMasterCompanion.Core.NavigationParameters;
using TwilightImperiumMasterCompanion.Core.Resources;

namespace TwilightImperiumMasterCompanion.Core.ViewModels.Rules
{
    public class RulesTableViewModel : MvxViewModel
    {
		public static string Title
		{
			get { return UIStrings.RuleBooks; }
		}

		private IMvxAsyncCommand showHexMainMenu;
		public IMvxAsyncCommand ShowHexMainMenu
		{
			get
			{
                showHexMainMenu = showHexMainMenu ?? new MvxAsyncCommand(() => navigationService.Navigate<HexMainMenuViewModel, MenuNavigationParameters>(new MenuNavigationParameters() { CurrentMenu = MenuPageType.Rules }));
				return showHexMainMenu;
			}
		}

		private MvxCommand<RuleBook> showRuleBook;
		public MvxCommand<RuleBook> ShowRuleBook
		{
			get
			{
                showRuleBook = showRuleBook ?? new MvxCommand<RuleBook>((ruleBook) => navigationService.Navigate<RulesViewModel, RuleBookNavigationParameter>(new RuleBookNavigationParameter() { SelectedRuleBook = ruleBook }));
				return showRuleBook;
			}
		}

        private IEnumerable<RuleBook> ruleBooks;
        public IEnumerable<RuleBook> RuleBooks
		{
			get { return ruleBooks; }
			set
			{
				ruleBooks = value;
				RaisePropertyChanged(() => RuleBooks);
			}
		}

		private readonly IMvxNavigationService navigationService;
        public RulesTableViewModel(IMvxNavigationService navigationService)
		{
			this.navigationService = navigationService;

            RuleBooks = new List<RuleBook>() {
                new RuleBook(){Name = "Base Rule Book"},
                new RuleBook(){Name = "Shattered Empires Rule Book"},
                new RuleBook(){Name = "Shard of the Throne Rule Book"},
            };
		}
    }
}
