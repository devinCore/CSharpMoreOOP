using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheCheapestPainter
{
    public static class EnumerableExtensions
    {
        //public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, 
        //                                         Func<T, TKey> criterion)
        //    where T : class
        //    where TKey : IComparable<TKey>
        //{
        //    return sequence.Aggregate((T)null, (best, curr) =>
        //        best == null ||
        //        criterion(curr).CompareTo(criterion(best)) < 0 ?
        //        curr : best);
        //}

        //Final implementation for better performance
        public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence,
                                                Func<T, TKey> criterion)
             where T : class
             where TKey : IComparable<TKey>
        {
            return sequence
                    .Select(obj => Tuple.Create(obj, criterion(obj)))
                    .Aggregate((Tuple<T, TKey>)null, (best, curr) =>
                        best == null ||
                        curr.Item2.CompareTo(best.Item2) < 0 ?
                        curr : best)
                    .Item1;
        }

    }
}
