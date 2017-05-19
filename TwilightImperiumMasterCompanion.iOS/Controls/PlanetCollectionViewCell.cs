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

        private readonly MvxImageViewLoader imageLoader;

		public PlanetCollectionViewCell(IntPtr handle) : base(handle)
        {
            //this.imageLoader = new MvxImageViewLoader(() => planetIcon);

        }

    }
}
