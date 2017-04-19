using Foundation;
using System;
using UIKit;
using System.ComponentModel;
using CoreGraphics;
using CoreAnimation;
using System.Drawing;
using System.Runtime.InteropServices;

namespace TwilightImperiumMasterCompanion.iOS
{
	public partial class HexMenuViewComponent : UIView
	{

		public static UIBezierPath RoundedPolygonPath(CGRect rect, float lineWidth, int sides, float cornerRadius, float rotationOffset)
		{
			var path = UIBezierPath.Create();
			var theta = (2.0 * Math.PI) / sides; // How much to turn at every corner.s
			var width = Math.Min(rect.Size.Width, rect.Size.Height);        // Width of the square

			var center = new CGPoint(rect.X + width / 2.0, rect.Y + width / 2.0);

			// Radius of the circle that encircles the polygon
			// Notice that the radius is adjusted for the corners, that way the largest outer
			// dimension of the resulting shape is always exactly the width - linewidth
			var radius = (width - lineWidth + cornerRadius - (Math.Cos(theta) * cornerRadius)) / 2.0;

			// Start drawing at a point, which by default is at the right hand edge
			// but can be offset
			var angle = (rotationOffset);

			var corner = new CGPoint(center.X + (radius - cornerRadius) * Math.Cos(angle), center.Y + (radius - cornerRadius) * Math.Sin(angle));

			path.MoveTo(new CGPoint(corner.X + cornerRadius * Math.Cos(angle + theta), corner.Y + cornerRadius * Math.Sin(angle + theta)));
			for (int i = 0; i < sides; i++)
			{
				angle += (float)theta;
				corner = new CGPoint(center.X + (radius - cornerRadius) * Math.Cos(angle), center.Y + (radius - cornerRadius) * Math.Sin(angle));
				var tip = new CGPoint(center.X + radius * Math.Cos(angle), center.Y + radius * Math.Sin(angle));
				var start = new CGPoint(corner.X + cornerRadius * Math.Cos(angle - theta), corner.Y + cornerRadius * Math.Sin(angle - theta));
				var end = new CGPoint(corner.X + cornerRadius * Math.Cos(angle + theta), corner.Y + cornerRadius * Math.Sin(angle + theta));

				path.AddLineTo(start);
				path.AddQuadCurveToPoint(end, tip);
			}

			path.ClosePath();
			var bounds = path.Bounds;
			return path;
		}


		public UIImage HexImage
		{
			get { return hexImageView.Image; }
			set { hexImageView.Image = value; }
		}

		public UIImage HexIconImage
		{
			get { return hexIconImage.Image; }
			set { hexIconImage.Image = value; }
		}

		private CAShapeLayer mask;

		public HexMenuViewComponent() : base()
		{
		}

		public override void LayoutSubviews()
		{
			var lineWidth = 1f;
			base.LayoutSubviews();

			//NSBundle.MainBundle.LoadNib("HexMenuViewComponent", this, null);
			var path = RoundedPolygonPath(Bounds, lineWidth, 6, 10f, (float)(Math.PI / 2.0));

			mask = new CAShapeLayer();
			//mask.Frame = Frame;
			//mask.Bounds = Bounds;

			mask.Path = path.CGPath;
			mask.LineWidth = lineWidth;
			mask.FillColor = ColorConstants.BLUE_PRIMARY.CGColor;
			mask.StrokeColor = UIColor.Black.CGColor;
			mask.Frame = this.Bounds;

			this.Layer.InsertSublayer(mask, 0);
			mask.AnchorPoint = new CGPoint(0.5, 0.5);
			//this.TouchesBegan += (arg1, arg2) => mask.FillColor = ColorConstants.ORANGE_PRIMARY;

			mask.AffineTransform = CGAffineTransform.MakeRotation((float)Math.PI / 6);
			//this.AddSubview(rootView);
			//rootView.BackgroundColor = UIColor.Clear;
			//HexImage = UIImage.FromBundle("HexagonInactive");
			//HexIconImage = UIImage.FromBundle("PlanetIcon");
		}

		public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
			base.TouchesBegan(touches, evt);
			mask.FillColor = ColorConstants.ORANGE_PRIMARY.CGColor;

		}

		public override bool PointInside(CGPoint point, UIEvent uievent)
		{;
			return mask.Path.ContainsPoint(point, false);
		}
	}
}