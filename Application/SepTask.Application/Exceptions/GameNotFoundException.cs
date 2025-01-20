using SepTask.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Exceptions
{
    public class GameNotFoundException : SepTaskException
    {
        public Guid Id { get; }

        public GameNotFoundException(Guid id) : base($"Game with ID '{id}' was not found.")
            => Id = id;
    }

}
