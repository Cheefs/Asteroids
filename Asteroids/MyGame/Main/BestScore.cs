using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace MyGame
{
    class BestScore
    {
        static BestScore()
        {
        }
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }

        Form form = new Form();
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
        }
        
        public static void Init(Form form)
        {
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
        }
        public static void Draw()
        {
            try { Buffer.Render(); }
            catch { Application.Exit();}

            //Buffer.Graphics.Clear(Color.Green);
            
            //StreamReader score = new StreamReader("score.txt");
            //SolidBrush drawBrush = new SolidBrush(Color.Black);
            //PointF drawPoint = new PointF(50, 10);
            //Font drawFont = new Font("Segoe Script", 10);
            //string drawString;
            //    drawString = score.ReadLine();


            //    Buffer.Graphics.DrawString(drawString, drawFont, drawBrush, drawPoint);
            //score.Close();
        }
    }
}

