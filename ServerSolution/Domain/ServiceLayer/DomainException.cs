using System;

namespace Domain.ServiceLayer
{
    public class DomainException : Exception
    {

        public DomainException()
        {
          
        }

        public DomainException(string message) : base(message)
        {
        }

        
    }
}
