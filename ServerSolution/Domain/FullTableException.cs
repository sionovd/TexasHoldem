using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ServiceLayer;

namespace Domain
{
    public class FullTableException : DomainException
    {
        public FullTableException()
        : base(string.Format("table is full")) { }

        public FullTableException(string message)
        : base(String.Format(message)) { }
    }
}
