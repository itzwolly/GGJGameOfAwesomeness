using System;
namespace GXPEngine
{
	public class Circle
	{
		public Vec2 Position;
		public int Size;

		public Circle(int pX,int pY, int pSize)
		{
			Position = new Vec2(pX, pY);
			Size = pSize;
		}
	}
}
