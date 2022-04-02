using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccountTask.Exceptions
{
    public class PasswordIsInvalidException : Exception
    {
        public PasswordIsInvalidException(string message) : base(message)
        {

        }
    }
}
