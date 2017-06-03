using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    [Serializable]
    public  class NotAPasswordException : DomainException
    {
        public NotAPasswordException (string password) : base("Invalid password: " + password)
        {         
        }
    }
}
