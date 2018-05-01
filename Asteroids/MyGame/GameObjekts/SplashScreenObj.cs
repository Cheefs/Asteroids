using System.Drawing;

namespace MyGame
{
    class SplasScreenObj : BaseObject
    {
        Image newImg;
        public SplasScreenObj(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            newImg = Image.FromFile(@"Splash.png");
        }
        public override void Draw()
        {
            RectangleF rect = new RectangleF(Pos.X, Pos.Y, Size.Width, Size.Height);
            SplashScreen.Buffer.Graphics.DrawImage(newImg, rect);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < -500) Dir.X = -Dir.X;
            if (Pos.X >SplashScreen.Width) Dir.X = -Dir.X;
            if (Pos.Y < -500) Dir.Y = -Dir.Y;
            if (Pos.Y > SplashScreen.Height) Dir.Y = -Dir.Y;
        }
    }
}
