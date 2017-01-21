using System;
using System.Collections.Generic;
using System.Drawing;
using GXPEngine;

public class MyGame : Game //MyGame is a Game
{
	private List<NLineSegment> _lines;
	private List<Bullet> _bullets;
	private Player _player1;
	private Player _player2;
	//int index;
	private int _timer1;
	private int _timer2;

	private NLineSegment _lineE;
	private NLineSegment _lineF;
	private NLineSegment _lineG;
	private NLineSegment _lineH;

	public MyGame () : base(800, 600, false, false)
	{
		_lines = new List<NLineSegment>();
		_bullets = new List<Bullet>();
		targetFps = 60;
		_player1 = new Player("test1.png",Player.PlayerId.PLAYERONE);
		_player2 = new Player("test2.png",Player.PlayerId.PLAYERTWO);
		AddChild(_player1);
		AddChild(_player2);
		_lineE = new NLineSegment(new Vec2(0, 0), new Vec2(game.width,0), 0xffffff00, 4);
		AddChild(_lineE);
		_lines.Add(_lineE);
		_lineF = new NLineSegment(new Vec2(0, 0), new Vec2(0, game.height), 0xffffff00, 4);
		AddChild(_lineF);
		_lines.Add(_lineF);
		_lineG = new NLineSegment(new Vec2(game.width, 0), new Vec2(game.width, game.height), 0xffffff00, 4);
		AddChild(_lineG);
		_lines.Add(_lineG);
		_lineH = new NLineSegment(new Vec2(0, game.height), new Vec2(game.width, game.height), 0xffffff00, 4);
		AddChild(_lineH);
		_lines.Add(_lineH);
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
			Bullet bullet = new Bullet(_player1.ReticlePosition.Clone().Subtract(_player1.Position),_player1.Position.Clone());
			bullet.x = _player1.x;
			bullet.y = _player1.y;
			game.AddChild(bullet);
			_bullets.Add(bullet);
			Console.WriteLine(bullet.Velocity + "||" + _player1.ReticlePosition);
		}

		if (Input.GetKeyDown(Key.NUMPAD_7))
		{ 
			Bullet bullet = new Bullet(_player2.ReticlePosition.Clone().Subtract(_player2.Position), _player2.Position.Clone());
			bullet.x = _player2.x;
			bullet.y = _player2.y;
			game.AddChild(bullet);
			_bullets.Add(bullet);
			Console.WriteLine(bullet.Velocity + "||" + _player1.ReticlePosition);
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

		if (_player2.Active)
		{
			if (_player2.Wave.Size > 310)
			{
				_player2.Active = false;
				_player2.Canvas.graphics.Clear(Color.Transparent);
				_player1.alpha = 0.5f;
				_player2.Wave.Size = 10;
			}
			else {
				if (_timer2 > 10)
				{
					_player2.Wave.Size += 100;
					CreateWaves(_player2, new Pen(Color.Red));
					_timer2 = 0;
				}
				_timer2++;
			}

			if (IsCollidingWithCircle(_player1, _player2.Wave))
			{
				//circle of player1 is colliding with player 2
				_player1.alpha = 1f;
			}
			else {
				_player1.alpha = 0.5f;
			}
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
		foreach (Bullet bullet in _bullets)
		{

		}

		foreach (NLineSegment sprite in _lines)
		{

		}

		return 0;
	}

	public Vec2 CheckIntersection(Vec2 v1, Vec2 v2, Vec2 v3, Vec2 v4)
	{
		//_test.x = v4.x;
		//_test.y = v4.y;
		v1.Add(v2.Clone().Subtract(v1).Normal().Scale(_player1.width));
		v2.Add(v2.Clone().Subtract(v1).Normal().Scale(_player1.width));

		float ua = ((v4.x - v3.x) * (v1.y - v3.y) - (v4.y - v3.y) * (v1.x - v3.x)) / ((v4.y - v3.y) * (v2.x - v1.x) - (v4.x - v3.x) * (v2.y - v1.y));
		float ub = ((v2.x - v1.x) * (v1.y - v3.y) - (v2.y - v1.y) * (v1.x - v3.x)) / ((v4.y - v3.y) * (v2.x - v1.x) - (v4.x - v3.x) * (v2.y - v1.y));
		//Console.WriteLine(ua+"||"+ub);
		if (Mathf.Abs(ub) < 1)
			return new Vec2(v1.x + ua * (v2.x - v1.x), v1.y + ua * (v2.y - v1.y));
		else return Vec2.zero;
	}

	private void ActualBounce(Bullet ball, LineSegment line)
	{
		Vec2 _ballToLineStart = ball.Position.Clone().Subtract(line.start);
		float _distance = Mathf.Abs(_ballToLineStart.Dot(line.lineOnOriginNormalized.Normal().Clone()));
		Vec2 _intersection = CheckIntersection(line.start.Clone(), line.end.Clone(), ball.Position, ball.NextPositionBorder);//try on border
		float _distanceToStart = line.start.DistanceTo(ball.Position);
		float _distanceToEnd = line.end.DistanceTo(ball.Position);

		//_test.x = _intersection.x;
		//_test.y = _intersection.y;

		if (_distance < ball.Radius)
		{
			//Console.WriteLine((_distanceToStart > line.lineLenght || _distanceToEnd > line.lineLenght) && _distance < ball.radius);
			if (!((_distanceToStart > line.lineLenght + ball.Radius || _distanceToEnd > line.lineLenght + ball.Radius) && _distance < ball.Radius))
			{
				if (_intersection.x == 0 && _intersection.y == 0)
				{
					ball.Position.Subtract(ball.Velocity.Clone().Normalize().Scale(_distance));
				}
				else
				{
					ball.Position = _intersection.Clone();
				}
				ball.UpdateNextPosition();

				ball.Velocity.Reflect(line.lineOnOriginNormalized, 1);
				ball.UpdateNextPosition();

				//ball.velocity = Vec2.zero;
			}
		}
	}
	static void Main() 
	{
		new MyGame().Start();
	}
}
