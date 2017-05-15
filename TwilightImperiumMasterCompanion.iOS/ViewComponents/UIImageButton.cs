using Foundation;
using System;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Platform;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class UIImageButton : UIButton
	{
		private MvxImageViewLoader _imageHelper;

		public string ImageUrl
		{
			get { return _imageHelper.ImageUrl; }
			set { _imageHelper.ImageUrl = value; }
		}

		public UIImageButton(IntPtr handle) : base(handle)
		{
			//_imageHelper = Mvx.Resolve<MvxImageViewLoader>();
			_imageHelper = new MvxImageViewLoader(() => this.ImageView);
			ImageUrl = "res:PDSIcon";

		}



		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			ImageUrl = "res:PDSIcon";
		}

		//public override void LayoutSubviews()
		//{
		//	base.LayoutSubviews();
		//	this.ImageView.Image = UIImage.FromBundle("PDSIcon");
		//	this.ImageView.Frame = this.Bounds;
		//	this.SetImage(UIImage.FromBundle("PDSIcon"), UIControlState.Normal);
		//}

	}
}