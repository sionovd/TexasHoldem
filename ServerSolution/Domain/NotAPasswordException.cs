using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.ServiceLayer;

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
