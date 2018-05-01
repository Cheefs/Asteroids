using System.Drawing;

namespace MyGame
{
    class Ship : BaseObject
    {
        private float _energy = 100;
        public static int _speed = 0;
        public float Energy => _energy;
        public bool flag = false;
        public static event Message MessageDie;

        public void EnergyUp(float n)
        {
            _energy += n;
        }
        public void EnergyLow(float n)
        {
            _energy -= n;
        }
        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            img = Image.FromFile("ship.png");
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Rect);
        }
        public override void Update()
        {
        }
        public bool BostSpeed()
        {
            if (flag == false)
            {
                flag = true;
                _speed = 5;
            }
            else
            {
                flag = false;
                _speed = 0;
            }
            
            return flag;  
        }
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y - _speed;
        }
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y + _speed;
        }
        public void Left()
        {
            if (Pos.X > 0) Pos.X = Pos.X - Dir.X - _speed;
        }
        public void Right()
        {
            if (Pos.X < Game.Height) Pos.X = Pos.X + Dir.X + _speed;
        }
        public void Die()
        {
            MessageDie?.Invoke();
        }
    }
}