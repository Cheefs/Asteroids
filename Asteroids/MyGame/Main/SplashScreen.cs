using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace MyGame
{
    static class SplashScreen
    {
        public static SplasScreenObj _objs;
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
         static string drawString;
        static Image img;
        static SplashScreen()
        {
            img = Image.FromFile("space.jpg");
        }
       

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Init(Form form)
        {
            Load();
            Score();

            Timer timer = new Timer { Interval = 30 };
            timer.Start();
            timer.Tick += Timer_Tick;
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
         
            Label lb = new Label();
            lb.Text= drawString;
            lb.BackColor = Color.Black;
            lb.ForeColor = Color.Yellow;
            form.Controls.Add(lb);
        }
     
        public static void Draw()
        {
            Buffer.Render();
           // Buffer.Graphics.DrawImage(img, 0, 0,SplashScreen. Width, SplashScreen.Height);
            Buffer.Graphics.Clear(Color.Black);
            _objs.Draw();
            Buffer.Render();
        }
        public static void Load()
        {

            Random rnd = new Random();
            int r = rnd.Next(5, 50);
            _objs = new SplasScreenObj(new Point(Width, 0), new Point(1,1), new Size(800, 800));
             
        }

        public static void Update()
        {
          _objs.Update();
        }

        private static void Score()
        {
            using (var sr = new StreamReader("score.txt"))
            {
              drawString=  sr.ReadLine();
            }
    }
}


}