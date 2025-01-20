using SepTask.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Application.Exceptions
{
     public class GameDuplicateNameException : SepTaskException
    {
        public GameDuplicateNameException(string name) : base($"Game with name '{name}' duplicated.")
        {
            Name = name;
        }

        public string Name { get; }
    }
}
