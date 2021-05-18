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
                int minEnumeratorIndex = 0;
                for (int i = 0; i < enumerators.Count; i++)
                {
                    if (enumerators[minEnumeratorIndex].Current.CompareTo(enumerators[i].Current) > 0)
                        minEnumeratorIndex = i;
                }

                var minEnumerator = enumerators[minEnumeratorIndex];
                enumerators.RemoveAt(minEnumeratorIndex);
                

                yield return minEnumerator.Current;
                if (minEnumerator.MoveNext())
                    enumerators.Insert(0, minEnumerator);
            }
        }        
    }
}