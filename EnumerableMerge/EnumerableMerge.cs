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

            List<T> result = new List<T>();
            List<IEnumerator<T>> enumerators = new List<IEnumerator<T>>();

            //здесь можно было бы через linq, но его нет в using и я добавлять не буду тогда
            foreach (var item in sortedInputs)
            {
                var enumerator = item.GetEnumerator();
                if (enumerator.MoveNext())
                    enumerators.Add(enumerator);
            }

            while(enumerators.Count > 0)
            {
                //теперь сортировка
                //мне же не нужна полная сортировка
                //достаточно просто найти индекс енумератора с наименьшим текущим значением
                int minEnumeratorIndex = 0;
                for (int i = 0; i < enumerators.Count; i++)
                {
                    if (enumerators[minEnumeratorIndex].Current.CompareTo(enumerators[i].Current) > 0)
                        minEnumeratorIndex = i;
                }

                var minEnumerator = enumerators[minEnumeratorIndex];
                enumerators.RemoveAt(minEnumeratorIndex);
                

                result.Add(minEnumerator.Current);
                if (minEnumerator.MoveNext())
                    enumerators.Insert(0, minEnumerator);
            }

            return result;
        }        
    }
}