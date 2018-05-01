using System;
using System.IO;

namespace MyGame
{
    public delegate void LogDeligate(string str);
    class Log
    {

        static LogDeligate myFunc;
        public void Add(LogDeligate f)
        {
            myFunc += f;
        }
        public void Remove(LogDeligate f)
        {
            myFunc -= f;
        }
    }

    class DelLog
    {
        DateTime t;
        StreamWriter sw = new StreamWriter("log.txt");
       
        private void WriterLog()
        {
            sw.WriteLine(text);
            sw.AutoFlush = true;
        }
        private string text;
        /// <summary>
        /// Лог создания обьекта
        /// </summary>
        /// <param name="str">Имя обьекта</param>
        public void Do(string str)
        {
         
            text = (t = DateTime.Now) + "\tСоздан элемент " + str;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(t + $"\tСоздан элемент {str}");
            WriterLog();

        }
        /// <summary>
        /// Удаление обьекта при сталкновении\уничтожение корабля
        /// </summary>
        /// <param name="str">Имя обьекта</param>
        public void Del(string score)
        {
            text = (t = DateTime.Now) + $"\tОбьект уничтожен! +{score} points!";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(t + "\tОбьект уничтожен" + $"\tScore +{score} points!");
            Console.ForegroundColor = ConsoleColor.Blue;
            WriterLog();

        }
        /// <summary>
        /// Лог повреджений  напоминание(незабыть добавить вывод повреждений)
        /// </summary>
        /// <param name="str">Имя обьекта </param>
        public void Dmg(string str)
        {
            text = (t = DateTime.Now) + str + $"\t {str}-Получает повреджения";
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(t + $"\t {str} - Получает повреждения");
            WriterLog();
        }
        /// <summary>
        /// Лог востановления энергии
        /// </summary>
        /// <param name="str">количество энергии </param>
        public void Healing(string str)
        {
            text = (t = DateTime.Now) + str + $"\t - Энергия востановлена: Energy+ {str} ";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(t + $"\t Энергия востановлена: Energy+ {str} ");
            WriterLog();
        }
        public void Costum(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine((t = DateTime.Now) + $"\t {str}");
            WriterLog();
        }
    }
}

