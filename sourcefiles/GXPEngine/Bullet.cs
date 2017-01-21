using System;
namespace GXPEngine
{
	public class Bullet:Sprite
	{
		public Vec2 Velocity;
		const float SPEED = 10;
		public Vec2 Position;
		public Vec2 NextPositionBorder;
		public float Radius;

		public Bullet(Vec2 pVelocity,Vec2 pPosition):base("test1.png")
		{
			Position = pPosition;
			Radius = height / 2;
			Velocity = pVelocity.Normalize().Scale(SPEED);
			SetOrigin(width / 2, height / 2);
			NextPositionBorder = Position.Clone().Add(Velocity.Clone().Normalize().Scale(Velocity.Length() + Radius));

		}

		public void Update()
		{
			Position.Add(Velocity);
			NextPositionBorder = Position.Clone().Add(Velocity.Clone().Normalize().Scale(Velocity.Length() + Radius));
			UpdateNextPosition();
		}

		public void UpdateNextPosition()
		{
			x = Position.x;
			y = Position.y;
			NextPositionBorder = Position.Clone().Add(Velocity.Clone().Normalize().Scale(Velocity.Length() + Radius));
		}
	}
}
