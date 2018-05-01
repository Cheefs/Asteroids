using System;
using System.Windows.Forms;

namespace MyGame
{
    class Btn 
    {
        public static Form form = new Form
        {
            Width = Screen.PrimaryScreen.Bounds.Width,
            Height = Screen.PrimaryScreen.Bounds.Height
        };
        /// <summary>
        /// Новая игра
        /// </summary>
        public void BtnClickNG(object sender, EventArgs e)
        {
            form.Width = 800;
            form.Height = 600; 
            Game.Init(form);
            form.Show();
            Game.Draw();
            Program.form.Hide();

        }
        /// <summary>
        ///  меню Рекорды
        /// </summary>
        public void BtnClickScore(object sender, EventArgs e)
        {
            Form form = new Form();
            {
                form.Width = 300;
                form.Height = 600;
            }
            BestScore.Init(form);
            form.Show();
            BestScore.Draw();
            Program.form.Hide();
        }
        /// <summary>
        /// Выход из игры
        /// </summary>
        public  void BtnClickExit(object sender, EventArgs e)
        {
           Application.Exit();   
        }
    }
}
