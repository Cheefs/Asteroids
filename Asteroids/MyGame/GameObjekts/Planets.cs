using System;
using System.Drawing;

namespace MyGame
{/// <summary>
/// Класс содержит на данный момент только 1 луну, в дальнейшем будет массив
/// с рандомной выборкой планеты по индексатору, как реализовать еще даже не думал, просто планы
/// </summary>
    class Planets : BaseObject
    {
        
        public Planets(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            img = Image.FromFile("moon.png");
           
        }
        public override void Draw()
        {
            Random rnd = new Random();
            Game.Buffer.Graphics.DrawImage(img, Rect);
        }
        public override void Update()
        {
            Pos.X = Pos.X - Ship._speed - Dir.X+4;
            if (Pos.X <-600) Pos.X = Game.Width + Size.Width;
        }
    }
}
