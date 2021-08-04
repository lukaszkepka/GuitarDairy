using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Domain.ValueObjects
{
    public struct ExclusiveRange<T> where T : IComparable<T>
    {
        public T From { get; }
        public T To { get; }

        private ExclusiveRange(T from, T to)
        {
            if(Comparer<T>.Default.Compare(to, from) < 0)
            {
                throw new ArgumentException($"Range \"from\" border must be lesser than \"to\" border. Was {from}-{to}");
            }

            From = from;
            To = to;
        }

        public static ExclusiveRange<T> Create(T from, T to)
        {
            return new ExclusiveRange<T>(from, to);
        }

        public bool Contains(T number)
        {
            return !DoesNotContain(number);
        }

        public bool DoesNotContain(T number)
        {
            return Comparer<T>.Default.Compare(number, From) < 0 ||
                   Comparer<T>.Default.Compare(number, To) > 0;
        }

        public override string ToString()
        {
            return $"<{From}-{To}>";
        }
    }
}
