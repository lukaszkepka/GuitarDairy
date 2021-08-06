using GuitarDairy.Domain.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace GuitarDairy.Domain.Entities
{
    public class EntriesPerDays : IReadOnlyDictionary<DayDate, IEnumerable<Entry>>
    {
        private readonly Dictionary<DayDate, IEnumerable<Entry>> _internalDictionary;

        private EntriesPerDays(Dictionary<DayDate, IEnumerable<Entry>> internalDictionary)
        {
            _internalDictionary = internalDictionary;
        }

        public static EntriesPerDays Empty(DaysRange daysRange)
        {
            return new EntriesPerDays(daysRange.AsEnumerable().ToDictionary(day => day, day => Enumerable.Empty<Entry>()));
        }

        public static EntriesPerDays For(DaysRange daysRange, IEnumerable<Entry> entries)
        {
            var result = Empty(daysRange);
            result.Merge(entries.GroupBy(x => x.Date).ToDictionary(x => x.Key, x => x.Cast<Entry>()));

            return result;
        }

        private void Merge(IDictionary<DayDate, IEnumerable<Entry>> entries)
        {
            foreach (var (key, values) in entries)
            {
                _internalDictionary[key] = _internalDictionary[key].Concat(values);
            }
        }
        
        #region Dictionary Implementation

        public IEnumerable<Entry> this[DayDate key] => _internalDictionary[key];

        public IEnumerable<DayDate> Keys => _internalDictionary.Keys;

        public IEnumerable<IEnumerable<Entry>> Values => _internalDictionary.Values;

        public int Count => _internalDictionary.Count;

        public bool ContainsKey(DayDate key)
        {
            return _internalDictionary.ContainsKey(key);
        }

        public bool TryGetValue(DayDate key, [MaybeNullWhen(false)] out IEnumerable<Entry> value)
        {
            return _internalDictionary.TryGetValue(key, out value);
        }

        public IEnumerator<KeyValuePair<DayDate, IEnumerable<Entry>>> GetEnumerator()
        {
            return _internalDictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _internalDictionary.GetEnumerator();
        }

        #endregion
    }
}
