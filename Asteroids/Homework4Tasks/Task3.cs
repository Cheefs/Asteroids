
//   Необязательное ДЗ, делал для тренеровки, и заметил что делегаты обобщенные знаю слабее лямбд, нужно подтянуть


//3. * Дан фрагмент программы:
//Dictionary<string, int> dict = new Dictionary<string, int>()
//  {
//    {"four",4 },
//    {"two",2 },
//    { "one",1 },
//    {"three",3 },
//  };
//var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
//     foreach (var pair in d)
//    {
//      Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
//    }
//        а) Свернуть обращение к OrderBy с использованием лямбда-выражения
//        б) * Развернуть обращение к OrderBy с использованием делегата Func<KeyValuePair<string, int>, int>.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4Tasks
{
    class Task3
    {
        Dictionary<string, int> dict = new Dictionary<string, int>()
        {
            {"four",4 },
            {"two",2 },
            { "one",1 },
             {"three",3 },
         };
        /// <summary>
        ///  а) Свернуть обращение к OrderBy с использованием лямбда-выражения
        /// </summary>
        public void Task3a()
        {
            Console.WriteLine("\tTask 3 - a");
            var d = dict.OrderBy(pair => pair.Value);
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

        }
        /// <summary>
        /// б) * Развернуть обращение к OrderBy с использованием делегата Func<KeyValuePair<string, int>, int>
        /// </summary>
        public void Task3b()
        {
            Console.WriteLine("\tTask 3 -b");
            var d = dict.OrderBy(Func);
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
        public int Func(KeyValuePair<string, int> pair) => pair.Value;

    }
}
