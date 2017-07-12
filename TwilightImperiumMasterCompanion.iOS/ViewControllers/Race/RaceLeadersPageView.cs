using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using TwilightImperiumMasterCompanion.Core;
using MvvmCross.Platform;
using UIKit;
using CoreGraphics;
using MvvmCross.Binding.BindingContext;

namespace TwilightImperiumMasterCompanion.iOS.ViewControllers.Race
{
    [MvxTabPresentation(WrapInNavigationController = true)]
    public class RaceLeadersPageView : MvxPageViewController<RaceLeadersPageViewModel>
    {
        private readonly INavigationBar navigationBar;
        private UIPageControl pageControl;

        public RaceLeadersPageView() : base()
        {
            this.Title = RaceLeadersPageViewModel.Title;
            navigationBar = Mvx.Resolve<INavigationBar>();
            pageControl = new UIPageControl();
        }

        private int index;
        public int Index
        {
            get { return index; }
            set
            {
                pageControl.CurrentPage = value;
                index = value;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.View.BackgroundColor = ColorConstants.WHITE;
            navigationBar.Initialize(this);

			
            pageControl.Pages = ViewModel.LeadersCount;

			//Bindings
            var set = this.CreateBindingSet<RaceLeadersPageView, RaceLeadersPageViewModel>();
            set.Bind(this).For(v => v.Index).To(vm => vm.PageIndex);
            set.Apply();



            View.AddSubview(pageControl);
            EdgesForExtendedLayout = UIRectEdge.None;
        }

        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            pageControl.Frame = new CGRect(0, View.Bounds.Height - 40, View.Bounds.Width, 25);

        }


    }
}
