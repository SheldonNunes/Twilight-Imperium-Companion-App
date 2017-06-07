using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using TwilightImperiumMasterCompanion.Core.Model;
using TwilightImperiumMasterCompanion.Core.NavigationParameters;

namespace TwilightImperiumMasterCompanion.Core.ViewModels.Rules
{
    public class RulesViewModel : MvxViewModel<RuleBookNavigationParameter>
    {
        public RuleBook SelectedRuleBook
        {
            get;
            set;
        }

        public string RuleBookFileName
        {
            get;
            set;
        }

        public RulesViewModel()
        {
        }

        public override Task Initialize(RuleBookNavigationParameter parameter)
        {
            return Task.Run(() => {
                SelectedRuleBook = parameter.SelectedRuleBook;
                RuleBookFileName = SelectedRuleBook.Name.Replace(" ", String.Empty) + ".pdf";
            });
            
        }
    }
}
