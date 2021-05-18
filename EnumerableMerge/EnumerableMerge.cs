using System;
using System.Collections.Generic;

// TODO
// - Write acceptance UT
// - Implement the function
// - Determine asymptotic complexity of your current approach
// - Check if this optimal way


namespace Tasks
{
    public class EnumerableMerge
    {
        /// <summary>
        /// Merges input sorted enumerables into output sorted enumerable
        /// </summary>
        /// <param name="sortedInputs">Input streams of the unlimited length</param>
        /// <returns></returns>
        public IEnumerable<T> Merge<T>(params IEnumerable<T>[] sortedInputs) where T : IComparable<T>
        {
            //Так как делать вложенные циклы и перебирать n массивов n раз - очевидно не лучшая идея, то мысль в следующем:
            //Работаем все время с нулевыми элементами массивов (через енумератор). Находим из них минимальный
            //(сортировка вставками, наверное), помещаем его в результирующий список и двигаем на
            //следующий элемент. Начинаем сначала

            throw new NotImplementedException();
        }
    }
}