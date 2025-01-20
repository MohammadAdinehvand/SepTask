using SepTask.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Exceptions
{
    public class GenreNotFoundException : SepTaskException
    {
        public Guid Id { get; }

        public GenreNotFoundException(Guid id) : base($"Genre with ID '{id}' was not found.")
            => Id = id;
    }

}
