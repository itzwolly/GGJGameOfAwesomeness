using System;
namespace GXPEngine
{
	public class Reticle2:Sprite
	{
		public Reticle2():base("reticle2.png")
		{
			SetOrigin(width / 2, height / 2);
		}

		public void Update()
		{
			if (Input.GetKey(Key.NUMPAD_8))
				y -= 10;
			if (Input.GetKey(Key.NUMPAD_5))
				y += 10;
			if (Input.GetKey(Key.NUMPAD_4))
				x -= 10;
			if (Input.GetKey(Key.NUMPAD_6))
				x += 10;
		}
	}
}
