using Foundation;
using System;
using UIKit;
using MvvmCross.iOS.Views;
using TwilightImperiumMasterCompanion.Core;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using System.Collections.Generic;
using ObjCRuntime;

namespace TwilightImperiumMasterCompanion.iOS
{
	[MvxFromStoryboard(StoryboardName = "UnitReference")]
	public partial class UnitReferenceView : MvxViewController
	{
		public UnitReferenceView(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			NavigationController.NavigationBar.Hidden = true;
			var source =  new UnitReferenceTableSource(tableView);

			tableView.Source = source;
			tableView.ReloadData();

			this.AddBindings(new Dictionary<object, string>
				{
					{source, "ItemsSource Ships"}
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