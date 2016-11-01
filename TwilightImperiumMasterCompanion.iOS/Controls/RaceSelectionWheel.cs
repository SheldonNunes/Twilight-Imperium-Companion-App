using System;
using System.Linq;
using System.Collections;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using TwilightImperiumMasterCompanion.Core;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class RaceSelectionWheel : MvxView
	{
		private UIView _container;
		private double _deltaAngle;
		private CGAffineTransform _initialTransform;

		private List<UIImage> _images;

		private List<Race> _subsetList;
		private List<Race> _dataSource;

		public List<Race> DataSource
		{
			get 
			{ 
				return _dataSource;
			}
			set
			{
				_dataSource = value;
				CreateCircleDataSource();
				//reload layout
			}
		}

		public RaceSelectionWheel(CGRect frame)
		{
			this.Frame = frame;
			this.BackgroundColor = UIColor.Black;
			//TODO remove this
			//DataSource = new List<String>() { "1", "2", "3", "4", "5", "6" };
		}

		public override void Draw(CGRect rect)
		{
			base.Draw(rect);
			DrawWheel(rect);
		}

		private void DrawWheel(CGRect rect)
		{
			_container = new UIView(rect);
			var swipeGestureRecognizer = new UIPanGestureRecognizer();
			_container.AddGestureRecognizer(swipeGestureRecognizer);

			var numberOfSegments = _dataSource.Count - 1;
			nfloat angleSize = (nfloat)(2 * Math.PI / numberOfSegments);

			for (int i = 0; i < numberOfSegments; i++)
			{
				UIView segment = new UIView(new CGRect(0, 0, 150, 50));
				//segment.BackgroundColor = UIColor.Purple;
				segment.Layer.AnchorPoint = new CGPoint(1, 0.5);
				segment.Layer.Position = new CGPoint(_container.Bounds.Size.Width / 2.0, _container.Bounds.Size.Height/2.0);
				segment.Transform = CGAffineTransform.MakeRotation((nfloat)(Math.PI / 2 + angleSize * i));

				var race = (Race)DataSource[i];
				//150 = radius
				UIImageView image = new UIImageView(new CGRect(0, 0, 50, 50));
				//image.BackgroundColor = UIColor.Blue;
				image.Image = UIImage.FromBundle("Images/Races/Emblems/" + race.URIName);
				image.ContentMode = UIViewContentMode.ScaleAspectFit;
				image.Transform = CGAffineTransform.MakeRotation((nfloat)(- Math.PI / 2 - angleSize * i));
				//Moves the middle right to a given position

				segment.AddSubview(image);


				_container.AddSubview(segment);
			}
			AddSubview(_container);
		}

		public override void TouchesBegan(Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesBegan(touches, evt);
			UITouch touch = (UITouch) touches.First();

			CGPoint touchPoint = touch.LocationInView(this);
			// 2 - Calculate distance from center
			nfloat dx = touchPoint.X - _container.Center.X;
			nfloat dy = touchPoint.Y - _container.Center.Y;
			// 3 - Calculate arctangent value
			_deltaAngle = Math.Atan2(dy, dx);
			// 4 - Save current transform
			_initialTransform = _container.Transform;
		}

		public override void TouchesMoved(Foundation.NSSet touches, UIEvent evt)
		{
			//base.TouchesMoved(touches, evt);
			UITouch touch = (UITouch)touches.First();
			CGPoint touchPoint = touch.LocationInView(this);

			nfloat dx = touchPoint.X - _container.Center.X;
			nfloat dy = touchPoint.Y - _container.Center.Y;
			var ang = Math.Atan2(dy, dx);
			nfloat angleDifference = (nfloat) (_deltaAngle - ang);
			_container.Transform = CGAffineTransform.Rotate(_initialTransform, -angleDifference);
		}

		public void CreateCircleDataSource()
		{
			_subsetList = _dataSource.Take(4).ToList();
			var segmentTwo = _dataSource.Skip(_dataSource.Count - 4);
			_subsetList.AddRange(segmentTwo);
		}


	}
}
