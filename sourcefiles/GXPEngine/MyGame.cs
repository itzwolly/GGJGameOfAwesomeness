using System;
using System.Collections.Generic;
using System.Drawing;
using GXPEngine;
using System.IO;

public class MyGame : Game //MyGame is a Game
{
    private List<NLineSegment> _lines;
    private List<Bullet> _bullets;
    private Player _player1;
    private Player _player2;

    private int _timer1;
    private int _timer2;

    private NLineSegment _line;

    public MyGame()
        : base(1905, 1002, false, false) {
        targetFps = 60;

        _lines = new List<NLineSegment>();
        _bullets = new List<Bullet>();

        _player1 = new Player("test1.png", Player.PlayerId.PLAYERONE);
        _player2 = new Player("test2.png", Player.PlayerId.PLAYERTWO);
        AddChild(_player1);
        _player1.Position = new Vec2(game.width/12,7*height/8);
        AddChild(_player2);
        _player2.Position = new Vec2(11*game.width/12,height/8);

        CreateBoundary();
        CreateLevel();
    }

    private void CreateLevel() {
        NLineSegment line = new NLineSegment(new Vec2(game.width / 2, game.height / 6), new Vec2(game.width / 2, game.height / 3), 0xffffff00, 4);
        _lines.Add(line);
        line = new NLineSegment(new Vec2(game.width / 2-50, game.height / 3), new Vec2(game.width / 2+50, game.height / 3), 0xffffff00, 4);
        _lines.Add(line);
        line = new NLineSegment(new Vec2(game.width / 2-50, 2*game.height / 3), new Vec2(game.width / 2+50, 2*game.height / 3), 0xffffff00, 4);
        _lines.Add(line);
        line = new NLineSegment(new Vec2(game.width / 2, 2*game.height / 3), new Vec2(game.width / 2, 5*game.height / 6), 0xffffff00, 4);
        _lines.Add(line);

        line = new NLineSegment(new Vec2(3*game.width/10, game.height/2), new Vec2(4*game.width/10,game.height/2), 0xffffff00, 4);
        _lines.Add(line);
        line = new NLineSegment(new Vec2(6 * game.width / 10, game.height / 2), new Vec2(7 * game.width / 10, game.height / 2), 0xffffff00, 4);
        _lines.Add(line);
        line = new NLineSegment(new Vec2(4 * game.width / 10, game.height / 2-50), new Vec2(4 * game.width / 10, game.height / 2+50), 0xffffff00, 4);
        _lines.Add(line);
        line = new NLineSegment(new Vec2(6 * game.width / 10, game.height / 2-50), new Vec2(6 * game.width / 10, game.height / 2+50), 0xffffff00, 4);
        _lines.Add(line);

        line = new NLineSegment(new Vec2(1*game.width / 10, 4*game.height / 6), new Vec2(1*game.width / 10, 5*game.height / 6), 0xffffff00, 4);
        _lines.Add(line);
        line = new NLineSegment(new Vec2(game.width / 10, 5*game.height / 6), new Vec2(2*game.width / 10, 5*game.height / 6), 0xffffff00, 4);
        _lines.Add(line);
        line = new NLineSegment(new Vec2(9*game.width / 10, game.height / 6), new Vec2(9*game.width / 10, 2*game.height / 6), 0xffffff00, 4);
        _lines.Add(line);
        line = new NLineSegment(new Vec2(8*game.width / 10, game.height / 6), new Vec2(9*game.width / 10, game.height / 6), 0xffffff00, 4);
        _lines.Add(line);

        foreach (NLineSegment item in _lines) {
            AddChild(item);
        }
    }


    private void CreateBoundary() {
        _line = new NLineSegment(new Vec2(0, 0), new Vec2(game.width, 0), 0xffffff00, 4); // top
        _lines.Add(_line);
        _line = new NLineSegment(new Vec2(0, 0), new Vec2(0, game.height), 0xffffff00, 4); // bottom
        _lines.Add(_line);
        _line = new NLineSegment(new Vec2(game.width, 0), new Vec2(game.width, game.height), 0xffffff00, 4); // right
        _lines.Add(_line);
        _line = new NLineSegment(new Vec2(0, game.height), new Vec2(game.width, game.height), 0xffffff00, 4); // left
        _lines.Add(_line);
    }

    public void Update() {
        CheckCollision();
        ResolveColisionPlayer(_player1);
        ResolveColisionPlayer(_player2);
        //Console.WriteLine(_bullets.Count);
        PlayerMovement();
        if (Input.GetMouseButtonDown(1)) {
            _player1.Position.y = Input.mouseY;
            _player1.Position.x = Input.mouseX;
            _player1.alpha = 1f;
        }

        if (Input.GetMouseButtonDown(2)) {
            _player2.Position.y = Input.mouseY;
            _player2.Position.x = Input.mouseX;
            _player2.alpha = 1f;
        }


        if (Input.GetKeyDown(Key.R)) {
            Bullet bullet = new Bullet(_player1.ReticlePosition.Clone().Subtract(_player1.Position), _player1.Position.Clone(), 1);
            bullet.x = _player1.x;
            bullet.y = _player1.y;
            game.AddChild(bullet);
            _bullets.Add(bullet);
            //Console.WriteLine(bullet.Velocity + "||" + _player1.ReticlePosition);
        }

        if (Input.GetKeyDown(Key.NUMPAD_7)) {
            Bullet bullet = new Bullet(_player2.ReticlePosition.Clone().Subtract(_player2.Position), _player2.Position.Clone(), 2);
            bullet.x = _player2.x;
            bullet.y = _player2.y;
            game.AddChild(bullet);
            _bullets.Add(bullet);
            //Console.WriteLine(bullet.Velocity + "||" + _player1.ReticlePosition);
        }

        if (Input.GetKeyDown(Key.V)) {
            _player1.Active = true;
            _player1.X = _player1.x;
            _player1.Y = _player1.y;
            _player1.Wave.Position = _player1.Position.Clone();
            CreateWaves(_player1, new Pen(Color.Red));
            _player1.Wave.Size = 10;
        }

        if (Input.GetKeyDown(Key.NUMPAD_1)) {
            _player2.Active = true;
            _player2.X = _player2.x;
            _player2.Y = _player2.y;
            CreateWaves(_player2, new Pen(Color.Green));
        }

        if (_player1.Active) {
            if (_player1.Wave.Size > 310) {
                _player1.Active = false;
                _player1.Canvas.graphics.Clear(Color.Transparent);
                _player2.alpha = 0.5f;
                _player1.Wave.Size = 10;
                _player1.Wave.UpdateCircleSize(_player1.Wave.Size);
                RemoveChild(_player1.Wave);
            } else {
                if (_timer1 > 10) {
                    _player1.Wave.Size += 100;
                    CreateWaves(_player1, new Pen(Color.Red, 10));
                    _player1.Wave.UpdateCircleSize(_player1.Wave.Size);
                    _timer1 = 0;
                }
                _timer1++;
            }

            if (IsCollidingWithCircle(_player2, _player1.Wave)) {
                //circle of player1 is colliding with player 2
                _player2.alpha = 1f;
            } else {
                _player2.alpha = 0.5f;
            }
        }

        if (_player2.Active) {
            if (_player2.Wave.Size > 310) {
                _player2.Active = false;
                _player2.Canvas.graphics.Clear(Color.Transparent);
                _player1.alpha = 0.5f;
                _player2.Wave.Size = 10;
                _player2.Wave.UpdateCircleSize(_player2.Wave.Size);
                RemoveChild(_player2.Wave);
            } else {
                if (_timer2 > 10) {
                    _player2.Wave.Size += 100;
                    CreateWaves(_player2, new Pen(Color.Red));
                    _player2.Wave.UpdateCircleSize(_player2.Wave.Size);
                    _timer2 = 0;
                }
                _timer2++;
            }

            if (IsCollidingWithCircle(_player1, _player2.Wave)) {
                //circle of player1 is colliding with player 2
                _player1.alpha = 1f;
            } else {
                _player1.alpha = 0.5f;
            }
        }

    }

    private void CreateWaves(Player pPlayer, Pen pPen) {
        pPlayer.Wave.Position.x = pPlayer.X;
        pPlayer.Wave.Position.y = pPlayer.Y;
        AddChild(pPlayer.Wave);

        Console.WriteLine(pPlayer.Wave.x + ", " + pPlayer.Wave.y);
        Console.WriteLine(pPlayer.Wave.Position.x + ", " + pPlayer.Wave.Position.y);
    }

    private bool IsCollidingWithCircle(Player pPlayer, Circle pCircle) {
        if (pCircle.Position.DistanceTo(pPlayer.Position) - pPlayer.height / 2 <= pCircle.Size / 2) {
            return true;
        }
        return false;
    }

    private void PlayerMovement() {
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
    public void CheckCollision() {
        foreach (Bullet bullet in _bullets) {
            if (_player1.Position.DistanceTo(bullet.Position) <= bullet.Radius + _player1.height && bullet.PlayerNumber == 2) {
                _player1.alpha = 1;
                bullet.Destroy();
                _bullets.Remove(bullet);
                ResetPlayer(_player1);
                return;
            }
            if (_player2.Position.DistanceTo(bullet.Position) <= bullet.Radius + _player2.height && bullet.PlayerNumber == 1) {
                _player2.alpha = 1;
                bullet.Destroy();
                _bullets.Remove(bullet);
                ResetPlayer(_player2);
                return;
            }
            foreach (NLineSegment line in _lines) {
                if (CheckLineBullet(bullet, line)) {
                    bullet.Destroy();
                    _bullets.Remove(bullet);
                    return;
                }
            }
        }
    }

    private void ResetPlayer(Player player) {
        player.alpha = 0.5f;
    }

    private Vec2 CheckIntersection(Vec2 v1, Vec2 v2, Vec2 v3, Vec2 v4) {
        v1.Add(v2.Clone().Subtract(v1).Normal().Scale(_player1.width));
        v2.Add(v2.Clone().Subtract(v1).Normal().Scale(_player1.width));

        float ua = ((v4.x - v3.x) * (v1.y - v3.y) - (v4.y - v3.y) * (v1.x - v3.x)) / ((v4.y - v3.y) * (v2.x - v1.x) - (v4.x - v3.x) * (v2.y - v1.y));
        float ub = ((v2.x - v1.x) * (v1.y - v3.y) - (v2.y - v1.y) * (v1.x - v3.x)) / ((v4.y - v3.y) * (v2.x - v1.x) - (v4.x - v3.x) * (v2.y - v1.y));
        if (Mathf.Abs(ub) < 1)
            return new Vec2(v1.x + ua * (v2.x - v1.x), v1.y + ua * (v2.y - v1.y));
        else
            return Vec2.zero;
    }

    private bool CheckLineBullet(Bullet ball, LineSegment line) {
        Vec2 _ballToLineStart = ball.Position.Clone().Subtract(line.start);
        float _distance = Mathf.Abs(_ballToLineStart.Dot(line.lineOnOriginNormalized.Normal().Clone()));
        Vec2 _intersection = CheckIntersection(line.start.Clone(), line.end.Clone(), ball.Position, ball.NextPositionBorder);
        float _distanceToStart = line.start.DistanceTo(ball.Position);
        float _distanceToEnd = line.end.DistanceTo(ball.Position);

        if (_distance < ball.Radius) {
            if (!((_distanceToStart > line.lineLenght + ball.Radius || _distanceToEnd > line.lineLenght + ball.Radius) && _distance < ball.Radius)) {
                return true;
            }
        }
        return false;
    }

    private void ResolveColisionPlayer(Player player)
    {
        if (player.x-player.width/2 < 0)
        {
            player.Position.x += 10;
            player.x += 10;
        }
        if (player.x + player.width / 2 > game.width)
        {
            player.Position.x -= 10;
            player.x -= 10;
        }
        if (player.y -player.height / 2 < 0)
        {
            player.Position.y += 10;
            player.y += 10;
        }
        if (player.y + player.height / 2 > game.height)
        {
            player.Position.y -= 10;
            player.y -= 10;
        }
    }

    static void Main() {
        new MyGame().Start();
    }
}
