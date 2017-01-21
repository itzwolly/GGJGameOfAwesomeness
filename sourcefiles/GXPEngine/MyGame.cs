using System;
using System.Collections.Generic;
using System.Drawing;
using GXPEngine;

public class MyGame : Game //MyGame is a Game
{
	private List<Sprite> _collidables;

	private Player _player1;
	private Player _player2;

	private int _timer1;


	public MyGame () : base(800, 600, false, false)
	{
		_collidables = new List<Sprite>();
		targetFps = 60;
		_player1 = new Player("test1.png", Player.PlayerId.PLAYERONE);
		_player2 = new Player("test2.png", Player.PlayerId.PLAYERTWO);
		AddChild(_player1);
		AddChild(_player2);
	}

	void Update ()
	{
		PlayerMovement();
		if (Input.GetMouseButtonDown(1))
		{
			_player1.Position.y = Input.mouseY;
			_player1.Position.x = Input.mouseX;
			_player1.alpha = 1f;
		}

		if (Input.GetMouseButtonDown(2))
		{
			_player2.Position.y = Input.mouseY;
			_player2.Position.x = Input.mouseX;
			_player2.alpha = 1f;
		}

		if (Input.GetKeyDown(Key.R))
		{
			Bullet bullet = new Bullet();
			bullet.x = _player1.x;
			bullet.y = _player1.y;
			AddChild(bullet);
			_collidables.Add(bullet);
		}

		if (Input.GetKeyDown(Key.NUMPAD_7))
		{ 
			Bullet bullet = new Bullet();
			bullet.x = _player2.x;
			bullet.y = _player2.y;
			AddChild(bullet);
			_collidables.Add(bullet);
		}

		if (Input.GetKeyDown(Key.V))
		{
			_player1.Active = true;
			_player1.X = _player1.x;
			_player1.Y = _player1.y;
			_player1.Wave.Position = _player1.Position.Clone();
			CreateWaves(_player1, new Pen(Color.Red));
			_player1.Wave.Size = 10;
		}

		if (Input.GetKeyDown(Key.NUMPAD_1))
		{
			_player2.Active = true;
			_player2.X = _player2.x;
			_player2.Y = _player2.y;
			CreateWaves(_player2, new Pen(Color.Green));
		}

		if (_player1.Active)
		{
			if (_player1.Wave.Size > 310)
			{
				_player1.Active = false;
				_player1.Canvas.graphics.Clear(Color.Transparent);
				_player2.alpha = 0.5f;
				_player1.Wave.Size = 10;
			} else {
				if (_timer1 > 10)
				{
					_player1.Wave.Size += 100;
					CreateWaves(_player1, new Pen(Color.Red));
					_timer1 = 0;
				}
				_timer1++;
			}

			if (IsCollidingWithCircle(_player2, _player1.Wave))
			{
				//circle of player1 is colliding with player 2
				_player2.alpha = 1f;
			} else {
				_player2.alpha = 0.5f;
			}
		}

		//Console.WriteLine(_timer1 + " SEPERATOR " + _player1.Wave.Size);

		if (_player2.Active)
		{
			//IsCollidingWithCircle();

	//        if (_player2.Wait == 10)
	//        {
				//_player2.Size += 100;
	//            CreateWaves(_player2, new Pen(Color.Green));
	//            if (_player2.Size >= 310)
	//            {
	//                _player2.Size = 10;
	//                _player2.Active = false;
	//                _player2.Canvas.graphics.Clear(Color.Transparent);
	//                //move the circle reset to a function, posibly that also does the clears
	//                _player2.Wave.Position = Vec2.zero;
	//                _player2.Wave.Size = 0;
				//	_player1.alpha = 0.5f;
	//            }
	//            _player2.Wait = 0;
	//        }
	//        _player2.Wait++;
		}

	}

	private void CreateWaves(Player pPlayer, Pen pPen)
	{
		pPlayer.Canvas.graphics.Clear(Color.Transparent);
		pPlayer.Wave.Position.x = pPlayer.X;
		pPlayer.Wave.Position.y = pPlayer.Y;
		pPlayer.Canvas.graphics.DrawEllipse(pPen, pPlayer.X - pPlayer.Wave.Size / 2, pPlayer.Y - pPlayer.Wave.Size / 2, pPlayer.Wave.Size, pPlayer.Wave.Size);
	}

	private bool IsCollidingWithCircle(Player pPlayer, Circle pCircle)
	{
		if (pCircle.Position.DistanceTo(pPlayer.Position) - pPlayer.height / 2 <= pCircle.Size / 2)
		{
			return true;
		}
		return false;
	}

	private void PlayerMovement()
	{
		if (Input.GetKey(Key.W))
			_player1.Position.y -= 1;
		if (Input.GetKey(Key.S))
			_player1.Position.y += 1;
		if (Input.GetKey(Key.A))
			_player1.Position.x -= 1;
		if (Input.GetKey(Key.D))
			_player1.Position.x += 1;
		if (Input.GetKey(Key.UP))
			_player2.Position.y -= 1;
		if (Input.GetKey(Key.DOWN))
			_player2.Position.y += 1;
		if (Input.GetKey(Key.LEFT))
			_player2.Position.x -= 1;
		if (Input.GetKey(Key.RIGHT))
			_player2.Position.x += 1;
	}

	//system starts here
	public int CheckCollision(Sprite other)
	{
		foreach (Sprite sprite in _collidables)
		{

		}
		return 0;
	}
	static void Main() 
	{
		new MyGame().Start();
	}
}
