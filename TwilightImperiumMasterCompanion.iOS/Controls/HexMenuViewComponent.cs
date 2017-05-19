using System;
using System.Collections.Generic;
using CoreGraphics;
using TwilightImperiumMasterCompanion.Core;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class HexMenuViewComponent : UIView
	{
		HexViewComponent centerHex;
		UIImageView backgroundHexBase;

		public Dictionary<MenuPageType, HexViewComponent> Hexes
		{
			get;
			private set;
		}

		private int centerHexSize;
		private int altHexSize;

		public HexMenuViewComponent()
		{
			Hexes = new Dictionary<MenuPageType, HexViewComponent>();

			backgroundHexBase = new UIImageView();
			backgroundHexBase.Image = UIImage.FromBundle("HexagonBase");
			AddSubview(backgroundHexBase);

			centerHex = new HexViewComponent();
			AddSubview(centerHex);

			foreach (MenuPageType item in Enum.GetValues(typeof(MenuPageType)))
			{
				var hex = new HexViewComponent();
				Hexes.Add(item, hex);
				AddSubview(hex);
			}

			Hexes[MenuPageType.Rules].HexImage = UIImage.FromBundle("RulesIcon");
			Hexes[MenuPageType.Race].HexImage = UIImage.FromBundle("RaceIcon");
			Hexes[MenuPageType.Ship].HexImage = UIImage.FromBundle("ShipIcon");
			Hexes[MenuPageType.Planet].HexImage = UIImage.FromBundle("PlanetIcon");
			Hexes[MenuPageType.Research].HexImage = UIImage.FromBundle("ResearchIcon");
			Hexes[MenuPageType.Galaxy].HexImage = UIImage.FromBundle("GalaxyMapIcon");

			Hexes[MenuPageType.Rules].HexText = "Rules";
			Hexes[MenuPageType.Race].HexText = "Race";
			Hexes[MenuPageType.Ship].HexText = "Units";
			Hexes[MenuPageType.Planet].HexText = "Planets";
			Hexes[MenuPageType.Research].HexText = "Research";
			Hexes[MenuPageType.Galaxy].HexText = "Galaxy";
		}

		public override bool PointInside(CGPoint point, UIEvent uievent)
		{
			foreach (var hex in Hexes)
			{
				if (hex.Value.Frame.Contains(point))
				{

					return true;
				}
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

			foreach (MenuPageType item in Enum.GetValues(typeof(MenuPageType)))
			{
				Hexes[item].Frame = new CGRect(0, 0, altHexSize, altHexSize);
			}

			centerHex.Center = new CGPoint(Bounds.GetMidX(), Bounds.GetMidY());
			Hexes[MenuPageType.Rules].Center = new CGPoint(Bounds.GetMidX(), Bounds.GetMidY() + (centerHexHeight + altHexHeight) / 2.0 + 3);
			Hexes[MenuPageType.Race].Center = new CGPoint(Bounds.GetMidX(), Bounds.GetMidY() - (centerHexHeight + altHexHeight) / 2.0 - 3);
			Hexes[MenuPageType.Ship].Center = new CGPoint(Bounds.GetMidX() + Math.Cos(Math.PI / 6) * centerHexHeight / 2 + altHexHeight / 2 - 3, Bounds.GetMidY() + centerHexHeight * 0.25 + altHexHeight * 0.25);
			Hexes[MenuPageType.Planet].Center = new CGPoint(Bounds.GetMidX() + Math.Cos(Math.PI / 6) * centerHexHeight / 2 + altHexHeight / 2 - 3, Bounds.GetMidY() - centerHexHeight * 0.25 - altHexHeight * 0.25);
			Hexes[MenuPageType.Research].Center = new CGPoint(Bounds.GetMidX() - Math.Cos(Math.PI / 6) * centerHexHeight / 2 - altHexHeight / 2 + 3, Bounds.GetMidY() + centerHexHeight * 0.25 + altHexHeight * 0.25);
			Hexes[MenuPageType.Galaxy].Center = new CGPoint(Bounds.GetMidX() - Math.Cos(Math.PI / 6) * centerHexHeight / 2 - altHexHeight / 2 + 3, Bounds.GetMidY() - centerHexHeight * 0.25 - altHexHeight * 0.25);
		}
	}
}
