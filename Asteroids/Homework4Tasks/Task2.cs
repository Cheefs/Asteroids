//2. Дана коллекция List<T>, требуется подсчитать, сколько раз каждый элемент встречается в
//данной коллекции.
//а) для целых чисел;
//б) * для обобщенной коллекции;
//в)** используя Linq.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4Tasks
{
    class Task2
    {
        List<int> list = new List<int> { 4, 6, 7, 9, 0, 4, 2, 6, 8,3, 6, 9, 48, 0, 5, 3, 46, 8,3, 90,90 };
        /// <summary>
        /// для целых чисел;
        /// * для обобщенной коллекции;
        /// </summary>
        public void Task2List ()
        {
            for (int i=0;i<list.Count;i++)
            {
                int count = 0;
                foreach (int el in list)
                {
                    if (list[i] == el) count++;
                }
                Console.WriteLine(" Число: {0}\t Элементов в колекции: {1}", list[i], count);
            }
        }
        /// <summary>
        ///** используя Linq
        /// </summary>
        public void Task2LINQ()
        {
            var num = from el in list
                      group el by el into tmp
                      let count = tmp.Count()
                      select new { Value = tmp.Key, Count = count };
            foreach (var x in num)
            {
                Console.WriteLine(" Число: {0}\t Элементов в колекции: {1}",x.Value, x.Count);
            }
        }
    }
}
