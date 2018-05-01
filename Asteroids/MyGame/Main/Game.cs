using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Media;
namespace MyGame
{
    /// <summary>
    ///                 Наброски на будущее, для себя
    ///      
    ///         Стерать выполненые пункты 
    /// Сделать наследование заставки от Гейма, дабы упростить код( не выполнено)---
    /// Устранить читерную стрельбу, либо сделать стрельбу на кнопку либо добавить Здоровье обьектам (не выполнено)----
    /// 
    /// Старатся устонять повторяющиеся действия, регулировать доступ переменных, и методов (не выполнено)----
    /// Добавить усилители как в игре Kontra с Dendy, меняющие вид оружия (не выполнено)----
    /// Добавить эксепшены свои (не выполнено)----
    /// 
    /// Закрывать заставку при запуске игры (???)+\- закрыть несмог, скрыл просто, можно ли так вопрос, по нагрузке нет изменений
    /// 
    /// Разнообразить игру ????? (не выполнено) ----
    /// Заменить Console.WriteLine методами пнаподобии Print как были на уроке 4 (не выполнено)-----
    /// 
    /// Разобратся с читерной стрельбой, при зажатии кнопки, которая вызывает обьект исключения ArgumentOutOfRangeException ------
    /// Чистка кода  -------
    /// </summary>
    static class Game
    {
        private static LogDeligate Del;
        private static Log log = new Log();
        private static DelLog delLog = new DelLog();
        private static HelpElements _heal;
        private static Planets _planets;
        private static Form form = new Form();

        private static BaseObject[] _objs;
        private static List<Bullet> _bullets = new List<Bullet>();
        private static List<Asteroid> _asteroids = new List<Asteroid>();
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static Ship _ship = new Ship(new Point(10, 200), new Point(5, 5), new Size(50, 30));


        private static Timer timer = new Timer();
        private static Random rnd = new Random();

        public static int Width { get; set; }
        public static int Height { get; set; }
        public static StreamWriter scoreWriter = new StreamWriter("score.txt");
        public static int score = 0;
        private static int AsteroidsCount { get; set; } = 0;

        private static string str = "ship";
        private static SoundPlayer _SndPlr;

        static Game()
        {
        }
        /// <summary>
        /// Проверка расширения экрана, Расширение самой игры задается в классе Button
        /// </summary>
        public static void ScreenCheck()
        {
            if (Width > 1000 || Height > 1000 || Width < 0 || Height < 0)
                throw new ArgumentOutOfRangeException();
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        /// <summary>
        /// Инициализация и обновление графического буфера
        /// </summary>
        public static void Init(Form form)
        {
            Load();
            form.KeyDown += Form_KeyDown;
            timer.Interval = 30;
            timer.Start();
            timer.Tick += Timer_Tick;
            Ship.MessageDie += Finish;

            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.Width;
            Height = form.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

        }
        /// <summary>
        /// Вывод всех обьектов на игровой экран
        /// </summary>
        public static void Draw()
        {           
            Buffer.Graphics.Clear(Color.Black);
            _planets?.Draw();
            Interface();
            foreach (BaseObject obj in _objs) obj.Draw();
            foreach (Asteroid a in _asteroids) a.Draw();
            foreach (Bullet b in _bullets) b.Draw();

            _heal?.Draw();
            _ship?.Draw();
            try { Buffer.Render(); }
            catch { Application.Exit(); }
        }
        /// <summary>
        /// Генерация игровых обьектов
        /// </summary>
        public static void Load()
        {

            _objs = new BaseObject[100];
            _heal = new HelpElements(new Point(900, 200), new Point(5, 0), new Size(30, 30));

            int r = rnd.Next(10, 50);
            for (var i = 0; i < _objs.Length; i++)
            {
                r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(Width, rnd.Next(0, 800)), new Point(-r, r), new Size(10, 10));

                string str = "Star";
                delLog.Do(str);
                Del += delLog.Do;

            }
            _planets = new Planets(new Point(Game.Width, 50), new Point(5, 0), new Size(300, 300));
        }

        /// <summary>
        /// Обновление расположения нашего обьекта на экране
        /// </summary>
        public static void Update()
        {


            int points = 0;
            int r = rnd.Next(10, 50);
            foreach (BaseObject obj in _objs) obj.Update();

            foreach (Bullet b in _bullets) b.Update();
            foreach (Asteroid a in _asteroids) a.Update();
           
            _heal?.Update();
            _planets?.Update();

            if (_ship.Energy <= 0) _ship?.Die();
            if (_ship.Collision(_heal)) BeHealed();
            if (_ship.flag == true) _ship.EnergyLow(0.05f);
 
            for (int i = 0; i < _asteroids.Count; i++)
            {

                if (_asteroids != null && _ship.Collision(_asteroids[i]))
                {
                    str = "ship";
                    delLog.Dmg(str);
                    _ship?.EnergyLow(rnd.Next(1, 10));

                   SystemSounds.Asterisk.Play();
                    _asteroids.RemoveAt(i);
                    str = "0";
                    delLog.Del(str);
                    continue;
                }

                for (int j = 0; j < _bullets.Count; j++)
                {
                    if (_bullets[j].Collision(_heal) || _ship.Collision(_heal))
                    {//РЕДАКТИРОВАТЬ НА УНИЧТОЖЕНИЕ ОБЬЕКТА ПРИ СТРЕЛЬБЕ

                        BeHealed();

                        _bullets.RemoveAt(j);
                        j--;

                        continue;
                    }
                    try
                    {
                        if (_bullets != null && _asteroids != null && _bullets[j].Collision(_asteroids[i]))
                        {
                            if (_asteroids == null) continue;

                            if (_asteroids[i].Power == 0)
                            {
                                points = rnd.Next(1, 30);
                                score += points;
                                delLog.Del(points.ToString());

                                _bullets.RemoveAt(j);
                                _asteroids.RemoveAt(i);

                                continue;
                            }
                            _bullets.RemoveAt(j);
                            j--;
                            SystemSounds.Hand.Play();
                            _asteroids[i].Power--;
                            continue;
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex); }
                }
                continue;
            }
            if (_asteroids.Count == 0)
            {
                AsteroidsCount++;
                for (int i = 0; i < AsteroidsCount; i++)
                {
                    r = rnd.Next(10, 50);
                    _asteroids.Add(new Asteroid(new Point(Width, rnd.Next(0, 800)), new Point(-r / 5, r), new Size(r, r)));
                    str = "Asteroid";
                    delLog.Do(str);
                }
            }
        }
        /// <summary>
        /// Обработчик событий нажатия клавиш
        /// </summary>
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F)
                _bullets.Add(new Bullet(new Point(_ship.Rect.X + 15, _ship.Rect.Y + 10), new Point(4, 0), new Size(8, 3)));
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down) _ship.Down();
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) _ship.Left();
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) _ship.Right();
            if (e.KeyCode == Keys.E || e.KeyCode == Keys.Shift)
            {
                _ship.BostSpeed();
                if (_ship.flag == true) delLog.Costum("Boost On\t Energy going down");
                else delLog.Costum("Boost Off");
               }
                if (e.KeyCode == Keys.N) SaundPlayer();
            if (e.KeyCode == Keys.M) { _SndPlr.Stop(); delLog.Costum("Music Off"); }

                if (e.KeyCode == Keys.Escape) Application.Exit();
        }
        /// <summary>
        /// Завершение иигры (когда энергия корабля == 0)
        /// </summary>
        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60,
            FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
            _SndPlr.Stop();
            BestScore();
        }

        /// <summary>
        /// Вывод очков игрока на экран
        /// </summary>
        static void GameScore()
        {

            string drawString = "Score:\t";
            SolidBrush drawBrush = new SolidBrush(Color.LimeGreen);
            PointF drawPoint = new PointF(0, 5);
            Buffer.Graphics.DrawString(drawString + score, SystemFonts.DefaultFont, drawBrush, drawPoint);
        }
        /// <summary>
        /// При получении GameOver (энергия равна 0) записывает результат в файл, 
        /// потом считывает его в меню Рекордов
        /// </summary>
        static void BestScore()
        {

            scoreWriter.AutoFlush = true;
            scoreWriter.WriteLine("Name: User_1\tscore :{0}", score.ToString());

        }
        /// <summary>
        /// Элемент интерфейса - Отображающий количество астероидов
        /// </summary>
        static void AsteroidsOnScreen()
        {
            string current = "\tAsteroids left:\t" + _asteroids.Count.ToString();
            string drawString = "Total Asteroids:\t";
            SolidBrush drawBrush = new SolidBrush(Color.Red);
            PointF drawPoint = new PointF(0, 35);
            Buffer.Graphics.DrawString(drawString + AsteroidsCount + current, SystemFonts.DefaultFont, drawBrush, drawPoint);
        }
        /// <summary>
        /// Элемент интерфейса - Отображающий энергию корабля
        /// </summary>
        static void Energy()
        {
            int _tmpEnrg = Convert.ToInt32(_ship.Energy);
            if (_ship != null) Buffer.Graphics.DrawString("Energy:" + _tmpEnrg, SystemFonts.DefaultFont, Brushes.Yellow, 0, 20);
        }
        /// <summary>
        /// Элемент интерфейса - Отображающий подсказки по управлению
        /// </summary>
        static void HelpString()
        {

            string drawString = "\tУправление:\nВверх: W или Up \t Вниз: S или Down \t Влево: A или Left \t Вправо: D или Right" +
                "\n Ускорение: Shift или E - Внимание тратится энергия!" +
                "\n Огонь: F или CTRL\n Включить музыку -N\t Выключить музыку - M\n Выход: ESC";
            SolidBrush drawBrush = new SolidBrush(Color.Yellow);
            PointF drawPoint = new PointF(0, 480);
            Buffer.Graphics.DrawString(drawString, SystemFonts.DefaultFont, drawBrush, drawPoint);
        }
        /// <summary>
        /// Метод инициализации интерфейса
        /// </summary>
        static void Interface()
        {
            AsteroidsOnScreen();
            GameScore();
            Energy();
            HelpString();
        }
        /// <summary>
        /// Метод востановления энергии 
        /// </summary>
        static void BeHealed()
        {
          int  tmpValue = rnd.Next(5, 20);
            if (_ship?.Energy < 100)
            {
                if (_ship?.Energy + tmpValue > 100)
                {
                    float tempValue = 0;
                    tempValue = 100 - _ship.Energy;
                    _ship.EnergyUp(tempValue);
                    str = Convert.ToInt32(tempValue).ToString();
                }
                else
                {
                    _ship?.EnergyUp(tmpValue);
                    str = tmpValue.ToString();
                }
                delLog.Healing(str);
                Del += delLog.Healing;

            }
            _heal.Geneerate();
           SystemSounds.Exclamation.Play();

        }
        /// <summary>
        /// Звуковое сопровождение
        /// Мелодия взята с базовой библиотеки программы RPG MakerMV
        /// </summary>
        static void SaundPlayer()
        {
            _SndPlr = new SoundPlayer(@"media.wav");
            _SndPlr.PlayLooping();
            delLog.Costum("Music On");

        }
    }
}