using System;
using System.Collections.Generic;
using System.Drawing;
using GXPEngine;

public class MyGame : Game //MyGame is a Game
{
    private List<Sprite> _collidables;

    private Player _player1;
    private Player _player2;


    public MyGame () : base(800, 600, false, false)
    {
        _collidables = new List<Sprite>();
        targetFps = 60;
        _player1 = new Player("test1.png");
        _player2 = new Player("test2.png");
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
            _player1.alpha = 100;
        }

        if (Input.GetMouseButtonDown(2))
        {
            _player2.Position.y = Input.mouseY;
            _player2.Position.x = Input.mouseX;
            _player2.alpha = 100;
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
            CreateWaves(_player1, new Pen(Color.Red));
        }

        if (Input.GetKeyDown(Key.NUMPAD_1))
        {
            _player2.Active = true;
            _player2.X = _player2.x;
            _player2.Y = _player2.y;
            CreateWaves(_player2, new Pen(Color.Green));
        }

        if (Input.GetKeyDown(Key.SEMICOLON))
        { 

        }

        if (_player1.Active)
        {
            CheckIfInCircle();

            if(_player1.Wait == 10)
            {
                CreateWaves(_player1, new Pen(Color.Red));
                _player1.Size += 100;
                if (_player1.Size >= 510)
                {
                    _player1.Size = 10;
                    _player1.Active = false;
                    _player1.Canvas.graphics.Clear(Color.Transparent);
                    //move the circle reset to a function, posibly that also does the clears
                    _player1.Wave.Position = Vec2.zero;
                    _player1.Wave.Size = 0;
                    _player1.alpha = 100;
                    _player2.alpha = 100;
                }
                _player1.Wait = 0;
            }
            _player1.Wait++;
        }

        Console.WriteLine("Player1 X,Y = " + _player1.X + ", " + _player1.Y + " ~ " + "Player1 x,y = " + _player1.x + ", " +  _player1.y);
        Console.WriteLine(_player1.Wave.Position.x + ", " + _player1.Wave.Position.y);

        if (_player2.Active)
        {
            CheckIfInCircle();

            if (_player2.Wait == 10)
            {
                CreateWaves(_player2, new Pen(Color.Green));
                _player2.Size += 100;
                if (_player2.Size >= 510)
                {
                    _player2.Size = 10;
                    _player2.Active = false;
                    _player2.Canvas.graphics.Clear(Color.Transparent);
                    //move the circle reset to a function, posibly that also does the clears
                    _player2.Wave.Position = Vec2.zero;
                    _player2.Wave.Size = 0;
                    _player1.alpha = 100;
                    _player2.alpha = 100;
                }
                _player2.Wait = 0;
            }
            _player2.Wait++;
        }

    }

    private void CreateWaves(Player pPlayer, Pen pPen)
    {
        //float pX, float pY, Pen pen, Circle circle, Canvas canvas
        pPlayer.Canvas.graphics.Clear(Color.Transparent);
        pPlayer.Wave.Position.x = pPlayer.X;
        pPlayer.Wave.Position.y = pPlayer.Y;
        pPlayer.Canvas.graphics.DrawEllipse(pPen, pPlayer.X - pPlayer.Size / 2, pPlayer.Y - pPlayer.Size / 2, pPlayer.Size, pPlayer.Size);
    }

    private void CheckIfInCircle()
    {
        if (_player1.Wave.Position.DistanceTo(_player1.Position) <= _player1.Size / 2)
        {
            _player2.alpha = 1;
        }
        if (_player2.Wave.Position.DistanceTo(_player2.Position) <= _player2.Size / 2)
        {
            _player1.alpha = 1;
        }
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
