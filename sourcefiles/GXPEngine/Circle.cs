using System;
namespace GXPEngine {
    public class Circle : Sprite {
        public Vec2 Position;
        public int Size;

        public Circle(float pX, float pY, int pSize)
            : base("wave.png") {
            SetOrigin(width / 2, height / 2);
            width = 10;
            height = 10;

            Position = new Vec2(pX, pY);
            Size = pSize;
        }


        private void Update() {
            x = Position.x;
            y = Position.y;
        }

        public void UpdateCircleSize(int pSize) {
            width = pSize;
            height = pSize;
        }
    }
}
