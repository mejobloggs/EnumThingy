using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumThingy.Exceptions
{
    public class EnumNotFoundException : Exception
    {
		public EnumNotFoundException(string message) : base(message) {	}
    }
}
