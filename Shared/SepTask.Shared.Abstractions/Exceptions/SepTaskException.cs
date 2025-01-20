using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SepTask.Shared.Abstractions.Exceptions
{
    public abstract class SepTaskException : Exception
    {
        protected SepTaskException(string message) : base(message)
        {

        }
    }
}
