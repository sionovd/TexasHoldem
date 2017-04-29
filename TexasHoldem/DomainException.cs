using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    public class DomainException : Exception
    {

        protected DomainException()
        {
          
        }

        protected DomainException(string message) : base(message)
        {
        }

        
    }
}
