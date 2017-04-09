using System;
using System.Collections.Generic;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class PurchaseUnitView : MvxViewController
	{
		public PurchaseUnitView() : base("PurchaseUnitView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			if (ViewModel == null)
				return;

			var source = new PurchaseTableSource(tableView);

			tableView.Source = source;
			tableView.ReloadData();

			this.AddBindings(new Dictionary<object, string>
				{
					{source, "ItemsSource Ships"}
				});
		}
	}

	public class PurchaseTableSource : MvxSimpleTableViewSource
	{
		public PurchaseTableSource(UITableView tableView)
			: base(tableView, "PurchaseUnitTableViewCell", "PurchaseUnitTableViewCell")
		{
		}
	}
}

