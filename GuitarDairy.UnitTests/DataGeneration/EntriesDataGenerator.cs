using GuitarDairy.Domain.Entities;
using GuitarDairy.UnitTests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuitarDairy.UnitTests.DataGeneration
{
    public class EntryDataGenerator
    {
        private TimeSpan _duration = TimeSpan.FromMinutes(30);
        private IEnumerable<Exercise> _exercises = Enumerable.Empty<Exercise>();
        private readonly Dictionary<DateTime, int> _itemsCountPerDate = new();

        public static EntryDataGenerator New()
        {
            return new EntryDataGenerator();
        }

        public EntryDataGenerator SetupDuration(TimeSpan duration)
        {
            this._duration = duration;
            return this;
        }

        public EntryDataGenerator SetupExercises(IEnumerable<Exercise> exercises)
        {
            this._exercises = exercises;
            return this;
        }

        public EntryDataGenerator SetupExerciseCount(int count)
        {
            var exerciseNames = Enumerable.Range(1, count).Select(x => x.ToString()).ToArray();
            this._exercises = ExerciseDataGenerator.GenerateFromNames(exerciseNames);
            return this;
        }

        public EntryDataGenerator SetupItemsCount(DateTime date, int count)
        {
            if(! _itemsCountPerDate.TryGetValue(date, out _))
            {
                _itemsCountPerDate[date] = 0;
            }

            _itemsCountPerDate[date] += count;
            return this;
        }

        public IEnumerable<Entry> Generate()
        {
            var entryInputData = this._exercises
                .Product(_itemsCountPerDate);

            foreach (var (exercise, itemsPerDate) in entryInputData)
            {
                for (int i = 0; i < itemsPerDate.Value; i++)
                {
                    yield return new Entry()
                    {
                        Duration = _duration,
                        Date = itemsPerDate.Key,
                        Exercise = exercise
                    };
                }
            }
        }
    }
}
