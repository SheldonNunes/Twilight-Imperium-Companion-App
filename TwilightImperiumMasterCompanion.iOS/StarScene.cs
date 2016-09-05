using System;
using System.Drawing;
using Foundation;
using SpriteKit;
using UIKit;

namespace TwilightImperiumMasterCompanion.iOS
{
	public class StarScene : SKScene
	{
		public StarScene(SizeF size) : base(size)
		{
			this.ScaleMode = SKSceneScaleMode.AspectFill;
			this.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0);

			SKEmitterNode starParticleEmitter = NSKeyedUnarchiver.UnarchiveFile("./Particles/StarParticles.sks") as SKEmitterNode;
			starParticleEmitter.ParticleTexture = SKTexture.FromImageNamed("./Particles/starSprite.png");
			starParticleEmitter.Position = new PointF((float)this.Frame.Width, (float)this.Frame.Height);
			this.AddChild(starParticleEmitter);
		}
	}
}

