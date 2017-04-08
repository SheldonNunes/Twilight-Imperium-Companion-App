using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using System.Collections.Generic;
using MvvmCross.Binding.iOS.Views;

namespace TwilightImperiumMasterCompanion.iOS
{
	[MvxFromStoryboard(StoryboardName = "UnitReference")]
    public partial class PurchaseUnitView : MvxViewController
    {
        public PurchaseUnitView (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

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