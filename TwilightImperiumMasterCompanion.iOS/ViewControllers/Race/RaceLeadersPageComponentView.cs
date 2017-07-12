using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using TwilightImperiumMasterCompanion.Core;
using TwilightImperiumMasterCompanion.Core.Converters;
using TwilightImperiumMasterCompanion.Core.ViewModels.Race;

namespace TwilightImperiumMasterCompanion.iOS
{
    [MvxChildPresentation]
    public partial class RaceLeadersPageComponentView : MvxViewController<RaceLeadersPageComponentViewModel>
    {
        private readonly MvxImageViewLoader imageLoader;

        public RaceLeadersPageComponentView() : base()
        {
            this.imageLoader = new MvxImageViewLoader(() => leaderImage);

			//Bindings
			this.DelayBind(
				() =>
				{
					var set = this.CreateBindingSet<RaceLeadersPageComponentView, RaceLeadersPageComponentViewModel>();
					set.Bind(leaderType).For(v => v.Text).To(vm => vm.Leader.LeaderType);
					set.Bind(imageLoader).To(vm => vm.Leader.LeaderType).WithConversion<RaceIconImagePathValueConverter>();
					set.Bind(leaderDescription).For(v => v.Text).To(vm => vm.Leader.Abilities).WithConversion<LeaderAbilityValueConverter>();
					set.Apply();

				});
        }
    }
}
