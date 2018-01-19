using System;

using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS.Controls
{
    public partial class LeaderCollectionViewCell : MvxCollectionViewCell
    {
        public static readonly NSString CellIdentifier = new NSString("LeaderCollectionViewCell");
        public static readonly UINib Nib = UINib.FromName("LeaderCollectionViewCell", NSBundle.MainBundle);

        private const string BindingText =
            "LeaderName Name;" +
            "LeaderIcon Image;" +
            "LeaderTypeLabel LeaderType;" +
            "LeaderAbilitiesLabel Abilities, Converter = LeaderAbility;";

        public string LeaderName
        {
            get { return leaderNameLabel.Text; }
            set
            {
                leaderNameLabel.Text = value;
            }
        }

		public string LeaderTypeLabel
		{
            get { return leaderTypeLabel.Text; }
			set
			{
				leaderTypeLabel.Text = value;
			}
		}

        public string LeaderAbilitiesLabel
		{
            get { return leaderAbilities.Text; }
			set
			{
                leaderAbilities.Text = value;
			}
		}

        public string LeaderIcon
        {
            set { leaderImageView.Image = UIImage.FromBundle(value); }
        }

		private readonly MvxImageViewLoader imageLoader;

        public LeaderCollectionViewCell(IntPtr handle) : base(BindingText, handle)
        {
            this.imageLoader = new MvxImageViewLoader(() => leaderImageView);

		}
    }
}
