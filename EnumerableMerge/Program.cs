using System;
using System.Collections.Generic;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            EnumerableMerge enumerableMerge = new EnumerableMerge();
            List<int> list1 = new List<int>() { 1, 5, 9, 11, 15, 23, 29 };
            List<int> list2 = new List<int>() { -2, 3, 6, 10, 11, 12, 15 };
            List<int> list3 = new List<int>() { -6, -4, 6, 7, 8, 9, 17, 44 };
            List<int> list4 = new List<int>() {  };

            var result = enumerableMerge.Merge(list1, list2, list3, list4);

            foreach (var item in result)
            {
                Console.WriteLine(item + "");
            }

            Console.ReadKey();
        }
    }
}
