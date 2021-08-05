using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.UnitTests.Utils
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<Tuple<T1, T2>> Product<T1, T2>(this IEnumerable<T1> items1, IEnumerable<T2> items2)
        {
            foreach (var item1 in items1)
            {
                foreach (var item2 in items2)
                {
                    yield return Tuple.Create(item1, item2);
                }
            }
        }
    }
}
