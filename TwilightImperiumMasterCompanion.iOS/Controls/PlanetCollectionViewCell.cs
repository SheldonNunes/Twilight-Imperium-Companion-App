using System;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS.Controls
{
    public partial class PlanetCollectionViewCell : MvxCollectionViewCell
    {
        public static readonly NSString CellIdentifier = new NSString("PlanetCollectionViewCell");
        public static readonly UINib Nib = UINib.FromName("PlanetCollectionViewCell", NSBundle.MainBundle);

        private const string BindingText =
            "CellName Title;" +
            "CellImage Image;";

		public string CellName
		{
            get { return cellNameLabel.Text; }
			set
			{
				cellNameLabel.Text = value;
			}
		}

        public string CellImage
		{
            set { cellImageView.Image = UIImage.FromBundle(value); }
		}

        private readonly MvxImageViewLoader imageLoader;

        public PlanetCollectionViewCell(IntPtr handle) : base(BindingText, handle)
        {
            this.imageLoader = new MvxImageViewLoader(() => cellImageView);

        }

    }
}
