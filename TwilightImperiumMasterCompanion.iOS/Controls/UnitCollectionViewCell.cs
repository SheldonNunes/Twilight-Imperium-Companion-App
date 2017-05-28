using System;

using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS.Controls
{
    public partial class UnitCollectionViewCell : MvxCollectionViewCell
    {
        public static readonly NSString Key = new NSString("UnitCollectionViewCell");
		public static readonly UINib Nib = UINib.FromName("UnitCollectionViewCell", NSBundle.MainBundle);

        private const string BindingText =
        "CellName Quantity;" +
        "CellImage Image;";

        //public string CellName
        //{
        //    get { return cellNameLabel.Text; }
        //    set
        //    {
        //        cellNameLabel.Text = value;
        //    }
        //}

        //public string CellImage
        //{
        //    set { cellImageView.Image = UIImage.FromBundle(value); }
        //}

        private readonly MvxImageViewLoader imageLoader;

        protected UnitCollectionViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
