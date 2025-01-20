using SepTask.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Exceptions
{
     public class GameAlreadyExistsException : SepTaskException
    {
        public GameAlreadyExistsException(string name) : base($"Game with name '{name}' already exists.")
        {
            Name = name;
        }

        public string Name { get; }
    }
}
