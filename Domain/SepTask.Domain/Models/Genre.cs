using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Domain.Models
{
    public class Genre
    {
        private Genre()
        {

        }
        public Genre(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id { get;private set; }
        public string Name { get; private set; }
    }
}
