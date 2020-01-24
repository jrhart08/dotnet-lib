using System;
using System.Collections.Generic;
using System.Text;

namespace NDash
{
    public static partial class NDashLib
    {
        public static Tuple<List<T>, List<T>> Partition<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var yes = new List<T>();
            var no = new List<T>();

            foreach(T item in collection)
            {
                var list = predicate(item) ? yes : no;

                list.Add(item);
            }

            return Tuple.Create(yes, no);
        }
    }
}
