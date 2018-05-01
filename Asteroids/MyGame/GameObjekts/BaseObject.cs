using System.Drawing;

namespace MyGame
{
    public delegate void Message();
    abstract class BaseObject:ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            if (Pos.X < 0 || Pos.Y < 0 ||Size.Height<0||Size.Width<0)
            {
                throw new GameObjektExeption("Неверные параметры обьекта", 0001);
            }
        }
        public abstract void Draw();

        public abstract void Update();
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);
        public Image img;
    }
}
