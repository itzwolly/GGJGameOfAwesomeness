using System;
namespace GXPEngine
{
	public class Player:Sprite
	{
		public Vec2 Position;
		public Vec2 Velocity;
		public Vec2 Reticle;
		public Reticle1 _reticle1;
		public Reticle2 _reticle2;
		public Player(string filename):base(filename)
		{
			Position = new Vec2();
			Reticle = new Vec2(game.width / 2, game.height / 2);
			SetOrigin(width / 2, height / 2);
			if (filename == "test1.png")
			{
				_reticle1 = new Reticle1();
				game.AddChild(_reticle1);
			}
			else
			{
				_reticle2 = new Reticle2();
				game.AddChild(_reticle2);
			}	
		}

		public void Update()
		{
			x = Position.x;
			y = Position.y;
		}
	}
}
