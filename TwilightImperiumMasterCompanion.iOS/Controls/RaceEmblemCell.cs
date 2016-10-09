using System;
using System.Drawing;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class RaceEmblemCell : MvxCollectionViewCell
	{
		public static readonly NSString CellId = new NSString("RaceEmblemCell");

		private UIImageView _emblem;

		public UIImage Emblem
		{
			get
			{
				return _emblem.Image;
			}
			set
			{
				_emblem.Image = value;
				SetNeedsDisplay();
			}
		}

		[Export("initWithFrame:")]
		RaceEmblemCell(RectangleF frame) : base(frame)
		{
			_emblem = new UIImageView(ContentView.Frame);
			_emblem.ContentMode = UIViewContentMode.ScaleAspectFit;

			BackgroundView = new UIView { BackgroundColor = UIColor.Orange };

			SelectedBackgroundView = new UIView { BackgroundColor = UIColor.Green };


			ContentView.AddSubview(_emblem);
		}
	}
}
