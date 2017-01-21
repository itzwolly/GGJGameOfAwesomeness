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

		private Canvas _canvas;
		private Circle _wave;
		private int _size;
		private bool _active;
		private int _wait;
		private float _x;
		private float _y;

		public Canvas Canvas {
			get { return _canvas; }
			set { _canvas = value; }
		}
		public Circle Wave {
			get { return _wave; }
			set { _wave = value; }
		}
		public int Size {
			get { return _size; }
			set { _size = value; }
		}
		public bool Active {
			get { return _active; }
			set { _active = value; }
		}
		public int Wait {
			get { return _wait; }
			set { _wait = value; }
		}
		public float X {
			get { return _x; }
			set { _x = value; }
		}
		public float Y {
			get { return _y; }
			set { _y = value; }
		}


		public Player(string filename):base(filename)
		{
			Position = new Vec2();
			Reticle = new Vec2(game.width / 2, game.height / 2);
			SetOrigin(width / 2, height / 2);

			_wave = new Circle(0, 0, 0);
			_size = 10;
			_canvas = new Canvas(800, 600);
			game.AddChild(_canvas);

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

		public int GetSize()
		{
			return _size;
		}
	}
}
