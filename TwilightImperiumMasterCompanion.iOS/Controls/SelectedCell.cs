using System;
using CoreGraphics;
using Foundation;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class SelectedCell : UIView
	{
		public CGPoint OriginalPosition
		{
			get;
			set;
		}

		public SelectedCell() : base()
		{
		}
	}
}
