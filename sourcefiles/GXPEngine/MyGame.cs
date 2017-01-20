using System;
using System.Collections.Generic;
using System.Drawing;
using GXPEngine;

public class MyGame : Game //MyGame is a Game
{	

	private Canvas _canvas1;
	private Canvas _canvas2;
	private Player _player1;
	private Player _player2;
	private int _size1;
	private int _size2;
	private bool _active1;
	private bool _active2;
	private int _wait1;
	private int _wait2;
	private float _x1;
	private float _y1;
	private float _x2;
	private float _y2;
	private Circle _circle1;
	private Circle _circle2;


	public MyGame () : base(800, 600, false, false)
	{
		targetFps = 60;
		_player1 = new Player("test1.png");
		_player2 = new Player("test2.png");
		AddChild(_player1);
		AddChild(_player2);
		_circle1 = new Circle(0,0,0);
		_circle2 = new Circle(0, 0, 0);
		_size1 = 10;
		_size2 = 10;
		_canvas1 = new Canvas(800, 600);
		AddChild(_canvas1);
		_canvas2 = new Canvas(800, 600);
		AddChild(_canvas2);
	}

	void Update ()
	{
		PlayerMovement();
		if (Input.GetMouseButtonDown(1))
		{
			_player1.Position.y = Input.mouseY;
			_player1.Position.x = Input.mouseX;
			_player1.alpha = 100;
		}
		if (Input.GetMouseButtonDown(2))
		{
			_player2.Position.y = Input.mouseY;
			_player2.Position.x = Input.mouseX;
			_player2.alpha = 100;
		}
		if (Input.GetKeyDown(Key.V))
		{
			_active1 = true;
			_x1 = _player1.x;
			_y1 = _player1.y;
			CreateThemWaves(_x1, _y1, ref _size1, new Pen(Color.Red),_circle1,_canvas1);
		}
		if (Input.GetKeyDown(Key.NUMPAD_1))
		{
			_active2= true;
			_x2 = _player2.x;
			_y2 = _player2.y;
			CreateThemWaves(_x2, _y2, ref _size2, new Pen(Color.Green),_circle2,_canvas2);
		}
		if (Input.GetKeyDown(Key.SEMICOLON))
		{ 
		}

		if (_active1)
		{

			CheckIfInCircle(_circle1);

			if(_wait1==10)
			{
				CreateThemWaves(_x1, _y1, ref _size1,new Pen(Color.Red),_circle1,_canvas1);
				if (_size1 >= 510)
				{
					_size1 = 10;
					_active1 = false;
					_canvas1.graphics.Clear(Color.Transparent);
					//move the circle reset to a function, posibly that also does the clears
					_circle1.Position=Vec2.zero;
					_circle1.Size = 0;
					_player1.alpha = 100;
					_player2.alpha = 100;
				}
				_wait1 = 0;
			}
			_wait1++;
		}

		if (_active2)
		{

			CheckIfInCircle(_circle2);

			if (_wait2 == 10)
			{
				CreateThemWaves(_x2, _y2, ref _size2, new Pen(Color.Green),_circle2,_canvas2);
				if (_size2 >= 510)
				{
					_size2 = 10;
					_active2 = false;
					_canvas2.graphics.Clear(Color.Transparent);
					//move the circle reset to a function, posibly that also does the clears
					_circle2.Position = Vec2.zero;
					_circle2.Size = 0;
					_player1.alpha = 100;
					_player2.alpha = 100;
				}
				_wait2 = 0;
			}
			_wait2++;
		}

	}

	private void CreateThemWaves(float pX, float pY,ref int pSize,Pen pen,Circle circle,Canvas canvas)
	{
		canvas.graphics.Clear(Color.Transparent);
		circle.Size = pSize;
		circle.Position.x = pX;
		circle.Position.y = pY;
		canvas.graphics.DrawEllipse(pen,pX-pSize/2, pY- pSize / 2, pSize, pSize);
		pSize += 100;
	}

	private void CheckIfInCircle(Circle pCircle)
	{
		if (pCircle.Position.DistanceTo(_player1.Position) <= pCircle.Size/2)
			_player1.alpha=10;
		if (pCircle.Position.DistanceTo(_player2.Position) <= pCircle.Size / 2)
			_player2.alpha = 10;
	}

	private void PlayerMovement()
	{
		if (Input.GetKey(Key.W))
			_player1.Position.y -= 10;
		if (Input.GetKey(Key.S))
			_player1.Position.y += 10;
		if (Input.GetKey(Key.A))
			_player1.Position.x -= 10;
		if (Input.GetKey(Key.D))
			_player1.Position.x += 10;
		if (Input.GetKey(Key.UP))
			_player2.Position.y -= 10;
		if (Input.GetKey(Key.DOWN))
			_player2.Position.y += 10;
		if (Input.GetKey(Key.LEFT))
			_player2.Position.x -= 10;
		if (Input.GetKey(Key.RIGHT))
			_player2.Position.x += 10;
	}

	//system starts here
	static void Main() 
	{
		new MyGame().Start();
	}
}
