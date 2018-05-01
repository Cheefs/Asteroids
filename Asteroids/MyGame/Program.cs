using System;
using System.Windows.Forms;


namespace MyGame
{
    class Program
    {
        public static Form form = new Form
        {
            Width = Screen.PrimaryScreen.Bounds.Width,
            Height = Screen.PrimaryScreen.Bounds.Height
        };

        static void Main(string[] args)
        {
            Console.SetWindowSize(60, 20);
            form.Width = 800;
            form.Height = 600;

            Btn button = new Btn();
            Button btnNewGame = new Button();
            {

                btnNewGame.Text = "Новая игра";
                btnNewGame.Top = 100;
                form.Controls.Add(btnNewGame);
                btnNewGame.Click += button.BtnClickNG;

            }
            Button btnBestScore = new Button();
            {
                btnBestScore.Text = "Рекорды ";
                btnBestScore.Top = 125;
                form.Controls.Add(btnBestScore);
                btnBestScore.Click += button.BtnClickScore;
            }
            Button btnExit = new Button();
            {
                btnExit.Text = "Выход";
                btnExit.Top = 150;
                form.Controls.Add(btnExit);
                btnExit.Click += button.BtnClickExit;
            }

            SplashScreen.Init(form);
            SplashScreen.Draw();
            form.Show();
            Application.Run(form);

        }
    }
}

