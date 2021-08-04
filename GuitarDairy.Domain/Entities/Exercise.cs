using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Domain.Entities
{
    // Aggregate root for entries?
    // Cannot add Entry if not in month
    public class Exercise
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public ICollection<Entry> Entries { get; set; }
    }
}
