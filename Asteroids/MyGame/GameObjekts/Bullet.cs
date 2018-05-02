using System.Drawing;

namespace MyGame
{
    class Bullet : BaseObject,ICollision
    {
        public int Power { get; set; } = 1;
        public Bullet(Point pos,Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X + 30;    
        }
    }
}
