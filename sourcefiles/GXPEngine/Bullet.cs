using System;
namespace GXPEngine
{
	public class Bullet:Sprite
	{
		public Vec2 Velocity;
		public Bullet():base("test1.png")
		{
			SetOrigin(width / 2, height / 2);
		}
	}
}
