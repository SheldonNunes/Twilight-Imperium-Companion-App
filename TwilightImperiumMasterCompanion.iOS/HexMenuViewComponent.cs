using System;
using CoreGraphics;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class HexMenuViewComponent : UIView
	{
		HexViewComponent centerHex;
		UIImageView backgroundHexBase;

		public HexViewComponent[] Hexes
		{
			get;
			private set;
		}

		private int centerHexSize;
		private int altHexSize;

		public HexMenuViewComponent()
		{
			Hexes = new HexViewComponent[6];

			backgroundHexBase = new UIImageView();
			backgroundHexBase.Image = UIImage.FromBundle("HexagonBase");
			AddSubview(backgroundHexBase);

			centerHex = new HexViewComponent();
			AddSubview(centerHex);

			for (int i = 0; i < 6; i++)
			{
				var hex = new HexViewComponent();
				Hexes[i] = hex;
				AddSubview(hex);
			}

			Hexes[0].HexImage = UIImage.FromBundle("RulesIcon");
			Hexes[1].HexImage = UIImage.FromBundle("RaceIcon");
			Hexes[2].HexImage = UIImage.FromBundle("ShipIcon");
			Hexes[3].HexImage = UIImage.FromBundle("PlanetIcon");
			Hexes[4].HexImage = UIImage.FromBundle("ResearchIcon");
			Hexes[5].HexImage = UIImage.FromBundle("GalaxyMapIcon");

			Hexes[0].HexText = "Rules";
			Hexes[1].HexText = "Race";
			Hexes[2].HexText = "Units";
			Hexes[3].HexText = "Planets";
			Hexes[4].HexText = "Research";
			Hexes[5].HexText = "Galaxy";
		}

		public override bool PointInside(CGPoint point, UIEvent uievent)
		{
			for (int i = 0; i < 6; i++)
			{
				if (Hexes[i].Frame.Contains(point))
					return true;
			}
			return false;
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			var smallestScreenDimension = Math.Min(Frame.Width, Frame.Height);

			centerHexSize = (int)(smallestScreenDimension / 2.5);
			altHexSize = (int)(smallestScreenDimension / 2.75);

			var centerHexHeight = Math.Sqrt(3) * centerHexSize / 2;
			var altHexHeight = Math.Sqrt(3) * altHexSize / 2;

			backgroundHexBase.Frame = new CGRect(0, 0, smallestScreenDimension / 1 + 10, smallestScreenDimension / 1);
			backgroundHexBase.Center = new CGPoint(Bounds.GetMidX(), Bounds.GetMidY());

			centerHex.Frame = new CGRect(0, 0, centerHexSize, centerHexSize);
			for (int i = 0; i < 6; i++)
			{
				Hexes[i].Frame = new CGRect(0, 0, altHexSize, altHexSize);
			}


			centerHex.Center = new CGPoint(Bounds.GetMidX(), Bounds.GetMidY());
			Hexes[0].Center = new CGPoint(Bounds.GetMidX(), Bounds.GetMidY() + (centerHexHeight + altHexHeight) / 2.0 + 3);
			Hexes[1].Center = new CGPoint(Bounds.GetMidX(), Bounds.GetMidY() - (centerHexHeight + altHexHeight) / 2.0 - 3);
			Hexes[2].Center = new CGPoint(Bounds.GetMidX() + Math.Cos(Math.PI / 6) * centerHexHeight / 2 + altHexHeight / 2 - 3, Bounds.GetMidY() + centerHexHeight * 0.25 + altHexHeight * 0.25);
			Hexes[3].Center = new CGPoint(Bounds.GetMidX() + Math.Cos(Math.PI / 6) * centerHexHeight / 2 + altHexHeight / 2 - 3, Bounds.GetMidY() - centerHexHeight * 0.25 - altHexHeight * 0.25);
			Hexes[4].Center = new CGPoint(Bounds.GetMidX() - Math.Cos(Math.PI / 6) * centerHexHeight / 2 - altHexHeight / 2 + 3, Bounds.GetMidY() + centerHexHeight * 0.25 + altHexHeight * 0.25);
			Hexes[5].Center = new CGPoint(Bounds.GetMidX() - Math.Cos(Math.PI / 6) * centerHexHeight / 2 - altHexHeight / 2 + 3, Bounds.GetMidY() - centerHexHeight * 0.25 - altHexHeight * 0.25);
		}
	}
}
