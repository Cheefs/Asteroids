using System;
using System.Drawing;

namespace MyGame
{/// <summary>
/// Класс содержаший элементы лечения корабля( в дльнейшем и бусты)
/// 
/// PS. На данный момент хил осуществляется столкновением обьекта с пулей
/// (так проше для тестирования игры и логов)
/// в дальнейшем это будет уничтожать обьект
/// а для лечения нужно использывать _ship.Collisium(_heal)
/// 
/// </summary>
    class HelpElements:BaseObject
    {
        Random rnd = new Random();
        public HelpElements(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            img = Image.FromFile("enerjy.png");
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Rect);
        }
        public void Geneerate()
        {   
            Pos.Y = rnd.Next(0, Game.Height);
            Pos.X = Game.Width;
        }
        public override void Update()
        {

            Pos.X = Pos.X- Dir.X - Ship._speed;
            if (Pos.X < 0)
            {
                Pos.Y = rnd.Next(0, 800);
                Pos.X = Game.Width;

            }
        }  
    }
}
