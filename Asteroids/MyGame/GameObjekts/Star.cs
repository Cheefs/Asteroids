using System;
using System.Drawing;

namespace MyGame
{
    class Star :BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
                img = Image.FromFile("star.png");   
        }
        public override void Draw()
        {
            Random rnd = new Random();
            Game.Buffer.Graphics.DrawImage(img, Rect);

            //Еще будет либо редактроватся, либо заменено
            Game.Buffer.Graphics.DrawBezier(Pens.White, 0, 450, 404, 380, 450, 400, 800, 450);
        }
        //Ship _ship = new Ship(Point.Empty, Point.Empty, Size.Empty);
        public override void Update()
        {
            Pos.X = Pos.X - Ship._speed*5 + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
