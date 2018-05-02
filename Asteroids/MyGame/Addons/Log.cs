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

        private void Print(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }
       /// <summary>
       /// Метод записи лог журнала в файл
       /// </summary>
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
            text = $"{ t = DateTime.Now }\tСоздан элемент {str}";
            Print(text, ConsoleColor.White);
            WriterLog();
        }
        /// <summary>
        /// Удаление обьекта при сталкновении\уничтожение корабля
        /// </summary>
        /// <param name="str">Имя обьекта</param>
        public void Del(string score)
        {
            text = $"{t = DateTime.Now}\tОбьект уничтожен! +{score} points!";
            Print(text, ConsoleColor.Blue);
            WriterLog();
        }
        /// <summary>
        /// Лог повреджений
        /// </summary>
        /// <param name="str">Имя обьекта </param>
        public void Dmg(string str)
        {
            text = $"{ t = DateTime.Now }\t {str} - Получает повреждения";
            Print(text, ConsoleColor.DarkCyan);
            WriterLog();
        }
        /// <summary>
        /// Лог востановления энергии
        /// </summary>
        /// <param name="str">количество энергии </param>
        public void Healing(string str)
        {
            text = $"{ t = DateTime.Now }\t Энергия востановлена: Energy+ {str} ";
            Print(text, ConsoleColor.Yellow);
            WriterLog();
        }
        /// <summary>
        /// Специальный лог, для особых элементов
        /// </summary>
        public void Costum(string str)
        {
            text = $"{ t = DateTime.Now }\t {str}";
            Print(text, ConsoleColor.Green);
            WriterLog();
        }
    }
}

