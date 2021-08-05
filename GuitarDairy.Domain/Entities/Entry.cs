using GuitarDairy.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Domain.Entities
{
    public class Entry
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public TimeSpan Duration { get; set; }
        public DayDate Date { get; set; }

        public override string ToString()
        {
            return $"ExerciseId={ExerciseId} Date={Date} Duration={Duration}";
        }
    }
}