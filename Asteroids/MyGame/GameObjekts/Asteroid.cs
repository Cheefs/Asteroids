using System;
using System.Drawing;

namespace MyGame
{
    class Asteroid : BaseObject, ICloneable, IComparable<Asteroid>
    {
        public static int _asteroidsSpeed = 1;
       
        int IComparable<Asteroid>.CompareTo(Asteroid obj)
        {
            if (Power > obj.Power)
                return 1;
            if (Power < obj.Power)
                return -1;
            return 0;
        }
        public int Power { get; set; } = 3;
      
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            img = Image.FromFile("meteor.png");
        }
        public object Clone()
        {
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y),
            new Size(Size.Width, Size.Height)) { Power = Power };
            return asteroid;
        }
        public override void Draw()
        { 
            Game.Buffer.Graphics.DrawImage(img, Rect);
        }
        public override void Update()
        {
            Random rnd = new Random();
            Pos.X = Pos.X + Dir.X + _asteroidsSpeed - Ship._speed;
            if (Pos.X < 0)
            {
                Pos.X = Game.Width+ Size.Width; Pos.Y = rnd.Next(0, 600);
            }    
        }
        public void AsteroidsCollisium()
        {
            Random rnd = new Random();
            Pos.X = Game.Width;
            Pos.Y = rnd.Next(0, 800);
        }
    }
}
