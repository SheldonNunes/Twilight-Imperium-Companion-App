using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Platform;
using TwilightImperiumMasterCompanion.Core.ViewModels.Rules;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS.ViewControllers.Rules
{
	[MvxRootPresentation(WrapInNavigationController = true)]
    public class RulesTableView : MvxTableViewController<RulesTableViewModel>
    {
        private readonly INavigationBar navigationBar;

        public RulesTableView() : base(UITableViewStyle.Plain)
        {
			navigationBar = Mvx.Resolve<INavigationBar>();
            Title = RulesTableViewModel.Title;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			navigationBar.Initialize(this);

            var source = new MvxStandardTableViewSource(this.TableView, "TitleText Name;");
            TableView.Source = source;

			//Bindings
			var set = this.CreateBindingSet<RulesTableView, RulesTableViewModel>();
			set.Bind(source).For(v => v.ItemsSource).To(vm => vm.RuleBooks);
            set.Bind(source).For(v => v.SelectionChangedCommand).To(vm => vm.ShowRuleBook);
			set.Bind(NavigationItem.LeftBarButtonItem).To(vm => vm.ShowHexMainMenu);
            set.Apply();
		}
    }
}

