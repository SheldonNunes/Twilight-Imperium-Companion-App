using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Platform;
using TwilightImperiumMasterCompanion.Core;
using TwilightImperiumMasterCompanion.Core.ViewModels.Race;
using TwilightImperiumMasterCompanion.iOS.Controls;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS.ViewControllers.Race
{
	//[MvxTabPresentation(WrapInNavigationController = true)]
	public partial class RaceLeadersPageComponentView : MvxViewController<RaceLeadersPageComponentViewModel>
	{
		private readonly INavigationBar navigationBar;

		public RaceLeadersPageComponentView() : base()
		{
			//this.Title = RaceLeadersPageViewModel.Title;
			//navigationBar = Mvx.Resolve<INavigationBar>();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//CollectionView.BackgroundColor = UIColor.White;
			//navigationBar.Initialize(this);

			//CollectionView.RegisterNibForCell(LeaderCollectionViewCell.Nib, LeaderCollectionViewCell.CellIdentifier);
			//var source = new MvxCollectionViewSource(CollectionView, LeaderCollectionViewCell.CellIdentifier);

			//CollectionView.ContentInset = new UIEdgeInsets(10, 20, 10, 20);
			//CollectionView.Source = source;



			//Bindings
			//var set = this.CreateBindingSet<RaceLeadersPageComponentView, RaceLeadersPageViewModel>();
			//set.Bind(NavigationItem.LeftBarButtonItem).To(vm => vm.ShowHexMainMenu);
			////set.Bind(source).For(v => v.ItemsSource).To(vm => vm.Leaders);
			//set.Apply();

		}

		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();

			//((UICollectionViewFlowLayout)CollectionView.CollectionViewLayout).EstimatedItemSize = new CoreGraphics.CGSize(CollectionView.Bounds.Width - 40, 400);
		}
	}
}
