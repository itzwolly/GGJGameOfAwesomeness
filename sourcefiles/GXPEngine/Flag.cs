using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;


public class Flag : Sprite {
    private bool _pickedUp = false;

    public bool PickedUp {
        get { return _pickedUp; }
        set { _pickedUp = value; }
    }

    public Flag() : base("assets\\flag.png") {
        SetOrigin(width / 2, height / 2);
        x = game.width / 2;
        y = game.height / 2;
    }
}
