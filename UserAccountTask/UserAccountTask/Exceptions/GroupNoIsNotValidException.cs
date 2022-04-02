using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAccountTask.Exceptions
{
    public class GroupNoIsNotValidException : Exception
    {
        public GroupNoIsNotValidException(string message) : base(message)
        {

        }
    }
}
