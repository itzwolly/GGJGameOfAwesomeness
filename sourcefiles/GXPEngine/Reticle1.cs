using System;
namespace GXPEngine
{
	public class Reticle1:Sprite
	{
		public Reticle1():base("reticle1.png")
		{
			SetOrigin(width / 2, height / 2);
		}

		public void Update()
		{
			if (Input.GetKey(Key.T))
				y -= 10;
			if (Input.GetKey(Key.G))
				y += 10;
			if (Input.GetKey(Key.F))
				x -= 10;
			if (Input.GetKey(Key.H))
				x += 10;
		}
	}
}
