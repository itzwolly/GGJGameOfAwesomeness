using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;


public class Flag : Sprite {
    private bool _pickedUp = false;
    private float _oldX;
    private float _oldY;

    public bool PickedUp {
        get { return _pickedUp; }
        set { _pickedUp = value; }
    }
    public float OldX {
        get { return _oldX; }
        set { _oldX = value; }
    }
    public float OldY {
        get { return _oldY; }
        set { _oldY = value; }
    }

    public Flag() : base("assets\\flag.png") {
        SetOrigin(width / 2, height / 2);
        x = game.width / 2;
        y = game.height / 2;
    }
}
