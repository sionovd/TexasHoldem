using System;

namespace Domain.DomainLayerExceptions
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
