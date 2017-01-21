using System;
using GXPEngine;

public class Player : Sprite {
    private Vec2 _position;
    private Vec2 _velocity;
    private Vec2 _reticlePosition;

    private Reticle _reticle1;
    private Reticle _reticle2;

    private PlayerId _playerId = PlayerId.NONE;
    private Canvas _canvas;
    private Circle _wave;
    private bool _active;
    private float _x;
    private float _y;

    public enum PlayerId {
        NONE,
        PLAYERONE,
        PLAYERTWO
    }

    public Canvas Canvas {
        get { return _canvas; }
        set { _canvas = value; }
    }
    public Circle Wave {
        get { return _wave; }
        set { _wave = value; }
    }
    public bool Active {
        get { return _active; }
        set { _active = value; }
    }
    public float X {
        get { return _x; }
        set { _x = value; }
    }
    public float Y {
        get { return _y; }
        set { _y = value; }
    }
    public Vec2 Position {
        get { return _position; }
        set { _position = value; }
    }
    public Vec2 Velocity {
        get { return _velocity; }
        set { _velocity = value; }
    }
    public Vec2 ReticlePosition {
        get { return _reticlePosition; }
        set { _reticlePosition = value; }
    }

    public Player(string pFileName, PlayerId pPlayerId)
        : base(pFileName) {
        _playerId = pPlayerId;
        _position = new Vec2();
        _reticlePosition = new Vec2(0, 0);
        SetOrigin(width / 2, height / 2);
        alpha = 0.5f;


        _wave = new Circle(x, y, 0);
        _canvas = new Canvas(game.width, game.height);
        game.AddChild(_canvas);

        if (_playerId == PlayerId.PLAYERONE) {
            _reticle1 = new Reticle("reticle1.png");
            game.AddChild(_reticle1);
        } else if (_playerId == PlayerId.PLAYERTWO) {
            _reticle2 = new Reticle("reticle2.png");
            game.AddChild(_reticle2);
        }
    }

    public void Update() {
        x = _position.x;
        y = _position.y;

        if (_playerId == PlayerId.PLAYERONE) {
            if (Input.GetKey(Key.T)) {
                _reticle1.y -= 10;
                _reticlePosition.y -= 10;
            }
            if (Input.GetKey(Key.G)) {
                _reticle1.y += 10;
                _reticlePosition.y += 10;
            }
            if (Input.GetKey(Key.F)) {
                _reticle1.x -= 10;
                _reticlePosition.x -= 10;
            }
            if (Input.GetKey(Key.H)) {
                _reticle1.x += 10;
                _reticlePosition.x += 10;
            }
        } else if (_playerId == PlayerId.PLAYERTWO) {
            if (Input.GetKey(Key.NUMPAD_8)) {
                _reticle2.y -= 10;
                _reticlePosition.y -= 10;
            }
            if (Input.GetKey(Key.NUMPAD_5)) {
                _reticle2.y += 10;
                _reticlePosition.y += 10;
            }
            if (Input.GetKey(Key.NUMPAD_4)) {
                _reticle2.x -= 10;
                _reticlePosition.x -= 10;
            }
            if (Input.GetKey(Key.NUMPAD_6)) {
                _reticle2.x += 10;
                _reticlePosition.x += 10;
            }
        }
    }
}
