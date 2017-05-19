using System;
using System.Collections.Generic;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class UnitReferenceView : MvxViewController
	{
		public UnitReferenceView()
			: base("UnitReferenceView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			if (ViewModel == null)
				return;
			
			var source = new UnitReferenceTableSource(tableView);

			tableView.Source = source;
			tableView.ReloadData();

			this.AddBindings(new Dictionary<object, string>
				{
					{source, "ItemsSource Units"}
				});
		}


	}

	public class UnitReferenceTableSource : MvxSimpleTableViewSource
	{
		public UnitReferenceTableSource(UITableView tableView)
			: base(tableView, "UnitReferenceTableViewCell", "UnitReferenceTableViewCell")
		{
		}
	}
}

