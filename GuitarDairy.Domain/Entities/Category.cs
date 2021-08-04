using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarDairy.Domain.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
    }
}
